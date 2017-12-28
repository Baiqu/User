   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_Bankinfo.generate.cs
 * CreateTime : 2017-10-09 17:00:01
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
	/// 银行信息表
	/// </summary>
	public partial class Tnet_Bankinfo : DataAccessBase
	{
		#region 构造和基本
		public Tnet_Bankinfo():base()
		{}
		public Tnet_Bankinfo(DataRow dataRow):base(dataRow)
		{}
		public const string _STATUS = "STATUS";
		public const string _BANK_INFO_ID = "BANK_INFO_ID";
		public const string _BANK_CHINA_NAME = "BANK_CHINA_NAME";
		public const string _BANK_ENGLISH_NAME = "BANK_ENGLISH_NAME";
		public const string _BANK_URL = "BANK_URL";
		public const string _CREATE_TIME = "CREATE_TIME";
		public const string _REMARKS = "REMARKS";
		public const string _BANK_CODE = "BANK_CODE";
		public const string _RANK = "RANK";
		public const string _LOGO = "LOGO";
		public const string _TableName = "TNET_BANKINFO";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_BANKINFO");
			table.Columns.Add(_STATUS,typeof(int)).DefaultValue=1;
			table.Columns.Add(_BANK_INFO_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_BANK_CHINA_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_BANK_ENGLISH_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_BANK_URL,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CREATE_TIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_BANK_CODE,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_RANK,typeof(int)).DefaultValue=1;
			table.Columns.Add(_LOGO,typeof(string)).DefaultValue=DBNull.Value;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 状态(必填)
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
		/// PK(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Bank_Info_Id
		{
			get{ return Convert.ToInt32(DataRow[_BANK_INFO_ID]);}
			 set{setProperty(_BANK_INFO_ID, value);}
		}
		/// <summary>
		/// 银行中文名称(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 100Byte
		/// </para>
		/// </summary>
		public string Bank_China_Name
		{
			get{ return DataRow[_BANK_CHINA_NAME].ToString();}
			 set{setProperty(_BANK_CHINA_NAME, value);}
		}
		/// <summary>
		/// 银行英文名称(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 200Byte
		/// </para>
		/// </summary>
		public string Bank_English_Name
		{
			get{ return DataRow[_BANK_ENGLISH_NAME].ToString();}
			 set{setProperty(_BANK_ENGLISH_NAME, value);}
		}
		/// <summary>
		/// 银行主页(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 200Byte
		/// </para>
		/// </summary>
		public string Bank_Url
		{
			get{ return DataRow[_BANK_URL].ToString();}
			 set{setProperty(_BANK_URL, value);}
		}
		/// <summary>
		/// 创建时间(必填)
		/// <para>
		/// defaultValue: DateTime.Now;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Create_Time
		{
			get{ return Convert.ToDateTime(DataRow[_CREATE_TIME]);}
			 set{setProperty(_CREATE_TIME, value);}
		}
		/// <summary>
		/// 备注(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 1000Byte
		/// </para>
		/// </summary>
		public string Remarks
		{
			get{ return DataRow[_REMARKS].ToString();}
			 set{setProperty(_REMARKS, value);}
		}
		/// <summary>
		/// 银行机构代码(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 30Byte
		/// </para>
		/// </summary>
		public string Bank_Code
		{
			get{ return DataRow[_BANK_CODE].ToString();}
			 set{setProperty(_BANK_CODE, value);}
		}
		/// <summary>
		/// 排序权重(必填)
		/// <para>
		/// defaultValue: 1;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Rank
		{
			get{ return Convert.ToInt32(DataRow[_RANK]);}
			 set{setProperty(_RANK, value);}
		}
		/// <summary>
		/// 银行logo(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 100Byte
		/// </para>
		/// </summary>
		public string Logo
		{
			get{ return DataRow[_LOGO].ToString();}
			 set{setProperty(_LOGO, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT STATUS,BANK_INFO_ID,BANK_CHINA_NAME,BANK_ENGLISH_NAME,BANK_URL,CREATE_TIME,REMARKS,BANK_CODE,RANK,LOGO FROM TNET_BANKINFO WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_BANKINFO WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int bank_info_id)
		{
			string condition = " BANK_INFO_ID=:BANK_INFO_ID";
			AddParameter(_BANK_INFO_ID,bank_info_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " BANK_INFO_ID=:BANK_INFO_ID";
			AddParameter(_BANK_INFO_ID,DataRow[_BANK_INFO_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Bank_Info_Id = GetSequence("SELECT SEQ_TNET_BANKINFO.nextval FROM DUAL");
			string sql = @"INSERT INTO TNET_BANKINFO(STATUS,BANK_INFO_ID,BANK_CHINA_NAME,BANK_ENGLISH_NAME,BANK_URL,REMARKS,BANK_CODE,RANK,LOGO)
			VALUES (:STATUS,:BANK_INFO_ID,:BANK_CHINA_NAME,:BANK_ENGLISH_NAME,:BANK_URL,:REMARKS,:BANK_CODE,:RANK,:LOGO)";
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_BANK_INFO_ID,DataRow[_BANK_INFO_ID]);
			AddParameter(_BANK_CHINA_NAME,DataRow[_BANK_CHINA_NAME]);
			AddParameter(_BANK_ENGLISH_NAME,DataRow[_BANK_ENGLISH_NAME]);
			AddParameter(_BANK_URL,DataRow[_BANK_URL]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_BANK_CODE,DataRow[_BANK_CODE]);
			AddParameter(_RANK,DataRow[_RANK]);
			AddParameter(_LOGO,DataRow[_LOGO]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_BankinfoCollection.Field,object> alterDic,Dictionary<Tnet_BankinfoCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_BankinfoCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_BankinfoCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_BANK_INFO_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_BANKINFO SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE BANK_INFO_ID=:BANK_INFO_ID");
			AddParameter(_BANK_INFO_ID, DataRow[_BANK_INFO_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int bank_info_id)
		{
			string condition = " BANK_INFO_ID=:BANK_INFO_ID";
			AddParameter(_BANK_INFO_ID,bank_info_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// 银行信息表[集合对象]
	/// </summary>
	public partial class Tnet_BankinfoCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_BankinfoCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_Bankinfo().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_Bankinfo(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_Bankinfo._TableName;}
		}
		public Tnet_Bankinfo this[int index]
        {
            get { return new Tnet_Bankinfo(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Status=0,
			Bank_Info_Id=1,
			Bank_China_Name=2,
			Bank_English_Name=3,
			Bank_Url=4,
			Create_Time=5,
			Remarks=6,
			Bank_Code=7,
			Rank=8,
			Logo=9,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT STATUS,BANK_INFO_ID,BANK_CHINA_NAME,BANK_ENGLISH_NAME,BANK_URL,CREATE_TIME,REMARKS,BANK_CODE,RANK,LOGO FROM TNET_BANKINFO WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_Bankinfo Find(Predicate<Tnet_Bankinfo> match)
        {
            foreach (Tnet_Bankinfo item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_BankinfoCollection FindAll(Predicate<Tnet_Bankinfo> match)
        {
            Tnet_BankinfoCollection list = new Tnet_BankinfoCollection();
            foreach (Tnet_Bankinfo item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_Bankinfo> match)
        {
            foreach (Tnet_Bankinfo item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_Bankinfo> match)
        {
            BeginTransaction();
            foreach (Tnet_Bankinfo item in this)
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