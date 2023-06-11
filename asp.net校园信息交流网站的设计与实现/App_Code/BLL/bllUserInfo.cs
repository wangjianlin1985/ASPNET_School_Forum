using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*学生业务逻辑层*/
    public class bllUserInfo{
        /*添加学生*/
        public static bool AddUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.AddUserInfo(userInfo);
        }

        /*根据user_name获取某条学生记录*/
        public static ENTITY.UserInfo getSomeUserInfo(string user_name)
        {
            return DAL.dalUserInfo.getSomeUserInfo(user_name);
        }

        /*更新学生*/
        public static bool EditUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.EditUserInfo(userInfo);
        }

        /*删除学生*/
        public static bool DelUserInfo(string p)
        {
            return DAL.dalUserInfo.DelUserInfo(p);
        }

        /*查询学生*/
        public static System.Data.DataSet GetUserInfo(string strWhere)
        {
            return DAL.dalUserInfo.GetUserInfo(strWhere);
        }

        /*根据条件分页查询学生*/
        public static System.Data.DataTable GetUserInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalUserInfo.GetUserInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的学生*/
        public static System.Data.DataSet getAllUserInfo()
        {
            return DAL.dalUserInfo.getAllUserInfo();
        }
    }
}
