using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*网站新闻业务逻辑层实现*/
    public class dalNews
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加网站新闻实现*/
        public static bool AddNews(ENTITY.News news)
        {
            string sql = "insert into News(title,content,publishDate) values(@title,@content,@publishDate)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = news.title; //标题
            parm[1].Value = news.content; //新闻内容
            parm[2].Value = news.publishDate; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据newsId获取某条网站新闻记录*/
        public static ENTITY.News getSomeNews(int newsId)
        {
            /*构建查询sql*/
            string sql = "select * from News where newsId=" + newsId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.News news = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                news = new ENTITY.News();
                news.newsId = Convert.ToInt32(DataRead["newsId"]);
                news.title = DataRead["title"].ToString();
                news.content = DataRead["content"].ToString();
                news.publishDate = Convert.ToDateTime(DataRead["publishDate"].ToString());
            }
            return news;
        }

        /*更新网站新闻实现*/
        public static bool EditNews(ENTITY.News news)
        {
            string sql = "update News set title=@title,content=@content,publishDate=@publishDate where newsId=@newsId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime),
             new SqlParameter("@newsId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = news.title;
            parm[1].Value = news.content;
            parm[2].Value = news.publishDate;
            parm[3].Value = news.newsId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除网站新闻*/
        public static bool DelNews(string p)
        {
            string sql = "delete from News where newsId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询网站新闻*/
        public static DataSet GetNews(string strWhere)
        {
            try
            {
                string strSql = "select * from News" + strWhere + " order by newsId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询网站新闻*/
        public static System.Data.DataTable GetNews(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from News";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "newsId", strShow, strSql, strWhere, " newsId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllNews()
        {
            try
            {
                string strSql = "select * from News";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
