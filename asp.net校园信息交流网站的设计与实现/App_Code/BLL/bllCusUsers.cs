using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class bllCusUsers
    {
        public static bool AddUsersInfo(ENTITY.CusUsers u1)
        {
            return DAL.dalCusUsers.AddUsersInfo(u1);
        }

        public static ENTITY.CusUsers getSomeUserInfo(int userid)
        {
            return DAL.dalCusUsers.getSomeUserInfo(userid);
        }

        public static bool EditUsersInfo(ENTITY.CusUsers u1)
        {
            return DAL.dalCusUsers.EditUsersInfo(u1);
        }

        public static bool DelUsersInfo(string p)
        {
            return DAL.dalCusUsers.DelUsersInfo(p);
        }

        public static bool ulogin(ref ENTITY.CusUsers userlogin)
        {
            return DAL.dalCusUsers.ulogin(userlogin);
        }

        public static bool Vld_UserName(ref ENTITY.CusUsers userlogin)
        {
            return DAL.dalCusUsers.Vld_UserName(userlogin);
        }

        public static System.Data.DataTable GetUsersInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCusUsers.GetUsersInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }

        public static List<ENTITY.CusUsers> getUserId(string username)
        {
            return DAL.dalCusUsers.getUserId(username);
        }

        public static bool ChangeUserPass(string p, string p_2, int p_3)
        {
            return DAL.dalCusUsers.ChangeUserPass(p,p_2,p_3);
        }

        public static void CheckUserType(int id, int p)
        {
            DAL.dalCusUsers.CheckUserType(id,p);
        }
    }
}
