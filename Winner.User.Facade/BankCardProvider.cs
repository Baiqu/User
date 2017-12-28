using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.User.DataAccess;
using Winner.User.Entities;
using Winner.User.Interface;
using Winner.User.Facade;
using Winner.Areas;

namespace Winner.User.Facade
{
    public class BankCardProvider : FacadeBase
    {
        public List<BankInfo> GetSupportBankList()
        {
            return null;
        }

        public bool Bind(BankCardInfo card)
        {
            card.CardNo = card.CardNo.Replace(" ", "");//删除空格
            City city = ChinaArea.GetCity(card.City_Id);
            if (city == null)
            {
                Alert((ResultType)409, "选择的城市有误");
                return false;
            }
            Province province = ChinaArea.GetProvince(city.Province_ID);
            if (province == null)
            {
                Alert((ResultType)409, "选择的城市有误");
                return false;
            }
            var fac = UserModuleFactory.GetUserModuleInstance();
            if (fac == null)
            {
                Alert((ResultType)500, "系统错误");
                return false;
            }
            IUser user = fac.GetUserByCode(card.UserCode);
            if (user == null)
            {
                Alert((ResultType)404, "找不到用户信息");
                return false;
            }
            if (user.Auth_Status != Interface.Enums.Auth_Status.已认证)
            {
                Alert((ResultType)403, "绑定银行卡必须先认证");
                return false;
            }
            if (!string.Equals(user.UserName, card.CardHolder))
            {
                Alert((ResultType)403, "持卡人户名与认证姓名不符");
                return false;
            }
            BankInfo bank = xUtils.GetBankInfoById(card.BankId);
            if (bank == null)
            {
                Alert((ResultType)409, "银行类型有误");
                return false;
            }
            Tnet_Bank_Account daAcct = new Tnet_Bank_Account();
            daAcct.Account_Name = card.CardHolder;
            daAcct.Account_Type = 1;
            daAcct.Bank_Id = card.BankId;
            daAcct.Bank_Name = bank.BankName;
            daAcct.Branch_No = card.BranchNo;
            daAcct.Branch_Bank = card.BranchName;
            daAcct.Card_No = card.CardNo;
            daAcct.City_Name = city.City_Name;
            daAcct.Image_Fullpath = card.CardImage;
            daAcct.Province_Name = province.Province_Name;
            daAcct.Remarks = null;
            daAcct.Status = (int)ValidateStatus.审核中;
            daAcct.User_Id = user.UserId;
            daAcct.Province_Id = province.Province_Id;
            daAcct.City_Id = city.City_ID;
            if (!daAcct.Insert())
            {
                Alert((ResultType)501, "系统错误");
                return false;
            }
            if (string.Equals(user.UserName, card.CardHolder))//认证名称与绑卡名称一致，自动审核通过
            {
                BankCardProvider bcp = new BankCardProvider();
                bool res = bcp.Validate(daAcct.Id, true, "系统自动审核", 0);
                Log.Info($"户名验证通过，自动审核！审核结果:{res},错误信息：{bcp.PromptInfo.CustomMessage}");
            }
            return true;
        }

        public bool Validate(int id, bool isValid, string remarks, int op_user_id)
        {
            BeginTransaction();
            Tnet_Bank_Account daAccount = new Tnet_Bank_Account();
            daAccount.ReferenceTransactionFrom(Transaction);
            if (!daAccount.SelectByPk(id))
            {
                Rollback();
                Alert("找不到银行卡信息");
                return false;
            }
            Tnet_User_Documents daDocs = new Tnet_User_Documents();
            if (!daDocs.SelectByUser_Id_Documents_Type(daAccount.User_Id, (int)DocsType.身份证))
            {
                Rollback();
                Alert("绑定银行卡必须先认证，找不到该会员的认证信息");
                return false;
            }
            if (daDocs.Status != (int)ValidateStatus.审核通过)
            {
                Rollback();
                Alert("绑定银行卡必须先认证，该会员的认证状态：" + ((ValidateStatus)daDocs.Status).ToString());
                return false;
            }
            string validMessage = string.Format("{0}|{1}|{2}|{3}", op_user_id, DateTime.Now, isValid, remarks);
            daAccount.Remarks = validMessage;
            daAccount.Status = (int)(isValid ? ValidateStatus.审核通过 : ValidateStatus.审核未通过);
            if (!daAccount.Update())
            {
                Rollback();
                Alert("操作失败，请重试");
                return false;
            }
            Tnet_Bank_AccountCollection daCollection = new Tnet_Bank_AccountCollection();
            daCollection.ReferenceTransactionFrom(Transaction);
            daCollection.ListByUserId(daAccount.User_Id);//查询会员已有银行数量
            //如果只允许绑定一张卡,并且当前审核状态为成功，且会员当前拥有银行卡数量大于限制
            Log.Info($"会员已有银行卡数量：{daCollection.Count},系统允许绑定银行卡数量：{AppConfig.MaxBankCardQuota},审核状态：{isValid},应用配置区域：{Winner.ConfigurationManager.ConfigurationProvider.AppId}");

            if (AppConfig.MaxBankCardQuota == 1 && isValid && daCollection.Count > AppConfig.MaxBankCardQuota)
            {
                Log.Info("作废旧银行卡");
                if (!daCollection.DeleteAllExceptById(daAccount.Id, daAccount.User_Id))
                {
                    Alert("作废旧银行卡失败");
                    Rollback();
                    return false;
                }
            }
            Commit();
            return true;
        }
    }
}
