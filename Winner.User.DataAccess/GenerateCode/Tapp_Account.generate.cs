   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tapp_Account.generate.cs
 * CreateTime : 2017-09-11 17:47:55
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
	public partial class Tapp_Account : DataAccessBase
	{
		#region 构造和基本
		public Tapp_Account():base()
		{}
		public Tapp_Account(DataRow dataRow):base(dataRow)
		{}
		public const string _ACCOUNT_ID = "ACCOUNT_ID";
		public const string _ACCOUNT_CODE = "ACCOUNT_CODE";
		public const string _SECRET_KEY = "SECRET_KEY";
		public const string _STATUS = "STATUS";
		public const string _USAGE_COUNT = "USAGE_COUNT";
		public const string _LIMITED_QUOTA = "LIMITED_QUOTA";
		public const string _REMARKS = "REMARKS";
		public const string _APP_ID = "APP_ID";
		public const string _TableName = "TAPP_ACCOUNT";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TAPP_ACCOUNT");
			table.Columns.Add(_ACCOUNT_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_ACCOUNT_CODE,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_SECRET_KEY,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_STATUS,typeof(int)).DefaultValue=1;
			table.Columns.Add(_USAGE_COUNT,typeof(int)).DefaultValue=0;
			table.Columns.Add(_LIMITED_QUOTA,typeof(int)).DefaultValue=0;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_APP_ID,typeof(int)).DefaultValue=0;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Account_Id
		{
			get{ return Convert.ToInt32(DataRow[_ACCOUNT_ID]);}
			 set{setProperty(_ACCOUNT_ID, value);}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 20Byte
		/// </para>
		/// </summary>
		public string Account_Code
		{
			get{ return DataRow[_ACCOUNT_CODE].ToString();}
			 set{setProperty(_ACCOUNT_CODE, value);}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 500Byte
		/// </para>
		/// </summary>
		public string Secret_Key
		{
			get{ return DataRow[_SECRET_KEY].ToString();}
			 set{setProperty(_SECRET_KEY, value);}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: 1;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Status
		{
			get{ return Convert.ToInt32(DataRow[_STATUS]);}
			 set{setProperty(_STATUS, value);}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Usage_Count
		{
			get{ return Convert.ToInt32(DataRow[_USAGE_COUNT]);}
			 set{setProperty(_USAGE_COUNT, value);}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Limited_Quota
		{
			get{ return Convert.ToInt32(DataRow[_LIMITED_QUOTA]);}
			 set{setProperty(_LIMITED_QUOTA, value);}
		}
		/// <summary>
		/// (可空)
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
		/// (必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int App_Id
		{
			get{ return Convert.ToInt32(DataRow[_APP_ID]);}
			 set{setProperty(_APP_ID, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT ACCOUNT_ID,ACCOUNT_CODE,SECRET_KEY,STATUS,USAGE_COUNT,LIMITED_QUOTA,REMARKS,APP_ID FROM TAPP_ACCOUNT WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TAPP_ACCOUNT WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int account_id)
		{
			string condition = " ACCOUNT_ID=:ACCOUNT_ID";
			AddParameter(_ACCOUNT_ID,account_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " ACCOUNT_ID=:ACCOUNT_ID";
			AddParameter(_ACCOUNT_ID,DataRow[_ACCOUNT_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Account_Id = GetSequence("SELECT SEQ_TAPP_ACCOUNT.nextval FROM DUAL");
			string sql = @"INSERT INTO TAPP_ACCOUNT(ACCOUNT_ID,ACCOUNT_CODE,SECRET_KEY,STATUS,USAGE_COUNT,LIMITED_QUOTA,REMARKS,APP_ID)
			VALUES (:ACCOUNT_ID,:ACCOUNT_CODE,:SECRET_KEY,:STATUS,:USAGE_COUNT,:LIMITED_QUOTA,:REMARKS,:APP_ID)";
			AddParameter(_ACCOUNT_ID,DataRow[_ACCOUNT_ID]);
			AddParameter(_ACCOUNT_CODE,DataRow[_ACCOUNT_CODE]);
			AddParameter(_SECRET_KEY,DataRow[_SECRET_KEY]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_USAGE_COUNT,DataRow[_USAGE_COUNT]);
			AddParameter(_LIMITED_QUOTA,DataRow[_LIMITED_QUOTA]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_APP_ID,DataRow[_APP_ID]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tapp_AccountCollection.Field,object> alterDic,Dictionary<Tapp_AccountCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tapp_AccountCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tapp_AccountCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_ACCOUNT_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TAPP_ACCOUNT SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE ACCOUNT_ID=:ACCOUNT_ID");
			AddParameter(_ACCOUNT_ID, DataRow[_ACCOUNT_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int account_id)
		{
			string condition = " ACCOUNT_ID=:ACCOUNT_ID";
			AddParameter(_ACCOUNT_ID,account_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	
	public partial class Tapp_AccountCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tapp_AccountCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tapp_Account().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tapp_Account(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tapp_Account._TableName;}
		}
		public Tapp_Account this[int index]
        {
            get { return new Tapp_Account(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Account_Id=0,
			Account_Code=1,
			Secret_Key=2,
			Status=3,
			Usage_Count=4,
			Limited_Quota=5,
			Remarks=6,
			App_Id=7,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT ACCOUNT_ID,ACCOUNT_CODE,SECRET_KEY,STATUS,USAGE_COUNT,LIMITED_QUOTA,REMARKS,APP_ID FROM TAPP_ACCOUNT WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListByApp_Id(int app_id)
		{
			string condition = "APP_ID=:APP_ID ORDER BY ACCOUNT_ID DESC";
			AddParameter(Tapp_Account._APP_ID,app_id);
			return ListByCondition(condition);		
		}
		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tapp_Account Find(Predicate<Tapp_Account> match)
        {
            foreach (Tapp_Account item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tapp_AccountCollection FindAll(Predicate<Tapp_Account> match)
        {
            Tapp_AccountCollection list = new Tapp_AccountCollection();
            foreach (Tapp_Account item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tapp_Account> match)
        {
            foreach (Tapp_Account item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tapp_Account> match)
        {
            BeginTransaction();
            foreach (Tapp_Account item in this)
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