using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.User.Entities;

namespace Winner.User.DataAccess
{
    public partial class Tnet_User_Documents
    {
        /// <summary>
        /// 查询认证信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="type">证件类型</param>
        /// <param name="isContainDel">是否包含已删除的数据</param>
        /// <returns></returns>
        public bool SelectByUid_DocType_DelFlag(int userId, DocsType type, bool isContainDel = false)
        {
            string sql_condition = " USER_ID=:USER_ID AND DOCUMENTS_TYPE=:DOCUMENTS_TYPE";
            AddParameter(_USER_ID, userId);
            AddParameter(_DOCUMENTS_TYPE, type);
            if (!isContainDel)
            {
                sql_condition += " AND STATUS<>:DEL_FLAG";
                AddParameter("DEL_FLAG", ValidateStatus.已删除);
            }
            return SelectByCondition(sql_condition);
        }
    }
    public partial class Tnet_User_DocumentsCollection
    {
        public bool ListByDocs_id(int document_id, DocsType docsType)
        {
            string sql_condition = string.Format("{0}=:{0} AND {1}=:{1}", Tnet_User_Documents._DOCUMENTS_ID, Tnet_User_Documents._DOCUMENTS_TYPE);
            AddParameter(Tnet_User_Documents._DOCUMENTS_ID, document_id);
            AddParameter(Tnet_User_Documents._DOCUMENTS_TYPE, docsType);
            return ListByCondition(sql_condition);
        }
    }
}
