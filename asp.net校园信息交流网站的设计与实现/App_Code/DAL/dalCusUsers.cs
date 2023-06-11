using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ENTITY;

namespace DAL
{   
    public class dalCusUsers
    {
        public static string sql = "";

        public static bool AddUsersInfo(ENTITY.CusUsers u1)
        {
            string sql = "insert into CusUsers(Customername,customerpwd ,Realname,CustomerSfz,address,telphone,IsCusAdmin,CusType) values(@Customername,@customerpwd,@Realname,@CustomerSfz,@address,@telphone,@IsCusAdmin,@CusType)";
            SqlParameter[] parm = new SqlParameter[] { 
             new SqlParameter("@Customername",SqlDbType.VarChar),
             new SqlParameter("@customerpwd",SqlDbType.VarChar),
             new SqlParameter("@Realname",SqlDbType.VarChar),
             new SqlParameter("@CustomerSfz",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.NVarChar),
             new SqlParameter("@telphone",SqlDbType.VarChar),
             new SqlParameter("@IsCusAdmin",SqlDbType.Int),
             new SqlParameter("@CusType",SqlDbType.Int)
            };
            parm[0].Value = u1.Customername;
            parm[1].Value = u1.customerpwd;
            parm[2].Value = u1.Realname;
            parm[3].Value = u1.CustomerSfz;
            parm[4].Value = u1.address;
            parm[5].Value = u1.telphone;
            parm[6].Value = u1.IsCusAdmin;
            parm[7].Value = u1.CusType;
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        public static ENTITY.CusUsers getSomeUserInfo(int userid)
        {
            string sql = "select * from CusUsers where customerid="+ userid;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CusUsers tempUser = new ENTITY.CusUsers();
            while (DataRead.Read())
            {
                tempUser.customerid = Convert.ToInt32(DataRead["customerid"]);
                tempUser.Customername = DataRead["Customername"].ToString();
                tempUser.customerpwd = DataRead["customerpwd"].ToString();
                tempUser.Realname = DataRead["Realname"].ToString();
                tempUser.CustomerSfz = DataRead["CustomerSfz"].ToString();
                tempUser.address = DataRead["address"].ToString();
                tempUser.telphone = DataRead["telphone"].ToString();
                tempUser.IsCusAdmin = Convert.ToInt32(DataRead["IsCusAdmin"]);
                tempUser.CusType = Convert.ToInt32(DataRead["CusType"]);
            }
            return tempUser;

        }

        public static bool EditUsersInfo(ENTITY.CusUsers u1)
        {
            string sql = "update CusUsers set Customername=@Customername,customerpwd=@customerpwd,Realname=@Realname,CustomerSfz=@CustomerSfz,address=@address,telphone=@telphone,IsCusAdmin=@IsCusAdmin,CusType=@CusType where customerid=@customerid";
            SqlParameter[] parm = new SqlParameter[] { 
             new SqlParameter("@customerid",SqlDbType.Int),
             new SqlParameter("@Customername",SqlDbType.VarChar),
             new SqlParameter("@customerpwd",SqlDbType.VarChar),
             new SqlParameter("@Realname",SqlDbType.VarChar),
             new SqlParameter("@CustomerSfz",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.NVarChar),
             new SqlParameter("@telphone",SqlDbType.VarChar),
             new SqlParameter("@IsCusAdmin",SqlDbType.Int),
             new SqlParameter("@CusType",SqlDbType.Int)
            };
            parm[0].Value = u1.customerid;
            parm[1].Value = u1.Customername;
            parm[2].Value = u1.customerpwd;
            parm[3].Value = u1.Realname;
            parm[4].Value = u1.CustomerSfz;
            parm[5].Value = u1.address;
            parm[6].Value = u1.telphone;
            parm[7].Value = u1.IsCusAdmin;
            parm[8].Value = u1.CusType;
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        public static bool DelUsersInfo(string p)
        {
            string sql = "delete from CusUsers where customerid in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }

        public static System.Data.DataTable GetUsersInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CusUsers";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "customerid", strShow, strSql, strWhere, " customerid desc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ulogin(global::ENTITY.CusUsers userlogin)
        {
            string sql = @"select customerid from CusUsers where Customername =@Customername and customerpwd =@customerpwd and IsCusAdmin=@IsCusAdmin";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@Customername",SqlDbType.VarChar),
             new SqlParameter("@customerpwd",SqlDbType.VarChar),
             new SqlParameter("@IsCusAdmin",SqlDbType.Int)
           };
            para[0].Value = userlogin.Customername;
            para[1].Value = userlogin.customerpwd;
            para[2].Value = userlogin.IsCusAdmin;
            return (DBHelp.ExecuteScalar(sql, para) != null) ? true : false;
        }

        public static bool Vld_UserName(global::ENTITY.CusUsers userlogin)
        {
            string sql = @"select customerid from CusUsers where Customername =@Customername";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@Customername",SqlDbType.VarChar)
           };
            para[0].Value = userlogin.Customername;
            return (DBHelp.ExecuteScalar(sql, para) != null) ? true : false;
        }

        public static List<CusUsers> getUserId(string username)
        {
            string sql = "select customerid from CusUsers where Customername =@Customername";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@Customername",SqlDbType.VarChar)
           };
            para[0].Value = username;
            List<CusUsers> liks = new List<CusUsers>();
            SqlDataReader sdr = DBHelp.ExecuteReader(sql, para);
            while (sdr.Read())
            {
                CusUsers l1 = new CusUsers();
                l1.customerid = Convert.ToInt32(sdr["customerid"].ToString());
                liks.Add(l1);
            }
            return liks;
        }

        public static bool ChangeUserPass(string p, string p_2, int p_3)
        {
            if (Common.EncryptString.encryptMD5(p).ToUpper() == getOldPass(p_3))
            {

                string sql = "update CusUsers set customerpwd=@p_2 where customerid=@p_3";
                SqlParameter[] para = new SqlParameter[] { 
                 new SqlParameter("p_2",SqlDbType.VarChar,50),
                 new SqlParameter("p_3",SqlDbType.Int,4)
                };
                para[0].Value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(p_2, "MD5").ToString();
                para[1].Value = p_3;
                return (DBHelp.ExecuteNonQuery(sql, para) > 0) ? true : false;
            }
            else
                return false;
        }

        private static string getOldPass(int p_3)
        {
            string sql = "select customerpwd from CusUsers where customerid=@ID";
            SqlParameter pa = new SqlParameter("@ID", SqlDbType.Int);
            pa.Value = p_3;
            return DBHelp.ExecuteScalar(sql, pa).ToString();
        }

        public static void CheckUserType(int id, int p)
        {
            string sql = "update CusUsers set CusType="+p+"  where customerid=@ID";
            SqlParameter pa = new SqlParameter("@ID", SqlDbType.Int);
            pa.Value = id;
            DBHelp.ExecuteNonQuery(sql, pa);
        }

    }
}
