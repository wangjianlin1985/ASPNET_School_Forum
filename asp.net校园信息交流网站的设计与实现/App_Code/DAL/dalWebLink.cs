using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��������ҵ���߼���ʵ��*/
    public class dalWebLink
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����������ʵ��*/
        public static bool AddWebLink(ENTITY.WebLink webLink)
        {
            string sql = "insert into WebLink(webName,webLogo,webAddress) values(@webName,@webLogo,@webAddress)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@webName",SqlDbType.VarChar),
             new SqlParameter("@webLogo",SqlDbType.VarChar),
             new SqlParameter("@webAddress",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = webLink.webName; //��վ����
            parm[1].Value = webLink.webLogo; //��վLogo
            parm[2].Value = webLink.webAddress; //��վ��ַ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����linkId��ȡĳ���������Ӽ�¼*/
        public static ENTITY.WebLink getSomeWebLink(int linkId)
        {
            /*������ѯsql*/
            string sql = "select * from WebLink where linkId=" + linkId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.WebLink webLink = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*������������ʵ��*/
        public static bool EditWebLink(ENTITY.WebLink webLink)
        {
            string sql = "update WebLink set webName=@webName,webLogo=@webLogo,webAddress=@webAddress where linkId=@linkId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@webName",SqlDbType.VarChar),
             new SqlParameter("@webLogo",SqlDbType.VarChar),
             new SqlParameter("@webAddress",SqlDbType.VarChar),
             new SqlParameter("@linkId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = webLink.webName;
            parm[1].Value = webLink.webLogo;
            parm[2].Value = webLink.webAddress;
            parm[3].Value = webLink.linkId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����������*/
        public static bool DelWebLink(string p)
        {
            string sql = "delete from WebLink where linkId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��������*/
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

        /*��ѯ��������*/
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
