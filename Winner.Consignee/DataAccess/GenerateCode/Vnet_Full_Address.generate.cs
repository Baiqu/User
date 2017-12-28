   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Vnet_Full_Address.generate.cs
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
	/// 收货地址详细信息视图
	/// </summary>
	public partial class Vnet_Full_Address : DataAccessBase
	{
		#region 构造和基本
		public Vnet_Full_Address():base()
		{}
		public Vnet_Full_Address(DataRow dataRow):base(dataRow)
		{}
		public const string _ADDRESS_ID = "ADDRESS_ID";
		public const string _OWNER_ID = "OWNER_ID";
		public const string _OWNER_TYPE = "OWNER_TYPE";
		public const string _CONSIGNEE_NAME = "CONSIGNEE_NAME";
		public const string _MOBILE_NO = "MOBILE_NO";
		public const string _POST_CODE = "POST_CODE";
		public const string _ADDRESS = "ADDRESS";
		public const string _REGION_ID = "REGION_ID";
		public const string _REGION_NAME = "REGION_NAME";
		public const string _CITY_ID = "CITY_ID";
		public const string _CITY_NAME = "CITY_NAME";
		public const string _PROVINCE_ID = "PROVINCE_ID";
		public const string _PROVINCE_NAME = "PROVINCE_NAME";
		public const string _IS_DEFAULT = "IS_DEFAULT";
		public const string _TAG_NAME = "TAG_NAME";
		public const string _IS_DEL = "IS_DEL";
		public const string _CREATE_TIME = "CREATE_TIME";
		public const string _TableName = "VNET_FULL_ADDRESS";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("VNET_FULL_ADDRESS");
			table.Columns.Add(_ADDRESS_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_OWNER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_OWNER_TYPE,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CONSIGNEE_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_MOBILE_NO,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_POST_CODE,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_ADDRESS,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_REGION_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_REGION_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CITY_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CITY_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_PROVINCE_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_PROVINCE_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_IS_DEFAULT,typeof(int)).DefaultValue=0;
			table.Columns.Add(_TAG_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_IS_DEL,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CREATE_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 收货地址ID(必填)
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
		/// 收件人姓名(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 60Byte
		/// </para>
		/// </summary>
		public string Consignee_Name
		{
			get{ return DataRow[_CONSIGNEE_NAME].ToString();}
			 set{setProperty(_CONSIGNEE_NAME, value);}
		}
		/// <summary>
		/// 收件人电话(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 40Byte
		/// </para>
		/// </summary>
		public string Mobile_No
		{
			get{ return DataRow[_MOBILE_NO].ToString();}
			 set{setProperty(_MOBILE_NO, value);}
		}
		/// <summary>
		/// 邮政编码(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 12Byte
		/// </para>
		/// </summary>
		public string Post_Code
		{
			get{ return DataRow[_POST_CODE].ToString();}
			 set{setProperty(_POST_CODE, value);}
		}
		/// <summary>
		/// 详细地址(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 400Byte
		/// </para>
		/// </summary>
		public string Address
		{
			get{ return DataRow[_ADDRESS].ToString();}
			 set{setProperty(_ADDRESS, value);}
		}
		/// <summary>
		/// 城市市区ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Region_Id
		{
			get{ return Convert.ToInt32(DataRow[_REGION_ID]);}
			 set{setProperty(_REGION_ID, value);}
		}
		/// <summary>
		/// 城市市区名称(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 50Byte
		/// </para>
		/// </summary>
		public string Region_Name
		{
			get{ return DataRow[_REGION_NAME].ToString();}
			 set{setProperty(_REGION_NAME, value);}
		}
		/// <summary>
		/// 城市ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int City_Id
		{
			get{ return Convert.ToInt32(DataRow[_CITY_ID]);}
			 set{setProperty(_CITY_ID, value);}
		}
		/// <summary>
		/// 城市名称(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 50Byte
		/// </para>
		/// </summary>
		public string City_Name
		{
			get{ return DataRow[_CITY_NAME].ToString();}
			 set{setProperty(_CITY_NAME, value);}
		}
		/// <summary>
		/// 省份ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Province_Id
		{
			get{ return Convert.ToInt32(DataRow[_PROVINCE_ID]);}
			 set{setProperty(_PROVINCE_ID, value);}
		}
		/// <summary>
		/// 省份名称(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 50Byte
		/// </para>
		/// </summary>
		public string Province_Name
		{
			get{ return DataRow[_PROVINCE_NAME].ToString();}
			 set{setProperty(_PROVINCE_NAME, value);}
		}
		/// <summary>
		/// 是否默认收货地址(必填)
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
		/// 收货地址标签(可空)
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
		/// 是否已删除(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Is_Del
		{
			get{ return Convert.ToInt32(DataRow[_IS_DEL]);}
			 set{setProperty(_IS_DEL, value);}
		}
		/// <summary>
		/// 创建时间(必填)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Create_Time
		{
			get{ return Convert.ToDateTime(DataRow[_CREATE_TIME]);}
			 set{setProperty(_CREATE_TIME, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT ADDRESS_ID,OWNER_ID,OWNER_TYPE,CONSIGNEE_NAME,MOBILE_NO,POST_CODE,ADDRESS,REGION_ID,REGION_NAME,CITY_ID,CITY_NAME,PROVINCE_ID,PROVINCE_NAME,IS_DEFAULT,TAG_NAME,IS_DEL,CREATE_TIME FROM VNET_FULL_ADDRESS WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM VNET_FULL_ADDRESS WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		#endregion
	}
	/// <summary>
	/// 收货地址详细信息视图[集合对象]
	/// </summary>
	public partial class Vnet_Full_AddressCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Vnet_Full_AddressCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Vnet_Full_Address().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Vnet_Full_Address(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Vnet_Full_Address._TableName;}
		}
		public Vnet_Full_Address this[int index]
        {
            get { return new Vnet_Full_Address(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Address_Id=0,
			Owner_Id=1,
			Owner_Type=2,
			Consignee_Name=3,
			Mobile_No=4,
			Post_Code=5,
			Address=6,
			Region_Id=7,
			Region_Name=8,
			City_Id=9,
			City_Name=10,
			Province_Id=11,
			Province_Name=12,
			Is_Default=13,
			Tag_Name=14,
			Is_Del=15,
			Create_Time=16,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT ADDRESS_ID,OWNER_ID,OWNER_TYPE,CONSIGNEE_NAME,MOBILE_NO,POST_CODE,ADDRESS,REGION_ID,REGION_NAME,CITY_ID,CITY_NAME,PROVINCE_ID,PROVINCE_NAME,IS_DEFAULT,TAG_NAME,IS_DEL,CREATE_TIME FROM VNET_FULL_ADDRESS WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Vnet_Full_Address Find(Predicate<Vnet_Full_Address> match)
        {
            foreach (Vnet_Full_Address item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Vnet_Full_AddressCollection FindAll(Predicate<Vnet_Full_Address> match)
        {
            Vnet_Full_AddressCollection list = new Vnet_Full_AddressCollection();
            foreach (Vnet_Full_Address item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Vnet_Full_Address> match)
        {
            foreach (Vnet_Full_Address item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		#endregion
		#endregion		
	}
}