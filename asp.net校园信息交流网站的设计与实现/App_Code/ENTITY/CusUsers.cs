using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTITY
{
    public class CusUsers
    {
        public CusUsers()
        {
        }
        public CusUsers(string ID, string PassWord,int isadmincus)
        {
            this.Customername = ID;
            this.customerpwd = PassWord;
            this.IsCusAdmin = isadmincus;
        }

        private int _customerid;

        public int customerid
        {
            get { return _customerid; }
            set { _customerid = value; }
        }

        private string _Customername;

        public string Customername
        {
            get { return _Customername; }
            set { _Customername = value; }
        }

        private string _customerpwd;

        public string customerpwd
        {
            get { return _customerpwd; }
            set { _customerpwd = value; }
        }

        private string _Realname;

        public string Realname
        {
            get { return _Realname; }
            set { _Realname = value; }
        }

        private string _CustomerSfz;

        public string CustomerSfz
        {
            get { return _CustomerSfz; }
            set { _CustomerSfz = value; }
        }

        private string _address;

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _telphone;

        public string telphone
        {
            get { return _telphone; }
            set { _telphone = value; }
        }

        private int _IsCusAdmin;

        public int IsCusAdmin
        {
            get { return _IsCusAdmin; }
            set { _IsCusAdmin = value; }
        }

        private int _CusType;

        public int CusType
        {
            get { return _CusType; }
            set { _CusType = value; }
        }
    }
}
