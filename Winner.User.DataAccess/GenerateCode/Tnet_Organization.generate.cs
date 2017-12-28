   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_Organization.generate.cs
 * CreateTime : 2017-10-27 15:07:11
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
	public partial class Tnet_Organization : DataAccessBase
	{
		#region 构造和基本
		public Tnet_Organization():base()
		{}
		public Tnet_Organization(DataRow dataRow):base(dataRow)
		{}
		public const string _ORG_ID = "ORG_ID";
		public const string _ORG_CODE = "ORG_CODE";
		public const string _ORG_NAME = "ORG_NAME";
		public const string _ORG_TYPE = "ORG_TYPE";
		public const string _REFER_ID = "REFER_ID";
		public const string _STATUS = "STATUS";
		public const string _CREATETIME = "CREATETIME";
		public const string _REMARKS = "REMARKS";
		public const string _PROVINCE_ID = "PROVINCE_ID";
		public const string _CITY_ID = "CITY_ID";
		public const string _REGION_ID = "REGION_ID";
		public const string _IS_FULL_MONEY = "IS_FULL_MONEY";
		public const string _TableName = "TNET_ORGANIZATION";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_ORGANIZATION");
			table.Columns.Add(_ORG_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_ORG_CODE,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_ORG_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_ORG_TYPE,typeof(int)).DefaultValue=0;
			table.Columns.Add(_REFER_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_STATUS,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CREATETIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_PROVINCE_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CITY_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_REGION_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_IS_FULL_MONEY,typeof(int)).DefaultValue=1;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 组织机构ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Org_Id
		{
			get{ return Convert.ToInt32(DataRow[_ORG_ID]);}
			 set{setProperty(_ORG_ID, value);}
		}
		/// <summary>
		/// 组织机构代码（唯一）(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 50Byte
		/// </para>
		/// </summary>
		public string Org_Code
		{
			get{ return DataRow[_ORG_CODE].ToString();}
			 set{setProperty(_ORG_CODE, value);}
		}
		/// <summary>
		/// 机构名称(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 40Byte
		/// </para>
		/// </summary>
		public string Org_Name
		{
			get{ return DataRow[_ORG_NAME].ToString();}
			 set{setProperty(_ORG_NAME, value);}
		}
		/// <summary>
		/// 机构类型(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Org_Type
		{
			get{ return Convert.ToInt32(DataRow[_ORG_TYPE]);}
			 set{setProperty(_ORG_TYPE, value);}
		}
		/// <summary>
		/// 推荐/归属机构(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 22Byte
		/// </para>
		/// </summary>
		public int? Refer_Id
		{
			get{ return Helper.ToInt32(DataRow[_REFER_ID]);}
			 set{setProperty(_REFER_ID, value);}
		}
		/// <summary>
		/// 机构状态(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Status
		{
			get{ return Convert.ToInt32(DataRow[_STATUS]);}
			 set{setProperty(_STATUS, value);}
		}
		/// <summary>
		/// 创建时间(必填)
		/// <para>
		/// defaultValue: DateTime.Now;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Createtime
		{
			get{ return Convert.ToDateTime(DataRow[_CREATETIME]);}
		}
		/// <summary>
		/// 备注信息(可空)
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
		/// 省份ID(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 22Byte
		/// </para>
		/// </summary>
		public int? Province_Id
		{
			get{ return Helper.ToInt32(DataRow[_PROVINCE_ID]);}
			 set{setProperty(_PROVINCE_ID, value);}
		}
		/// <summary>
		/// 城市ID(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 22Byte
		/// </para>
		/// </summary>
		public int? City_Id
		{
			get{ return Helper.ToInt32(DataRow[_CITY_ID]);}
			 set{setProperty(_CITY_ID, value);}
		}
		/// <summary>
		/// 城市区ID(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 22Byte
		/// </para>
		/// </summary>
		public int? Region_Id
		{
			get{ return Helper.ToInt32(DataRow[_REGION_ID]);}
			 set{setProperty(_REGION_ID, value);}
		}
		/// <summary>
		/// 是否完款(必填)
		/// <para>
		/// defaultValue: 1;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Is_Full_Money
		{
			get{ return Convert.ToInt32(DataRow[_IS_FULL_MONEY]);}
			 set{setProperty(_IS_FULL_MONEY, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT ORG_ID,ORG_CODE,ORG_NAME,ORG_TYPE,REFER_ID,STATUS,CREATETIME,REMARKS,PROVINCE_ID,CITY_ID,REGION_ID,IS_FULL_MONEY FROM TNET_ORGANIZATION WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_ORGANIZATION WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int org_id)
		{
			string condition = " ORG_ID=:ORG_ID";
			AddParameter(_ORG_ID,org_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " ORG_ID=:ORG_ID";
			AddParameter(_ORG_ID,DataRow[_ORG_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Org_Id = GetSequence("SELECT SEQ_TNET_ORGANIZATION.nextval FROM DUAL");
			string sql = @"INSERT INTO TNET_ORGANIZATION(ORG_ID,ORG_CODE,ORG_NAME,ORG_TYPE,REFER_ID,STATUS,REMARKS,PROVINCE_ID,CITY_ID,REGION_ID,IS_FULL_MONEY)
			VALUES (:ORG_ID,:ORG_CODE,:ORG_NAME,:ORG_TYPE,:REFER_ID,:STATUS,:REMARKS,:PROVINCE_ID,:CITY_ID,:REGION_ID,:IS_FULL_MONEY)";
			AddParameter(_ORG_ID,DataRow[_ORG_ID]);
			AddParameter(_ORG_CODE,DataRow[_ORG_CODE]);
			AddParameter(_ORG_NAME,DataRow[_ORG_NAME]);
			AddParameter(_ORG_TYPE,DataRow[_ORG_TYPE]);
			AddParameter(_REFER_ID,DataRow[_REFER_ID]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_PROVINCE_ID,DataRow[_PROVINCE_ID]);
			AddParameter(_CITY_ID,DataRow[_CITY_ID]);
			AddParameter(_REGION_ID,DataRow[_REGION_ID]);
			AddParameter(_IS_FULL_MONEY,DataRow[_IS_FULL_MONEY]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_OrganizationCollection.Field,object> alterDic,Dictionary<Tnet_OrganizationCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_OrganizationCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_OrganizationCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_ORG_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_ORGANIZATION SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE ORG_ID=:ORG_ID");
			AddParameter(_ORG_ID, DataRow[_ORG_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByOrgCode(string org_code)
		{
			string condition = " ORG_CODE=:ORG_CODE";
			AddParameter(_ORG_CODE,org_code);
			return SelectByCondition(condition);
		}
		public bool SelectByPk(int org_id)
		{
			string condition = " ORG_ID=:ORG_ID";
			AddParameter(_ORG_ID,org_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// [集合对象]
	/// </summary>
	public partial class Tnet_OrganizationCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_OrganizationCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_Organization().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_Organization(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_Organization._TableName;}
		}
		public Tnet_Organization this[int index]
        {
            get { return new Tnet_Organization(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Org_Id=0,
			Org_Code=1,
			Org_Name=2,
			Org_Type=3,
			Refer_Id=4,
			Status=5,
			Createtime=6,
			Remarks=7,
			Province_Id=8,
			City_Id=9,
			Region_Id=10,
			Is_Full_Money=11,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT ORG_ID,ORG_CODE,ORG_NAME,ORG_TYPE,REFER_ID,STATUS,CREATETIME,REMARKS,PROVINCE_ID,CITY_ID,REGION_ID,IS_FULL_MONEY FROM TNET_ORGANIZATION WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_Organization Find(Predicate<Tnet_Organization> match)
        {
            foreach (Tnet_Organization item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_OrganizationCollection FindAll(Predicate<Tnet_Organization> match)
        {
            Tnet_OrganizationCollection list = new Tnet_OrganizationCollection();
            foreach (Tnet_Organization item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_Organization> match)
        {
            foreach (Tnet_Organization item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_Organization> match)
        {
            BeginTransaction();
            foreach (Tnet_Organization item in this)
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