using Javirs.Common;
using Javirs.Common.Security;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Areas;
using Winner.DataChangeLog;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.User.Interface;

namespace Winner.User.Facade
{
    public class UserFacade : FacadeBase
    {
        #region GET USER INFO
        public Dictionary<string, object> GetUserInfo(string userCode)
        {
            IUser user = xUtils.GetUserByCode(userCode);
            if (user == null)
            {
                return null;
            }
            var dic = new Dictionary<string, object>();
            dic.Add("UserCode", user.UserCode);//账号
            dic.Add("UserName", user.UserName);//姓名
            dic.Add("Register_Time", user.Register_Time);//注册时间
            dic.Add("Avatar", user.Avatar);//头像
            dic.Add("User_Level", user.Grade.Level);//会员等级
            dic.Add("Auth_Status", (int)user.Auth_Status);//认证状态
            dic.Add("UserStatus", (int)user.Status);//账户状态
            dic.Add("HasPayPwd", user.HasPayPassword());//是否已设置支付密码
            FillIdentityInfo(user.UserId, dic);//填充认证信息
            FillShareInfo(user.UserId, dic);//填充分享链接
            FillInviterInfo(user.Refer_ID, dic);//填充推荐人信息
            var list = ProviderContainer.GetProviders<IUserProfile>();
            List<Task> tasks = new List<Task>();
            foreach (var item in list)
            {
                //多线程获取用户资料
                tasks.Add(
                Task.Factory.StartNew(() =>
                {
                    if (!dic.ContainsKey(item.PropertyName))
                    {
                        object value = item.GetProfile(user);
                        dic.Add(item.PropertyName, value);
                    }
                }));
            }
            //同步线程
            Task.WaitAll(tasks.ToArray());
            return dic;
        }

