using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ƭ����ҵ���߼���*/
    public class bllPhotoClass{
        /*�����Ƭ����*/
        public static bool AddPhotoClass(ENTITY.PhotoClass photoClass)
        {
            return DAL.dalPhotoClass.AddPhotoClass(photoClass);
        }

        /*����photoClassId��ȡĳ����Ƭ�����¼*/
        public static ENTITY.PhotoClass getSomePhotoClass(int photoClassId)
        {
            return DAL.dalPhotoClass.getSomePhotoClass(photoClassId);
        }

        /*������Ƭ����*/
        public static bool EditPhotoClass(ENTITY.PhotoClass photoClass)
        {
            return DAL.dalPhotoClass.EditPhotoClass(photoClass);
        }

        /*ɾ����Ƭ����*/
        public static bool DelPhotoClass(string p)
        {
            return DAL.dalPhotoClass.DelPhotoClass(p);
        }

        /*��ѯ��Ƭ����*/
        public static System.Data.DataSet GetPhotoClass(string strWhere)
        {
            return DAL.dalPhotoClass.GetPhotoClass(strWhere);
        }

        /*����������ҳ��ѯ��Ƭ����*/
        public static System.Data.DataTable GetPhotoClass(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPhotoClass.GetPhotoClass(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ƭ����*/
        public static System.Data.DataSet getAllPhotoClass()
        {
            return DAL.dalPhotoClass.getAllPhotoClass();
        }
    }
}
