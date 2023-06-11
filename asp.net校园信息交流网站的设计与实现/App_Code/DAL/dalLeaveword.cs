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
    public class dalLeaveword
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�������ʵ��*/
        public static bool AddLeaveword(ENTITY.Leaveword leaveword)
        {
            string sql = "insert into Leaveword(leaveTitle,leaveContent,questionFile,userObj,leaveTime,replyContent,replyTime) values(@leaveTitle,@leaveContent,@questionFile,@userObj,@leaveTime,@replyContent,@replyTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@leaveTitle",SqlDbType.VarChar),
             new SqlParameter("@leaveContent",SqlDbType.VarChar),
             new SqlParameter("@questionFile",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@leaveTime",SqlDbType.DateTime),
             new SqlParameter("@replyContent",SqlDbType.VarChar),
             new SqlParameter("@replyTime",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = leaveword.leaveTitle; //���Ա���
            parm[1].Value = leaveword.leaveContent; //��������
            parm[2].Value = leaveword.questionFile; //�����ļ�
            parm[3].Value = leaveword.userObj; //������
            parm[4].Value = leaveword.leaveTime; //����ʱ��
            parm[5].Value = leaveword.replyContent; //��ʦ�ظ�
            parm[6].Value = leaveword.replyTime; //�ظ�ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����leaveWordId��ȡĳ�����Լ�¼*/
        public static ENTITY.Leaveword getSomeLeaveword(int leaveWordId)
        {
            /*������ѯsql*/
            string sql = "select * from Leaveword where leaveWordId=" + leaveWordId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Leaveword leaveword = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                leaveword = new ENTITY.Leaveword();
                leaveword.leaveWordId = Convert.ToInt32(DataRead["leaveWordId"]);
                leaveword.leaveTitle = DataRead["leaveTitle"].ToString();
                leaveword.leaveContent = DataRead["leaveContent"].ToString();
                leaveword.questionFile = DataRead["questionFile"].ToString();
                leaveword.userObj = DataRead["userObj"].ToString();
                leaveword.leaveTime = Convert.ToDateTime(DataRead["leaveTime"].ToString());
                leaveword.replyContent = DataRead["replyContent"].ToString();
                leaveword.replyTime = DataRead["replyTime"].ToString();
            }
            return leaveword;
        }

        /*��������ʵ��*/
        public static bool EditLeaveword(ENTITY.Leaveword leaveword)
        {
            string sql = "update Leaveword set leaveTitle=@leaveTitle,leaveContent=@leaveContent,questionFile=@questionFile,userObj=@userObj,leaveTime=@leaveTime,replyContent=@replyContent,replyTime=@replyTime where leaveWordId=@leaveWordId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@leaveTitle",SqlDbType.VarChar),
             new SqlParameter("@leaveContent",SqlDbType.VarChar),
             new SqlParameter("@questionFile",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@leaveTime",SqlDbType.DateTime),
             new SqlParameter("@replyContent",SqlDbType.VarChar),
             new SqlParameter("@replyTime",SqlDbType.VarChar),
             new SqlParameter("@leaveWordId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = leaveword.leaveTitle;
            parm[1].Value = leaveword.leaveContent;
            parm[2].Value = leaveword.questionFile;
            parm[3].Value = leaveword.userObj;
            parm[4].Value = leaveword.leaveTime;
            parm[5].Value = leaveword.replyContent;
            parm[6].Value = leaveword.replyTime;
            parm[7].Value = leaveword.leaveWordId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������*/
        public static bool DelLeaveword(string p)
        {
            string sql = "delete from Leaveword where leaveWordId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����*/
        public static DataSet GetLeaveword(string strWhere)
        {
            try
            {
                string strSql = "select * from Leaveword" + strWhere + " order by leaveWordId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ����*/
        public static System.Data.DataTable GetLeaveword(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Leaveword";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "leaveWordId", strShow, strSql, strWhere, " leaveWordId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllLeaveword()
        {
            try
            {
                string strSql = "select * from Leaveword";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
