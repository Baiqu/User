   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tvip_Upgrade_His.generate.cs
 * CreateTime : 2017-08-28 10:55:27
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
	/// VIP升级历史
	/// </summary>
	public partial class Tvip_Upgrade_His : DataAccessBase
	{
		#region 构造和基本
		public Tvip_Upgrade_His():base()
		{}
		public Tvip_Upgrade_His(DataRow dataRow):base(dataRow)
		{}
		public const string _HIS_ID = "HIS_ID";
		public const string _USER_ID = "USER_ID";
		public const string _START_TIME = "START_TIME";
		public const string _EXPIRE_TIME = "EXPIRE_TIME";
		public const string _ORDER_ID = "ORDER_ID";
		public const string _CREATETIME = "CREATETIME";
		public const string _REMARKS = "REMARKS";
		public const string _TableName = "TVIP_UPGRADE_HIS";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TVIP_UPGRADE_HIS");
			table.Columns.Add(_HIS_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_START_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_EXPIRE_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_ORDER_ID,typeof(int)).DefaultValue=0;
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
		/// 历史记录ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int His_Id
		{
			get{ return Convert.ToInt32(DataRow[_HIS_ID]);}
			 set{setProperty(_HIS_ID, value);}
		}
		/// <summary>
		/// 会员ID(必填)
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
		/// VIP生效时间(必填)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Start_Time
		{
			get{ return Convert.ToDateTime(DataRow[_START_TIME]);}
			 set{setProperty(_START_TIME, value);}
		}
		/// <summary>
		/// VIP过期时间(必填)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Expire_Time
		{
			get{ return Convert.ToDateTime(DataRow[_EXPIRE_TIME]);}
			 set{setProperty(_EXPIRE_TIME, value);}
		}
		/// <summary>
		/// 订单ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Order_Id
		{
			get{ return Convert.ToInt32(DataRow[_ORDER_ID]);}
			 set{setProperty(_ORDER_ID, value);}
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
			string sql = "SELECT HIS_ID,USER_ID,START_TIME,EXPIRE_TIME,ORDER_ID,CREATETIME,REMARKS FROM TVIP_UPGRADE_HIS WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TVIP_UPGRADE_HIS WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int his_id)
		{
			string condition = " HIS_ID=:HIS_ID";
			AddParameter(_HIS_ID,his_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " HIS_ID=:HIS_ID";
			AddParameter(_HIS_ID,DataRow[_HIS_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.His_Id = GetSequence("SELECT SEQ_TVIP_UPGRADE_HIS.nextval FROM DUAL");
			string sql = @"INSERT INTO TVIP_UPGRADE_HIS(HIS_ID,USER_ID,START_TIME,EXPIRE_TIME,ORDER_ID,REMARKS)
			VALUES (:HIS_ID,:USER_ID,:START_TIME,:EXPIRE_TIME,:ORDER_ID,:REMARKS)";
			AddParameter(_HIS_ID,DataRow[_HIS_ID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_START_TIME,DataRow[_START_TIME]);
			AddParameter(_EXPIRE_TIME,DataRow[_EXPIRE_TIME]);
			AddParameter(_ORDER_ID,DataRow[_ORDER_ID]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tvip_Upgrade_HisCollection.Field,object> alterDic,Dictionary<Tvip_Upgrade_HisCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tvip_Upgrade_HisCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tvip_Upgrade_HisCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_HIS_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TVIP_UPGRADE_HIS SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE HIS_ID=:HIS_ID");
			AddParameter(_HIS_ID, DataRow[_HIS_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int his_id)
		{
			string condition = " HIS_ID=:HIS_ID";
			AddParameter(_HIS_ID,his_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	
	public partial class Tvip_Upgrade_HisCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tvip_Upgrade_HisCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tvip_Upgrade_His().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tvip_Upgrade_His(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tvip_Upgrade_His._TableName;}
		}
		public Tvip_Upgrade_His this[int index]
        {
            get { return new Tvip_Upgrade_His(DataTable.Rows[index]); }
        }
		public enum Field
        {
			His_Id=0,
			User_Id=1,
			Start_Time=2,
			Expire_Time=3,
			Order_Id=4,
			Createtime=5,
			Remarks=6,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT HIS_ID,USER_ID,START_TIME,EXPIRE_TIME,ORDER_ID,CREATETIME,REMARKS FROM TVIP_UPGRADE_HIS WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tvip_Upgrade_His Find(Predicate<Tvip_Upgrade_His> match)
        {
            foreach (Tvip_Upgrade_His item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tvip_Upgrade_HisCollection FindAll(Predicate<Tvip_Upgrade_His> match)
        {
            Tvip_Upgrade_HisCollection list = new Tvip_Upgrade_HisCollection();
            foreach (Tvip_Upgrade_His item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tvip_Upgrade_His> match)
        {
            foreach (Tvip_Upgrade_His item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tvip_Upgrade_His> match)
        {
            BeginTransaction();
            foreach (Tvip_Upgrade_His item in this)
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