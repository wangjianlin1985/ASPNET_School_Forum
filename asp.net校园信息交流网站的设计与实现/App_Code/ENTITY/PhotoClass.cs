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
    ///PhotoClass ��ժҪ˵������Ƭ����ʵ��
    /// </summary>

    public class PhotoClass
    {
        /*��Ƭ����id*/
        private int _photoClassId;
        public int photoClassId
        {
            get { return _photoClassId; }
            set { _photoClassId = value; }
        }

        /*��Ƭ��������*/
        private string _photoClassName;
        public string photoClassName
        {
            get { return _photoClassName; }
            set { _photoClassName = value; }
        }

    }
}
