using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*������־ҵ���߼���*/
    public class bllJournal{
        /*���������־*/
        public static bool AddJournal(ENTITY.Journal journal)
        {
            return DAL.dalJournal.AddJournal(journal);
        }

        /*����postId��ȡĳ��������־��¼*/
        public static ENTITY.Journal getSomeJournal(int postId)
        {
            return DAL.dalJournal.getSomeJournal(postId);
        }

        /*����������־*/
        public static bool EditJournal(ENTITY.Journal journal)
        {
            return DAL.dalJournal.EditJournal(journal);
        }

        /*ɾ��������־*/
        public static bool DelJournal(string p)
        {
            return DAL.dalJournal.DelJournal(p);
        }

        /*��ѯ������־*/
        public static System.Data.DataSet GetJournal(string strWhere)
        {
            return DAL.dalJournal.GetJournal(strWhere);
        }

        /*����������ҳ��ѯ������־*/
        public static System.Data.DataTable GetJournal(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalJournal.GetJournal(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�������־*/
        public static System.Data.DataSet getAllJournal()
        {
            return DAL.dalJournal.getAllJournal();
        }
    }
}
