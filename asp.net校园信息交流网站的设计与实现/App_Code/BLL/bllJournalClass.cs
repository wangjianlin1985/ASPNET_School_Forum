using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*日志分类业务逻辑层*/
    public class bllJournalClass{
        /*添加日志分类*/
        public static bool AddJournalClass(ENTITY.JournalClass journalClass)
        {
            return DAL.dalJournalClass.AddJournalClass(journalClass);
        }

        /*根据journalClassId获取某条日志分类记录*/
        public static ENTITY.JournalClass getSomeJournalClass(int journalClassId)
        {
            return DAL.dalJournalClass.getSomeJournalClass(journalClassId);
        }

        /*更新日志分类*/
        public static bool EditJournalClass(ENTITY.JournalClass journalClass)
        {
            return DAL.dalJournalClass.EditJournalClass(journalClass);
        }

        /*删除日志分类*/
        public static bool DelJournalClass(string p)
        {
            return DAL.dalJournalClass.DelJournalClass(p);
        }

        /*查询日志分类*/
        public static System.Data.DataSet GetJournalClass(string strWhere)
        {
            return DAL.dalJournalClass.GetJournalClass(strWhere);
        }

        /*根据条件分页查询日志分类*/
        public static System.Data.DataTable GetJournalClass(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalJournalClass.GetJournalClass(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的日志分类*/
        public static System.Data.DataSet getAllJournalClass()
        {
            return DAL.dalJournalClass.getAllJournalClass();
        }
    }
}
