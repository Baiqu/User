   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_Share_Report.generate.cs
 * CreateTime : 2017-10-31 11:03:45
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
	public partial class Tnet_Share_Report : DataAccessBase
	{
		#region 构造和基本
		public Tnet_Share_Report():base()
		{}
		public Tnet_Share_Report(DataRow dataRow):base(dataRow)
		{}
		public const string _REPORT_ID = "REPORT_ID";
		public const string _USER_ID = "USER_ID";
		public const string _SHARE_TYPE = "SHARE_TYPE";
		public const string _SHARE_NAME = "SHARE_NAME";
		public const string _CREATETIME = "CREATETIME";
		public const string _REMARKS = "REMARKS";
		public const string _TableName = "TNET_SHARE_REPORT";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_SHARE_REPORT");
			table.Columns.Add(_REPORT_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_SHARE_TYPE,typeof(int)).DefaultValue=0;
			table.Columns.Add(_SHARE_NAME,typeof(string)).DefaultValue=DBNull.Value;
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
		/// (必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Report_Id
		{
			get{ return Convert.ToInt32(DataRow[_REPORT_ID]);}
			 set{setProperty(_REPORT_ID, value);}
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
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Share_Type
		{
			get{ return Convert.ToInt32(DataRow[_SHARE_TYPE]);}
			 set{setProperty(_SHARE_TYPE, value);}
		}
		/// <summary>
		/// (可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 40Byte
		/// </para>
		/// </summary>
		public string Share_Name
		{
			get{ return DataRow[_SHARE_NAME].ToString();}
			 set{setProperty(_SHARE_NAME, value);}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: DateTime.Now;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Createtime
		{
			get{ return Convert.ToDateTime(DataRow[_CREATETIME]);}
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
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT REPORT_ID,USER_ID,SHARE_TYPE,SHARE_NAME,CREATETIME,REMARKS FROM TNET_SHARE_REPORT WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_SHARE_REPORT WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int report_id)
		{
			string condition = " REPORT_ID=:REPORT_ID";
			AddParameter(_REPORT_ID,report_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " REPORT_ID=:REPORT_ID";
			AddParameter(_REPORT_ID,DataRow[_REPORT_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Report_Id = GetSequence("SELECT SEQ_TNET_SHARE_REPORT.nextval FROM DUAL");
			string sql = @"INSERT INTO TNET_SHARE_REPORT(REPORT_ID,USER_ID,SHARE_TYPE,SHARE_NAME,REMARKS)
			VALUES (:REPORT_ID,:USER_ID,:SHARE_TYPE,:SHARE_NAME,:REMARKS)";
			AddParameter(_REPORT_ID,DataRow[_REPORT_ID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_SHARE_TYPE,DataRow[_SHARE_TYPE]);
			AddParameter(_SHARE_NAME,DataRow[_SHARE_NAME]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_Share_ReportCollection.Field,object> alterDic,Dictionary<Tnet_Share_ReportCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_Share_ReportCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_Share_ReportCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_REPORT_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_SHARE_REPORT SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE REPORT_ID=:REPORT_ID");
			AddParameter(_REPORT_ID, DataRow[_REPORT_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int report_id)
		{
			string condition = " REPORT_ID=:REPORT_ID";
			AddParameter(_REPORT_ID,report_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// [集合对象]
	/// </summary>
	public partial class Tnet_Share_ReportCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_Share_ReportCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_Share_Report().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_Share_Report(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_Share_Report._TableName;}
		}
		public Tnet_Share_Report this[int index]
        {
            get { return new Tnet_Share_Report(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Report_Id=0,
			User_Id=1,
			Share_Type=2,
			Share_Name=3,
			Createtime=4,
			Remarks=5,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT REPORT_ID,USER_ID,SHARE_TYPE,SHARE_NAME,CREATETIME,REMARKS FROM TNET_SHARE_REPORT WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListByUser_Id(int user_id)
		{
			string condition = "USER_ID=:USER_ID ORDER BY REPORT_ID DESC";
			AddParameter(Tnet_Share_Report._USER_ID,user_id);
			return ListByCondition(condition);		
		}
		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_Share_Report Find(Predicate<Tnet_Share_Report> match)
        {
            foreach (Tnet_Share_Report item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_Share_ReportCollection FindAll(Predicate<Tnet_Share_Report> match)
        {
            Tnet_Share_ReportCollection list = new Tnet_Share_ReportCollection();
            foreach (Tnet_Share_Report item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_Share_Report> match)
        {
            foreach (Tnet_Share_Report item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_Share_Report> match)
        {
            BeginTransaction();
            foreach (Tnet_Share_Report item in this)
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