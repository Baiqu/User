   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Vnet_Province.generate.cs
 * CreateTime : 2017-04-08 10:52:10
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
	public partial class Vnet_Province : DataAccessBase
	{
		#region 构造和基本
		public Vnet_Province():base()
		{}
		public Vnet_Province(DataRow dataRow):base(dataRow)
		{}
		public const string _PROVINCE_ID = "PROVINCE_ID";
		public const string _PROVINCE_NAME = "PROVINCE_NAME";
		public const string _COUNTRY_ID = "COUNTRY_ID";
		public const string _IDCODE = "IDCODE";
		public const string _STATUS = "STATUS";
		public const string _TableName = "VNET_PROVINCE";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("VNET_PROVINCE");
			table.Columns.Add(_PROVINCE_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_PROVINCE_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_COUNTRY_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_IDCODE,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_STATUS,typeof(decimal)).DefaultValue=DBNull.Value;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 省ID
		/// </summary>
		public int Province_Id
		{
			get{ return Convert.ToInt32(DataRow[_PROVINCE_ID]);}
			 set{setProperty(_PROVINCE_ID, value);}
		}
		/// <summary>
		/// 省名。如“广西”
		/// </summary>
		public string Province_Name
		{
			get{ return DataRow[_PROVINCE_NAME].ToString();}
			 set{setProperty(_PROVINCE_NAME, value);}
		}
		/// <summary>
		/// 国家ID
		/// </summary>
		public int? Country_Id
		{
			get{ return Helper.ToInt32(DataRow[_COUNTRY_ID]);}
			 set{setProperty(_COUNTRY_ID, value);}
		}
		/// <summary>
		/// 身份证前6位
		/// </summary>
		public string Idcode
		{
			get{ return DataRow[_IDCODE].ToString();}
			 set{setProperty(_IDCODE, value);}
		}
		/// <summary>
		/// 状态：不可用=0,可用=1
		/// </summary>
		public decimal? Status
		{
			get{ return Helper.ToDecimal(DataRow[_STATUS]);}
			 set{setProperty(_STATUS, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT PROVINCE_ID,PROVINCE_NAME,COUNTRY_ID,IDCODE,STATUS FROM VNET_PROVINCE WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM VNET_PROVINCE WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		#endregion
	}
	
	public partial class Vnet_ProvinceCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Vnet_ProvinceCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Vnet_Province().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Vnet_Province(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Vnet_Province._TableName;}
		}
		public Vnet_Province this[int index]
        {
            get { return new Vnet_Province(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Province_Id=0,
			Province_Name=1,
			Country_Id=2,
			Idcode=3,
			Status=4,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT PROVINCE_ID,PROVINCE_NAME,COUNTRY_ID,IDCODE,STATUS FROM VNET_PROVINCE WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Vnet_Province Find(Predicate<Vnet_Province> match)
        {
            foreach (Vnet_Province item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Vnet_ProvinceCollection FindAll(Predicate<Vnet_Province> match)
        {
            Vnet_ProvinceCollection list = new Vnet_ProvinceCollection();
            foreach (Vnet_Province item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Vnet_Province> match)
        {
            foreach (Vnet_Province item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		#endregion
		#endregion		
	}
}