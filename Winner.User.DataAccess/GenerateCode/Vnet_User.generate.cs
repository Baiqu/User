   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Vnet_User.generate.cs
 * CreateTime : 2017-07-25 13:46:26
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
	/// 
	/// </summary>
	public partial class Vnet_User : DataAccessBase
	{
		#region 构造和基本
		public Vnet_User():base()
		{}
		public Vnet_User(DataRow dataRow):base(dataRow)
		{}
		public const string _USER_ID = "USER_ID";
		public const string _USER_CODE = "USER_CODE";
		public const string _USER_NICKNAME = "USER_NICKNAME";
		public const string _USER_NAME = "USER_NAME";
		public const string _FATHER_ID = "FATHER_ID";
		public const string _USER_STATUS = "USER_STATUS";
		public const string _USER_LEVEL = "USER_LEVEL";
		public const string _E_MAIL = "E_MAIL";
		public const string _MOBILE_NO = "MOBILE_NO";
		public const string _AUTH_STATUS = "AUTH_STATUS";
		public const string _AUTH_TIME = "AUTH_TIME";
		public const string _PHOTO_URL = "PHOTO_URL";
		public const string _DATA_SOURCE = "DATA_SOURCE";
		public const string _REMARKS = "REMARKS";
		public const string _CREATE_TIME = "CREATE_TIME";
		public const string _IS_LOCKED = "IS_LOCKED";
		public const string _AUTO_UNLOCK_TIME = "AUTO_UNLOCK_TIME";
		public const string _LOCK_MINUTES = "LOCK_MINUTES";
		public const string _TableName = "VNET_USER";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("VNET_USER");
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_CODE,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_USER_NICKNAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_USER_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_FATHER_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_USER_STATUS,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_LEVEL,typeof(int)).DefaultValue=0;
			table.Columns.Add(_E_MAIL,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_MOBILE_NO,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_AUTH_STATUS,typeof(int)).DefaultValue=0;
			table.Columns.Add(_AUTH_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_PHOTO_URL,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_DATA_SOURCE,typeof(int)).DefaultValue=0;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CREATE_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_IS_LOCKED,typeof(decimal)).DefaultValue=DBNull.Value;
			table.Columns.Add(_AUTO_UNLOCK_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_LOCK_MINUTES,typeof(decimal)).DefaultValue=DBNull.Value;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 用户编号(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int User_Id
		{
			get{ return Convert.ToInt32(DataRow[_USER_ID]);}
			 set{setProperty(_USER_ID, value);}
		}
		/// <summary>
		/// 用户账号(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 40Byte
		/// </para>
		/// </summary>
		public string User_Code
		{
			get{ return DataRow[_USER_CODE].ToString();}
			 set{setProperty(_USER_CODE, value);}
		}
		/// <summary>
		/// 用户昵称(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 100Byte
		/// </para>
		/// </summary>
		public string User_Nickname
		{
			get{ return DataRow[_USER_NICKNAME].ToString();}
			 set{setProperty(_USER_NICKNAME, value);}
		}
		/// <summary>
		/// 用户姓名(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 100Byte
		/// </para>
		/// </summary>
		public string User_Name
		{
			get{ return DataRow[_USER_NAME].ToString();}
			 set{setProperty(_USER_NAME, value);}
		}
		/// <summary>
		/// 推荐人用户编号(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 22Byte
		/// </para>
		/// </summary>
		public int? Father_Id
		{
			get{ return Helper.ToInt32(DataRow[_FATHER_ID]);}
			 set{setProperty(_FATHER_ID, value);}
		}
		/// <summary>
		/// 用户状态$UserStatus$,未激活=0,已激活=1,已注销=2,已封锁=3(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int User_Status
		{
			get{ return Convert.ToInt32(DataRow[_USER_STATUS]);}
			 set{setProperty(_USER_STATUS, value);}
		}
		/// <summary>
		/// 用户级别(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int User_Level
		{
			get{ return Convert.ToInt32(DataRow[_USER_LEVEL]);}
			 set{setProperty(_USER_LEVEL, value);}
		}
		/// <summary>
		/// E-Mail(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 40Byte
		/// </para>
		/// </summary>
		public string E_Mail
		{
			get{ return DataRow[_E_MAIL].ToString();}
			 set{setProperty(_E_MAIL, value);}
		}
		/// <summary>
		/// 手机号码(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 20Byte
		/// </para>
		/// </summary>
		public string Mobile_No
		{
			get{ return DataRow[_MOBILE_NO].ToString();}
			 set{setProperty(_MOBILE_NO, value);}
		}
		/// <summary>
		/// 实名认证状态$AuthStatus${未实名=0,审核中=1,实名认证=2}(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Auth_Status
		{
			get{ return Convert.ToInt32(DataRow[_AUTH_STATUS]);}
			 set{setProperty(_AUTH_STATUS, value);}
		}
		/// <summary>
		/// 实名验证时间(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? Auth_Time
		{
			get{ return Helper.ToDateTime(DataRow[_AUTH_TIME]);}
			 set{setProperty(_AUTH_TIME, value);}
		}
		/// <summary>
		/// 用户头像(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 200Byte
		/// </para>
		/// </summary>
		public string Photo_Url
		{
			get{ return DataRow[_PHOTO_URL].ToString();}
			 set{setProperty(_PHOTO_URL, value);}
		}
		/// <summary>
		/// 数据来源(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Data_Source
		{
			get{ return Convert.ToInt32(DataRow[_DATA_SOURCE]);}
			 set{setProperty(_DATA_SOURCE, value);}
		}
		/// <summary>
		/// 备注信息(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 400Byte
		/// </para>
		/// </summary>
		public string Remarks
		{
			get{ return DataRow[_REMARKS].ToString();}
			 set{setProperty(_REMARKS, value);}
		}
		/// <summary>
		/// 录入时间(必填)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Create_Time
		{
			get{ return Convert.ToDateTime(DataRow[_CREATE_TIME]);}
			 set{setProperty(_CREATE_TIME, value);}
		}
		/// <summary>
		/// (可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 22Byte
		/// </para>
		/// </summary>
		public decimal? Is_Locked
		{
			get{ return Helper.ToDecimal(DataRow[_IS_LOCKED]);}
			 set{setProperty(_IS_LOCKED, value);}
		}
		/// <summary>
		/// (可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? Auto_Unlock_Time
		{
			get{ return Helper.ToDateTime(DataRow[_AUTO_UNLOCK_TIME]);}
			 set{setProperty(_AUTO_UNLOCK_TIME, value);}
		}
		/// <summary>
		/// (可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 22Byte
		/// </para>
		/// </summary>
		public decimal? Lock_Minutes
		{
			get{ return Helper.ToDecimal(DataRow[_LOCK_MINUTES]);}
			 set{setProperty(_LOCK_MINUTES, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT USER_ID,USER_CODE,USER_NICKNAME,USER_NAME,FATHER_ID,USER_STATUS,USER_LEVEL,E_MAIL,MOBILE_NO,AUTH_STATUS,AUTH_TIME,PHOTO_URL,DATA_SOURCE,REMARKS,CREATE_TIME,IS_LOCKED,AUTO_UNLOCK_TIME,LOCK_MINUTES FROM VNET_USER WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM VNET_USER WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		#endregion
	}
	
	public partial class Vnet_UserCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Vnet_UserCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Vnet_User().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Vnet_User(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Vnet_User._TableName;}
		}
		public Vnet_User this[int index]
        {
            get { return new Vnet_User(DataTable.Rows[index]); }
        }
		public enum Field
        {
			User_Id=0,
			User_Code=1,
			User_Nickname=2,
			User_Name=3,
			Father_Id=4,
			User_Status=5,
			User_Level=6,
			E_Mail=7,
			Mobile_No=8,
			Auth_Status=9,
			Auth_Time=10,
			Photo_Url=11,
			Data_Source=12,
			Remarks=13,
			Create_Time=14,
			Is_Locked=15,
			Auto_Unlock_Time=16,
			Lock_Minutes=17,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT USER_ID,USER_CODE,USER_NICKNAME,USER_NAME,FATHER_ID,USER_STATUS,USER_LEVEL,E_MAIL,MOBILE_NO,AUTH_STATUS,AUTH_TIME,PHOTO_URL,DATA_SOURCE,REMARKS,CREATE_TIME,IS_LOCKED,AUTO_UNLOCK_TIME,LOCK_MINUTES FROM VNET_USER WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Vnet_User Find(Predicate<Vnet_User> match)
        {
            foreach (Vnet_User item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Vnet_UserCollection FindAll(Predicate<Vnet_User> match)
        {
            Vnet_UserCollection list = new Vnet_UserCollection();
            foreach (Vnet_User item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Vnet_User> match)
        {
            foreach (Vnet_User item in this)
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