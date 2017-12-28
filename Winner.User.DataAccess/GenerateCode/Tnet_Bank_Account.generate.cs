   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_Bank_Account.generate.cs
 * CreateTime : 2017-05-12 17:26:19
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
	/// 
	/// </summary>
	public partial class Tnet_Bank_Account : DataAccessBase
	{
		#region 构造和基本
		public Tnet_Bank_Account():base()
		{}
		public Tnet_Bank_Account(DataRow dataRow):base(dataRow)
		{}
		public const string _ID = "ID";
		public const string _USER_ID = "USER_ID";
		public const string _BANK_ID = "BANK_ID";
		public const string _ACCOUNT_NAME = "ACCOUNT_NAME";
		public const string _CARD_NO = "CARD_NO";
		public const string _BRANCH_BANK = "BRANCH_BANK";
		public const string _PROVINCE_NAME = "PROVINCE_NAME";
		public const string _CITY_NAME = "CITY_NAME";
		public const string _BANK_NAME = "BANK_NAME";
		public const string _ACCOUNT_TYPE = "ACCOUNT_TYPE";
		public const string _STATUS = "STATUS";
		public const string _BRANCH_NO = "BRANCH_NO";
		public const string _IMAGE_FULLPATH = "IMAGE_FULLPATH";
		public const string _REMARKS = "REMARKS";
		public const string _CREATETIME = "CREATETIME";
		public const string _PROVINCE_ID = "PROVINCE_ID";
		public const string _CITY_ID = "CITY_ID";
		public const string _TableName = "TNET_BANK_ACCOUNT";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_BANK_ACCOUNT");
			table.Columns.Add(_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_BANK_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_ACCOUNT_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_CARD_NO,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_BRANCH_BANK,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_PROVINCE_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CITY_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_BANK_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_ACCOUNT_TYPE,typeof(int)).DefaultValue=1;
			table.Columns.Add(_STATUS,typeof(int)).DefaultValue=0;
			table.Columns.Add(_BRANCH_NO,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_IMAGE_FULLPATH,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CREATETIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_PROVINCE_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CITY_ID,typeof(int)).DefaultValue=0;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 主键编号(必填)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int Id
		{
			get{ return Convert.ToInt32(DataRow[_ID]);}
			 set{setProperty(_ID, value);}
		}
		/// <summary>
		/// 用户编号(必填)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int User_Id
		{
			get{ return Convert.ToInt32(DataRow[_USER_ID]);}
			 set{setProperty(_USER_ID, value);}
		}
		/// <summary>
		/// 银行信息，关联到银行卡信息表(必填)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int Bank_Id
		{
			get{ return Convert.ToInt32(DataRow[_BANK_ID]);}
			 set{setProperty(_BANK_ID, value);}
		}
		/// <summary>
		/// 开户用户姓名(必填)
		/// <para>
		/// defaultValue:    Length: 40Byte
		/// </para>
		/// </summary>
		public string Account_Name
		{
			get{ return DataRow[_ACCOUNT_NAME].ToString();}
			 set{setProperty(_ACCOUNT_NAME, value);}
		}
		/// <summary>
		/// 银行卡卡号(必填)
		/// <para>
		/// defaultValue:    Length: 20Byte
		/// </para>
		/// </summary>
		public string Card_No
		{
			get{ return DataRow[_CARD_NO].ToString();}
			 set{setProperty(_CARD_NO, value);}
		}
		/// <summary>
		/// 支行信息(可空)
		/// <para>
		/// defaultValue:    Length: 100Byte
		/// </para>
		/// </summary>
		public string Branch_Bank
		{
			get{ return DataRow[_BRANCH_BANK].ToString();}
			 set{setProperty(_BRANCH_BANK, value);}
		}
		/// <summary>
		/// 开户省份(可空)
		/// <para>
		/// defaultValue:    Length: 20Byte
		/// </para>
		/// </summary>
		public string Province_Name
		{
			get{ return DataRow[_PROVINCE_NAME].ToString();}
			 set{setProperty(_PROVINCE_NAME, value);}
		}
		/// <summary>
		/// 开户城市(可空)
		/// <para>
		/// defaultValue:    Length: 20Byte
		/// </para>
		/// </summary>
		public string City_Name
		{
			get{ return DataRow[_CITY_NAME].ToString();}
			 set{setProperty(_CITY_NAME, value);}
		}
		/// <summary>
		/// 银行名称(必填)
		/// <para>
		/// defaultValue:    Length: 50Byte
		/// </para>
		/// </summary>
		public string Bank_Name
		{
			get{ return DataRow[_BANK_NAME].ToString();}
			 set{setProperty(_BANK_NAME, value);}
		}
		/// <summary>
		/// 帐号类型$BankAccountType$[个人账号=1，企业账号=2](必填)
		/// <para>
		/// defaultValue: 1    Length: 22Byte
		/// </para>
		/// </summary>
		public int Account_Type
		{
			get{ return Convert.ToInt32(DataRow[_ACCOUNT_TYPE]);}
			 set{setProperty(_ACCOUNT_TYPE, value);}
		}
		/// <summary>
		/// 银行卡状态$BankStatus${审核中=1,审核通过=2,审核失败=4,删除=8}(必填)
		/// <para>
		/// defaultValue: 0    Length: 22Byte
		/// </para>
		/// </summary>
		public int Status
		{
			get{ return Convert.ToInt32(DataRow[_STATUS]);}
			 set{setProperty(_STATUS, value);}
		}
		/// <summary>
		/// 银行联行号(可空)
		/// <para>
		/// defaultValue:    Length: 15Byte
		/// </para>
		/// </summary>
		public string Branch_No
		{
			get{ return DataRow[_BRANCH_NO].ToString();}
			 set{setProperty(_BRANCH_NO, value);}
		}
		/// <summary>
		/// 手持银行卡图像的完整路径(可空)
		/// <para>
		/// defaultValue:    Length: 200Byte
		/// </para>
		/// </summary>
		public string Image_Fullpath
		{
			get{ return DataRow[_IMAGE_FULLPATH].ToString();}
			 set{setProperty(_IMAGE_FULLPATH, value);}
		}
		/// <summary>
		/// 备注(可空)
		/// <para>
		/// defaultValue:    Length: 1000Byte
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
		/// defaultValue: sysdate    Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Createtime
		{
			get{ return Convert.ToDateTime(DataRow[_CREATETIME]);}
		}
		/// <summary>
		/// 开户省份ID(必填)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int Province_Id
		{
			get{ return Convert.ToInt32(DataRow[_PROVINCE_ID]);}
			 set{setProperty(_PROVINCE_ID, value);}
		}
		/// <summary>
		/// 开户城市ID(必填)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int City_Id
		{
			get{ return Convert.ToInt32(DataRow[_CITY_ID]);}
			 set{setProperty(_CITY_ID, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT ID,USER_ID,BANK_ID,ACCOUNT_NAME,CARD_NO,BRANCH_BANK,PROVINCE_NAME,CITY_NAME,BANK_NAME,ACCOUNT_TYPE,STATUS,BRANCH_NO,IMAGE_FULLPATH,REMARKS,CREATETIME,PROVINCE_ID,CITY_ID FROM TNET_BANK_ACCOUNT WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_BANK_ACCOUNT WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int id)
		{
			string condition = " ID=:ID";
			AddParameter(_ID,id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " ID=:ID";
			AddParameter(_ID,DataRow[_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Id = GetSequence("SELECT SEQ_TNET_BANK_ACCOUNT.nextval FROM DUAL");
			string sql = @"INSERT INTO TNET_BANK_ACCOUNT(ID,USER_ID,BANK_ID,ACCOUNT_NAME,CARD_NO,BRANCH_BANK,PROVINCE_NAME,CITY_NAME,BANK_NAME,ACCOUNT_TYPE,STATUS,BRANCH_NO,IMAGE_FULLPATH,REMARKS,PROVINCE_ID,CITY_ID)
			VALUES (:ID,:USER_ID,:BANK_ID,:ACCOUNT_NAME,:CARD_NO,:BRANCH_BANK,:PROVINCE_NAME,:CITY_NAME,:BANK_NAME,:ACCOUNT_TYPE,:STATUS,:BRANCH_NO,:IMAGE_FULLPATH,:REMARKS,:PROVINCE_ID,:CITY_ID)";
			AddParameter(_ID,DataRow[_ID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_BANK_ID,DataRow[_BANK_ID]);
			AddParameter(_ACCOUNT_NAME,DataRow[_ACCOUNT_NAME]);
			AddParameter(_CARD_NO,DataRow[_CARD_NO]);
			AddParameter(_BRANCH_BANK,DataRow[_BRANCH_BANK]);
			AddParameter(_PROVINCE_NAME,DataRow[_PROVINCE_NAME]);
			AddParameter(_CITY_NAME,DataRow[_CITY_NAME]);
			AddParameter(_BANK_NAME,DataRow[_BANK_NAME]);
			AddParameter(_ACCOUNT_TYPE,DataRow[_ACCOUNT_TYPE]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_BRANCH_NO,DataRow[_BRANCH_NO]);
			AddParameter(_IMAGE_FULLPATH,DataRow[_IMAGE_FULLPATH]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			AddParameter(_PROVINCE_ID,DataRow[_PROVINCE_ID]);
			AddParameter(_CITY_ID,DataRow[_CITY_ID]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_Bank_AccountCollection.Field,object> alterDic,Dictionary<Tnet_Bank_AccountCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_Bank_AccountCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_Bank_AccountCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TNET_BANK_ACCOUNT SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE ID=:ID");
			AddParameter(_ID, DataRow[_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int id)
		{
			string condition = " ID=:ID";
			AddParameter(_ID,id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	
	public partial class Tnet_Bank_AccountCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_Bank_AccountCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_Bank_Account().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_Bank_Account(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_Bank_Account._TableName;}
		}
		public Tnet_Bank_Account this[int index]
        {
            get { return new Tnet_Bank_Account(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Id=0,
			User_Id=1,
			Bank_Id=2,
			Account_Name=3,
			Card_No=4,
			Branch_Bank=5,
			Province_Name=6,
			City_Name=7,
			Bank_Name=8,
			Account_Type=9,
			Status=10,
			Branch_No=11,
			Image_Fullpath=12,
			Remarks=13,
			Createtime=14,
			Province_Id=15,
			City_Id=16,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT ID,USER_ID,BANK_ID,ACCOUNT_NAME,CARD_NO,BRANCH_BANK,PROVINCE_NAME,CITY_NAME,BANK_NAME,ACCOUNT_TYPE,STATUS,BRANCH_NO,IMAGE_FULLPATH,REMARKS,CREATETIME,PROVINCE_ID,CITY_ID FROM TNET_BANK_ACCOUNT WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListByBank_Id(int bank_id)
		{
			string condition = "BANK_ID=:BANK_ID ORDER BY ID DESC";
			AddParameter(Tnet_Bank_Account._BANK_ID,bank_id);
			return ListByCondition(condition);		
		}
		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_Bank_Account Find(Predicate<Tnet_Bank_Account> match)
        {
            foreach (Tnet_Bank_Account item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_Bank_AccountCollection FindAll(Predicate<Tnet_Bank_Account> match)
        {
            Tnet_Bank_AccountCollection list = new Tnet_Bank_AccountCollection();
            foreach (Tnet_Bank_Account item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_Bank_Account> match)
        {
            foreach (Tnet_Bank_Account item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_Bank_Account> match)
        {
            BeginTransaction();
            foreach (Tnet_Bank_Account item in this)
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