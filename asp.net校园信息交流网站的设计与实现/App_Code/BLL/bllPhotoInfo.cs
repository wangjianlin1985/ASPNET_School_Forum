using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ƭҵ���߼���*/
    public class bllPhotoInfo{
        /*�����Ƭ*/
        public static bool AddPhotoInfo(ENTITY.PhotoInfo photoInfo)
        {
            return DAL.dalPhotoInfo.AddPhotoInfo(photoInfo);
        }

        /*����photoId��ȡĳ����Ƭ��¼*/
        public static ENTITY.PhotoInfo getSomePhotoInfo(int photoId)
        {
            return DAL.dalPhotoInfo.getSomePhotoInfo(photoId);
        }

        /*������Ƭ*/
        public static bool EditPhotoInfo(ENTITY.PhotoInfo photoInfo)
        {
            return DAL.dalPhotoInfo.EditPhotoInfo(photoInfo);
        }

        /*ɾ����Ƭ*/
        public static bool DelPhotoInfo(string p)
        {
            return DAL.dalPhotoInfo.DelPhotoInfo(p);
        }

        /*��ѯ��Ƭ*/
        public static System.Data.DataSet GetPhotoInfo(string strWhere)
        {
            return DAL.dalPhotoInfo.GetPhotoInfo(strWhere);
        }

        /*����������ҳ��ѯ��Ƭ*/
        public static System.Data.DataTable GetPhotoInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPhotoInfo.GetPhotoInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ƭ*/
        public static System.Data.DataSet getAllPhotoInfo()
        {
            return DAL.dalPhotoInfo.getAllPhotoInfo();
        }
    }
}
