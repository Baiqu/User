   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tvip_Reward.generate.cs
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
using Winner.Framework.Utils;

namespace Winner.User.DataAccess
{
	/// <summary>
	/// VIP每日奖励
	/// </summary>
	public partial class Tvip_Reward : DataAccessBase
	{
		#region 构造和基本
		public Tvip_Reward():base()
		{}
		public Tvip_Reward(DataRow dataRow):base(dataRow)
		{}
		public const string _REWARD_ID = "REWARD_ID";
		public const string _USER_ID = "USER_ID";
		public const string _AMOUNT = "AMOUNT";
		public const string _YESTERDAY = "YESTERDAY";
		public const string _EXPECT = "EXPECT";
		public const string _CREATETIME = "CREATETIME";
		public const string _STATUS = "STATUS";
		public const string _REMARKS = "REMARKS";
		public const string _RECOMMEND = "RECOMMEND";
		public const string _TRANSFER_ID = "TRANSFER_ID";
		public const string _DATECODE = "DATECODE";
		public const string _RECEIVE_TIME = "RECEIVE_TIME";
		public const string _TableName = "TVIP_REWARD";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TVIP_REWARD");
			table.Columns.Add(_REWARD_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_AMOUNT,typeof(decimal)).DefaultValue=0;
			table.Columns.Add(_YESTERDAY,typeof(decimal)).DefaultValue=0;
			table.Columns.Add(_EXPECT,typeof(decimal)).DefaultValue=0;
			table.Columns.Add(_CREATETIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_STATUS,typeof(int)).DefaultValue=0;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_RECOMMEND,typeof(int)).DefaultValue=0;
			table.Columns.Add(_TRANSFER_ID,typeof(int)).DefaultValue=DBNull.Value;
			table.Columns.Add(_DATECODE,typeof(int)).DefaultValue=0;
			table.Columns.Add(_RECEIVE_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 奖励ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Reward_Id
		{
			get{ return Convert.ToInt32(DataRow[_REWARD_ID]);}
			 set{setProperty(_REWARD_ID, value);}
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
		/// 奖励金额(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public decimal Amount
		{
			get{ return Convert.ToDecimal(DataRow[_AMOUNT]);}
			 set{setProperty(_AMOUNT, value);}
		}
		/// <summary>
		/// 昨日返佣(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public decimal Yesterday
		{
			get{ return Convert.ToDecimal(DataRow[_YESTERDAY]);}
			 set{setProperty(_YESTERDAY, value);}
		}
		/// <summary>
		/// 预期收益(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public decimal Expect
		{
			get{ return Convert.ToDecimal(DataRow[_EXPECT]);}
			 set{setProperty(_EXPECT, value);}
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
		/// 领取状态[0：未领取，1：已领取](必填)
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
		/// 推荐会员数量(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Recommend
		{
			get{ return Convert.ToInt32(DataRow[_RECOMMEND]);}
			 set{setProperty(_RECOMMEND, value);}
		}
		/// <summary>
		/// 转账ID(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 22Byte
		/// </para>
		/// </summary>
		public int? Transfer_Id
		{
			get{ return Helper.ToInt32(DataRow[_TRANSFER_ID]);}
			 set{setProperty(_TRANSFER_ID, value);}
		}
		/// <summary>
		/// 日期代码(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Datecode
		{
			get{ return Convert.ToInt32(DataRow[_DATECODE]);}
			 set{setProperty(_DATECODE, value);}
		}
		/// <summary>
		/// 领取时间(可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? Receive_Time
		{
			get{ return Helper.ToDateTime(DataRow[_RECEIVE_TIME]);}
			 set{setProperty(_RECEIVE_TIME, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT REWARD_ID,USER_ID,AMOUNT,YESTERDAY,EXPECT,CREATETIME,STATUS,REMARKS,RECOMMEND,TRANSFER_ID,DATECODE,RECEIVE_TIME FROM TVIP_REWARD WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TVIP_REWARD WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int reward_id)
		{
			string condition = " REWARD_ID=:REWARD_ID";
			AddParameter(_REWARD_ID,reward_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " REWARD_ID=:REWARD_ID";
			AddParameter(_REWARD_ID,DataRow[_REWARD_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Reward_Id = GetSequence("SELECT SEQ_TVIP_REWARD.nextval FROM DUAL");
			string sql = @"INSERT INTO TVIP_REWARD(REWARD_ID,USER_ID,AMOUNT,YESTERDAY,EXPECT,STATUS,REMARKS,RECOMMEND,TRANSFER_ID,DATECODE,RECEIVE_TIME)
			VALUES (:REWARD_ID,:USER_ID,:AMOUNT,:YESTERDAY,:EXPECT,:STATUS,:REMARKS,:RECOMMEND,:TRANSFER_ID,:DATECODE,:RECEIVE_TIME)";
			AddParameter(_REWARD_ID,DataRow[_REWARD_ID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_AMOUNT,DataRow[_AMOUNT]);
			AddParameter(_YESTERDAY,DataRow[_YESTERDAY]);
			AddParameter(_EXPECT,DataRow[_EXPECT]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_RECOMMEND,DataRow[_RECOMMEND]);
			AddParameter(_TRANSFER_ID,DataRow[_TRANSFER_ID]);
			AddParameter(_DATECODE,DataRow[_DATECODE]);
			AddParameter(_RECEIVE_TIME,DataRow[_RECEIVE_TIME]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tvip_RewardCollection.Field,object> alterDic,Dictionary<Tvip_RewardCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tvip_RewardCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tvip_RewardCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_REWARD_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TVIP_REWARD SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE REWARD_ID=:REWARD_ID");
			AddParameter(_REWARD_ID, DataRow[_REWARD_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByUserId_Datecode(int user_id,int datecode)
		{
			string condition = " USER_ID=:USER_ID AND DATECODE=:DATECODE";
			AddParameter(_USER_ID,user_id);
			AddParameter(_DATECODE,datecode);
			return SelectByCondition(condition);
		}
		public bool SelectByPk(int reward_id)
		{
			string condition = " REWARD_ID=:REWARD_ID";
			AddParameter(_REWARD_ID,reward_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	
	public partial class Tvip_RewardCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tvip_RewardCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tvip_Reward().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tvip_Reward(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tvip_Reward._TableName;}
		}
		public Tvip_Reward this[int index]
        {
            get { return new Tvip_Reward(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Reward_Id=0,
			User_Id=1,
			Amount=2,
			Yesterday=3,
			Expect=4,
			Createtime=5,
			Status=6,
			Remarks=7,
			Recommend=8,
			Transfer_Id=9,
			Datecode=10,
			Receive_Time=11,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT REWARD_ID,USER_ID,AMOUNT,YESTERDAY,EXPECT,CREATETIME,STATUS,REMARKS,RECOMMEND,TRANSFER_ID,DATECODE,RECEIVE_TIME FROM TVIP_REWARD WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tvip_Reward Find(Predicate<Tvip_Reward> match)
        {
            foreach (Tvip_Reward item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tvip_RewardCollection FindAll(Predicate<Tvip_Reward> match)
        {
            Tvip_RewardCollection list = new Tvip_RewardCollection();
            foreach (Tvip_Reward item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tvip_Reward> match)
        {
            foreach (Tvip_Reward item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tvip_Reward> match)
        {
            BeginTransaction();
            foreach (Tvip_Reward item in this)
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