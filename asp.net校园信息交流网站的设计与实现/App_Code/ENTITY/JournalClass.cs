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
    ///JournalClass ��ժҪ˵������־����ʵ��
    /// </summary>

    public class JournalClass
    {
        /*��־����id*/
        private int _journalClassId;
        public int journalClassId
        {
            get { return _journalClassId; }
            set { _journalClassId = value; }
        }

        /*��־��������*/
        private string _journalClassName;
        public string journalClassName
        {
            get { return _journalClassName; }
            set { _journalClassName = value; }
        }

    }
}
