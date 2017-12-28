/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tnet_Recharge.generate.cs
* CreateTime : 2017-09-26 15:37:38
* CodeGenerateVersion : 1.0.0.0
* TemplateVersion: 2.0.0
* E_Mail : zhj.pavel@gmail.com
* Blog : 
* Copyright (C) YXH
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Winner.Framework.Core.DataAccess.Oracle;
using Winner.User.Entities;
using Winner.Framework.Utils;

namespace Winner.User.DataAccess
{
    /// <summary>
    /// 充值订单表
    /// </summary>
    public partial class Tnet_Recharge : DataAccessBase
    {
        #region 构造和基本
        public Tnet_Recharge() : base()
        { }
        public Tnet_Recharge(DataRow dataRow) : base(dataRow)
        { }
        public const string _RECHARGE_ID = "RECHARGE_ID";
        public const string _SUBJECT = "SUBJECT";
        public const string _USER_ID = "USER_ID";
        public const string _ORDER_NO = "ORDER_NO";
        public const string _AMOUNT = "AMOUNT";
        public const string _RECHARGE_TYPE = "RECHARGE_TYPE";
        public const string _PAY_TYPE = "PAY_TYPE";
        public const string _PAY_STATUS = "PAY_STATUS";
        public const string _CREATE_TIME = "CREATE_TIME";
        public const string _DEAL_TIME = "DEAL_TIME";
        public const string _VOUCHER = "VOUCHER";
        public const string _TRANSFER_ID = "TRANSFER_ID";
        public const string _REMARKS = "REMARKS";
        public const string _TableName = "TNET_RECHARGE";
        protected override DataRow BuildRow()
        {
            DataTable table = new DataTable("TNET_RECHARGE");
            table.Columns.Add(_RECHARGE_ID, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_SUBJECT, typeof(string)).DefaultValue = string.Empty;
            table.Columns.Add(_USER_ID, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_ORDER_NO, typeof(string)).DefaultValue = string.Empty;
            table.Columns.Add(_AMOUNT, typeof(decimal)).DefaultValue = 0;
            table.Columns.Add(_RECHARGE_TYPE, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_PAY_TYPE, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_PAY_STATUS, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_CREATE_TIME, typeof(DateTime)).DefaultValue = DateTime.Now;
            table.Columns.Add(_DEAL_TIME, typeof(DateTime)).DefaultValue = DBNull.Value;
            table.Columns.Add(_VOUCHER, typeof(string)).DefaultValue = DBNull.Value;
            table.Columns.Add(_TRANSFER_ID, typeof(int)).DefaultValue = DBNull.Value;
            table.Columns.Add(_REMARKS, typeof(string)).DefaultValue = DBNull.Value;
            return table.NewRow();
        }
        #endregion

        #region 属性
        protected override string TableName
        {
            get { return _TableName; }
        }
        /// <summary>
        /// 充值ID(必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public int Recharge_Id
        {
            get { return Convert.ToInt32(DataRow[_RECHARGE_ID]); }
            set { setProperty(_RECHARGE_ID, value); }
        }
        /// <summary>
        /// 交易主题(必填)
        /// <para>
        /// defaultValue: string.Empty;   Length: 100Byte
        /// </para>
        /// </summary>
        public string Subject
        {
            get { return DataRow[_SUBJECT].ToString(); }
            set { setProperty(_SUBJECT, value); }
        }
        /// <summary>
        /// 会员ID(必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public int User_Id
        {
            get { return Convert.ToInt32(DataRow[_USER_ID]); }
            set { setProperty(_USER_ID, value); }
        }
        /// <summary>
        /// 充值订单号$AUTOINCREASE$(必填)
        /// <para>
        /// defaultValue: string.Empty;   Length: 100Byte
        /// </para>
        /// </summary>
        public string Order_No
        {
            get { return DataRow[_ORDER_NO].ToString(); }
            protected set { setProperty(_ORDER_NO, value); }
        }
        /// <summary>
        /// 充值金额，单位元(必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public decimal Amount
        {
            get { return Convert.ToDecimal(DataRow[_AMOUNT]); }
            set { setProperty(_AMOUNT, value); }
        }
        /// <summary>
        /// 充值类型(必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public int Recharge_Type
        {
            get { return Convert.ToInt32(DataRow[_RECHARGE_TYPE]); }
            set { setProperty(_RECHARGE_TYPE, value); }
        }
        /// <summary>
        /// 支付方式(必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public int Pay_Type
        {
            get { return Convert.ToInt32(DataRow[_PAY_TYPE]); }
            set { setProperty(_PAY_TYPE, value); }
        }
        /// <summary>
        /// 支付状态[0：等待支付，1：支付成功，2：支付失败](必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public int Pay_Status
        {
            get { return Convert.ToInt32(DataRow[_PAY_STATUS]); }
            set { setProperty(_PAY_STATUS, value); }
        }
        /// <summary>
        /// 订单创建时间(必填)
        /// <para>
        /// defaultValue: DateTime.Now;   Length: 7Byte
        /// </para>
        /// </summary>
        public DateTime Create_Time
        {
            get { return Convert.ToDateTime(DataRow[_CREATE_TIME]); }
            set { setProperty(_CREATE_TIME, value); }
        }
        /// <summary>
        /// 支付时间(可空)
        /// <para>
        /// defaultValue: DBNull.Value;   Length: 7Byte
        /// </para>
        /// </summary>
        public DateTime? Deal_Time
        {
            get { return Helper.ToDateTime(DataRow[_DEAL_TIME]); }
            set { setProperty(_DEAL_TIME, value); }
        }
        /// <summary>
        /// 支付订单凭证号(可空)
        /// <para>
        /// defaultValue: DBNull.Value;   Length: 200Byte
        /// </para>
        /// </summary>
        public string Voucher
        {
            get { return DataRow[_VOUCHER].ToString(); }
            set { setProperty(_VOUCHER, value); }
        }
        /// <summary>
        /// 充值转账ID(可空)
        /// <para>
        /// defaultValue: DBNull.Value;   Length: 22Byte
        /// </para>
        /// </summary>
        public int? Transfer_Id
        {
            get { return Helper.ToInt32(DataRow[_TRANSFER_ID]); }
            set { setProperty(_TRANSFER_ID, value); }
        }
        /// <summary>
        /// 备注信息(可空)
        /// <para>
        /// defaultValue: DBNull.Value;   Length: 400Byte
        /// </para>
        /// </summary>
        public string Remarks
        {
            get { return DataRow[_REMARKS].ToString(); }
            set { setProperty(_REMARKS, value); }
        }
        #endregion

