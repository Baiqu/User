   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tvip_Express.generate.cs
 * CreateTime : 2017-08-28 11:15:51
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

namespace Winner.User.DataAccess
{
	/// <summary>
	/// VIP升级收货地址
	/// </summary>
	public partial class Tvip_Express : DataAccessBase
	{
		#region 构造和基本
		public Tvip_Express():base()
		{}
		public Tvip_Express(DataRow dataRow):base(dataRow)
		{}
		public const string _ORDER_ID = "ORDER_ID";
		public const string _RECEIVER = "RECEIVER";
		public const string _CONTRACT_PHONE = "CONTRACT_PHONE";
		public const string _PROVINCE_NAME = "PROVINCE_NAME";
		public const string _CITY_NAME = "CITY_NAME";
		public const string _REGION_NAME = "REGION_NAME";
		public const string _FULL_ADDRESS = "FULL_ADDRESS";
		public const string _STATUS = "STATUS";
		public const string _CREATETIME = "CREATETIME";
		public const string _EXPRESS_NAME = "EXPRESS_NAME";
		public const string _EXPRESS_NO = "EXPRESS_NO";
		public const string _CONFIRM_EXPRESS = "CONFIRM_EXPRESS";
		public const string _TableName = "TVIP_EXPRESS";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TVIP_EXPRESS");
			table.Columns.Add(_ORDER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_RECEIVER,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_CONTRACT_PHONE,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_PROVINCE_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_CITY_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_REGION_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_FULL_ADDRESS,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_STATUS,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CREATETIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_EXPRESS_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_EXPRESS_NO,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CONFIRM_EXPRESS,typeof(int)).DefaultValue=0;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 订单ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Order_Id
		{
			get{ return Convert.ToInt32(DataRow[_ORDER_ID]);}
			 set{setProperty(_ORDER_ID, value);}
		}
		/// <summary>
		/// 收货人姓名(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 20Byte
		/// </para>
		/// </summary>
		public string Receiver
		{
			get{ return DataRow[_RECEIVER].ToString();}
			 set{setProperty(_RECEIVER, value);}
		}
		/// <summary>
		/// 联系电话(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 20Byte
		/// </para>
		/// </summary>
		public string Contract_Phone
		{
			get{ return DataRow[_CONTRACT_PHONE].ToString();}
			 set{setProperty(_CONTRACT_PHONE, value);}
		}
		/// <summary>
		/// 省份(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 20Byte
		/// </para>
		/// </summary>
		public string Province_Name
		{
			get{ return DataRow[_PROVINCE_NAME].ToString();}
			 set{setProperty(_PROVINCE_NAME, value);}
		}
		/// <summary>
		/// 城市(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 20Byte
		/// </para>
		/// </summary>
		public string City_Name
		{
			get{ return DataRow[_CITY_NAME].ToString();}
			 set{setProperty(_CITY_NAME, value);}
		}
		/// <summary>
		/// 城市市区(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 20Byte
		/// </para>
		/// </summary>
		public string Region_Name
		{
			get{ return DataRow[_REGION_NAME].ToString();}
			 set{setProperty(_REGION_NAME, value);}
		}
		/// <summary>
		/// 完整地址(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 400Byte
		/// </para>
		/// </summary>
		public string Full_Address
		{
			get{ return DataRow[_FULL_ADDRESS].ToString();}
			 set{setProperty(_FULL_ADDRESS, value);}
		}
		/// <summary>
		/// 发货状态(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Status
		{
			get{ return Convert.ToInt32(DataRow[_STATUS]);}
			 set{setProperty(_STATUS, value);}
		}
		/// <summary>
		/// 创建时间(必填)
		/// <para>
		/// defaultValue: DateTime.Now;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Createtime
		{
			get{ return Convert.ToDateTime(DataRow[_CREATETIME]);}
		}
		/// <summary>
		/// 发货快递名称(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 100Byte
		/// </para>
		/// </summary>
		public string Express_Name
		{
			get{ return DataRow[_EXPRESS_NAME].ToString();}
			 set{setProperty(_EXPRESS_NAME, value);}
		}
		/// <summary>
		/// 快递运单号(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 100Byte
		/// </para>
		/// </summary>
		public string Express_No
		{
			get{ return DataRow[_EXPRESS_NO].ToString();}
			 set{setProperty(_EXPRESS_NO, value);}
		}
		/// <summary>
		/// 确认收货[0：未确认，1：已确认](必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Confirm_Express
		{
			get{ return Convert.ToInt32(DataRow[_CONFIRM_EXPRESS]);}
			 set{setProperty(_CONFIRM_EXPRESS, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT ORDER_ID,RECEIVER,CONTRACT_PHONE,PROVINCE_NAME,CITY_NAME,REGION_NAME,FULL_ADDRESS,STATUS,CREATETIME,EXPRESS_NAME,EXPRESS_NO,CONFIRM_EXPRESS FROM TVIP_EXPRESS WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TVIP_EXPRESS WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int order_id)
		{
			string condition = " ORDER_ID=:ORDER_ID";
			AddParameter(_ORDER_ID,order_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " ORDER_ID=:ORDER_ID";
			AddParameter(_ORDER_ID,DataRow[_ORDER_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			string sql = @"INSERT INTO TVIP_EXPRESS(ORDER_ID,RECEIVER,CONTRACT_PHONE,PROVINCE_NAME,CITY_NAME,REGION_NAME,FULL_ADDRESS,STATUS,EXPRESS_NAME,EXPRESS_NO,CONFIRM_EXPRESS)
			VALUES (:ORDER_ID,:RECEIVER,:CONTRACT_PHONE,:PROVINCE_NAME,:CITY_NAME,:REGION_NAME,:FULL_ADDRESS,:STATUS,:EXPRESS_NAME,:EXPRESS_NO,:CONFIRM_EXPRESS)";
			AddParameter(_ORDER_ID,DataRow[_ORDER_ID]);
			AddParameter(_RECEIVER,DataRow[_RECEIVER]);
			AddParameter(_CONTRACT_PHONE,DataRow[_CONTRACT_PHONE]);
			AddParameter(_PROVINCE_NAME,DataRow[_PROVINCE_NAME]);
			AddParameter(_CITY_NAME,DataRow[_CITY_NAME]);
			AddParameter(_REGION_NAME,DataRow[_REGION_NAME]);
			AddParameter(_FULL_ADDRESS,DataRow[_FULL_ADDRESS]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_EXPRESS_NAME,DataRow[_EXPRESS_NAME]);
			AddParameter(_EXPRESS_NO,DataRow[_EXPRESS_NO]);
			AddParameter(_CONFIRM_EXPRESS,DataRow[_CONFIRM_EXPRESS]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tvip_ExpressCollection.Field,object> alterDic,Dictionary<Tvip_ExpressCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tvip_ExpressCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tvip_ExpressCollection.Field key in conditionDic.Keys)
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
            sql.AppendLine("UPDATE TVIP_EXPRESS SET");
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
		public bool SelectByPk(int order_id)
		{
			string condition = " ORDER_ID=:ORDER_ID";
			AddParameter(_ORDER_ID,order_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	
	public partial class Tvip_ExpressCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tvip_ExpressCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tvip_Express().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tvip_Express(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tvip_Express._TableName;}
		}
		public Tvip_Express this[int index]
        {
            get { return new Tvip_Express(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Order_Id=0,
			Receiver=1,
			Contract_Phone=2,
			Province_Name=3,
			City_Name=4,
			Region_Name=5,
			Full_Address=6,
			Status=7,
			Createtime=8,
			Express_Name=9,
			Express_No=10,
			Confirm_Express=11,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT ORDER_ID,RECEIVER,CONTRACT_PHONE,PROVINCE_NAME,CITY_NAME,REGION_NAME,FULL_ADDRESS,STATUS,CREATETIME,EXPRESS_NAME,EXPRESS_NO,CONFIRM_EXPRESS FROM TVIP_EXPRESS WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListByOrder_Id(int order_id)
		{
			string condition = "ORDER_ID=:ORDER_ID ORDER BY ORDER_ID DESC";
			AddParameter(Tvip_Express._ORDER_ID,order_id);
			return ListByCondition(condition);		
		}
		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tvip_Express Find(Predicate<Tvip_Express> match)
        {
            foreach (Tvip_Express item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tvip_ExpressCollection FindAll(Predicate<Tvip_Express> match)
        {
            Tvip_ExpressCollection list = new Tvip_ExpressCollection();
            foreach (Tvip_Express item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tvip_Express> match)
        {
            foreach (Tvip_Express item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tvip_Express> match)
        {
            BeginTransaction();
            foreach (Tvip_Express item in this)
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