using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��ʦҵ���߼���*/
    public class bllTeacher{

        public static bool ulogin(string teacherNo,string password)
        {
            return DAL.dalTeacher.ulogin(teacherNo, password);
        }


        /*��ӽ�ʦ*/
        public static bool AddTeacher(ENTITY.Teacher teacher)
        {
            return DAL.dalTeacher.AddTeacher(teacher);
        }

        /*����teacherNo��ȡĳ����ʦ��¼*/
        public static ENTITY.Teacher getSomeTeacher(string teacherNo)
        {
            return DAL.dalTeacher.getSomeTeacher(teacherNo);
        }

        /*���½�ʦ*/
        public static bool EditTeacher(ENTITY.Teacher teacher)
        {
            return DAL.dalTeacher.EditTeacher(teacher);
        }

        /*ɾ����ʦ*/
        public static bool DelTeacher(string p)
        {
            return DAL.dalTeacher.DelTeacher(p);
        }

        /*��ѯ��ʦ*/
        public static System.Data.DataSet GetTeacher(string strWhere)
        {
            return DAL.dalTeacher.GetTeacher(strWhere);
        }

        /*����������ҳ��ѯ��ʦ*/
        public static System.Data.DataTable GetTeacher(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTeacher.GetTeacher(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĽ�ʦ*/
        public static System.Data.DataSet getAllTeacher()
        {
            return DAL.dalTeacher.getAllTeacher();
        }
    }
}
