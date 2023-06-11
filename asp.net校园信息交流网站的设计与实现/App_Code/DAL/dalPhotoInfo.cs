using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*照片业务逻辑层实现*/
    public class dalPhotoInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加照片实现*/
        public static bool AddPhotoInfo(ENTITY.PhotoInfo photoInfo)
        {
            string sql = "insert into PhotoInfo(photoClassObj,photoName,photoImage,userObj,addTime) values(@photoClassObj,@photoName,@photoImage,@userObj,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@photoClassObj",SqlDbType.Int),
             new SqlParameter("@photoName",SqlDbType.VarChar),
             new SqlParameter("@photoImage",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = photoInfo.photoClassObj; //照片分类
            parm[1].Value = photoInfo.photoName; //照片名称
            parm[2].Value = photoInfo.photoImage; //照片文件
            parm[3].Value = photoInfo.userObj; //发布用户
            parm[4].Value = photoInfo.addTime; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据photoId获取某条照片记录*/
        public static ENTITY.PhotoInfo getSomePhotoInfo(int photoId)
        {
            /*构建查询sql*/
            string sql = "select * from PhotoInfo where photoId=" + photoId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.PhotoInfo photoInfo = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                photoInfo = new ENTITY.PhotoInfo();
                photoInfo.photoId = Convert.ToInt32(DataRead["photoId"]);
                photoInfo.photoClassObj = Convert.ToInt32(DataRead["photoClassObj"]);
                photoInfo.photoName = DataRead["photoName"].ToString();
                photoInfo.photoImage = DataRead["photoImage"].ToString();
                photoInfo.userObj = DataRead["userObj"].ToString();
                photoInfo.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return photoInfo;
        }

        /*更新照片实现*/
        public static bool EditPhotoInfo(ENTITY.PhotoInfo photoInfo)
        {
            string sql = "update PhotoInfo set photoClassObj=@photoClassObj,photoName=@photoName,photoImage=@photoImage,userObj=@userObj,addTime=@addTime where photoId=@photoId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@photoClassObj",SqlDbType.Int),
             new SqlParameter("@photoName",SqlDbType.VarChar),
             new SqlParameter("@photoImage",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@photoId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = photoInfo.photoClassObj;
            parm[1].Value = photoInfo.photoName;
            parm[2].Value = photoInfo.photoImage;
            parm[3].Value = photoInfo.userObj;
            parm[4].Value = photoInfo.addTime;
            parm[5].Value = photoInfo.photoId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除照片*/
        public static bool DelPhotoInfo(string p)
        {
            string sql = "delete from PhotoInfo where photoId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询照片*/
        public static DataSet GetPhotoInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from PhotoInfo" + strWhere + " order by photoId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询照片*/
        public static System.Data.DataTable GetPhotoInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from PhotoInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "photoId", strShow, strSql, strWhere, " photoId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllPhotoInfo()
        {
            try
            {
                string strSql = "select * from PhotoInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
