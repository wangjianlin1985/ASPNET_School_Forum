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
    ///Journal 的摘要说明：帖子日志实体
    /// </summary>

    public class Journal
    {
        /*日志id*/
        private int _postId;
        public int postId
        {
            get { return _postId; }
            set { _postId = value; }
        }

        /*日志分类*/
        private int _journalClassObj;
        public int journalClassObj
        {
            get { return _journalClassObj; }
            set { _journalClassObj = value; }
        }

        /*标题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*日志内容*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*发布用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*发布时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
