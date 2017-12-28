   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_Role_Expires.generate.cs
 * CreateTime : 2017-11-20 10:08:08
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
	/// 会员角色过期记录
	/// </summary>
	public partial class Tnet_Role_Expires : DataAccessBase
	{
		#region 构造和基本
		public Tnet_Role_Expires():base()
		{}
		public Tnet_Role_Expires(DataRow dataRow):base(dataRow)
		{}
		public const string _HISID = "HISID";
		public const string _USER_ID = "USER_ID";
		public const string _USER_LEVEL = "USER_LEVEL";
		public const string _BEFORE_LEVEL = "BEFORE_LEVEL";
		public const string _AFTER_LEVEL = "AFTER_LEVEL";
		public const string _CREATETIME = "CREATETIME";
		public const string _REMARKS = "REMARKS";
		public const string _TableName = "TNET_ROLE_EXPIRES";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_ROLE_EXPIRES");
			table.Columns.Add(_HISID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_LEVEL,typeof(int)).DefaultValue=0;
			table.Columns.Add(_BEFORE_LEVEL,typeof(int)).DefaultValue=0;
			table.Columns.Add(_AFTER_LEVEL,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CREATETIME,typeof(DateTime)).DefaultValue=DateTime.Now;
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
		/// 降级历史ID(必填)
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
		/// 会员ID(必填)
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
		/// 降级级别(必填)
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
		/// 降级前级别(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Before_Level
		{
			get{ return Convert.ToInt32(DataRow[_BEFORE_LEVEL]);}
			 set{setProperty(_BEFORE_LEVEL, value);}
		}
		/// <summary>
		/// 降级后级别(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int After_Level
		{
			get{ return Convert.ToInt32(DataRow[_AFTER_LEVEL]);}
			 set{setProperty(_AFTER_LEVEL, value);}
		}
		/// <summary>
		/// 降级时间(必填)
		/// <para>
		/// defaultValue: DateTime.Now;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Createtime
		{
			get{ return Convert.ToDateTime(DataRow[_CREATETIME]);}
		}
		/// <summary>
		/// 备注(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 400Byte
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
			string sql = "SELECT HISID,USER_ID,USER_LEVEL,BEFORE_LEVEL,AFTER_LEVEL,CREATETIME,REMARKS FROM TNET_ROLE_EXPIRES WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_ROLE_EXPIRES WHERE "+condition;
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
			int id = this.Hisid = GetSequence("SELECT SEQ_TNET_ROLE_EXPIRES.nextval FROM DUAL");
			string sql = @"INSERT INTO TNET_ROLE_EXPIRES(HISID,USER_ID,USER_LEVEL,BEFORE_LEVEL,AFTER_LEVEL,REMARKS)
			VALUES (:HISID,:USER_ID,:USER_LEVEL,:BEFORE_LEVEL,:AFTER_LEVEL,:REMARKS)";
			AddParameter(_HISID,DataRow[_HISID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_USER_LEVEL,DataRow[_USER_LEVEL]);
			AddParameter(_BEFORE_LEVEL,DataRow[_BEFORE_LEVEL]);
			AddParameter(_AFTER_LEVEL,DataRow[_AFTER_LEVEL]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_Role_ExpiresCollection.Field,object> alterDic,Dictionary<Tnet_Role_ExpiresCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_Role_ExpiresCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_Role_ExpiresCollection.Field key in conditionDic.Keys)
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
            sql.AppendLine("UPDATE TNET_ROLE_EXPIRES SET");
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
		public bool SelectByPk(int hisid)
		{
			string condition = " HISID=:HISID";
			AddParameter(_HISID,hisid);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// 会员角色过期记录[集合对象]
	/// </summary>
	public partial class Tnet_Role_ExpiresCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_Role_ExpiresCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_Role_Expires().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_Role_Expires(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_Role_Expires._TableName;}
		}
		public Tnet_Role_Expires this[int index]
        {
            get { return new Tnet_Role_Expires(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Hisid=0,
			User_Id=1,
			User_Level=2,
			Before_Level=3,
			After_Level=4,
			Createtime=5,
			Remarks=6,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT HISID,USER_ID,USER_LEVEL,BEFORE_LEVEL,AFTER_LEVEL,CREATETIME,REMARKS FROM TNET_ROLE_EXPIRES WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_Role_Expires Find(Predicate<Tnet_Role_Expires> match)
        {
            foreach (Tnet_Role_Expires item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_Role_ExpiresCollection FindAll(Predicate<Tnet_Role_Expires> match)
        {
            Tnet_Role_ExpiresCollection list = new Tnet_Role_ExpiresCollection();
            foreach (Tnet_Role_Expires item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_Role_Expires> match)
        {
            foreach (Tnet_Role_Expires item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_Role_Expires> match)
        {
            BeginTransaction();
            foreach (Tnet_Role_Expires item in this)
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