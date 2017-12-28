   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tnet_Identity.generate.cs
 * CreateTime : 2017-05-12 17:26:20
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
	/// 身份证信息
	/// </summary>
	public partial class Tnet_Identity : DataAccessBase
	{
		#region 构造和基本
		public Tnet_Identity():base()
		{}
		public Tnet_Identity(DataRow dataRow):base(dataRow)
		{}
		public const string _ID = "ID";
		public const string _USER_NAME = "USER_NAME";
		public const string _IDENTITY_NO = "IDENTITY_NO";
		public const string _BIRTHDAY = "BIRTHDAY";
		public const string _SEX = "SEX";
		public const string _NATION = "NATION";
		public const string _BEGIN_TIME = "BEGIN_TIME";
		public const string _END_TIME = "END_TIME";
		public const string _ISSUING = "ISSUING";
		public const string _STATUS = "STATUS";
		public const string _REGION_ID = "REGION_ID";
		public const string _ADDRESS = "ADDRESS";
		public const string _HEAD_PHOTO = "HEAD_PHOTO";
		public const string _FRONT_PHOTO = "FRONT_PHOTO";
		public const string _BACK_PHOTO = "BACK_PHOTO";
		public const string _SCENE_PHOTO = "SCENE_PHOTO";
		public const string _REMARKS = "REMARKS";
		public const string _CREATE_TIME = "CREATE_TIME";
		public const string _TableName = "TNET_IDENTITY";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TNET_IDENTITY");
			table.Columns.Add(_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_IDENTITY_NO,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_BIRTHDAY,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_SEX,typeof(int)).DefaultValue=0;
			table.Columns.Add(_NATION,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_BEGIN_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_END_TIME,typeof(DateTime)).DefaultValue=DBNull.Value;
			table.Columns.Add(_ISSUING,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_STATUS,typeof(int)).DefaultValue=0;
			table.Columns.Add(_REGION_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_ADDRESS,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_HEAD_PHOTO,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_FRONT_PHOTO,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_BACK_PHOTO,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_SCENE_PHOTO,typeof(string)).DefaultValue=DBNull.Value;
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
		/// 主键(必填)
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
		/// 证件用户姓名(必填)
		/// <para>
		/// defaultValue:    Length: 20Byte
		/// </para>
		/// </summary>
		public string User_Name
		{
			get{ return DataRow[_USER_NAME].ToString();}
			 set{setProperty(_USER_NAME, value);}
		}
		/// <summary>
		/// 证件号码(必填)
		/// <para>
		/// defaultValue:    Length: 20Byte
		/// </para>
		/// </summary>
		public string Identity_No
		{
			get{ return DataRow[_IDENTITY_NO].ToString();}
			 set{setProperty(_IDENTITY_NO, value);}
		}
		/// <summary>
		/// 出生日期(必填)
		/// <para>
		/// defaultValue:    Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Birthday
		{
			get{ return Convert.ToDateTime(DataRow[_BIRTHDAY]);}
			 set{setProperty(_BIRTHDAY, value);}
		}
		/// <summary>
		/// 性别{女=0,男=1}(必填)
		/// <para>
		/// defaultValue: 0    Length: 22Byte
		/// </para>
		/// </summary>
		public int Sex
		{
			get{ return Convert.ToInt32(DataRow[_SEX]);}
			 set{setProperty(_SEX, value);}
		}
		/// <summary>
		/// 民族(可空)
		/// <para>
		/// defaultValue:    Length: 200Byte
		/// </para>
		/// </summary>
		public string Nation
		{
			get{ return DataRow[_NATION].ToString();}
			 set{setProperty(_NATION, value);}
		}
		/// <summary>
		/// 有效期开始时间(可空)
		/// <para>
		/// defaultValue:    Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? Begin_Time
		{
			get{ return Helper.ToDateTime(DataRow[_BEGIN_TIME]);}
			 set{setProperty(_BEGIN_TIME, value);}
		}
		/// <summary>
		/// 有效期结束时间(可空)
		/// <para>
		/// defaultValue:    Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime? End_Time
		{
			get{ return Helper.ToDateTime(DataRow[_END_TIME]);}
			 set{setProperty(_END_TIME, value);}
		}
		/// <summary>
		/// 签发机关(可空)
		/// <para>
		/// defaultValue:    Length: 400Byte
		/// </para>
		/// </summary>
		public string Issuing
		{
			get{ return DataRow[_ISSUING].ToString();}
			 set{setProperty(_ISSUING, value);}
		}
		/// <summary>
		/// 状态$DataStatus${禁用=0,正常=1,删除=2}(必填)
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
		/// 所在市区(必填)
		/// <para>
		/// defaultValue:    Length: 22Byte
		/// </para>
		/// </summary>
		public int Region_Id
		{
			get{ return Convert.ToInt32(DataRow[_REGION_ID]);}
			 set{setProperty(_REGION_ID, value);}
		}
		/// <summary>
		/// 详细地址(可空)
		/// <para>
		/// defaultValue:    Length: 400Byte
		/// </para>
		/// </summary>
		public string Address
		{
			get{ return DataRow[_ADDRESS].ToString();}
			 set{setProperty(_ADDRESS, value);}
		}
		/// <summary>
		/// 证件头像(可空)
		/// <para>
		/// defaultValue:    Length: 200Byte
		/// </para>
		/// </summary>
		public string Head_Photo
		{
			get{ return DataRow[_HEAD_PHOTO].ToString();}
			 set{setProperty(_HEAD_PHOTO, value);}
		}
		/// <summary>
		/// 正面图片(可空)
		/// <para>
		/// defaultValue:    Length: 200Byte
		/// </para>
		/// </summary>
		public string Front_Photo
		{
			get{ return DataRow[_FRONT_PHOTO].ToString();}
			 set{setProperty(_FRONT_PHOTO, value);}
		}
		/// <summary>
		/// 背面图片(可空)
		/// <para>
		/// defaultValue:    Length: 200Byte
		/// </para>
		/// </summary>
		public string Back_Photo
		{
			get{ return DataRow[_BACK_PHOTO].ToString();}
			 set{setProperty(_BACK_PHOTO, value);}
		}
		/// <summary>
		/// 现场合影图片(可空)
		/// <para>
		/// defaultValue:    Length: 200Byte
		/// </para>
		/// </summary>
		public string Scene_Photo
		{
			get{ return DataRow[_SCENE_PHOTO].ToString();}
			 set{setProperty(_SCENE_PHOTO, value);}
		}
		/// <summary>
		/// 备注(可空)
		/// <para>
		/// defaultValue:    Length: 400Byte
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
		public DateTime Create_Time
		{
			get{ return Convert.ToDateTime(DataRow[_CREATE_TIME]);}
			 set{setProperty(_CREATE_TIME, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT ID,USER_NAME,IDENTITY_NO,BIRTHDAY,SEX,NATION,BEGIN_TIME,END_TIME,ISSUING,STATUS,REGION_ID,ADDRESS,HEAD_PHOTO,FRONT_PHOTO,BACK_PHOTO,SCENE_PHOTO,REMARKS,CREATE_TIME FROM TNET_IDENTITY WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TNET_IDENTITY WHERE "+condition;
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
			int id = this.Id = GetSequence("SELECT SEQ_TNET_IDENTITY.nextval FROM DUAL");
			string sql = @"INSERT INTO TNET_IDENTITY(ID,USER_NAME,IDENTITY_NO,BIRTHDAY,SEX,NATION,BEGIN_TIME,END_TIME,ISSUING,STATUS,REGION_ID,ADDRESS,HEAD_PHOTO,FRONT_PHOTO,BACK_PHOTO,SCENE_PHOTO,REMARKS)
			VALUES (:ID,:USER_NAME,:IDENTITY_NO,:BIRTHDAY,:SEX,:NATION,:BEGIN_TIME,:END_TIME,:ISSUING,:STATUS,:REGION_ID,:ADDRESS,:HEAD_PHOTO,:FRONT_PHOTO,:BACK_PHOTO,:SCENE_PHOTO,:REMARKS)";
			AddParameter(_ID,DataRow[_ID]);
			AddParameter(_USER_NAME,DataRow[_USER_NAME]);
			AddParameter(_IDENTITY_NO,DataRow[_IDENTITY_NO]);
			AddParameter(_BIRTHDAY,DataRow[_BIRTHDAY]);
			AddParameter(_SEX,DataRow[_SEX]);
			AddParameter(_NATION,DataRow[_NATION]);
			AddParameter(_BEGIN_TIME,DataRow[_BEGIN_TIME]);
			AddParameter(_END_TIME,DataRow[_END_TIME]);
			AddParameter(_ISSUING,DataRow[_ISSUING]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_REGION_ID,DataRow[_REGION_ID]);
			AddParameter(_ADDRESS,DataRow[_ADDRESS]);
			AddParameter(_HEAD_PHOTO,DataRow[_HEAD_PHOTO]);
			AddParameter(_FRONT_PHOTO,DataRow[_FRONT_PHOTO]);
			AddParameter(_BACK_PHOTO,DataRow[_BACK_PHOTO]);
			AddParameter(_SCENE_PHOTO,DataRow[_SCENE_PHOTO]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tnet_IdentityCollection.Field,object> alterDic,Dictionary<Tnet_IdentityCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tnet_IdentityCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tnet_IdentityCollection.Field key in conditionDic.Keys)
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
            sql.AppendLine("UPDATE TNET_IDENTITY SET");
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
		public bool SelectByIdentity_No(string identity_no)
		{
			string condition = " LOWER(IDENTITY_NO)=LOWER(:IDENTITY_NO)";
			AddParameter(_IDENTITY_NO,identity_no);
			return SelectByCondition(condition);
		}
		public bool SelectByPk(int id)
		{
			string condition = " ID=:ID";
			AddParameter(_ID,id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	
	public partial class Tnet_IdentityCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tnet_IdentityCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tnet_Identity().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tnet_Identity(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tnet_Identity._TableName;}
		}
		public Tnet_Identity this[int index]
        {
            get { return new Tnet_Identity(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Id=0,
			User_Name=1,
			Identity_No=2,
			Birthday=3,
			Sex=4,
			Nation=5,
			Begin_Time=6,
			End_Time=7,
			Issuing=8,
			Status=9,
			Region_Id=10,
			Address=11,
			Head_Photo=12,
			Front_Photo=13,
			Back_Photo=14,
			Scene_Photo=15,
			Remarks=16,
			Create_Time=17,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT ID,USER_NAME,IDENTITY_NO,BIRTHDAY,SEX,NATION,BEGIN_TIME,END_TIME,ISSUING,STATUS,REGION_ID,ADDRESS,HEAD_PHOTO,FRONT_PHOTO,BACK_PHOTO,SCENE_PHOTO,REMARKS,CREATE_TIME FROM TNET_IDENTITY WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tnet_Identity Find(Predicate<Tnet_Identity> match)
        {
            foreach (Tnet_Identity item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tnet_IdentityCollection FindAll(Predicate<Tnet_Identity> match)
        {
            Tnet_IdentityCollection list = new Tnet_IdentityCollection();
            foreach (Tnet_Identity item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tnet_Identity> match)
        {
            foreach (Tnet_Identity item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tnet_Identity> match)
        {
            BeginTransaction();
            foreach (Tnet_Identity item in this)
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