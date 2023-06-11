using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*教师业务逻辑层*/
    public class bllTeacher{

        public static bool ulogin(string teacherNo,string password)
        {
            return DAL.dalTeacher.ulogin(teacherNo, password);
        }


        /*添加教师*/
        public static bool AddTeacher(ENTITY.Teacher teacher)
        {
            return DAL.dalTeacher.AddTeacher(teacher);
        }

        /*根据teacherNo获取某条教师记录*/
        public static ENTITY.Teacher getSomeTeacher(string teacherNo)
        {
            return DAL.dalTeacher.getSomeTeacher(teacherNo);
        }

        /*更新教师*/
        public static bool EditTeacher(ENTITY.Teacher teacher)
        {
            return DAL.dalTeacher.EditTeacher(teacher);
        }

        /*删除教师*/
        public static bool DelTeacher(string p)
        {
            return DAL.dalTeacher.DelTeacher(p);
        }

        /*查询教师*/
        public static System.Data.DataSet GetTeacher(string strWhere)
        {
            return DAL.dalTeacher.GetTeacher(strWhere);
        }

        /*根据条件分页查询教师*/
        public static System.Data.DataTable GetTeacher(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTeacher.GetTeacher(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的教师*/
        public static System.Data.DataSet getAllTeacher()
        {
            return DAL.dalTeacher.getAllTeacher();
        }
    }
}
