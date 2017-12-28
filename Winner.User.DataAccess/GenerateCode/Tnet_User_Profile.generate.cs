   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_User_Profile.generate.cs
 * CreateTime : 2017-05-12 17:26:21
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
	public partial class Tnet_User_Profile : DataAccessBase
	{
		#region 构造和基本
		public Tnet_User_Profile():base()
		{}
		public Tnet_User_Profile(DataRow dataRow):base(dataRow)
		{}
		public const string _ORG_ID = "ORG_ID";
		public const string _LAST_MODIFY_TIME = "LAST_MODIFY_TIME";
		public const string _REMARKS = "REMARKS";
		public const string _USER_ID = "USER_ID";
		public const string _CITY_ID = "CITY_ID";
		public const string _INDUSTRY = "INDUSTRY";
		public const string _TableName = "TNET_USER_PROFILE";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_USER_PROFILE");
			table.Columns.Add(_ORG_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_LAST_MODIFY_TIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CITY_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_INDUSTRY,typeof(string)).DefaultValue=DBNull.Value;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 归属ID(可空)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int? Org_Id
		{
			get{ return Helper.ToInt32(DataRow[_ORG_ID]);}
			 set{setProperty(_ORG_ID, value);}
		}
		/// <summary>
		/// 上次修改时间(必填)
		/// <para>
		/// defaultValue: SYSDATE    Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Last_Modify_Time
		{
			get{ return Convert.ToDateTime(DataRow[_LAST_MODIFY_TIME]);}
			 set{setProperty(_LAST_MODIFY_TIME, value);}
		}
		/// <summary>
		/// 备注信息(可空)
		/// <para>
		/// defaultValue:    Length: 280Byte
		/// </para>
		/// </summary>
		public string Remarks
		{
			get{ return DataRow[_REMARKS].ToString();}
			 set{setProperty(_REMARKS, value);}
		}
		/// <summary>
		/// 用户ID，主键兼外键(必填)
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
		/// 所在城市ID(可空)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int? City_Id
		{
			get{ return Helper.ToInt32(DataRow[_CITY_ID]);}
			 set{setProperty(_CITY_ID, value);}
		}
		/// <summary>
		/// 从事行业(可空)
		/// <para>
		/// defaultValue:    Length: 40Byte
		/// </para>
		/// </summary>
		public string Industry
		{
			get{ return DataRow[_INDUSTRY].ToString();}
			 set{setProperty(_INDUSTRY, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT ORG_ID,LAST_MODIFY_TIME,REMARKS,USER_ID,CITY_ID,INDUSTRY FROM TNET_USER_PROFILE WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_USER_PROFILE WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int user_id)
		{
			string condition = " USER_ID=:USER_ID";
			AddParameter(_USER_ID,user_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " USER_ID=:USER_ID";
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			string sql = @"INSERT INTO TNET_USER_PROFILE(ORG_ID,LAST_MODIFY_TIME,REMARKS,USER_ID,CITY_ID,INDUSTRY)
			VALUES (:ORG_ID,:LAST_MODIFY_TIME,:REMARKS,:USER_ID,:CITY_ID,:INDUSTRY)";
			AddParameter(_ORG_ID,DataRow[_ORG_ID]);
			AddParameter(_LAST_MODIFY_TIME,DataRow[_LAST_MODIFY_TIME]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_CITY_ID,DataRow[_CITY_ID]);
			AddParameter(_INDUSTRY,DataRow[_INDUSTRY]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_User_ProfileCollection.Field,object> alterDic,Dictionary<Tnet_User_ProfileCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_User_ProfileCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_User_ProfileCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_USER_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_USER_PROFILE SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE USER_ID=:USER_ID");
			AddParameter(_USER_ID, DataRow[_USER_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int user_id)
		{
			string condition = " USER_ID=:USER_ID";
			AddParameter(_USER_ID,user_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	
	public partial class Tnet_User_ProfileCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_User_ProfileCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_User_Profile().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_User_Profile(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_User_Profile._TableName;}
		}
		public Tnet_User_Profile this[int index]
        {
            get { return new Tnet_User_Profile(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Org_Id=0,
			Last_Modify_Time=1,
			Remarks=2,
			User_Id=3,
			City_Id=4,
			Industry=5,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT ORG_ID,LAST_MODIFY_TIME,REMARKS,USER_ID,CITY_ID,INDUSTRY FROM TNET_USER_PROFILE WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListByUser_Id(int user_id)
		{
			string condition = "USER_ID=:USER_ID ORDER BY USER_ID DESC";
			AddParameter(Tnet_User_Profile._USER_ID,user_id);
			return ListByCondition(condition);		
		}
		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_User_Profile Find(Predicate<Tnet_User_Profile> match)
        {
            foreach (Tnet_User_Profile item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_User_ProfileCollection FindAll(Predicate<Tnet_User_Profile> match)
        {
            Tnet_User_ProfileCollection list = new Tnet_User_ProfileCollection();
            foreach (Tnet_User_Profile item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_User_Profile> match)
        {
            foreach (Tnet_User_Profile item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_User_Profile> match)
        {
            BeginTransaction();
            foreach (Tnet_User_Profile item in this)
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