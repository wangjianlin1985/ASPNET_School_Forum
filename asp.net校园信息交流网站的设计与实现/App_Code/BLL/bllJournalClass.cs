using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��־����ҵ���߼���*/
    public class bllJournalClass{
        /*�����־����*/
        public static bool AddJournalClass(ENTITY.JournalClass journalClass)
        {
            return DAL.dalJournalClass.AddJournalClass(journalClass);
        }

        /*����journalClassId��ȡĳ����־�����¼*/
        public static ENTITY.JournalClass getSomeJournalClass(int journalClassId)
        {
            return DAL.dalJournalClass.getSomeJournalClass(journalClassId);
        }

        /*������־����*/
        public static bool EditJournalClass(ENTITY.JournalClass journalClass)
        {
            return DAL.dalJournalClass.EditJournalClass(journalClass);
        }

        /*ɾ����־����*/
        public static bool DelJournalClass(string p)
        {
            return DAL.dalJournalClass.DelJournalClass(p);
        }

        /*��ѯ��־����*/
        public static System.Data.DataSet GetJournalClass(string strWhere)
        {
            return DAL.dalJournalClass.GetJournalClass(strWhere);
        }

        /*����������ҳ��ѯ��־����*/
        public static System.Data.DataTable GetJournalClass(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalJournalClass.GetJournalClass(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���־����*/
        public static System.Data.DataSet getAllJournalClass()
        {
            return DAL.dalJournalClass.getAllJournalClass();
        }
    }
}
