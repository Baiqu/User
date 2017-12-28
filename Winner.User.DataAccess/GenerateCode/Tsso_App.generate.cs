   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tsso_App.generate.cs
 * CreateTime : 2017-05-12 17:26:22
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
	/// 
	/// </summary>
	public partial class Tsso_App : DataAccessBase
	{
		#region 构造和基本
		public Tsso_App():base()
		{}
		public Tsso_App(DataRow dataRow):base(dataRow)
		{}
		public const string _APP_ID = "APP_ID";
		public const string _APP_NAME = "APP_NAME";
		public const string _DEFAULT_URL = "DEFAULT_URL";
		public const string _LOGOUT_URL = "LOGOUT_URL";
		public const string _PRIVATE_KEY = "PRIVATE_KEY";
		public const string _STATUS = "STATUS";
		public const string _REMARKS = "REMARKS";
		public const string _CREATE_TIME = "CREATE_TIME";
		public const string _TableName = "TSSO_APP";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TSSO_APP");
			table.Columns.Add(_APP_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_APP_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_DEFAULT_URL,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_LOGOUT_URL,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_PRIVATE_KEY,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_STATUS,typeof(int)).DefaultValue=1;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CREATE_TIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 应用网站ID(必填)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int App_Id
		{
			get{ return Convert.ToInt32(DataRow[_APP_ID]);}
			 set{setProperty(_APP_ID, value);}
		}
		/// <summary>
		/// 网站名称(必填)
		/// <para>
		/// defaultValue:    Length: 100Byte
		/// </para>
		/// </summary>
		public string App_Name
		{
			get{ return DataRow[_APP_NAME].ToString();}
			 set{setProperty(_APP_NAME, value);}
		}
		/// <summary>
		/// 网站默认地址(必填)
		/// <para>
		/// defaultValue:    Length: 200Byte
		/// </para>
		/// </summary>
		public string Default_Url
		{
			get{ return DataRow[_DEFAULT_URL].ToString();}
			 set{setProperty(_DEFAULT_URL, value);}
		}
		/// <summary>
		/// 网站退出地址(必填)
		/// <para>
		/// defaultValue:    Length: 200Byte
		/// </para>
		/// </summary>
		public string Logout_Url
		{
			get{ return DataRow[_LOGOUT_URL].ToString();}
			 set{setProperty(_LOGOUT_URL, value);}
		}
		/// <summary>
		/// 网站私钥(单点登录中心验证使用)(必填)
		/// <para>
		/// defaultValue:    Length: 2400Byte
		/// </para>
		/// </summary>
		public string Private_Key
		{
			get{ return DataRow[_PRIVATE_KEY].ToString();}
			 set{setProperty(_PRIVATE_KEY, value);}
		}
		/// <summary>
		/// 状态$AppStatus${禁止登陆=0,正常登陆=1}(必填)
		/// <para>
		/// defaultValue: 1    Length: 22Byte
		/// </para>
		/// </summary>
		public int Status
		{
			get{ return Convert.ToInt32(DataRow[_STATUS]);}
			 set{setProperty(_STATUS, value);}
		}
		/// <summary>
		/// 备注(可空)
		/// <para>
		/// defaultValue:    Length: 200Byte
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
		/// defaultValue: sysdate    Length: 7Byte
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
			string sql = "SELECT APP_ID,APP_NAME,DEFAULT_URL,LOGOUT_URL,PRIVATE_KEY,STATUS,REMARKS,CREATE_TIME FROM TSSO_APP WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TSSO_APP WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int app_id)
		{
			string condition = " APP_ID=:APP_ID";
			AddParameter(_APP_ID,app_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " APP_ID=:APP_ID";
			AddParameter(_APP_ID,DataRow[_APP_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.App_Id = GetSequence("SELECT SEQ_TSSO_APP.nextval FROM DUAL");
			string sql = @"INSERT INTO TSSO_APP(APP_ID,APP_NAME,DEFAULT_URL,LOGOUT_URL,PRIVATE_KEY,STATUS,REMARKS)
			VALUES (:APP_ID,:APP_NAME,:DEFAULT_URL,:LOGOUT_URL,:PRIVATE_KEY,:STATUS,:REMARKS)";
			AddParameter(_APP_ID,DataRow[_APP_ID]);
			AddParameter(_APP_NAME,DataRow[_APP_NAME]);
			AddParameter(_DEFAULT_URL,DataRow[_DEFAULT_URL]);
			AddParameter(_LOGOUT_URL,DataRow[_LOGOUT_URL]);
			AddParameter(_PRIVATE_KEY,DataRow[_PRIVATE_KEY]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tsso_AppCollection.Field,object> alterDic,Dictionary<Tsso_AppCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tsso_AppCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tsso_AppCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_APP_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TSSO_APP SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE APP_ID=:APP_ID");
			AddParameter(_APP_ID, DataRow[_APP_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByApp_Name(string app_name)
		{
			string condition = " APP_NAME=:APP_NAME";
			AddParameter(_APP_NAME,app_name);
			return SelectByCondition(condition);
		}
		public bool SelectByPk(int app_id)
		{
			string condition = " APP_ID=:APP_ID";
			AddParameter(_APP_ID,app_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	
	public partial class Tsso_AppCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tsso_AppCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tsso_App().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tsso_App(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tsso_App._TableName;}
		}
		public Tsso_App this[int index]
        {
            get { return new Tsso_App(DataTable.Rows[index]); }
        }
		public enum Field
        {
			App_Id=0,
			App_Name=1,
			Default_Url=2,
			Logout_Url=3,
			Private_Key=4,
			Status=5,
			Remarks=6,
			Create_Time=7,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT APP_ID,APP_NAME,DEFAULT_URL,LOGOUT_URL,PRIVATE_KEY,STATUS,REMARKS,CREATE_TIME FROM TSSO_APP WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tsso_App Find(Predicate<Tsso_App> match)
        {
            foreach (Tsso_App item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tsso_AppCollection FindAll(Predicate<Tsso_App> match)
        {
            Tsso_AppCollection list = new Tsso_AppCollection();
            foreach (Tsso_App item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tsso_App> match)
        {
            foreach (Tsso_App item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tsso_App> match)
        {
            BeginTransaction();
            foreach (Tsso_App item in this)
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