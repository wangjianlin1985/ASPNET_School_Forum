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
    ///News 的摘要说明：网站新闻实体
    /// </summary>

    public class News
    {
        /*新闻id*/
        private int _newsId;
        public int newsId
        {
            get { return _newsId; }
            set { _newsId = value; }
        }

        /*标题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*新闻内容*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*发布时间*/
        private DateTime _publishDate;
        public DateTime publishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

    }
}