        #region 基本方法
        protected bool SelectByCondition(string condition)
        {
            string sql = "SELECT RECHARGE_ID,SUBJECT,USER_ID,ORDER_NO,AMOUNT,RECHARGE_TYPE,PAY_TYPE,PAY_STATUS,CREATE_TIME,DEAL_TIME,VOUCHER,TRANSFER_ID,REMARKS FROM TNET_RECHARGE WHERE " + condition;
            return base.SelectBySql(sql);
        }
        protected bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TNET_RECHARGE WHERE " + condition;
            return base.DeleteBySql(sql);
        }

        public bool Delete(int recharge_id)
        {
            string condition = " RECHARGE_ID=:RECHARGE_ID";
            AddParameter(_RECHARGE_ID, recharge_id);
            return DeleteByCondition(condition);
        }
        public bool Delete()
        {
            string condition = " RECHARGE_ID=:RECHARGE_ID";
            AddParameter(_RECHARGE_ID, DataRow[_RECHARGE_ID]);
            return DeleteByCondition(condition);
        }

        public bool Insert(string prefix, out string order_no)
        {
            int id = this.Recharge_Id = GetSequence("SELECT SEQ_TNET_RECHARGE.nextval FROM DUAL");
            order_no = this.Order_No = string.Concat(prefix, DateTime.Now.ToString("yyyyMMdd"), id.ToString().PadLeft(10, '0'));
            string sql = @"INSERT INTO TNET_RECHARGE(RECHARGE_ID,SUBJECT,USER_ID,ORDER_NO,AMOUNT,RECHARGE_TYPE,PAY_TYPE,PAY_STATUS,DEAL_TIME,VOUCHER,TRANSFER_ID,REMARKS)
			VALUES (:RECHARGE_ID,:SUBJECT,:USER_ID,:ORDER_NO,:AMOUNT,:RECHARGE_TYPE,:PAY_TYPE,:PAY_STATUS,:DEAL_TIME,:VOUCHER,:TRANSFER_ID,:REMARKS)";
            AddParameter(_RECHARGE_ID, DataRow[_RECHARGE_ID]);
            AddParameter(_SUBJECT, DataRow[_SUBJECT]);
            AddParameter(_USER_ID, DataRow[_USER_ID]);
            AddParameter(_ORDER_NO, DataRow[_ORDER_NO]);
            AddParameter(_AMOUNT, DataRow[_AMOUNT]);
            AddParameter(_RECHARGE_TYPE, DataRow[_RECHARGE_TYPE]);
            AddParameter(_PAY_TYPE, DataRow[_PAY_TYPE]);
            AddParameter(_PAY_STATUS, DataRow[_PAY_STATUS]);
            AddParameter(_DEAL_TIME, DataRow[_DEAL_TIME]);
            AddParameter(_VOUCHER, DataRow[_VOUCHER]);
            AddParameter(_TRANSFER_ID, DataRow[_TRANSFER_ID]);
            AddParameter(_REMARKS, DataRow[_REMARKS]);
            return InsertBySql(sql);
        }

