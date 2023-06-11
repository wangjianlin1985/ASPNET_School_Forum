using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*������־ҵ���߼���ʵ��*/
    public class dalJournal
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���������־ʵ��*/
        public static bool AddJournal(ENTITY.Journal journal)
        {
            string sql = "insert into Journal(journalClassObj,title,content,userObj,addTime) values(@journalClassObj,@title,@content,@userObj,@addTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalClassObj",SqlDbType.Int),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = journal.journalClassObj; //��־����
            parm[1].Value = journal.title; //����
            parm[2].Value = journal.content; //��־����
            parm[3].Value = journal.userObj; //�����û�
            parm[4].Value = journal.addTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����postId��ȡĳ��������־��¼*/
        public static ENTITY.Journal getSomeJournal(int postId)
        {
            /*������ѯsql*/
            string sql = "select * from Journal where postId=" + postId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Journal journal = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                journal = new ENTITY.Journal();
                journal.postId = Convert.ToInt32(DataRead["postId"]);
                journal.journalClassObj = Convert.ToInt32(DataRead["journalClassObj"]);
                journal.title = DataRead["title"].ToString();
                journal.content = DataRead["content"].ToString();
                journal.userObj = DataRead["userObj"].ToString();
                journal.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return journal;
        }

        /*����������־ʵ��*/
        public static bool EditJournal(ENTITY.Journal journal)
        {
            string sql = "update Journal set journalClassObj=@journalClassObj,title=@title,content=@content,userObj=@userObj,addTime=@addTime where postId=@postId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalClassObj",SqlDbType.Int),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@postId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = journal.journalClassObj;
            parm[1].Value = journal.title;
            parm[2].Value = journal.content;
            parm[3].Value = journal.userObj;
            parm[4].Value = journal.addTime;
            parm[5].Value = journal.postId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��������־*/
        public static bool DelJournal(string p)
        {
            string sql = "delete from Journal where postId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ������־*/
        public static DataSet GetJournal(string strWhere)
        {
            try
            {
                string strSql = "select * from Journal" + strWhere + " order by postId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ������־*/
        public static System.Data.DataTable GetJournal(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Journal";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "postId", strShow, strSql, strWhere, " postId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllJournal()
        {
            try
            {
                string strSql = "select * from Journal";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
