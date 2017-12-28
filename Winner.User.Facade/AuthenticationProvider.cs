using Javirs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.User.Interface;
using Winner.WebApi.Contract;

namespace Winner.User.Facade
{
    public class AuthenticationProvider : FacadeBase
    {
        public bool Authencate(string userCode, AuthIdentityInfo authinfo)
        {
            if (authinfo.Score < 60)
            {
                Alert("认证匹配度太低，认证失败");
                return false;
            }
            var fac = UserModuleFactory.GetUserModuleInstance();
            if (fac == null)
            {
                Alert((ResultType)541, "系统错误");
                return false;
            }
            IUser user = fac.GetUserByCode(userCode);
            if (user == null)
            {
                Alert((ResultType)404, "用户账户未注册");
                return false;
            }
            if (user.Auth_Status != Interface.Enums.Auth_Status.未认证 && user.Auth_Status != Interface.Enums.Auth_Status.认证失败)
            {
                Alert((ResultType)409, user.Auth_Status.ToString() + ",请不要重复上传");
                return false;
            }
            try
            {
                IDCard idCard = new IDCard(authinfo.ID_NO);
                if (!idCard.IsValid)
                {
                    Alert((ResultType)409, "身份证号码有误");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Alert("身份证号码验证失败，请检查您上传的身份证号码");
                Log.Info("身份证号码验证失败", ex);
                return false;
            }
            IUserProfileManager userMgt = fac.GetProfileManager(user);
            if (userMgt == null)
            {
                Alert((ResultType)541, "系统错误");
                return false;
            }
            BeginTransaction();
            Tnet_User_Documents daDocs = new Tnet_User_Documents();
            daDocs.ReferenceTransactionFrom(Transaction);
            bool isSubmit = daDocs.SelectByUid_DocType_DelFlag(user.UserId, DocsType.身份证);
            if (isSubmit && daDocs.Status != (int)ValidateStatus.审核未通过)
            {
                Rollback();
                Alert((ResultType)409, "您的认证信息已提交，请勿重复提交");
                return false;
            }
            Tnet_Identity daIdentity = new Tnet_Identity();
            daIdentity.ReferenceTransactionFrom(Transaction);
            bool isExist = daIdentity.SelectByIdentity_No(authinfo.ID_NO);
            if (isExist)
            {
                Tnet_User_DocumentsCollection daDocsColl = new Tnet_User_DocumentsCollection();
                daDocsColl.ListByDocs_id(daIdentity.Id, DocsType.身份证);
                if (daDocsColl.Count > 0)
                {
                    foreach (Tnet_User_Documents item in daDocsColl)
                    {
                        if (item.User_Id != user.UserId)
                        {
                            Rollback();
                            Alert("该证件已被其他账号认证！");
                            return false;
                        }
                    }
                }
            }
            if (!isExist || (isExist && daIdentity.Status != 1))//证件不存在，或证件存在但未通过认证
            {
                daIdentity.User_Name = authinfo.RealName;
                daIdentity.Identity_No = authinfo.ID_NO;
                daIdentity.Status = 0;
                daIdentity.Region_Id = authinfo.Region_Id;
                daIdentity.Front_Photo = authinfo.Front_Photo;
                daIdentity.Back_Photo = authinfo.Back_Photo;
                daIdentity.Scene_Photo = authinfo.Scene_Photo;
                daIdentity.Sex = GetGenderFromIdNo(authinfo.ID_NO);
                daIdentity.Birthday = GetBirthFromIdNO(authinfo.ID_NO);
                daIdentity.Address = authinfo.Address;
                daIdentity.Begin_Time = authinfo.Begin_Date;
                daIdentity.End_Time = authinfo.EndDate;
                daIdentity.Issuing = authinfo.Issuing;
                daIdentity.Nation = authinfo.Nation;
                if (!isExist)
                {
                    if (!daIdentity.Insert())
                    {
                        Rollback();
                        Alert((ResultType)540, "认证信息录入失败");
                        return false;
                    }
                }
                else
                {
                    if (!daIdentity.Update())
                    {
                        Rollback();
                        Alert((ResultType)541, "认证信息录入失败");
                        return false;
                    }
                }
            }

            daDocs.User_Id = user.UserId;
            daDocs.Documents_Type = (int)DocsType.身份证;
            daDocs.Documents_Id = daIdentity.Id;
            daDocs.Status = (int)ValidateStatus.审核中;
            if (isSubmit)
            {
                if (!daDocs.Update())
                {
                    Rollback();
                    Alert((ResultType)544, "认证信息录入失败");
                    return false;
                }
            }
            else
            {
                if (!daDocs.Insert())
                {
                    Rollback();
                    Alert((ResultType)542, "认证信息录入失败");
                    return false;
                }
            }
            user.Auth_Status = Interface.Enums.Auth_Status.认证中;
            if (!userMgt.Update())
            {
                Rollback();
                Alert("系统繁忙，请稍后重试");
                return false;
            }
            Commit();
            Task.Factory.StartNew(() =>
            {
                if (authinfo.Score >= 80)//活体认证得分大于等于80分，自动审核通过
                {
                    AuthenticationProvider identity = new AuthenticationProvider();
                    bool res = identity.Validate(daDocs.Id, true, 0, "系统自动通过");
                    Log.Info($"自动审核，结果：{res}，错误信息：{identity.PromptInfo.CustomMessage}");
                }
                else
                {
                    Log.Info("活体认证得分低于80分，转入人工审核");
                }
            });
            return true;
        }
        public bool RelateAuth(string relateTo, string paypwd, string authUserCode)
        {
            var fac = UserModuleFactory.GetUserModuleInstance();
            if (fac == null)
            {
                Alert((ResultType)ApiStatusCode.MODULE_LOAD_FAIL, "用户模块加载失败");
                return false;
            }
            IUser relateUser = fac.GetUserByCode(relateTo);
            if (relateUser == null)
            {
                Alert((ResultType)ApiStatusCode.DATA_NOT_FOUND, "未找到关联会员信息");
                return false;
            }
            IUser authUser = fac.GetUserByCode(authUserCode);
            if (authUser == null)
            {
                Alert((ResultType)ApiStatusCode.DATA_NOT_FOUND, "用户信息未找到");
                return false;
            }
            if (!relateUser.CheckPayPassword(paypwd))
            {
                Alert((ResultType)ApiStatusCode.IDENTITY_FAILD, "关联会员的支付密码不正确");
                return false;
            }
            Tnet_User_Documents daUserDoc = new Tnet_User_Documents();
            if (!daUserDoc.SelectByUser_Id_Documents_Type(relateUser.UserId, (int)DocsType.身份证))
            {
                Alert((ResultType)ApiStatusCode.OPERATOR_FORBIDDEN, "关联账户未认证");
                return false;
            }
            if (daUserDoc.Status != (int)ValidateStatus.审核通过)
            {
                Alert((ResultType)ApiStatusCode.OPERATOR_FORBIDDEN, "关联账户未认证");
                return false;
            }
            int doc_id = daUserDoc.Documents_Id;
            BeginTransaction();
            Tnet_User_Documents daMyDoc = new Tnet_User_Documents();
            daMyDoc.ReferenceTransactionFrom(Transaction);
            bool isExist = daMyDoc.SelectByUser_Id_Documents_Type(authUser.UserId, (int)DocsType.身份证);
            daMyDoc.Documents_Id = doc_id;
            daMyDoc.Documents_Type = (int)DocsType.身份证;
            daMyDoc.Remarks = "关联认证";
            daMyDoc.Status = (int)ValidateStatus.审核通过;
            daMyDoc.User_Id = authUser.UserId;
            if (isExist)
            {
                if (!daMyDoc.Update())
                {
                    Rollback();
                    Alert((ResultType)ApiStatusCode.DATA_REFRESH_FAIL, "关联认证失败");
                    return false;
                }
            }
            else
            {
                if (!daMyDoc.Insert())
                {
                    Rollback();
                    Alert((ResultType)ApiStatusCode.DATA_PERSIST_FAIL, "关联认证失败");
                    return false;
                }
            }
            var mgt = fac.GetProfileManager(authUser);
            authUser.Auth_Status = Interface.Enums.Auth_Status.已认证;
            authUser.UserName = relateUser.UserName;
            if (!mgt.Update())
            {
                Rollback();
                Alert((ResultType)ApiStatusCode.DATA_REFRESH_FAIL, "关联认证失败");
                return false;
            }
            Commit();
            return true;

        }
        public bool Validate(int docs_id, bool weatherPass, int op_user_id, string remarks)
        {
            BeginTransaction();
            Tnet_User_Documents daDocs = new Tnet_User_Documents();
            daDocs.ReferenceTransactionFrom(Transaction);
            if (!daDocs.SelectByPk(docs_id))
            {
                Rollback();
                Alert("认证信息未找到");
                return false;
            }
            Tnet_Identity daIdentity = new Tnet_Identity();
            daIdentity.ReferenceTransactionFrom(Transaction);
            if (!daIdentity.SelectByPk(daDocs.Documents_Id))
            {
                Rollback();
                Alert("认证信息未找到");
                return false;
            }

            if (weatherPass && daIdentity.Status == 0)
            {
                daIdentity.Status = 1;
                if (!daIdentity.Update())
                {
                    Rollback();
                    Alert("操作失败，更新证件信息失败");
                    return false;
                }
            }
            //else if (!weatherPass)
            //{
            //    if (!daIdentity.Delete())
            //    {
            //        Rollback();
            //        Alert("操作失败，删除证件失败");
            //        return false;
            //    }
            //}
            IUser user = GetUser(daDocs.User_Id);
            if (user == null)
            {
                Rollback();
                Alert("用户信息未找到");
                return false;
            }
            #region parameters
            var alter = new Dictionary<Tnet_User_DocumentsCollection.Field, object>();
            alter.Add(Tnet_User_DocumentsCollection.Field.Status, weatherPass ? ValidateStatus.审核通过 : ValidateStatus.审核未通过);
            alter.Add(Tnet_User_DocumentsCollection.Field.Remarks, string.Concat(op_user_id, "|", DateTime.Now.ToString(), "|", weatherPass, "|", remarks));

            var where = new Dictionary<Tnet_User_DocumentsCollection.Field, object>();
            where.Add(Tnet_User_DocumentsCollection.Field.Id, daDocs.Id);
            where.Add(Tnet_User_DocumentsCollection.Field.Status, ValidateStatus.审核中);
            #endregion
            if (!daDocs.Update(alter, where))
            {
                Rollback();
                Alert("审核失败");
                return false;
            }
            user.Auth_Status = weatherPass ? Interface.Enums.Auth_Status.已认证 : Interface.Enums.Auth_Status.认证失败;
            user.UserName = daIdentity.User_Name;

            var fac = UserModuleFactory.GetUserModuleInstance();
            if (fac == null)
            {
                Rollback();
                Alert("系统错误");
                return false;
            }
            var manager = fac.GetProfileManager(user);
            if (!manager.Update())
            {
                Rollback();
                Alert("更新用户信息失败");
                return false;
            }
            Commit();
            return true;
        }
        private static IUser GetUser(string userCode)
        {
            var fac = UserModuleFactory.GetUserModuleInstance();
            return fac == null ? null : fac.GetUserByCode(userCode);
        }
        private static IUser GetUser(int userid)
        {
            var fac = UserModuleFactory.GetUserModuleInstance();
            return fac == null ? null : fac.GetUserByID(userid);
        }

        public object IdentityInfo(string userCode)
        {
            IUser user = GetUser(userCode);
            if (user == null)
            {
                return null;
            }
            Tnet_User_Documents daDocs = new Tnet_User_Documents();
            if (!daDocs.SelectByUser_Id_Documents_Type(user.UserId, 1))
            {
                return null;
            }
            Tnet_Identity daIdentity = new Tnet_Identity();
            if (!daIdentity.SelectByPk(daDocs.Documents_Id))
            {
                return null;
            }
            var result = new
            {
                RealName = daIdentity.User_Name,
                Identity_No = daIdentity.Identity_No,
                Birthday = daIdentity.Birthday,
                Gender = daIdentity.Sex,
                Region_Id = daIdentity.Region_Id,
                Front_Photo = daIdentity.Front_Photo,
                Back_Photo = daIdentity.Back_Photo,
                Scene_Phone = daIdentity.Scene_Photo,
                Status = daDocs.Status,
                RefuseReason = xUtils.GetValidateRemarks(daDocs.Remarks)
            };
            return result;
        }
        #region GET INFO FROM ID CARD NO.
        private static DateTime GetBirthFromIdNO(string idNo)
        {
            string pattern = "^\\d{6}(\\d{4})(\\d{2})(\\d{2})\\d{3}[0-9Xx]$";
            string str = Regex.Replace(idNo, pattern, "$1-$2-$3");
            DateTime birth;
            if (!DateTime.TryParse(str, out birth))
            {
                birth = new DateTime(1970, 1, 1);
            }
            return birth;
        }
        private static int GetGenderFromIdNo(string idNO)
        {
            string pattern = "^\\d{16}(\\d)[0-9xX]$";
            string str = Regex.Replace(idNO, pattern, "$1");
            int gender;
            if (!int.TryParse(str, out gender))
            {
                gender = 1;
            }
            return gender % 2;
        }
        #endregion
    }
}
