using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*友情链接业务逻辑层实现*/
    public class dalWebLink
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加友情链接实现*/
        public static bool AddWebLink(ENTITY.WebLink webLink)
        {
            string sql = "insert into WebLink(webName,webLogo,webAddress) values(@webName,@webLogo,@webAddress)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@webName",SqlDbType.VarChar),
             new SqlParameter("@webLogo",SqlDbType.VarChar),
             new SqlParameter("@webAddress",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = webLink.webName; //网站名称
            parm[1].Value = webLink.webLogo; //网站Logo
            parm[2].Value = webLink.webAddress; //网站地址

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据linkId获取某条友情链接记录*/
        public static ENTITY.WebLink getSomeWebLink(int linkId)
        {
            /*构建查询sql*/
            string sql = "select * from WebLink where linkId=" + linkId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.WebLink webLink = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                webLink = new ENTITY.WebLink();
                webLink.linkId = Convert.ToInt32(DataRead["linkId"]);
                webLink.webName = DataRead["webName"].ToString();
                webLink.webLogo = DataRead["webLogo"].ToString();
                webLink.webAddress = DataRead["webAddress"].ToString();
            }
            return webLink;
        }

        /*更新友情链接实现*/
        public static bool EditWebLink(ENTITY.WebLink webLink)
        {
            string sql = "update WebLink set webName=@webName,webLogo=@webLogo,webAddress=@webAddress where linkId=@linkId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@webName",SqlDbType.VarChar),
             new SqlParameter("@webLogo",SqlDbType.VarChar),
             new SqlParameter("@webAddress",SqlDbType.VarChar),
             new SqlParameter("@linkId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = webLink.webName;
            parm[1].Value = webLink.webLogo;
            parm[2].Value = webLink.webAddress;
            parm[3].Value = webLink.linkId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除友情链接*/
        public static bool DelWebLink(string p)
        {
            string sql = "delete from WebLink where linkId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询友情链接*/
        public static DataSet GetWebLink(string strWhere)
        {
            try
            {
                string strSql = "select * from WebLink" + strWhere + " order by linkId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询友情链接*/
        public static System.Data.DataTable GetWebLink(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from WebLink";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "linkId", strShow, strSql, strWhere, " linkId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllWebLink()
        {
            try
            {
                string strSql = "select * from WebLink";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
