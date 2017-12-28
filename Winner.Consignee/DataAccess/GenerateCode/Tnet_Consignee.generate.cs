   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_Consignee.generate.cs
 * CreateTime : 2017-09-15 16:44:13
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
using Winner.Consignee.Entities;

namespace Winner.Consignee.DataAccess
{
	/// <summary>
	/// 用户收件人信息
	/// </summary>
	public partial class Tnet_Consignee : DataAccessBase
	{
		#region 构造和基本
		public Tnet_Consignee():base()
		{}
		public Tnet_Consignee(DataRow dataRow):base(dataRow)
		{}
		public const string _CONSIGNEE_ID = "CONSIGNEE_ID";
		public const string _REGION_ID = "REGION_ID";
		public const string _ADDRESS = "ADDRESS";
		public const string _POST_CODE = "POST_CODE";
		public const string _CONSIGNEE_NAME = "CONSIGNEE_NAME";
		public const string _MOBILE_NO = "MOBILE_NO";
		public const string _REMARKS = "REMARKS";
		public const string _CREATE_TIME = "CREATE_TIME";
		public const string _TableName = "TNET_CONSIGNEE";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_CONSIGNEE");
			table.Columns.Add(_CONSIGNEE_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_REGION_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_ADDRESS,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_POST_CODE,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CONSIGNEE_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_MOBILE_NO,typeof(string)).DefaultValue=string.Empty;
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
		/// 主键ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Consignee_Id
		{
			get{ return Convert.ToInt32(DataRow[_CONSIGNEE_ID]);}
			 set{setProperty(_CONSIGNEE_ID, value);}
		}
		/// <summary>
		/// 区(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Region_Id
		{
			get{ return Convert.ToInt32(DataRow[_REGION_ID]);}
			 set{setProperty(_REGION_ID, value);}
		}
		/// <summary>
		/// 详细地址(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 400Byte
		/// </para>
		/// </summary>
		public string Address
		{
			get{ return DataRow[_ADDRESS].ToString();}
			 set{setProperty(_ADDRESS, value);}
		}
		/// <summary>
		/// 邮政编码(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 12Byte
		/// </para>
		/// </summary>
		public string Post_Code
		{
			get{ return DataRow[_POST_CODE].ToString();}
			 set{setProperty(_POST_CODE, value);}
		}
		/// <summary>
		/// 收货人名称(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 60Byte
		/// </para>
		/// </summary>
		public string Consignee_Name
		{
			get{ return DataRow[_CONSIGNEE_NAME].ToString();}
			 set{setProperty(_CONSIGNEE_NAME, value);}
		}
		/// <summary>
		/// 收货人手机号码(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 40Byte
		/// </para>
		/// </summary>
		public string Mobile_No
		{
			get{ return DataRow[_MOBILE_NO].ToString();}
			 set{setProperty(_MOBILE_NO, value);}
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
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT CONSIGNEE_ID,REGION_ID,ADDRESS,POST_CODE,CONSIGNEE_NAME,MOBILE_NO,REMARKS,CREATE_TIME FROM TNET_CONSIGNEE WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_CONSIGNEE WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int consignee_id)
		{
			string condition = " CONSIGNEE_ID=:CONSIGNEE_ID";
			AddParameter(_CONSIGNEE_ID,consignee_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " CONSIGNEE_ID=:CONSIGNEE_ID";
			AddParameter(_CONSIGNEE_ID,DataRow[_CONSIGNEE_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Consignee_Id = GetSequence("SELECT SEQ_TNET_CONSIGNEE.nextval FROM DUAL");
			string sql = @"INSERT INTO TNET_CONSIGNEE(CONSIGNEE_ID,REGION_ID,ADDRESS,POST_CODE,CONSIGNEE_NAME,MOBILE_NO,REMARKS)
			VALUES (:CONSIGNEE_ID,:REGION_ID,:ADDRESS,:POST_CODE,:CONSIGNEE_NAME,:MOBILE_NO,:REMARKS)";
			AddParameter(_CONSIGNEE_ID,DataRow[_CONSIGNEE_ID]);
			AddParameter(_REGION_ID,DataRow[_REGION_ID]);
			AddParameter(_ADDRESS,DataRow[_ADDRESS]);
			AddParameter(_POST_CODE,DataRow[_POST_CODE]);
			AddParameter(_CONSIGNEE_NAME,DataRow[_CONSIGNEE_NAME]);
			AddParameter(_MOBILE_NO,DataRow[_MOBILE_NO]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_ConsigneeCollection.Field,object> alterDic,Dictionary<Tnet_ConsigneeCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_ConsigneeCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_ConsigneeCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_CONSIGNEE_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_CONSIGNEE SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE CONSIGNEE_ID=:CONSIGNEE_ID");
			AddParameter(_CONSIGNEE_ID, DataRow[_CONSIGNEE_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int consignee_id)
		{
			string condition = " CONSIGNEE_ID=:CONSIGNEE_ID";
			AddParameter(_CONSIGNEE_ID,consignee_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// 用户收件人信息[集合对象]
	/// </summary>
	public partial class Tnet_ConsigneeCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_ConsigneeCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_Consignee().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_Consignee(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_Consignee._TableName;}
		}
		public Tnet_Consignee this[int index]
        {
            get { return new Tnet_Consignee(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Consignee_Id=0,
			Region_Id=1,
			Address=2,
			Post_Code=3,
			Consignee_Name=4,
			Mobile_No=5,
			Remarks=6,
			Create_Time=7,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT CONSIGNEE_ID,REGION_ID,ADDRESS,POST_CODE,CONSIGNEE_NAME,MOBILE_NO,REMARKS,CREATE_TIME FROM TNET_CONSIGNEE WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_Consignee Find(Predicate<Tnet_Consignee> match)
        {
            foreach (Tnet_Consignee item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_ConsigneeCollection FindAll(Predicate<Tnet_Consignee> match)
        {
            Tnet_ConsigneeCollection list = new Tnet_ConsigneeCollection();
            foreach (Tnet_Consignee item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_Consignee> match)
        {
            foreach (Tnet_Consignee item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_Consignee> match)
        {
            BeginTransaction();
            foreach (Tnet_Consignee item in this)
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