        public bool ModifyUserProfile(Entities.ViewModels.UserModifyModel model)
        {
            if (!model.City_Id.HasValue && string.IsNullOrEmpty(model.Avatar) && !model.Org_Id.HasValue
                && string.IsNullOrEmpty(model.Industry))
            {
                return true;
            }
            var fac = UserModuleFactory.GetUserModuleInstance();
            if (fac == null)
            {
                Alert((ResultType)500, "系统错误");
                return false;
            }
            IUser user = fac.GetUserByCode(model.UserCode);
            if (user == null)
            {
                Alert((ResultType)404, "找不到用户信息");
                return false;
            }
            if (!model.City_Id.HasValue && string.IsNullOrEmpty(model.Avatar) && !model.Org_Id.HasValue
                && !string.IsNullOrEmpty(user.Avatar) && user.Avatar.Equals(model.Avatar, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            BeginTransaction();
            Tnet_User_Profile daProfile = new Tnet_User_Profile();
            daProfile.ReferenceTransactionFrom(Transaction);
            bool isExist = daProfile.SelectByPk(user.UserId);
            if (model.City_Id.HasValue)
            {
                daProfile.City_Id = model.City_Id.Value;
            }
            if (!string.IsNullOrEmpty(model.Industry))
            {
                daProfile.Industry = model.Industry;
            }
            if (model.Org_Id.HasValue)
            {
                daProfile.Org_Id = model.Org_Id.Value;
            }
            if (!isExist)
            {
                daProfile.User_Id = user.UserId;
                if (!daProfile.Insert())
                {
                    Rollback();
                    Alert((ResultType)541, "用户资料更新失败");
                    return false;
                }
            }
            else
            {
                if (!daProfile.Update())
                {
                    Rollback();
                    Alert((ResultType)542, "用户资料更新失败");
                    return false;
                }
            }
            if (!string.IsNullOrEmpty(model.Avatar))
            {
                user.Avatar = model.Avatar;
                var manager = fac.GetProfileManager(user);
                if (!manager.Update())
                {
                    Rollback();
                    Alert((ResultType)540, "头像上传失败");
                    return false;
                }
            }

            Commit();
            return true;
        }

        public void FillIdentityInfo(int userId, Dictionary<string, object> dictionary)
        {
            string birth = null, industry = null;
            int? gender = null, cityId = null;
            Vnet_Identity daIdentity = new Vnet_Identity();
            if (daIdentity.SelectByUser_Id(userId))
            {
                birth = daIdentity.Birthday.HasValue ? daIdentity.Birthday.Value.ToString() : string.Empty;
                gender = daIdentity.Gender;
                if (daIdentity.Region_Id.HasValue)
                {
                    var region = ChinaArea.GetRegion(daIdentity.Region_Id.Value);
                    cityId = region?.City_ID;
                }
            }
            Tnet_User_Profile daUserProfile = new Tnet_User_Profile();
            if (daUserProfile.SelectByPk(userId))
            {
                if (daUserProfile.City_Id.HasValue)
                {
                    cityId = daUserProfile.City_Id.Value;
                }
                industry = daUserProfile.Industry;
            }
            dictionary.Add("Birthday", birth);
            dictionary.Add("Industry", industry);
            dictionary.Add("Gender", gender);
            dictionary.Add("CityId", cityId);
        }
        private void FillShareInfo(int userId, Dictionary<string, object> dictionary)
        {
            string cipherUserId = Base58.Encode(Encoding.UTF8.GetBytes(userId.ToString()));
            string ssoLogin = System.Configuration.ConfigurationManager.AppSettings["SSO_LoginUrl"];
            string shareUrl = string.Empty;
            if (!string.IsNullOrEmpty(ssoLogin))
            {
                Uri uri = new Uri(ssoLogin);
                shareUrl = uri.Scheme + "://" + uri.Authority + "/wap/register/" + cipherUserId;
            }
            dictionary.Add("ShareUrl", shareUrl);
        }
        private void FillInviterInfo(int? refereeId, Dictionary<string, object> dictionary)
        {
            IUser refereeUser = null;
            if (refereeId.HasValue)
            {
                var fac = UserModuleFactory.GetUserModuleInstance();
                if (fac != null)
                {
                    refereeUser = fac.GetUserByID(refereeId.Value);
                }
            }
            dictionary.Add("RefereeCode", refereeUser == null ? "" : refereeUser.UserCode);
            dictionary.Add("RefereeName", refereeUser == null ? "" : refereeUser.UserName);
        }
        #endregion
        /// <summary>
        /// 修改推荐人
        /// </summary>
        /// <returns></returns>
        public bool ChangeReferee(int userId, string refereeCode, int op_user_id)
        {
            var fac = UserModuleFactory.GetUserModuleInstance();
            if (fac == null)
            {
                Alert("系统错误");
                return false;
            }
            IUser user = fac.GetUserByID(userId);
            if (user == null)
            {
                Alert("会员信息有误");
                return false;
            }
            string value_before = user.Refer_ID.HasValue ? user.Refer_ID.Value.ToString() : null;
            IUser refereeUser = fac.GetUserByCode(refereeCode);
            if (refereeUser == null)
            {
                Alert("推荐人信息有误");
                return false;
            }
            if (user.Refer_ID.HasValue && user.Refer_ID.Value == refereeUser.UserId)
            {
                return true;
            }
            user.Refer_ID = refereeUser.UserId;
            var mgt = fac.GetProfileManager(user);
            if (!mgt.Update())
            {
                Alert("推荐人修改失败");
                return false;
            }
            LogDetails refereeInfo = new LogDetails
            {
                DATA_FIELD = "Refer_ID",
                VALUE_AFTER = refereeUser.UserId.ToString(),
                VALUE_BEFORE = value_before
            };
            AdminDatabaseLog.PersistToDatabase(OperateType.UPDATE, op_user_id, "TNET_USER", user.UserId, "会员管理后台修改推荐人", null, refereeInfo);
            return true;
        }

        public bool DisableUser(int user_id, int days, string reason, int op_user_id)
        {
            if (days <= 0)
            {
                Alert("封禁时间天数不能小于等于零");
                return false;
            }
            DateTime lockDate = DateTime.Now.AddDays(days);
            Tnet_LockCollection daLockCollection = new Tnet_LockCollection();
            daLockCollection.ListLockedByUser_id(user_id);
            bool isExist = daLockCollection.Count > 0;
            int lockid = 0;
            DateTime? tempLockDate = null;
            foreach (Tnet_Lock mlock in daLockCollection)
            {
                if (mlock.Auto_Unlock_Time > lockDate)
                {
                    Alert("该用户已由其他原因被封禁，并且封禁时间大于您选择的时间");
                    return false;
                }
                else
                {
                    if (!tempLockDate.HasValue || tempLockDate.Value > mlock.Auto_Unlock_Time)
                    {
                        tempLockDate = mlock.Auto_Unlock_Time;
                        lockid = mlock.Lock_Id;
                    }
                }

            }
            BeginTransaction();
            Tnet_Lock daLock = new Tnet_Lock();
            daLock.ReferenceTransactionFrom(Transaction);
            daLock.User_Id = user_id;
            daLock.Auto_Unlock_Time = lockDate;
            daLock.Lock_Right = 1;
            daLock.Remarks = reason;
            if (isExist && lockid > 0)
            {
                daLock.Lock_Id = lockid;
                if (!daLock.Update())
                {
                    Rollback();
                    return false;
                }
            }
            else if (!daLock.Insert())
            {
                Rollback();
                return false;
            }
            LogDetails lockDetails = new LogDetails
            {
                DATA_FIELD = "USER_ID",
                VALUE_BEFORE = isExist ? tempLockDate.ToString() : null,
                VALUE_AFTER = "LOCKED",
            };
            if (!AdminDatabaseLog.PersistToDatabase(OperateType.ADD, op_user_id, "TNET_LOCK", daLock.Lock_Id, "通过用户后台管理", this.Transaction, lockDetails))
            {
                Rollback();
                return false;
            }
            Commit();
            return true;
        }

        public bool EnableUser(int user_id, string reason, int op_user_id)
        {
            if (string.IsNullOrEmpty(reason))
            {
                Alert("请输入解除封禁的原因");
                return false;
            }
            Tnet_LockCollection daLockCollection = new Tnet_LockCollection();
            daLockCollection.ListLockedByUser_id(user_id);
            if (daLockCollection.Count <= 0)
            {
                return true;
            }
            BeginTransaction();
            foreach (Tnet_Lock mlock in daLockCollection)
            {
                DateTime before = mlock.Auto_Unlock_Time;
                mlock.Auto_Unlock_Time = DateTime.Now;
                if (!mlock.Update())
                {
                    Rollback();
                    return false;
                }
                var lockDetails = new LogDetails
                {
                    DATA_FIELD = "AUTO_UNLOCK_TIME",
                    VALUE_BEFORE = before.ToString(),
                    VALUE_AFTER = mlock.Auto_Unlock_Time.ToString(),
                };
                if (!AdminDatabaseLog.PersistToDatabase(OperateType.UPDATE, op_user_id, "TNET_LOCK", mlock.Lock_Id, "后台解除封号，原因：" + reason, this.Transaction, lockDetails))
                {
                    Rollback();
                    return false;
                }
            }
            Commit();
            return true;
        }
    }
}
