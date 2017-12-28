   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tvip_Device.generate.cs
 * CreateTime : 2017-10-28 10:57:39
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
	/// VIP赠送设备
	/// </summary>
	public partial class Tvip_Device : DataAccessBase
	{
		#region 构造和基本
		public Tvip_Device():base()
		{}
		public Tvip_Device(DataRow dataRow):base(dataRow)
		{}
		public const string _IMAGE_URL = "IMAGE_URL";
		public const string _DEVICE_ID = "DEVICE_ID";
		public const string _DEVICE_NAME = "DEVICE_NAME";
		public const string _PRICE = "PRICE";
		public const string _LINK_URL = "LINK_URL";
		public const string _STATUS = "STATUS";
		public const string _CREATETIME = "CREATETIME";
		public const string _REMARKS = "REMARKS";
		public const string _TableName = "TVIP_DEVICE";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TVIP_DEVICE");
			table.Columns.Add(_IMAGE_URL,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_DEVICE_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_DEVICE_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_PRICE,typeof(decimal)).DefaultValue=0;
			table.Columns.Add(_LINK_URL,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_STATUS,typeof(int)).DefaultValue=1;
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
		/// 图片地址(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 200Byte
		/// </para>
		/// </summary>
		public string Image_Url
		{
			get{ return DataRow[_IMAGE_URL].ToString();}
			 set{setProperty(_IMAGE_URL, value);}
		}
		/// <summary>
		/// 设备ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Device_Id
		{
			get{ return Convert.ToInt32(DataRow[_DEVICE_ID]);}
			 set{setProperty(_DEVICE_ID, value);}
		}
		/// <summary>
		/// 设备名称(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 40Byte
		/// </para>
		/// </summary>
		public string Device_Name
		{
			get{ return DataRow[_DEVICE_NAME].ToString();}
			 set{setProperty(_DEVICE_NAME, value);}
		}
		/// <summary>
		/// 价格，单位元(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public decimal Price
		{
			get{ return Convert.ToDecimal(DataRow[_PRICE]);}
			 set{setProperty(_PRICE, value);}
		}
		/// <summary>
		/// 设备资料URL(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 400Byte
		/// </para>
		/// </summary>
		public string Link_Url
		{
			get{ return DataRow[_LINK_URL].ToString();}
			 set{setProperty(_LINK_URL, value);}
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
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT IMAGE_URL,DEVICE_ID,DEVICE_NAME,PRICE,LINK_URL,STATUS,CREATETIME,REMARKS FROM TVIP_DEVICE WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TVIP_DEVICE WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int device_id)
		{
			string condition = " DEVICE_ID=:DEVICE_ID";
			AddParameter(_DEVICE_ID,device_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " DEVICE_ID=:DEVICE_ID";
			AddParameter(_DEVICE_ID,DataRow[_DEVICE_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Device_Id = GetSequence("SELECT SEQ_TVIP_DEVICE.nextval FROM DUAL");
			string sql = @"INSERT INTO TVIP_DEVICE(IMAGE_URL,DEVICE_ID,DEVICE_NAME,PRICE,LINK_URL,STATUS,REMARKS)
			VALUES (:IMAGE_URL,:DEVICE_ID,:DEVICE_NAME,:PRICE,:LINK_URL,:STATUS,:REMARKS)";
			AddParameter(_IMAGE_URL,DataRow[_IMAGE_URL]);
			AddParameter(_DEVICE_ID,DataRow[_DEVICE_ID]);
			AddParameter(_DEVICE_NAME,DataRow[_DEVICE_NAME]);
			AddParameter(_PRICE,DataRow[_PRICE]);
			AddParameter(_LINK_URL,DataRow[_LINK_URL]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tvip_DeviceCollection.Field,object> alterDic,Dictionary<Tvip_DeviceCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tvip_DeviceCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tvip_DeviceCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_DEVICE_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TVIP_DEVICE SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE DEVICE_ID=:DEVICE_ID");
			AddParameter(_DEVICE_ID, DataRow[_DEVICE_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int device_id)
		{
			string condition = " DEVICE_ID=:DEVICE_ID";
			AddParameter(_DEVICE_ID,device_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// VIP赠送设备[集合对象]
	/// </summary>
	public partial class Tvip_DeviceCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tvip_DeviceCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tvip_Device().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tvip_Device(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tvip_Device._TableName;}
		}
		public Tvip_Device this[int index]
        {
            get { return new Tvip_Device(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Image_Url=0,
			Device_Id=1,
			Device_Name=2,
			Price=3,
			Link_Url=4,
			Status=5,
			Createtime=6,
			Remarks=7,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT IMAGE_URL,DEVICE_ID,DEVICE_NAME,PRICE,LINK_URL,STATUS,CREATETIME,REMARKS FROM TVIP_DEVICE WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tvip_Device Find(Predicate<Tvip_Device> match)
        {
            foreach (Tvip_Device item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tvip_DeviceCollection FindAll(Predicate<Tvip_Device> match)
        {
            Tvip_DeviceCollection list = new Tvip_DeviceCollection();
            foreach (Tvip_Device item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tvip_Device> match)
        {
            foreach (Tvip_Device item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tvip_Device> match)
        {
            BeginTransaction();
            foreach (Tvip_Device item in this)
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