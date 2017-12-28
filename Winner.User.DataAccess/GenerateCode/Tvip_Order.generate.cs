/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tvip_Order.generate.cs
* CreateTime : 2017-10-27 14:53:22
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
    /// VIP升级订单表
    /// </summary>
    public partial class Tvip_Order : DataAccessBase
    {
        #region 构造和基本
        public Tvip_Order() : base()
        { }
        public Tvip_Order(DataRow dataRow) : base(dataRow)
        { }
        public const string _BIZ_ARGS = "BIZ_ARGS";
        public const string _ORDER_ID = "ORDER_ID";
        public const string _USER_ID = "USER_ID";
        public const string _ORDER_NO = "ORDER_NO";
        public const string _AMOUNT = "AMOUNT";
        public const string _STATUS = "STATUS";
        public const string _PAY_TYPE = "PAY_TYPE";
        public const string _TRANSFER_ID = "TRANSFER_ID";
        public const string _ORDER_TYPE = "ORDER_TYPE";
        public const string _CREATETIME = "CREATETIME";
        public const string _REMAKRS = "REMAKRS";
        public const string _PAYER_ORG_ID = "PAYER_ORG_ID";
        public const string _VOUCHER = "VOUCHER";
        public const string _DELIVERY_TYPE = "DELIVERY_TYPE";
        public const string _DEVICE_ID = "DEVICE_ID";
        public const string _TableName = "TVIP_ORDER";
        protected override DataRow BuildRow()
        {
            DataTable table = new DataTable("TVIP_ORDER");
            table.Columns.Add(_BIZ_ARGS, typeof(string)).DefaultValue = DBNull.Value;
            table.Columns.Add(_ORDER_ID, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_USER_ID, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_ORDER_NO, typeof(string)).DefaultValue = string.Empty;
            table.Columns.Add(_AMOUNT, typeof(decimal)).DefaultValue = 0;
            table.Columns.Add(_STATUS, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_PAY_TYPE, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_TRANSFER_ID, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_ORDER_TYPE, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = DateTime.Now;
            table.Columns.Add(_REMAKRS, typeof(string)).DefaultValue = DBNull.Value;
            table.Columns.Add(_PAYER_ORG_ID, typeof(int)).DefaultValue = DBNull.Value;
            table.Columns.Add(_VOUCHER, typeof(string)).DefaultValue = DBNull.Value;
            table.Columns.Add(_DELIVERY_TYPE, typeof(int)).DefaultValue = 0;
            table.Columns.Add(_DEVICE_ID, typeof(int)).DefaultValue = 0;
            return table.NewRow();
        }
        #endregion

        #region 属性
        protected override string TableName
        {
            get { return _TableName; }
        }
        /// <summary>
        /// 业务参数，Json格式(可空)
        /// <para>
        /// defaultValue: DBNull.Value;   Length: 2000Byte
        /// </para>
        /// </summary>
        public string Biz_Args
        {
            get { return DataRow[_BIZ_ARGS].ToString(); }
            set { setProperty(_BIZ_ARGS, value); }
        }
        /// <summary>
        /// 订单ID(必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public int Order_Id
        {
            get { return Convert.ToInt32(DataRow[_ORDER_ID]); }
            set { setProperty(_ORDER_ID, value); }
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
        /// 订单号$AUTOINCREASE$(必填)
        /// <para>
        /// defaultValue: string.Empty;   Length: 50Byte
        /// </para>
        /// </summary>
        public string Order_No
        {
            get { return DataRow[_ORDER_NO].ToString(); }
            protected set { setProperty(_ORDER_NO, value); }
        }
        /// <summary>
        /// 订单金额，单位元(必填)
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
        /// 订单状态[0：等待支付，1：支付成功](必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public int Status
        {
            get { return Convert.ToInt32(DataRow[_STATUS]); }
            set { setProperty(_STATUS, value); }
        }
        /// <summary>
        /// 支付类型[0：金币支付，1：刷卡支付](必填)
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
        /// 转账ID(必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public int Transfer_Id
        {
            get { return Convert.ToInt32(DataRow[_TRANSFER_ID]); }
            set { setProperty(_TRANSFER_ID, value); }
        }
        /// <summary>
        /// 订单类型(必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public int Order_Type
        {
            get { return Convert.ToInt32(DataRow[_ORDER_TYPE]); }
            set { setProperty(_ORDER_TYPE, value); }
        }
        /// <summary>
        /// 创建时间(必填)
        /// <para>
        /// defaultValue: DateTime.Now;   Length: 7Byte
        /// </para>
        /// </summary>
        public DateTime Createtime
        {
            get { return Convert.ToDateTime(DataRow[_CREATETIME]); }
        }
        /// <summary>
        /// 备注信息(可空)
        /// <para>
        /// defaultValue: DBNull.Value;   Length: 400Byte
        /// </para>
        /// </summary>
        public string Remakrs
        {
            get { return DataRow[_REMAKRS].ToString(); }
            set { setProperty(_REMAKRS, value); }
        }
        /// <summary>
        /// 付款俱乐部(可空)
        /// <para>
        /// defaultValue: DBNull.Value;   Length: 22Byte
        /// </para>
        /// </summary>
        public int? Payer_Org_Id
        {
            get { return Helper.ToInt32(DataRow[_PAYER_ORG_ID]); }
            set { setProperty(_PAYER_ORG_ID, value); }
        }
        /// <summary>
        /// 支付凭证号(可空)
        /// <para>
        /// defaultValue: DBNull.Value;   Length: 100Byte
        /// </para>
        /// </summary>
        public string Voucher
        {
            get { return DataRow[_VOUCHER].ToString(); }
            set { setProperty(_VOUCHER, value); }
        }
        /// <summary>
        /// 发货类型[0：自提，1：快递](必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public int Delivery_Type
        {
            get { return Convert.ToInt32(DataRow[_DELIVERY_TYPE]); }
            set { setProperty(_DELIVERY_TYPE, value); }
        }
        /// <summary>
        /// 赠送设备(必填)
        /// <para>
        /// defaultValue: 0;   Length: 22Byte
        /// </para>
        /// </summary>
        public int Device_Id
        {
            get { return Convert.ToInt32(DataRow[_DEVICE_ID]); }
            set { setProperty(_DEVICE_ID, value); }
        }
        #endregion

        #region 基本方法
        protected bool SelectByCondition(string condition)
        {
            string sql = "SELECT BIZ_ARGS,ORDER_ID,USER_ID,ORDER_NO,AMOUNT,STATUS,PAY_TYPE,TRANSFER_ID,ORDER_TYPE,CREATETIME,REMAKRS,PAYER_ORG_ID,VOUCHER,DELIVERY_TYPE,DEVICE_ID FROM TVIP_ORDER WHERE " + condition;
            return base.SelectBySql(sql);
        }
        protected bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TVIP_ORDER WHERE " + condition;
            return base.DeleteBySql(sql);
        }

        public bool Delete(int order_id)
        {
            string condition = " ORDER_ID=:ORDER_ID";
            AddParameter(_ORDER_ID, order_id);
            return DeleteByCondition(condition);
        }
        public bool Delete()
        {
            string condition = " ORDER_ID=:ORDER_ID";
            AddParameter(_ORDER_ID, DataRow[_ORDER_ID]);
            return DeleteByCondition(condition);
        }

        public bool Insert(string prefix, out string order_no)
        {
            int id = this.Order_Id = GetSequence("SELECT SEQ_TVIP_ORDER.nextval FROM DUAL");
            order_no = this.Order_No = string.Concat(prefix, DateTime.Now.ToString("yyyyMMdd"), id.ToString().PadLeft(10, '0'));
            string sql = @"INSERT INTO TVIP_ORDER(BIZ_ARGS,ORDER_ID,USER_ID,ORDER_NO,AMOUNT,STATUS,PAY_TYPE,TRANSFER_ID,ORDER_TYPE,REMAKRS,PAYER_ORG_ID,VOUCHER,DELIVERY_TYPE,DEVICE_ID)
			VALUES (:BIZ_ARGS,:ORDER_ID,:USER_ID,:ORDER_NO,:AMOUNT,:STATUS,:PAY_TYPE,:TRANSFER_ID,:ORDER_TYPE,:REMAKRS,:PAYER_ORG_ID,:VOUCHER,:DELIVERY_TYPE,:DEVICE_ID)";
            AddParameter(_BIZ_ARGS, DataRow[_BIZ_ARGS]);
            AddParameter(_ORDER_ID, DataRow[_ORDER_ID]);
            AddParameter(_USER_ID, DataRow[_USER_ID]);
            AddParameter(_ORDER_NO, DataRow[_ORDER_NO]);
            AddParameter(_AMOUNT, DataRow[_AMOUNT]);
            AddParameter(_STATUS, DataRow[_STATUS]);
            AddParameter(_PAY_TYPE, DataRow[_PAY_TYPE]);
            AddParameter(_TRANSFER_ID, DataRow[_TRANSFER_ID]);
            AddParameter(_ORDER_TYPE, DataRow[_ORDER_TYPE]);
            AddParameter(_REMAKRS, DataRow[_REMAKRS]);
            AddParameter(_PAYER_ORG_ID, DataRow[_PAYER_ORG_ID]);
            AddParameter(_VOUCHER, DataRow[_VOUCHER]);
            AddParameter(_DELIVERY_TYPE, DataRow[_DELIVERY_TYPE]);
            AddParameter(_DEVICE_ID, DataRow[_DEVICE_ID]);
            return InsertBySql(sql);
        }

        public bool Update()
        {
            return UpdateByCondition(string.Empty);
        }
        public bool Update(Dictionary<Tvip_OrderCollection.Field, object> alterDic, Dictionary<Tvip_OrderCollection.Field, object> conditionDic)
        {
            if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tvip_OrderCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tvip_OrderCollection.Field key in conditionDic.Keys)
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
            ChangePropertys.Remove(_ORDER_ID);
            if (ChangePropertys.Count == 0)
            {
                return true;
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TVIP_ORDER SET");
            while (ChangePropertys.MoveNext())
            {
                sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.Append(" WHERE ORDER_ID=:ORDER_ID");
            AddParameter(_ORDER_ID, DataRow[_ORDER_ID]);
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
        public bool SelectByPk(int order_id)
        {
            string condition = " ORDER_ID=:ORDER_ID";
            AddParameter(_ORDER_ID, order_id);
            return SelectByCondition(condition);
        }
        #endregion
    }
    /// <summary>
    /// VIP升级订单表[集合对象]
    /// </summary>
    public partial class Tvip_OrderCollection : DataAccessCollectionBase
    {
        #region 构造和基本
        public Tvip_OrderCollection() : base()
        {
        }

        protected override DataTable BuildTable()
        {
            return new Tvip_Order().CloneSchemaOfTable();
        }
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tvip_Order(DataTable.Rows[index]);
        }
        protected override string TableName
        {
            get { return Tvip_Order._TableName; }
        }
        public Tvip_Order this[int index]
        {
            get { return new Tvip_Order(DataTable.Rows[index]); }
        }
        public enum Field
        {
            Biz_Args = 0,
            Order_Id = 1,
            User_Id = 2,
            Order_No = 3,
            Amount = 4,
            Status = 5,
            Pay_Type = 6,
            Transfer_Id = 7,
            Order_Type = 8,
            Createtime = 9,
            Remakrs = 10,
            Payer_Org_Id = 11,
            Voucher = 12,
            Delivery_Type = 13,
            Device_Id = 14,
        }
        #endregion
        #region 基本方法
        protected bool ListByCondition(string condition)
        {
            string sql = "SELECT BIZ_ARGS,ORDER_ID,USER_ID,ORDER_NO,AMOUNT,STATUS,PAY_TYPE,TRANSFER_ID,ORDER_TYPE,CREATETIME,REMAKRS,PAYER_ORG_ID,VOUCHER,DELIVERY_TYPE,DEVICE_ID FROM TVIP_ORDER WHERE " + condition;
            return ListBySql(sql);
        }

        public bool ListByUser_Id(int user_id)
        {
            string condition = "USER_ID=:USER_ID ORDER BY ORDER_ID DESC";
            AddParameter(Tvip_Order._USER_ID, user_id);
            return ListByCondition(condition);
        }
        public bool ListAll()
        {
            string condition = " 1=1";
            return ListByCondition(condition);
        }
        #region Linq
        public Tvip_Order Find(Predicate<Tvip_Order> match)
        {
            foreach (Tvip_Order item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tvip_OrderCollection FindAll(Predicate<Tvip_Order> match)
        {
            Tvip_OrderCollection list = new Tvip_OrderCollection();
            foreach (Tvip_Order item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tvip_Order> match)
        {
            foreach (Tvip_Order item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
        public bool DeleteAt(Predicate<Tvip_Order> match)
        {
            BeginTransaction();
            foreach (Tvip_Order item in this)
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