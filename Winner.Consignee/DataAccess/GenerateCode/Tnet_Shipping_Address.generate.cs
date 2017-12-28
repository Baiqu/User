   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_Shipping_Address.generate.cs
 * CreateTime : 2017-09-15 16:44:14
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
using Winner.Consignee.Entities;

namespace Winner.Consignee.DataAccess
{
	/// <summary>
	/// 收货地址表
	/// </summary>
	public partial class Tnet_Shipping_Address : DataAccessBase
	{
		#region 构造和基本
		public Tnet_Shipping_Address():base()
		{}
		public Tnet_Shipping_Address(DataRow dataRow):base(dataRow)
		{}
		public const string _ADDRESS_ID = "ADDRESS_ID";
		public const string _OWNER_ID = "OWNER_ID";
		public const string _OWNER_TYPE = "OWNER_TYPE";
		public const string _CONSIGNEE_ID = "CONSIGNEE_ID";
		public const string _IS_DEFAULT = "IS_DEFAULT";
		public const string _TAG_NAME = "TAG_NAME";
		public const string _CREATE_TIME = "CREATE_TIME";
		public const string _IS_DEL = "IS_DEL";
		public const string _TableName = "TNET_SHIPPING_ADDRESS";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_SHIPPING_ADDRESS");
			table.Columns.Add(_ADDRESS_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_OWNER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_OWNER_TYPE,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CONSIGNEE_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_IS_DEFAULT,typeof(int)).DefaultValue=0;
			table.Columns.Add(_TAG_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CREATE_TIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_IS_DEL,typeof(int)).DefaultValue=0;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 地址ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Address_Id
		{
			get{ return Convert.ToInt32(DataRow[_ADDRESS_ID]);}
			 set{setProperty(_ADDRESS_ID, value);}
		}
		/// <summary>
		/// 拥有者ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Owner_Id
		{
			get{ return Convert.ToInt32(DataRow[_OWNER_ID]);}
			 set{setProperty(_OWNER_ID, value);}
		}
		/// <summary>
		/// 拥有者类型(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Owner_Type
		{
			get{ return Convert.ToInt32(DataRow[_OWNER_TYPE]);}
			 set{setProperty(_OWNER_TYPE, value);}
		}
		/// <summary>
		/// 收件人信息ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Consignee_Id
		{
			get{ return Convert.ToInt32(DataRow[_CONSIGNEE_ID]);}
			 set{setProperty(_CONSIGNEE_ID, value);}
		}
		/// <summary>
		/// 是否默认地址(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Is_Default
		{
			get{ return Convert.ToInt32(DataRow[_IS_DEFAULT]);}
			 set{setProperty(_IS_DEFAULT, value);}
		}
		/// <summary>
		/// 地址标签(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 40Byte
		/// </para>
		/// </summary>
		public string Tag_Name
		{
			get{ return DataRow[_TAG_NAME].ToString();}
			 set{setProperty(_TAG_NAME, value);}
		}
		/// <summary>
		/// 添加时间(必填)
		/// <para>
		/// defaultValue: DateTime.Now;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Create_Time
		{
			get{ return Convert.ToDateTime(DataRow[_CREATE_TIME]);}
			 set{setProperty(_CREATE_TIME, value);}
		}
		/// <summary>
		/// 是否删除(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Is_Del
		{
			get{ return Convert.ToInt32(DataRow[_IS_DEL]);}
			 set{setProperty(_IS_DEL, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT ADDRESS_ID,OWNER_ID,OWNER_TYPE,CONSIGNEE_ID,IS_DEFAULT,TAG_NAME,CREATE_TIME,IS_DEL FROM TNET_SHIPPING_ADDRESS WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_SHIPPING_ADDRESS WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int address_id)
		{
			string condition = " ADDRESS_ID=:ADDRESS_ID";
			AddParameter(_ADDRESS_ID,address_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " ADDRESS_ID=:ADDRESS_ID";
			AddParameter(_ADDRESS_ID,DataRow[_ADDRESS_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Address_Id = GetSequence("SELECT SEQ_TNET_SHIPPING_ADDRESS.nextval FROM DUAL");
			string sql = @"INSERT INTO TNET_SHIPPING_ADDRESS(ADDRESS_ID,OWNER_ID,OWNER_TYPE,CONSIGNEE_ID,IS_DEFAULT,TAG_NAME,IS_DEL)
			VALUES (:ADDRESS_ID,:OWNER_ID,:OWNER_TYPE,:CONSIGNEE_ID,:IS_DEFAULT,:TAG_NAME,:IS_DEL)";
			AddParameter(_ADDRESS_ID,DataRow[_ADDRESS_ID]);
			AddParameter(_OWNER_ID,DataRow[_OWNER_ID]);
			AddParameter(_OWNER_TYPE,DataRow[_OWNER_TYPE]);
			AddParameter(_CONSIGNEE_ID,DataRow[_CONSIGNEE_ID]);
			AddParameter(_IS_DEFAULT,DataRow[_IS_DEFAULT]);
			AddParameter(_TAG_NAME,DataRow[_TAG_NAME]);
			AddParameter(_IS_DEL,DataRow[_IS_DEL]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_Shipping_AddressCollection.Field,object> alterDic,Dictionary<Tnet_Shipping_AddressCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_Shipping_AddressCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_Shipping_AddressCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_ADDRESS_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_SHIPPING_ADDRESS SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE ADDRESS_ID=:ADDRESS_ID");
			AddParameter(_ADDRESS_ID, DataRow[_ADDRESS_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int address_id)
		{
			string condition = " ADDRESS_ID=:ADDRESS_ID";
			AddParameter(_ADDRESS_ID,address_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// 收货地址表[集合对象]
	/// </summary>
	public partial class Tnet_Shipping_AddressCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_Shipping_AddressCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_Shipping_Address().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_Shipping_Address(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_Shipping_Address._TableName;}
		}
		public Tnet_Shipping_Address this[int index]
        {
            get { return new Tnet_Shipping_Address(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Address_Id=0,
			Owner_Id=1,
			Owner_Type=2,
			Consignee_Id=3,
			Is_Default=4,
			Tag_Name=5,
			Create_Time=6,
			Is_Del=7,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT ADDRESS_ID,OWNER_ID,OWNER_TYPE,CONSIGNEE_ID,IS_DEFAULT,TAG_NAME,CREATE_TIME,IS_DEL FROM TNET_SHIPPING_ADDRESS WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListByConsignee_Id(int consignee_id)
		{
			string condition = "CONSIGNEE_ID=:CONSIGNEE_ID ORDER BY ADDRESS_ID DESC";
			AddParameter(Tnet_Shipping_Address._CONSIGNEE_ID,consignee_id);
			return ListByCondition(condition);		
		}
		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_Shipping_Address Find(Predicate<Tnet_Shipping_Address> match)
        {
            foreach (Tnet_Shipping_Address item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_Shipping_AddressCollection FindAll(Predicate<Tnet_Shipping_Address> match)
        {
            Tnet_Shipping_AddressCollection list = new Tnet_Shipping_AddressCollection();
            foreach (Tnet_Shipping_Address item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_Shipping_Address> match)
        {
            foreach (Tnet_Shipping_Address item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_Shipping_Address> match)
        {
            BeginTransaction();
            foreach (Tnet_Shipping_Address item in this)
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