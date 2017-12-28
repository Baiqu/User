   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tvip_Sub_Order.generate.cs
 * CreateTime : 2017-10-30 11:34:18
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
	/// VIP升级子订单
	/// </summary>
	public partial class Tvip_Sub_Order : DataAccessBase
	{
		#region 构造和基本
		public Tvip_Sub_Order():base()
		{}
		public Tvip_Sub_Order(DataRow dataRow):base(dataRow)
		{}
		public const string _IS_DEALED = "IS_DEALED";
		public const string _SUB_ID = "SUB_ID";
		public const string _ORDER_ID = "ORDER_ID";
		public const string _USER_ID = "USER_ID";
		public const string _CREATETIME = "CREATETIME";
		public const string _DEAL_TIME = "DEAL_TIME";
		public const string _REMARKS = "REMARKS";
		public const string _TableName = "TVIP_SUB_ORDER";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TVIP_SUB_ORDER");
			table.Columns.Add(_IS_DEALED,typeof(int)).DefaultValue=0;
			table.Columns.Add(_SUB_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_ORDER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CREATETIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_DEAL_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
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
		/// 是否已处理(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Is_Dealed
		{
			get{ return Convert.ToInt32(DataRow[_IS_DEALED]);}
			 set{setProperty(_IS_DEALED, value);}
		}
		/// <summary>
		/// 子订单ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Sub_Id
		{
			get{ return Convert.ToInt32(DataRow[_SUB_ID]);}
			 set{setProperty(_SUB_ID, value);}
		}
		/// <summary>
		/// 关联主订单ID(必填)
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
		/// 升级会员ID(必填)
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
		/// 处理时间(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? Deal_Time
		{
			get{ return Helper.ToDateTime(DataRow[_DEAL_TIME]);}
			 set{setProperty(_DEAL_TIME, value);}
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
			string sql = "SELECT IS_DEALED,SUB_ID,ORDER_ID,USER_ID,CREATETIME,DEAL_TIME,REMARKS FROM TVIP_SUB_ORDER WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TVIP_SUB_ORDER WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int sub_id)
		{
			string condition = " SUB_ID=:SUB_ID";
			AddParameter(_SUB_ID,sub_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " SUB_ID=:SUB_ID";
			AddParameter(_SUB_ID,DataRow[_SUB_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Sub_Id = GetSequence("SELECT SEQ_TVIP_SUB_ORDER.nextval FROM DUAL");
			string sql = @"INSERT INTO TVIP_SUB_ORDER(IS_DEALED,SUB_ID,ORDER_ID,USER_ID,DEAL_TIME,REMARKS)
			VALUES (:IS_DEALED,:SUB_ID,:ORDER_ID,:USER_ID,:DEAL_TIME,:REMARKS)";
			AddParameter(_IS_DEALED,DataRow[_IS_DEALED]);
			AddParameter(_SUB_ID,DataRow[_SUB_ID]);
			AddParameter(_ORDER_ID,DataRow[_ORDER_ID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_DEAL_TIME,DataRow[_DEAL_TIME]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tvip_Sub_OrderCollection.Field,object> alterDic,Dictionary<Tvip_Sub_OrderCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tvip_Sub_OrderCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tvip_Sub_OrderCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_SUB_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TVIP_SUB_ORDER SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE SUB_ID=:SUB_ID");
			AddParameter(_SUB_ID, DataRow[_SUB_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int sub_id)
		{
			string condition = " SUB_ID=:SUB_ID";
			AddParameter(_SUB_ID,sub_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// VIP升级子订单[集合对象]
	/// </summary>
	public partial class Tvip_Sub_OrderCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tvip_Sub_OrderCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tvip_Sub_Order().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tvip_Sub_Order(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tvip_Sub_Order._TableName;}
		}
		public Tvip_Sub_Order this[int index]
        {
            get { return new Tvip_Sub_Order(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Is_Dealed=0,
			Sub_Id=1,
			Order_Id=2,
			User_Id=3,
			Createtime=4,
			Deal_Time=5,
			Remarks=6,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT IS_DEALED,SUB_ID,ORDER_ID,USER_ID,CREATETIME,DEAL_TIME,REMARKS FROM TVIP_SUB_ORDER WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListByOrder_Id(int order_id)
		{
			string condition = "ORDER_ID=:ORDER_ID ORDER BY SUB_ID DESC";
			AddParameter(Tvip_Sub_Order._ORDER_ID,order_id);
			return ListByCondition(condition);		
		}
		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tvip_Sub_Order Find(Predicate<Tvip_Sub_Order> match)
        {
            foreach (Tvip_Sub_Order item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tvip_Sub_OrderCollection FindAll(Predicate<Tvip_Sub_Order> match)
        {
            Tvip_Sub_OrderCollection list = new Tvip_Sub_OrderCollection();
            foreach (Tvip_Sub_Order item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tvip_Sub_Order> match)
        {
            foreach (Tvip_Sub_Order item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tvip_Sub_Order> match)
        {
            BeginTransaction();
            foreach (Tvip_Sub_Order item in this)
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