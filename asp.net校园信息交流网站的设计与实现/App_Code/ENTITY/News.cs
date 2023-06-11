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
    ///News ��ժҪ˵������վ����ʵ��
    /// </summary>

    public class News
    {
        /*����id*/
        private int _newsId;
        public int newsId
        {
            get { return _newsId; }
            set { _newsId = value; }
        }

        /*����*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*��������*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*����ʱ��*/
        private DateTime _publishDate;
        public DateTime publishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

    }
}
