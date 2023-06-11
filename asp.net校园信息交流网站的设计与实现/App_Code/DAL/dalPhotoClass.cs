using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ƭ����ҵ���߼���ʵ��*/
    public class dalPhotoClass
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ƭ����ʵ��*/
        public static bool AddPhotoClass(ENTITY.PhotoClass photoClass)
        {
            string sql = "insert into PhotoClass(photoClassName) values(@photoClassName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@photoClassName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = photoClass.photoClassName; //��Ƭ��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����photoClassId��ȡĳ����Ƭ�����¼*/
        public static ENTITY.PhotoClass getSomePhotoClass(int photoClassId)
        {
            /*������ѯsql*/
            string sql = "select * from PhotoClass where photoClassId=" + photoClassId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.PhotoClass photoClass = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                photoClass = new ENTITY.PhotoClass();
                photoClass.photoClassId = Convert.ToInt32(DataRead["photoClassId"]);
                photoClass.photoClassName = DataRead["photoClassName"].ToString();
            }
            return photoClass;
        }

        /*������Ƭ����ʵ��*/
        public static bool EditPhotoClass(ENTITY.PhotoClass photoClass)
        {
            string sql = "update PhotoClass set photoClassName=@photoClassName where photoClassId=@photoClassId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@photoClassName",SqlDbType.VarChar),
             new SqlParameter("@photoClassId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = photoClass.photoClassName;
            parm[1].Value = photoClass.photoClassId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ƭ����*/
        public static bool DelPhotoClass(string p)
        {
            string sql = "delete from PhotoClass where photoClassId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ƭ����*/
        public static DataSet GetPhotoClass(string strWhere)
        {
            try
            {
                string strSql = "select * from PhotoClass" + strWhere + " order by photoClassId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��Ƭ����*/
        public static System.Data.DataTable GetPhotoClass(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from PhotoClass";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "photoClassId", strShow, strSql, strWhere, " photoClassId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllPhotoClass()
        {
            try
            {
                string strSql = "select * from PhotoClass";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
