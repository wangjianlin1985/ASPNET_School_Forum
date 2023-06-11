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
    ///WebLink 的摘要说明：友情链接实体
    /// </summary>

    public class WebLink
    {
        /*记录id*/
        private int _linkId;
        public int linkId
        {
            get { return _linkId; }
            set { _linkId = value; }
        }

        /*网站名称*/
        private string _webName;
        public string webName
        {
            get { return _webName; }
            set { _webName = value; }
        }

        /*网站Logo*/
        private string _webLogo;
        public string webLogo
        {
            get { return _webLogo; }
            set { _webLogo = value; }
        }

        /*网站地址*/
        private string _webAddress;
        public string webAddress
        {
            get { return _webAddress; }
            set { _webAddress = value; }
        }

    }
}
