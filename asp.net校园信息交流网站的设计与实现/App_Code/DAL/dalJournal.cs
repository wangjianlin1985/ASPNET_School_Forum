using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*帖子日志业务逻辑层实现*/
    public class dalJournal
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加帖子日志实现*/
        public static bool AddJournal(ENTITY.Journal journal)
        {
            string sql = "insert into Journal(journalClassObj,title,content,userObj,addTime) values(@journalClassObj,@title,@content,@userObj,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalClassObj",SqlDbType.Int),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = journal.journalClassObj; //日志分类
            parm[1].Value = journal.title; //标题
            parm[2].Value = journal.content; //日志内容
            parm[3].Value = journal.userObj; //发布用户
            parm[4].Value = journal.addTime; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据postId获取某条帖子日志记录*/
        public static ENTITY.Journal getSomeJournal(int postId)
        {
            /*构建查询sql*/
            string sql = "select * from Journal where postId=" + postId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Journal journal = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新帖子日志实现*/
        public static bool EditJournal(ENTITY.Journal journal)
        {
            string sql = "update Journal set journalClassObj=@journalClassObj,title=@title,content=@content,userObj=@userObj,addTime=@addTime where postId=@postId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@journalClassObj",SqlDbType.Int),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@postId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = journal.journalClassObj;
            parm[1].Value = journal.title;
            parm[2].Value = journal.content;
            parm[3].Value = journal.userObj;
            parm[4].Value = journal.addTime;
            parm[5].Value = journal.postId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除帖子日志*/
        public static bool DelJournal(string p)
        {
            string sql = "delete from Journal where postId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询帖子日志*/
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

        /*查询帖子日志*/
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
