   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_User_Role.generate.cs
 * CreateTime : 2017-10-30 11:06:13
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
	public partial class Tnet_User_Role : DataAccessBase
	{
		#region 构造和基本
		public Tnet_User_Role():base()
		{}
		public Tnet_User_Role(DataRow dataRow):base(dataRow)
		{}
		public const string _HISID = "HISID";
		public const string _USER_ID = "USER_ID";
		public const string _EXPIRE_TIME = "EXPIRE_TIME";
		public const string _USER_LEVEL = "USER_LEVEL";
		public const string _ROLE_NAME = "ROLE_NAME";
		public const string _LAST_MODIFY_TIME = "LAST_MODIFY_TIME";
		public const string _TableName = "TNET_USER_ROLE";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_USER_ROLE");
			table.Columns.Add(_HISID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_EXPIRE_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_USER_LEVEL,typeof(int)).DefaultValue=0;
			table.Columns.Add(_ROLE_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_LAST_MODIFY_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
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
		public int Hisid
		{
			get{ return Convert.ToInt32(DataRow[_HISID]);}
			 set{setProperty(_HISID, value);}
		}
		/// <summary>
		/// (必填)
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
		/// (必填)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Expire_Time
		{
			get{ return Convert.ToDateTime(DataRow[_EXPIRE_TIME]);}
			 set{setProperty(_EXPIRE_TIME, value);}
		}
		/// <summary>
		/// (必填)
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
		/// (可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 20Byte
		/// </para>
		/// </summary>
		public string Role_Name
		{
			get{ return DataRow[_ROLE_NAME].ToString();}
			 set{setProperty(_ROLE_NAME, value);}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Last_Modify_Time
		{
			get{ return Convert.ToDateTime(DataRow[_LAST_MODIFY_TIME]);}
			 set{setProperty(_LAST_MODIFY_TIME, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT HISID,USER_ID,EXPIRE_TIME,USER_LEVEL,ROLE_NAME,LAST_MODIFY_TIME FROM TNET_USER_ROLE WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_USER_ROLE WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int hisid)
		{
			string condition = " HISID=:HISID";
			AddParameter(_HISID,hisid);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " HISID=:HISID";
			AddParameter(_HISID,DataRow[_HISID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Hisid = GetSequence("SELECT SEQ_TNET_USER_ROLE.nextval FROM DUAL");
			string sql = @"INSERT INTO TNET_USER_ROLE(HISID,USER_ID,EXPIRE_TIME,USER_LEVEL,ROLE_NAME,LAST_MODIFY_TIME)
			VALUES (:HISID,:USER_ID,:EXPIRE_TIME,:USER_LEVEL,:ROLE_NAME,:LAST_MODIFY_TIME)";
			AddParameter(_HISID,DataRow[_HISID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_EXPIRE_TIME,DataRow[_EXPIRE_TIME]);
			AddParameter(_USER_LEVEL,DataRow[_USER_LEVEL]);
			AddParameter(_ROLE_NAME,DataRow[_ROLE_NAME]);
			AddParameter(_LAST_MODIFY_TIME,DataRow[_LAST_MODIFY_TIME]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_User_RoleCollection.Field,object> alterDic,Dictionary<Tnet_User_RoleCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_User_RoleCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_User_RoleCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_HISID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_USER_ROLE SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE HISID=:HISID");
			AddParameter(_HISID, DataRow[_HISID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByUserId_UserLevel(int user_id,int user_level)
		{
			string condition = " USER_ID=:USER_ID AND USER_LEVEL=:USER_LEVEL";
			AddParameter(_USER_ID,user_id);
			AddParameter(_USER_LEVEL,user_level);
			return SelectByCondition(condition);
		}
		public bool SelectByPk(int hisid)
		{
			string condition = " HISID=:HISID";
			AddParameter(_HISID,hisid);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// [集合对象]
	/// </summary>
	public partial class Tnet_User_RoleCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_User_RoleCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_User_Role().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_User_Role(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_User_Role._TableName;}
		}
		public Tnet_User_Role this[int index]
        {
            get { return new Tnet_User_Role(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Hisid=0,
			User_Id=1,
			Expire_Time=2,
			User_Level=3,
			Role_Name=4,
			Last_Modify_Time=5,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT HISID,USER_ID,EXPIRE_TIME,USER_LEVEL,ROLE_NAME,LAST_MODIFY_TIME FROM TNET_USER_ROLE WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_User_Role Find(Predicate<Tnet_User_Role> match)
        {
            foreach (Tnet_User_Role item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_User_RoleCollection FindAll(Predicate<Tnet_User_Role> match)
        {
            Tnet_User_RoleCollection list = new Tnet_User_RoleCollection();
            foreach (Tnet_User_Role item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_User_Role> match)
        {
            foreach (Tnet_User_Role item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_User_Role> match)
        {
            BeginTransaction();
            foreach (Tnet_User_Role item in this)
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