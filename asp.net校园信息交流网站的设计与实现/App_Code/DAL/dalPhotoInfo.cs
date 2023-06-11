using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ƭҵ���߼���ʵ��*/
    public class dalPhotoInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ƭʵ��*/
        public static bool AddPhotoInfo(ENTITY.PhotoInfo photoInfo)
        {
            string sql = "insert into PhotoInfo(photoClassObj,photoName,photoImage,userObj,addTime) values(@photoClassObj,@photoName,@photoImage,@userObj,@addTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@photoClassObj",SqlDbType.Int),
             new SqlParameter("@photoName",SqlDbType.VarChar),
             new SqlParameter("@photoImage",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = photoInfo.photoClassObj; //��Ƭ����
            parm[1].Value = photoInfo.photoName; //��Ƭ����
            parm[2].Value = photoInfo.photoImage; //��Ƭ�ļ�
            parm[3].Value = photoInfo.userObj; //�����û�
            parm[4].Value = photoInfo.addTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����photoId��ȡĳ����Ƭ��¼*/
        public static ENTITY.PhotoInfo getSomePhotoInfo(int photoId)
        {
            /*������ѯsql*/
            string sql = "select * from PhotoInfo where photoId=" + photoId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.PhotoInfo photoInfo = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*������Ƭʵ��*/
        public static bool EditPhotoInfo(ENTITY.PhotoInfo photoInfo)
        {
            string sql = "update PhotoInfo set photoClassObj=@photoClassObj,photoName=@photoName,photoImage=@photoImage,userObj=@userObj,addTime=@addTime where photoId=@photoId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@photoClassObj",SqlDbType.Int),
             new SqlParameter("@photoName",SqlDbType.VarChar),
             new SqlParameter("@photoImage",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@photoId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = photoInfo.photoClassObj;
            parm[1].Value = photoInfo.photoName;
            parm[2].Value = photoInfo.photoImage;
            parm[3].Value = photoInfo.userObj;
            parm[4].Value = photoInfo.addTime;
            parm[5].Value = photoInfo.photoId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ƭ*/
        public static bool DelPhotoInfo(string p)
        {
            string sql = "delete from PhotoInfo where photoId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ƭ*/
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

        /*��ѯ��Ƭ*/
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
