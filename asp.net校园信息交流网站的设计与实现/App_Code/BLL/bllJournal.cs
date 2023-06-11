using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*帖子日志业务逻辑层*/
    public class bllJournal{
        /*添加帖子日志*/
        public static bool AddJournal(ENTITY.Journal journal)
        {
            return DAL.dalJournal.AddJournal(journal);
        }

        /*根据postId获取某条帖子日志记录*/
        public static ENTITY.Journal getSomeJournal(int postId)
        {
            return DAL.dalJournal.getSomeJournal(postId);
        }

        /*更新帖子日志*/
        public static bool EditJournal(ENTITY.Journal journal)
        {
            return DAL.dalJournal.EditJournal(journal);
        }

        /*删除帖子日志*/
        public static bool DelJournal(string p)
        {
            return DAL.dalJournal.DelJournal(p);
        }

        /*查询帖子日志*/
        public static System.Data.DataSet GetJournal(string strWhere)
        {
            return DAL.dalJournal.GetJournal(strWhere);
        }

        /*根据条件分页查询帖子日志*/
        public static System.Data.DataTable GetJournal(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalJournal.GetJournal(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的帖子日志*/
        public static System.Data.DataSet getAllJournal()
        {
            return DAL.dalJournal.getAllJournal();
        }
    }
}
