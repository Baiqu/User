   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Vnet_Region.generate.cs
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
	public partial class Vnet_Region : DataAccessBase
	{
		#region 构造和基本
		public Vnet_Region():base()
		{}
		public Vnet_Region(DataRow dataRow):base(dataRow)
		{}
		public const string _REGION_ID = "REGION_ID";
		public const string _REGION_NAME = "REGION_NAME";
		public const string _CITY_ID = "CITY_ID";
		public const string _ID_CODE = "ID_CODE";
		public const string _ORDER_NO = "ORDER_NO";
		public const string _STATUS = "STATUS";
		public const string _TableName = "VNET_REGION";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("VNET_REGION");
			table.Columns.Add(_REGION_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_REGION_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CITY_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_ID_CODE,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_ORDER_NO,typeof(int)).DefaultValue=DBNull.Value;
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
		/// 区ID
		/// </summary>
		public int Region_Id
		{
			get{ return Convert.ToInt32(DataRow[_REGION_ID]);}
			 set{setProperty(_REGION_ID, value);}
		}
		/// <summary>
		/// 区名。如“天河区”
		/// </summary>
		public string Region_Name
		{
			get{ return DataRow[_REGION_NAME].ToString();}
			 set{setProperty(_REGION_NAME, value);}
		}
		/// <summary>
		/// 市ID
		/// </summary>
		public int? City_Id
		{
			get{ return Helper.ToInt32(DataRow[_CITY_ID]);}
			 set{setProperty(_CITY_ID, value);}
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
		/// 
		/// </summary>
		public int? Order_No
		{
			get{ return Helper.ToInt32(DataRow[_ORDER_NO]);}
			 set{setProperty(_ORDER_NO, value);}
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
			string sql = "SELECT REGION_ID,REGION_NAME,CITY_ID,ID_CODE,ORDER_NO,STATUS FROM VNET_REGION WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM VNET_REGION WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		#endregion
	}
	
	public partial class Vnet_RegionCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Vnet_RegionCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Vnet_Region().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Vnet_Region(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Vnet_Region._TableName;}
		}
		public Vnet_Region this[int index]
        {
            get { return new Vnet_Region(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Region_Id=0,
			Region_Name=1,
			City_Id=2,
			Id_Code=3,
			Order_No=4,
			Status=5,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT REGION_ID,REGION_NAME,CITY_ID,ID_CODE,ORDER_NO,STATUS FROM VNET_REGION WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Vnet_Region Find(Predicate<Vnet_Region> match)
        {
            foreach (Vnet_Region item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Vnet_RegionCollection FindAll(Predicate<Vnet_Region> match)
        {
            Vnet_RegionCollection list = new Vnet_RegionCollection();
            foreach (Vnet_Region item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Vnet_Region> match)
        {
            foreach (Vnet_Region item in this)
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