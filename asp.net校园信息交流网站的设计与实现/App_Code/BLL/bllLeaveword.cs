using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*留言业务逻辑层*/
    public class bllLeaveword{
        /*添加留言*/
        public static bool AddLeaveword(ENTITY.Leaveword leaveword)
        {
            return DAL.dalLeaveword.AddLeaveword(leaveword);
        }

        /*根据leaveWordId获取某条留言记录*/
        public static ENTITY.Leaveword getSomeLeaveword(int leaveWordId)
        {
            return DAL.dalLeaveword.getSomeLeaveword(leaveWordId);
        }

        /*更新留言*/
        public static bool EditLeaveword(ENTITY.Leaveword leaveword)
        {
            return DAL.dalLeaveword.EditLeaveword(leaveword);
        }

        /*删除留言*/
        public static bool DelLeaveword(string p)
        {
            return DAL.dalLeaveword.DelLeaveword(p);
        }

        /*查询留言*/
        public static System.Data.DataSet GetLeaveword(string strWhere)
        {
            return DAL.dalLeaveword.GetLeaveword(strWhere);
        }

        /*根据条件分页查询留言*/
        public static System.Data.DataTable GetLeaveword(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalLeaveword.GetLeaveword(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的留言*/
        public static System.Data.DataSet getAllLeaveword()
        {
            return DAL.dalLeaveword.getAllLeaveword();
        }
    }
}
