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
    ///PhotoInfo ��ժҪ˵������Ƭʵ��
    /// </summary>

    public class PhotoInfo
    {
        /*��Ƭid*/
        private int _photoId;
        public int photoId
        {
            get { return _photoId; }
            set { _photoId = value; }
        }

        /*��Ƭ����*/
        private int _photoClassObj;
        public int photoClassObj
        {
            get { return _photoClassObj; }
            set { _photoClassObj = value; }
        }

        /*��Ƭ����*/
        private string _photoName;
        public string photoName
        {
            get { return _photoName; }
            set { _photoName = value; }
        }

        /*��Ƭ�ļ�*/
        private string _photoImage;
        public string photoImage
        {
            get { return _photoImage; }
            set { _photoImage = value; }
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
