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
    ///WebLink ��ժҪ˵������������ʵ��
    /// </summary>

    public class WebLink
    {
        /*��¼id*/
        private int _linkId;
        public int linkId
        {
            get { return _linkId; }
            set { _linkId = value; }
        }

        /*��վ����*/
        private string _webName;
        public string webName
        {
            get { return _webName; }
            set { _webName = value; }
        }

        /*��վLogo*/
        private string _webLogo;
        public string webLogo
        {
            get { return _webLogo; }
            set { _webLogo = value; }
        }

        /*��վ��ַ*/
        private string _webAddress;
        public string webAddress
        {
            get { return _webAddress; }
            set { _webAddress = value; }
        }

    }
}
