using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*日志分类业务逻辑层实现*/
    public class dalJournalClass
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加日志分类实现*/
        public static bool AddJournalClass(ENTITY.JournalClass journalClass)
        {
            string sql = "insert into JournalClass(journalClassName) values(@journalClassName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalClassName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = journalClass.journalClassName; //日志分类名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据journalClassId获取某条日志分类记录*/
        public static ENTITY.JournalClass getSomeJournalClass(int journalClassId)
        {
            /*构建查询sql*/
            string sql = "select * from JournalClass where journalClassId=" + journalClassId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.JournalClass journalClass = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                journalClass = new ENTITY.JournalClass();
                journalClass.journalClassId = Convert.ToInt32(DataRead["journalClassId"]);
                journalClass.journalClassName = DataRead["journalClassName"].ToString();
            }
            return journalClass;
        }

        /*更新日志分类实现*/
        public static bool EditJournalClass(ENTITY.JournalClass journalClass)
        {
            string sql = "update JournalClass set journalClassName=@journalClassName where journalClassId=@journalClassId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalClassName",SqlDbType.VarChar),
             new SqlParameter("@journalClassId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = journalClass.journalClassName;
            parm[1].Value = journalClass.journalClassId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除日志分类*/
        public static bool DelJournalClass(string p)
        {
            string sql = "delete from JournalClass where journalClassId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询日志分类*/
        public static DataSet GetJournalClass(string strWhere)
        {
            try
            {
                string strSql = "select * from JournalClass" + strWhere + " order by journalClassId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询日志分类*/
        public static System.Data.DataTable GetJournalClass(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from JournalClass";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "journalClassId", strShow, strSql, strWhere, " journalClassId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllJournalClass()
        {
            try
            {
                string strSql = "select * from JournalClass";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