        public bool Update()
        {
            return UpdateByCondition(string.Empty);
        }
        public bool Update(Dictionary<Tnet_RechargeCollection.Field, object> alterDic, Dictionary<Tnet_RechargeCollection.Field, object> conditionDic)
        {
            if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_RechargeCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_RechargeCollection.Field key in conditionDic.Keys)
            {
                object value = conditionDic[key];
                string name = key.ToString();
                if (alterDic.Keys.Contains(key))
                {
                    name = string.Concat("condition_", key);
                }
                sql.Append(key).Append("=:").Append(name).Append(" and ");
                AddParameter(name, value);
            }
            int len = " and ".Length;
            sql.Remove(sql.Length - len, len);//移除最后一个and
            return UpdateBySql(sql.ToString());
        }
        protected bool UpdateByCondition(string condition)
        {
            ChangePropertys.Remove(_RECHARGE_ID);
            if (ChangePropertys.Count == 0)
            {
                return true;
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_RECHARGE SET");
            while (ChangePropertys.MoveNext())
            {
                sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.Append(" WHERE RECHARGE_ID=:RECHARGE_ID");
            AddParameter(_RECHARGE_ID, DataRow[_RECHARGE_ID]);
            if (!string.IsNullOrEmpty(condition))
            {
                sql.AppendLine(" AND " + condition);
            }
            bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
        }
        public bool SelectByOrderNo(string order_no)
        {
            string condition = " ORDER_NO=:ORDER_NO";
            AddParameter(_ORDER_NO, order_no);
            return SelectByCondition(condition);
        }
        public bool SelectByPk(int recharge_id)
        {
            string condition = " RECHARGE_ID=:RECHARGE_ID";
            AddParameter(_RECHARGE_ID, recharge_id);
            return SelectByCondition(condition);
        }
        #endregion
    }
    /// <summary>
    /// 充值订单表[集合对象]
    /// </summary>
    public partial class Tnet_RechargeCollection : DataAccessCollectionBase
    {
        #region 构造和基本
        public Tnet_RechargeCollection() : base()
        {
        }

        protected override DataTable BuildTable()
        {
            return new Tnet_Recharge().CloneSchemaOfTable();
        }
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_Recharge(DataTable.Rows[index]);
        }
        protected override string TableName
        {
            get { return Tnet_Recharge._TableName; }
        }
        public Tnet_Recharge this[int index]
        {
            get { return new Tnet_Recharge(DataTable.Rows[index]); }
        }
        public enum Field
        {
            Recharge_Id = 0,
            Subject = 1,
            User_Id = 2,
            Order_No = 3,
            Amount = 4,
            Recharge_Type = 5,
            Pay_Type = 6,
            Pay_Status = 7,
            Create_Time = 8,
            Deal_Time = 9,
            Voucher = 10,
            Transfer_Id = 11,
            Remarks = 12,
        }
        #endregion
        #region 基本方法
        protected bool ListByCondition(string condition)
        {
            string sql = "SELECT RECHARGE_ID,SUBJECT,USER_ID,ORDER_NO,AMOUNT,RECHARGE_TYPE,PAY_TYPE,PAY_STATUS,CREATE_TIME,DEAL_TIME,VOUCHER,TRANSFER_ID,REMARKS FROM TNET_RECHARGE WHERE " + condition;
            return ListBySql(sql);
        }

        public bool ListByUser_Id(int user_id)
        {
            string condition = "USER_ID=:USER_ID ORDER BY RECHARGE_ID DESC";
            AddParameter(Tnet_Recharge._USER_ID, user_id);
            return ListByCondition(condition);
        }
        public bool ListAll()
        {
            string condition = " 1=1";
            return ListByCondition(condition);
        }
        #region Linq
        public Tnet_Recharge Find(Predicate<Tnet_Recharge> match)
        {
            foreach (Tnet_Recharge item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_RechargeCollection FindAll(Predicate<Tnet_Recharge> match)
        {
            Tnet_RechargeCollection list = new Tnet_RechargeCollection();
            foreach (Tnet_Recharge item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_Recharge> match)
        {
            foreach (Tnet_Recharge item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
        public bool DeleteAt(Predicate<Tnet_Recharge> match)
        {
            BeginTransaction();
            foreach (Tnet_Recharge item in this)
            {
                item.ReferenceTransactionFrom(Transaction);
                if (!match(item))
                    continue;
                if (!item.Delete())
                {
                    Rollback();
                    return false;
                }
            }
            Commit();
            return true;
        }
        #endregion
        #endregion
    }
}