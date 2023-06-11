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
    ///Journal ��ժҪ˵����������־ʵ��
    /// </summary>

    public class Journal
    {
        /*��־id*/
        private int _postId;
        public int postId
        {
            get { return _postId; }
            set { _postId = value; }
        }

        /*��־����*/
        private int _journalClassObj;
        public int journalClassObj
        {
            get { return _journalClassObj; }
            set { _journalClassObj = value; }
        }

        /*����*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*��־����*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*�����û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*����ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
