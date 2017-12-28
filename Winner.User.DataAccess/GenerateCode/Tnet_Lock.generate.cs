   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_Lock.generate.cs
 * CreateTime : 2017-07-25 10:11:16
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
	/// 用户锁信息表
	/// </summary>
	public partial class Tnet_Lock : DataAccessBase
	{
		#region 构造和基本
		public Tnet_Lock():base()
		{}
		public Tnet_Lock(DataRow dataRow):base(dataRow)
		{}
		public const string _LOCK_ID = "LOCK_ID";
		public const string _USER_ID = "USER_ID";
		public const string _LOCK_RIGHT = "LOCK_RIGHT";
		public const string _AUTO_UNLOCK_TIME = "AUTO_UNLOCK_TIME";
		public const string _UNLOCK_TIME = "UNLOCK_TIME";
		public const string _REMARKS = "REMARKS";
		public const string _CREATE_TIME = "CREATE_TIME";
		public const string _TableName = "TNET_LOCK";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_LOCK");
			table.Columns.Add(_LOCK_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_LOCK_RIGHT,typeof(int)).DefaultValue=0;
			table.Columns.Add(_AUTO_UNLOCK_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_UNLOCK_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=string.Empty;
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
		/// 主键(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Lock_Id
		{
			get{ return Convert.ToInt32(DataRow[_LOCK_ID]);}
			 set{setProperty(_LOCK_ID, value);}
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
		/// 锁定权限$LockRight${登陆=1,消费=2,提现=4}(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Lock_Right
		{
			get{ return Convert.ToInt32(DataRow[_LOCK_RIGHT]);}
			 set{setProperty(_LOCK_RIGHT, value);}
		}
		/// <summary>
		/// 系统自动解锁时间(必填)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Auto_Unlock_Time
		{
			get{ return Convert.ToDateTime(DataRow[_AUTO_UNLOCK_TIME]);}
			 set{setProperty(_AUTO_UNLOCK_TIME, value);}
		}
		/// <summary>
		/// 实际解锁时间(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? Unlock_Time
		{
			get{ return Helper.ToDateTime(DataRow[_UNLOCK_TIME]);}
			 set{setProperty(_UNLOCK_TIME, value);}
		}
		/// <summary>
		/// 冻结原因(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 400Byte
		/// </para>
		/// </summary>
		public string Remarks
		{
			get{ return DataRow[_REMARKS].ToString();}
			 set{setProperty(_REMARKS, value);}
		}
		/// <summary>
		/// 冻结时间(必填)
		/// <para>
		/// defaultValue: DateTime.Now;   Length: 7Byte
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
			string sql = "SELECT LOCK_ID,USER_ID,LOCK_RIGHT,AUTO_UNLOCK_TIME,UNLOCK_TIME,REMARKS,CREATE_TIME FROM TNET_LOCK WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_LOCK WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int lock_id)
		{
			string condition = " LOCK_ID=:LOCK_ID";
			AddParameter(_LOCK_ID,lock_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " LOCK_ID=:LOCK_ID";
			AddParameter(_LOCK_ID,DataRow[_LOCK_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Lock_Id = GetSequence("SELECT SEQ_TNET_LOCK.nextval FROM DUAL");
			string sql = @"INSERT INTO TNET_LOCK(LOCK_ID,USER_ID,LOCK_RIGHT,AUTO_UNLOCK_TIME,UNLOCK_TIME,REMARKS)
			VALUES (:LOCK_ID,:USER_ID,:LOCK_RIGHT,:AUTO_UNLOCK_TIME,:UNLOCK_TIME,:REMARKS)";
			AddParameter(_LOCK_ID,DataRow[_LOCK_ID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_LOCK_RIGHT,DataRow[_LOCK_RIGHT]);
			AddParameter(_AUTO_UNLOCK_TIME,DataRow[_AUTO_UNLOCK_TIME]);
			AddParameter(_UNLOCK_TIME,DataRow[_UNLOCK_TIME]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_LockCollection.Field,object> alterDic,Dictionary<Tnet_LockCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_LockCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_LockCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_LOCK_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_LOCK SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE LOCK_ID=:LOCK_ID");
			AddParameter(_LOCK_ID, DataRow[_LOCK_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int lock_id)
		{
			string condition = " LOCK_ID=:LOCK_ID";
			AddParameter(_LOCK_ID,lock_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	
	public partial class Tnet_LockCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_LockCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_Lock().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_Lock(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_Lock._TableName;}
		}
		public Tnet_Lock this[int index]
        {
            get { return new Tnet_Lock(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Lock_Id=0,
			User_Id=1,
			Lock_Right=2,
			Auto_Unlock_Time=3,
			Unlock_Time=4,
			Remarks=5,
			Create_Time=6,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT LOCK_ID,USER_ID,LOCK_RIGHT,AUTO_UNLOCK_TIME,UNLOCK_TIME,REMARKS,CREATE_TIME FROM TNET_LOCK WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_Lock Find(Predicate<Tnet_Lock> match)
        {
            foreach (Tnet_Lock item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_LockCollection FindAll(Predicate<Tnet_Lock> match)
        {
            Tnet_LockCollection list = new Tnet_LockCollection();
            foreach (Tnet_Lock item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_Lock> match)
        {
            foreach (Tnet_Lock item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_Lock> match)
        {
            BeginTransaction();
            foreach (Tnet_Lock item in this)
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