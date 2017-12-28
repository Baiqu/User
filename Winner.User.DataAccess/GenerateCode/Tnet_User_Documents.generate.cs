   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_User_Documents.generate.cs
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

namespace Winner.User.DataAccess
{
	/// <summary>
	/// 用户证件表
	/// </summary>
	public partial class Tnet_User_Documents : DataAccessBase
	{
		#region 构造和基本
		public Tnet_User_Documents():base()
		{}
		public Tnet_User_Documents(DataRow dataRow):base(dataRow)
		{}
		public const string _DOCUMENTS_TYPE = "DOCUMENTS_TYPE";
		public const string _DOCUMENTS_ID = "DOCUMENTS_ID";
		public const string _STATUS = "STATUS";
		public const string _REMARKS = "REMARKS";
		public const string _CREATE_TIME = "CREATE_TIME";
		public const string _ID = "ID";
		public const string _USER_ID = "USER_ID";
		public const string _TableName = "TNET_USER_DOCUMENTS";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_USER_DOCUMENTS");
			table.Columns.Add(_DOCUMENTS_TYPE,typeof(int)).DefaultValue=0;
			table.Columns.Add(_DOCUMENTS_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_STATUS,typeof(int)).DefaultValue=0;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CREATE_TIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 证件类型$DocumentsType${身份证=1}(必填)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int Documents_Type
		{
			get{ return Convert.ToInt32(DataRow[_DOCUMENTS_TYPE]);}
			 set{setProperty(_DOCUMENTS_TYPE, value);}
		}
		/// <summary>
		/// 证件编号，根据证件类型对应不同表(必填)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int Documents_Id
		{
			get{ return Convert.ToInt32(DataRow[_DOCUMENTS_ID]);}
			 set{setProperty(_DOCUMENTS_ID, value);}
		}
		/// <summary>
		/// 状态$DocumentsStatus${审核中=1,审核成功=2,审核失败=4,删除=8}(必填)
		/// <para>
		/// defaultValue: 0    Length: 22Byte
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
		/// defaultValue:    Length: 400Byte
		/// </para>
		/// </summary>
		public string Remarks
		{
			get{ return DataRow[_REMARKS].ToString();}
			 set{setProperty(_REMARKS, value);}
		}
		/// <summary>
		/// 创建时间(必填)
		/// <para>
		/// defaultValue: sysdate    Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Create_Time
		{
			get{ return Convert.ToDateTime(DataRow[_CREATE_TIME]);}
			 set{setProperty(_CREATE_TIME, value);}
		}
		/// <summary>
		/// 主键(必填)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int Id
		{
			get{ return Convert.ToInt32(DataRow[_ID]);}
			 set{setProperty(_ID, value);}
		}
		/// <summary>
		/// 用户编号(必填)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int User_Id
		{
			get{ return Convert.ToInt32(DataRow[_USER_ID]);}
			 set{setProperty(_USER_ID, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT DOCUMENTS_TYPE,DOCUMENTS_ID,STATUS,REMARKS,CREATE_TIME,ID,USER_ID FROM TNET_USER_DOCUMENTS WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_USER_DOCUMENTS WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int id)
		{
			string condition = " ID=:ID";
			AddParameter(_ID,id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " ID=:ID";
			AddParameter(_ID,DataRow[_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Id = GetSequence("SELECT SEQ_TNET_USER_DOCUMENTS.nextval FROM DUAL");
			string sql = @"INSERT INTO TNET_USER_DOCUMENTS(DOCUMENTS_TYPE,DOCUMENTS_ID,STATUS,REMARKS,ID,USER_ID)
			VALUES (:DOCUMENTS_TYPE,:DOCUMENTS_ID,:STATUS,:REMARKS,:ID,:USER_ID)";
			AddParameter(_DOCUMENTS_TYPE,DataRow[_DOCUMENTS_TYPE]);
			AddParameter(_DOCUMENTS_ID,DataRow[_DOCUMENTS_ID]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_ID,DataRow[_ID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_User_DocumentsCollection.Field,object> alterDic,Dictionary<Tnet_User_DocumentsCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_User_DocumentsCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_User_DocumentsCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_USER_DOCUMENTS SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE ID=:ID");
			AddParameter(_ID, DataRow[_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByUser_Id_Documents_Type(int user_id,int documents_type)
		{
			string condition = " USER_ID=:USER_ID AND DOCUMENTS_TYPE=:DOCUMENTS_TYPE";
			AddParameter(_USER_ID,user_id);
			AddParameter(_DOCUMENTS_TYPE,documents_type);
			return SelectByCondition(condition);
		}
		public bool SelectByPk(int id)
		{
			string condition = " ID=:ID";
			AddParameter(_ID,id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	
	public partial class Tnet_User_DocumentsCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_User_DocumentsCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_User_Documents().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_User_Documents(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_User_Documents._TableName;}
		}
		public Tnet_User_Documents this[int index]
        {
            get { return new Tnet_User_Documents(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Documents_Type=0,
			Documents_Id=1,
			Status=2,
			Remarks=3,
			Create_Time=4,
			Id=5,
			User_Id=6,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT DOCUMENTS_TYPE,DOCUMENTS_ID,STATUS,REMARKS,CREATE_TIME,ID,USER_ID FROM TNET_USER_DOCUMENTS WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListByUser_Id(int user_id)
		{
			string condition = "USER_ID=:USER_ID ORDER BY ID DESC";
			AddParameter(Tnet_User_Documents._USER_ID,user_id);
			return ListByCondition(condition);		
		}
		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_User_Documents Find(Predicate<Tnet_User_Documents> match)
        {
            foreach (Tnet_User_Documents item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_User_DocumentsCollection FindAll(Predicate<Tnet_User_Documents> match)
        {
            Tnet_User_DocumentsCollection list = new Tnet_User_DocumentsCollection();
            foreach (Tnet_User_Documents item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_User_Documents> match)
        {
            foreach (Tnet_User_Documents item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_User_Documents> match)
        {
            BeginTransaction();
            foreach (Tnet_User_Documents item in this)
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