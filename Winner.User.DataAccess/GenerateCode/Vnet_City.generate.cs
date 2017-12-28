   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Vnet_City.generate.cs
 * CreateTime : 2017-04-08 10:52:09
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
	public partial class Vnet_City : DataAccessBase
	{
		#region 构造和基本
		public Vnet_City():base()
		{}
		public Vnet_City(DataRow dataRow):base(dataRow)
		{}
		public const string _CITY_ID = "CITY_ID";
		public const string _CITY_NAME = "CITY_NAME";
		public const string _PROVINCE_ID = "PROVINCE_ID";
		public const string _ID_CODE = "ID_CODE";
		public const string _STATUS = "STATUS";
		public const string _TableName = "VNET_CITY";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("VNET_CITY");
			table.Columns.Add(_CITY_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CITY_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_PROVINCE_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_ID_CODE,typeof(string)).DefaultValue=DBNull.Value;
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
		/// 市ID
		/// </summary>
		public int City_Id
		{
			get{ return Convert.ToInt32(DataRow[_CITY_ID]);}
			 set{setProperty(_CITY_ID, value);}
		}
		/// <summary>
		/// 市名。如“广州”
		/// </summary>
		public string City_Name
		{
			get{ return DataRow[_CITY_NAME].ToString();}
			 set{setProperty(_CITY_NAME, value);}
		}
		/// <summary>
		/// 省ID
		/// </summary>
		public int? Province_Id
		{
			get{ return Helper.ToInt32(DataRow[_PROVINCE_ID]);}
			 set{setProperty(_PROVINCE_ID, value);}
		}
		/// <summary>
		/// 身份证前6位
		/// </summary>
		public string Id_Code
		{
			get{ return DataRow[_ID_CODE].ToString();}
			 set{setProperty(_ID_CODE, value);}
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
			string sql = "SELECT CITY_ID,CITY_NAME,PROVINCE_ID,ID_CODE,STATUS FROM VNET_CITY WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM VNET_CITY WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		#endregion
	}
	
	public partial class Vnet_CityCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Vnet_CityCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Vnet_City().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Vnet_City(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Vnet_City._TableName;}
		}
		public Vnet_City this[int index]
        {
            get { return new Vnet_City(DataTable.Rows[index]); }
        }
		public enum Field
        {
			City_Id=0,
			City_Name=1,
			Province_Id=2,
			Id_Code=3,
			Status=4,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT CITY_ID,CITY_NAME,PROVINCE_ID,ID_CODE,STATUS FROM VNET_CITY WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Vnet_City Find(Predicate<Vnet_City> match)
        {
            foreach (Vnet_City item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Vnet_CityCollection FindAll(Predicate<Vnet_City> match)
        {
            Vnet_CityCollection list = new Vnet_CityCollection();
            foreach (Vnet_City item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Vnet_City> match)
        {
            foreach (Vnet_City item in this)
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