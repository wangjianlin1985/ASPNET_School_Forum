using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��־����ҵ���߼���ʵ��*/
    public class dalJournalClass
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����־����ʵ��*/
        public static bool AddJournalClass(ENTITY.JournalClass journalClass)
        {
            string sql = "insert into JournalClass(journalClassName) values(@journalClassName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalClassName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = journalClass.journalClassName; //��־��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����journalClassId��ȡĳ����־�����¼*/
        public static ENTITY.JournalClass getSomeJournalClass(int journalClassId)
        {
            /*������ѯsql*/
            string sql = "select * from JournalClass where journalClassId=" + journalClassId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.JournalClass journalClass = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                journalClass = new ENTITY.JournalClass();
                journalClass.journalClassId = Convert.ToInt32(DataRead["journalClassId"]);
                journalClass.journalClassName = DataRead["journalClassName"].ToString();
            }
            return journalClass;
        }

        /*������־����ʵ��*/
        public static bool EditJournalClass(ENTITY.JournalClass journalClass)
        {
            string sql = "update JournalClass set journalClassName=@journalClassName where journalClassId=@journalClassId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalClassName",SqlDbType.VarChar),
             new SqlParameter("@journalClassId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = journalClass.journalClassName;
            parm[1].Value = journalClass.journalClassId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����־����*/
        public static bool DelJournalClass(string p)
        {
            string sql = "delete from JournalClass where journalClassId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��־����*/
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

        /*��ѯ��־����*/
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
