using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*评论业务逻辑层*/
    public class bllComment{
        /*添加评论*/
        public static bool AddComment(ENTITY.Comment comment)
        {
            return DAL.dalComment.AddComment(comment);
        }

        /*根据commentId获取某条评论记录*/
        public static ENTITY.Comment getSomeComment(int commentId)
        {
            return DAL.dalComment.getSomeComment(commentId);
        }

        /*更新评论*/
        public static bool EditComment(ENTITY.Comment comment)
        {
            return DAL.dalComment.EditComment(comment);
        }

        /*删除评论*/
        public static bool DelComment(string p)
        {
            return DAL.dalComment.DelComment(p);
        }

        /*查询评论*/
        public static System.Data.DataSet GetComment(string strWhere)
        {
            return DAL.dalComment.GetComment(strWhere);
        }

        /*根据条件分页查询评论*/
        public static System.Data.DataTable GetComment(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalComment.GetComment(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的评论*/
        public static System.Data.DataSet getAllComment()
        {
            return DAL.dalComment.getAllComment();
        }
    }
}
