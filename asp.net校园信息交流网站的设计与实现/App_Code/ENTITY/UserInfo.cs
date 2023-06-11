using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///UserInfo 的摘要说明：学生实体
    /// </summary>

    public class UserInfo
    {
        /*用户名*/
        private string _user_name;
        public string user_name
        {
            get { return _user_name; }
            set { _user_name = value; }
        }

        /*登录密码*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*姓名*/
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        /*性别*/
        private string _gender;
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        /*出生日期*/
        private DateTime _bornDate;
        public DateTime bornDate
        {
            get { return _bornDate; }
            set { _bornDate = value; }
        }

        /*用户照片*/
        private string _userPhoto;
        public string userPhoto
        {
            get { return _userPhoto; }
            set { _userPhoto = value; }
        }

        /*联系电话*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*邮箱*/
        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        /*家庭地址*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        /*注册时间*/
        private DateTime _regTime;
        public DateTime regTime
        {
            get { return _regTime; }
            set { _regTime = value; }
        }

    }
}
