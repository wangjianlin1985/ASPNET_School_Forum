using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*留言业务逻辑层实现*/
    public class dalLeaveword
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加留言实现*/
        public static bool AddLeaveword(ENTITY.Leaveword leaveword)
        {
            string sql = "insert into Leaveword(leaveTitle,leaveContent,questionFile,userObj,leaveTime,replyContent,replyTime) values(@leaveTitle,@leaveContent,@questionFile,@userObj,@leaveTime,@replyContent,@replyTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@leaveTitle",SqlDbType.VarChar),
             new SqlParameter("@leaveContent",SqlDbType.VarChar),
             new SqlParameter("@questionFile",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@leaveTime",SqlDbType.DateTime),
             new SqlParameter("@replyContent",SqlDbType.VarChar),
             new SqlParameter("@replyTime",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = leaveword.leaveTitle; //留言标题
            parm[1].Value = leaveword.leaveContent; //留言内容
            parm[2].Value = leaveword.questionFile; //提问文件
            parm[3].Value = leaveword.userObj; //留言人
            parm[4].Value = leaveword.leaveTime; //留言时间
            parm[5].Value = leaveword.replyContent; //老师回复
            parm[6].Value = leaveword.replyTime; //回复时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据leaveWordId获取某条留言记录*/
        public static ENTITY.Leaveword getSomeLeaveword(int leaveWordId)
        {
            /*构建查询sql*/
            string sql = "select * from Leaveword where leaveWordId=" + leaveWordId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Leaveword leaveword = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新留言实现*/
        public static bool EditLeaveword(ENTITY.Leaveword leaveword)
        {
            string sql = "update Leaveword set leaveTitle=@leaveTitle,leaveContent=@leaveContent,questionFile=@questionFile,userObj=@userObj,leaveTime=@leaveTime,replyContent=@replyContent,replyTime=@replyTime where leaveWordId=@leaveWordId";
            /*构建sql参数信息*/
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
            /*为参数赋值*/
            parm[0].Value = leaveword.leaveTitle;
            parm[1].Value = leaveword.leaveContent;
            parm[2].Value = leaveword.questionFile;
            parm[3].Value = leaveword.userObj;
            parm[4].Value = leaveword.leaveTime;
            parm[5].Value = leaveword.replyContent;
            parm[6].Value = leaveword.replyTime;
            parm[7].Value = leaveword.leaveWordId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除留言*/
        public static bool DelLeaveword(string p)
        {
            string sql = "delete from Leaveword where leaveWordId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询留言*/
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

        /*查询留言*/
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
