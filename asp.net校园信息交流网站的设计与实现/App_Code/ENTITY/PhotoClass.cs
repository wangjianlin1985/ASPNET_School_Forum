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
    ///PhotoClass 的摘要说明：照片分类实体
    /// </summary>

    public class PhotoClass
    {
        /*照片分类id*/
        private int _photoClassId;
        public int photoClassId
        {
            get { return _photoClassId; }
            set { _photoClassId = value; }
        }

        /*照片分类名称*/
        private string _photoClassName;
        public string photoClassName
        {
            get { return _photoClassName; }
            set { _photoClassName = value; }
        }

    }
}
