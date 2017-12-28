   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Vnet_Identity.generate.cs
 * CreateTime : 2017-05-03 15:57:56
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
	/// 会员实名身份信息
	/// </summary>
	public partial class Vnet_Identity : DataAccessBase
	{
		#region 构造和基本
		public Vnet_Identity():base()
		{}
		public Vnet_Identity(DataRow dataRow):base(dataRow)
		{}
		public const string _DOCS_ID = "DOCS_ID";
		public const string _USER_ID = "USER_ID";
		public const string _DOCS_TYPE = "DOCS_TYPE";
		public const string _VALIDATE_STATUS = "VALIDATE_STATUS";
		public const string _USER_NAME = "USER_NAME";
		public const string _IDENTITY_NO = "IDENTITY_NO";
		public const string _BIRTHDAY = "BIRTHDAY";
		public const string _GENDER = "GENDER";
		public const string _BEGIN_TIME = "BEGIN_TIME";
		public const string _END_TIME = "END_TIME";
		public const string _ISSUING = "ISSUING";
		public const string _REGION_ID = "REGION_ID";
		public const string _ADDRESS = "ADDRESS";
		public const string _FRONT_PHOTO = "FRONT_PHOTO";
		public const string _BACK_PHOTO = "BACK_PHOTO";
		public const string _SCENE_PHOTO = "SCENE_PHOTO";
		public const string _CREATE_TIME = "CREATE_TIME";
		public const string _DOC_STATUS = "DOC_STATUS";
		public const string _REMARKS = "REMARKS";
		public const string _TableName = "VNET_IDENTITY";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("VNET_IDENTITY");
			table.Columns.Add(_DOCS_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_DOCS_TYPE,typeof(int)).DefaultValue=0;
			table.Columns.Add(_VALIDATE_STATUS,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_IDENTITY_NO,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_BIRTHDAY,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_GENDER,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_BEGIN_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_END_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_ISSUING,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_REGION_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_ADDRESS,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_FRONT_PHOTO,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_BACK_PHOTO,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_SCENE_PHOTO,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CREATE_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_DOC_STATUS,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=DBNull.Value;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 认证信息ID
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int Docs_Id
		{
			get{ return Convert.ToInt32(DataRow[_DOCS_ID]);}
			 set{setProperty(_DOCS_ID, value);}
		}
		/// <summary>
		/// 会员ID
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int User_Id
		{
			get{ return Convert.ToInt32(DataRow[_USER_ID]);}
			 set{setProperty(_USER_ID, value);}
		}
		/// <summary>
		/// 证件类型
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int Docs_Type
		{
			get{ return Convert.ToInt32(DataRow[_DOCS_TYPE]);}
			 set{setProperty(_DOCS_TYPE, value);}
		}
		/// <summary>
		/// 审核状态[1：审核中，2：审核通过，4：审核不通过]
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int Validate_Status
		{
			get{ return Convert.ToInt32(DataRow[_VALIDATE_STATUS]);}
			 set{setProperty(_VALIDATE_STATUS, value);}
		}
		/// <summary>
		/// 真实姓名
		/// <para>
		/// defaultValue:    Length: 20Byte
		/// </para>
		/// </summary>
		public string User_Name
		{
			get{ return DataRow[_USER_NAME].ToString();}
			 set{setProperty(_USER_NAME, value);}
		}
		/// <summary>
		/// 证件号码
		/// <para>
		/// defaultValue:    Length: 20Byte
		/// </para>
		/// </summary>
		public string Identity_No
		{
			get{ return DataRow[_IDENTITY_NO].ToString();}
			 set{setProperty(_IDENTITY_NO, value);}
		}
		/// <summary>
		/// 出生日期
		/// <para>
		/// defaultValue:    Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? Birthday
		{
			get{ return Helper.ToDateTime(DataRow[_BIRTHDAY]);}
			 set{setProperty(_BIRTHDAY, value);}
		}
		/// <summary>
		/// 性别
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int? Gender
		{
			get{ return Helper.ToInt32(DataRow[_GENDER]);}
			 set{setProperty(_GENDER, value);}
		}
		/// <summary>
		/// 证件有效起始日期
		/// <para>
		/// defaultValue:    Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? Begin_Time
		{
			get{ return Helper.ToDateTime(DataRow[_BEGIN_TIME]);}
			 set{setProperty(_BEGIN_TIME, value);}
		}
		/// <summary>
		/// 证件有效截止日期
		/// <para>
		/// defaultValue:    Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? End_Time
		{
			get{ return Helper.ToDateTime(DataRow[_END_TIME]);}
			 set{setProperty(_END_TIME, value);}
		}
		/// <summary>
		/// 发证机关
		/// <para>
		/// defaultValue:    Length: 400Byte
		/// </para>
		/// </summary>
		public string Issuing
		{
			get{ return DataRow[_ISSUING].ToString();}
			 set{setProperty(_ISSUING, value);}
		}
		/// <summary>
		/// 城市市区ID
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int? Region_Id
		{
			get{ return Helper.ToInt32(DataRow[_REGION_ID]);}
			 set{setProperty(_REGION_ID, value);}
		}
		/// <summary>
		/// 详细地址
		/// <para>
		/// defaultValue:    Length: 400Byte
		/// </para>
		/// </summary>
		public string Address
		{
			get{ return DataRow[_ADDRESS].ToString();}
			 set{setProperty(_ADDRESS, value);}
		}
		/// <summary>
		/// 证件正面照片
		/// <para>
		/// defaultValue:    Length: 200Byte
		/// </para>
		/// </summary>
		public string Front_Photo
		{
			get{ return DataRow[_FRONT_PHOTO].ToString();}
			 set{setProperty(_FRONT_PHOTO, value);}
		}
		/// <summary>
		/// 证件背面照片
		/// <para>
		/// defaultValue:    Length: 200Byte
		/// </para>
		/// </summary>
		public string Back_Photo
		{
			get{ return DataRow[_BACK_PHOTO].ToString();}
			 set{setProperty(_BACK_PHOTO, value);}
		}
		/// <summary>
		/// 手持证件照片
		/// <para>
		/// defaultValue:    Length: 200Byte
		/// </para>
		/// </summary>
		public string Scene_Photo
		{
			get{ return DataRow[_SCENE_PHOTO].ToString();}
			 set{setProperty(_SCENE_PHOTO, value);}
		}
		/// <summary>
		/// 认证时间
		/// <para>
		/// defaultValue:    Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? Create_Time
		{
			get{ return Helper.ToDateTime(DataRow[_CREATE_TIME]);}
			 set{setProperty(_CREATE_TIME, value);}
		}
		/// <summary>
		/// 证件状态
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int? Doc_Status
		{
			get{ return Helper.ToInt32(DataRow[_DOC_STATUS]);}
			 set{setProperty(_DOC_STATUS, value);}
		}
		/// <summary>
		/// 审核备注
		/// <para>
		/// defaultValue:    Length: 400Byte
		/// </para>
		/// </summary>
		public string Remarks
		{
			get{ return DataRow[_REMARKS].ToString();}
			 set{setProperty(_REMARKS, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT DOCS_ID,USER_ID,DOCS_TYPE,VALIDATE_STATUS,USER_NAME,IDENTITY_NO,BIRTHDAY,GENDER,BEGIN_TIME,END_TIME,ISSUING,REGION_ID,ADDRESS,FRONT_PHOTO,BACK_PHOTO,SCENE_PHOTO,CREATE_TIME,DOC_STATUS,REMARKS FROM VNET_IDENTITY WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM VNET_IDENTITY WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		#endregion
	}
	
	public partial class Vnet_IdentityCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Vnet_IdentityCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Vnet_Identity().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Vnet_Identity(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Vnet_Identity._TableName;}
		}
		public Vnet_Identity this[int index]
        {
            get { return new Vnet_Identity(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Docs_Id=0,
			User_Id=1,
			Docs_Type=2,
			Validate_Status=3,
			User_Name=4,
			Identity_No=5,
			Birthday=6,
			Gender=7,
			Begin_Time=8,
			End_Time=9,
			Issuing=10,
			Region_Id=11,
			Address=12,
			Front_Photo=13,
			Back_Photo=14,
			Scene_Photo=15,
			Create_Time=16,
			Doc_Status=17,
			Remarks=18,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT DOCS_ID,USER_ID,DOCS_TYPE,VALIDATE_STATUS,USER_NAME,IDENTITY_NO,BIRTHDAY,GENDER,BEGIN_TIME,END_TIME,ISSUING,REGION_ID,ADDRESS,FRONT_PHOTO,BACK_PHOTO,SCENE_PHOTO,CREATE_TIME,DOC_STATUS,REMARKS FROM VNET_IDENTITY WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Vnet_Identity Find(Predicate<Vnet_Identity> match)
        {
            foreach (Vnet_Identity item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Vnet_IdentityCollection FindAll(Predicate<Vnet_Identity> match)
        {
            Vnet_IdentityCollection list = new Vnet_IdentityCollection();
            foreach (Vnet_Identity item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Vnet_Identity> match)
        {
            foreach (Vnet_Identity item in this)
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