using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*����ҵ���߼���ʵ��*/
    public class dalComment
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�������ʵ��*/
        public static bool AddComment(ENTITY.Comment comment)
        {
            string sql = "insert into Comment(journalObj,content,userObj,commentTime) values(@journalObj,@content,@userObj,@commentTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = comment.journalObj; //������־
            parm[1].Value = comment.content; //��������
            parm[2].Value = comment.userObj; //�����û�
            parm[3].Value = comment.commentTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����commentId��ȡĳ�����ۼ�¼*/
        public static ENTITY.Comment getSomeComment(int commentId)
        {
            /*������ѯsql*/
            string sql = "select * from Comment where commentId=" + commentId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Comment comment = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                comment = new ENTITY.Comment();
                comment.commentId = Convert.ToInt32(DataRead["commentId"]);
                comment.journalObj = Convert.ToInt32(DataRead["journalObj"]);
                comment.content = DataRead["content"].ToString();
                comment.userObj = DataRead["userObj"].ToString();
                comment.commentTime = DataRead["commentTime"].ToString();
            }
            return comment;
        }

        /*��������ʵ��*/
        public static bool EditComment(ENTITY.Comment comment)
        {
            string sql = "update Comment set journalObj=@journalObj,content=@content,userObj=@userObj,commentTime=@commentTime where commentId=@commentId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar),
             new SqlParameter("@commentId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = comment.journalObj;
            parm[1].Value = comment.content;
            parm[2].Value = comment.userObj;
            parm[3].Value = comment.commentTime;
            parm[4].Value = comment.commentId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������*/
        public static bool DelComment(string p)
        {
            string sql = "delete from Comment where commentId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����*/
        public static DataSet GetComment(string strWhere)
        {
            try
            {
                string strSql = "select * from Comment" + strWhere + " order by commentId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ����*/
        public static System.Data.DataTable GetComment(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Comment";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "commentId", strShow, strSql, strWhere, " commentId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllComment()
        {
            try
            {
                string strSql = "select * from Comment";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
