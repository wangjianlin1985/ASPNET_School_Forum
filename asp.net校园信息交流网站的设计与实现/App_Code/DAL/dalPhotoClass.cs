using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*照片分类业务逻辑层实现*/
    public class dalPhotoClass
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加照片分类实现*/
        public static bool AddPhotoClass(ENTITY.PhotoClass photoClass)
        {
            string sql = "insert into PhotoClass(photoClassName) values(@photoClassName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@photoClassName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = photoClass.photoClassName; //照片分类名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据photoClassId获取某条照片分类记录*/
        public static ENTITY.PhotoClass getSomePhotoClass(int photoClassId)
        {
            /*构建查询sql*/
            string sql = "select * from PhotoClass where photoClassId=" + photoClassId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.PhotoClass photoClass = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                photoClass = new ENTITY.PhotoClass();
                photoClass.photoClassId = Convert.ToInt32(DataRead["photoClassId"]);
                photoClass.photoClassName = DataRead["photoClassName"].ToString();
            }
            return photoClass;
        }

        /*更新照片分类实现*/
        public static bool EditPhotoClass(ENTITY.PhotoClass photoClass)
        {
            string sql = "update PhotoClass set photoClassName=@photoClassName where photoClassId=@photoClassId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@photoClassName",SqlDbType.VarChar),
             new SqlParameter("@photoClassId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = photoClass.photoClassName;
            parm[1].Value = photoClass.photoClassId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除照片分类*/
        public static bool DelPhotoClass(string p)
        {
            string sql = "delete from PhotoClass where photoClassId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询照片分类*/
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

        /*查询照片分类*/
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
