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
    ///PhotoInfo 的摘要说明：照片实体
    /// </summary>

    public class PhotoInfo
    {
        /*照片id*/
        private int _photoId;
        public int photoId
        {
            get { return _photoId; }
            set { _photoId = value; }
        }

        /*照片分类*/
        private int _photoClassObj;
        public int photoClassObj
        {
            get { return _photoClassObj; }
            set { _photoClassObj = value; }
        }

        /*照片名称*/
        private string _photoName;
        public string photoName
        {
            get { return _photoName; }
            set { _photoName = value; }
        }

        /*照片文件*/
        private string _photoImage;
        public string photoImage
        {
            get { return _photoImage; }
            set { _photoImage = value; }
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
