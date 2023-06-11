using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*教师业务逻辑层实现*/
    public class dalTeacher
    {
        /*待执行的sql语句*/
        public static string sql = "";

        public static bool ulogin(string teacherNo,string password)
        {
            string sql = @"select teacherNo from Teacher where teacherNo =@teacherNo and password =@password";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@teacherNo",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar)
           };
            para[0].Value = teacherNo;
            para[1].Value = password; 
            return (DBHelp.ExecuteScalar(sql, para) != null) ? true : false;
        }

        /*添加教师实现*/
        public static bool AddTeacher(ENTITY.Teacher teacher)
        {
            string sql = "insert into Teacher(teacherNo,password,name,sex,bornDate,teacherPhoto,telephone,email) values(@teacherNo,@password,@name,@sex,@bornDate,@teacherPhoto,@telephone,@email)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@teacherNo",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@sex",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@teacherPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@email",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = teacher.teacherNo; //教师编号
            parm[1].Value = teacher.password; //登录密码
            parm[2].Value = teacher.name; //姓名
            parm[3].Value = teacher.sex; //性别
            parm[4].Value = teacher.bornDate; //出生日期
            parm[5].Value = teacher.teacherPhoto; //教师照片
            parm[6].Value = teacher.telephone; //联系电话
            parm[7].Value = teacher.email; //邮箱

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据teacherNo获取某条教师记录*/
        public static ENTITY.Teacher getSomeTeacher(string teacherNo)
        {
            /*构建查询sql*/
            string sql = "select * from Teacher where teacherNo='" + teacherNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Teacher teacher = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                teacher = new ENTITY.Teacher();
                teacher.teacherNo = DataRead["teacherNo"].ToString();
                teacher.password = DataRead["password"].ToString();
                teacher.name = DataRead["name"].ToString();
                teacher.sex = DataRead["sex"].ToString();
                teacher.bornDate = Convert.ToDateTime(DataRead["bornDate"].ToString());
                teacher.teacherPhoto = DataRead["teacherPhoto"].ToString();
                teacher.telephone = DataRead["telephone"].ToString();
                teacher.email = DataRead["email"].ToString();
            }
            return teacher;
        }

        /*更新教师实现*/
        public static bool EditTeacher(ENTITY.Teacher teacher)
        {
            string sql = "update Teacher set password=@password,name=@name,sex=@sex,bornDate=@bornDate,teacherPhoto=@teacherPhoto,telephone=@telephone,email=@email where teacherNo=@teacherNo";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@sex",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@teacherPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@email",SqlDbType.VarChar),
             new SqlParameter("@teacherNo",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = teacher.password;
            parm[1].Value = teacher.name;
            parm[2].Value = teacher.sex;
            parm[3].Value = teacher.bornDate;
            parm[4].Value = teacher.teacherPhoto;
            parm[5].Value = teacher.telephone;
            parm[6].Value = teacher.email;
            parm[7].Value = teacher.teacherNo;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除教师*/
        public static bool DelTeacher(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from Teacher where teacherNo in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询教师*/
        public static DataSet GetTeacher(string strWhere)
        {
            try
            {
                string strSql = "select * from Teacher" + strWhere + " order by teacherNo asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询教师*/
        public static System.Data.DataTable GetTeacher(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Teacher";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "teacherNo", strShow, strSql, strWhere, " teacherNo asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTeacher()
        {
            try
            {
                string strSql = "select * from Teacher";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
