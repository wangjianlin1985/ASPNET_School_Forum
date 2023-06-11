using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*评论业务逻辑层实现*/
    public class dalComment
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加评论实现*/
        public static bool AddComment(ENTITY.Comment comment)
        {
            string sql = "insert into Comment(journalObj,content,userObj,commentTime) values(@journalObj,@content,@userObj,@commentTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = comment.journalObj; //被评日志
            parm[1].Value = comment.content; //评论内容
            parm[2].Value = comment.userObj; //评论用户
            parm[3].Value = comment.commentTime; //评论时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据commentId获取某条评论记录*/
        public static ENTITY.Comment getSomeComment(int commentId)
        {
            /*构建查询sql*/
            string sql = "select * from Comment where commentId=" + commentId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Comment comment = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新评论实现*/
        public static bool EditComment(ENTITY.Comment comment)
        {
            string sql = "update Comment set journalObj=@journalObj,content=@content,userObj=@userObj,commentTime=@commentTime where commentId=@commentId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar),
             new SqlParameter("@commentId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = comment.journalObj;
            parm[1].Value = comment.content;
            parm[2].Value = comment.userObj;
            parm[3].Value = comment.commentTime;
            parm[4].Value = comment.commentId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除评论*/
        public static bool DelComment(string p)
        {
            string sql = "delete from Comment where commentId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询评论*/
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

        /*查询评论*/
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
