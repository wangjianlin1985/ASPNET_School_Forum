using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*����ҵ���߼���*/
    public class bllComment{
        /*�������*/
        public static bool AddComment(ENTITY.Comment comment)
        {
            return DAL.dalComment.AddComment(comment);
        }

        /*����commentId��ȡĳ�����ۼ�¼*/
        public static ENTITY.Comment getSomeComment(int commentId)
        {
            return DAL.dalComment.getSomeComment(commentId);
        }

        /*��������*/
        public static bool EditComment(ENTITY.Comment comment)
        {
            return DAL.dalComment.EditComment(comment);
        }

        /*ɾ������*/
        public static bool DelComment(string p)
        {
            return DAL.dalComment.DelComment(p);
        }

        /*��ѯ����*/
        public static System.Data.DataSet GetComment(string strWhere)
        {
            return DAL.dalComment.GetComment(strWhere);
        }

        /*����������ҳ��ѯ����*/
        public static System.Data.DataTable GetComment(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalComment.GetComment(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�����*/
        public static System.Data.DataSet getAllComment()
        {
            return DAL.dalComment.getAllComment();
        }
    }
}
