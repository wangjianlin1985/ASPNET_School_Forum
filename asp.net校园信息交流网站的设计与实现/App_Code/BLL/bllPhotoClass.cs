using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*照片分类业务逻辑层*/
    public class bllPhotoClass{
        /*添加照片分类*/
        public static bool AddPhotoClass(ENTITY.PhotoClass photoClass)
        {
            return DAL.dalPhotoClass.AddPhotoClass(photoClass);
        }

        /*根据photoClassId获取某条照片分类记录*/
        public static ENTITY.PhotoClass getSomePhotoClass(int photoClassId)
        {
            return DAL.dalPhotoClass.getSomePhotoClass(photoClassId);
        }

        /*更新照片分类*/
        public static bool EditPhotoClass(ENTITY.PhotoClass photoClass)
        {
            return DAL.dalPhotoClass.EditPhotoClass(photoClass);
        }

        /*删除照片分类*/
        public static bool DelPhotoClass(string p)
        {
            return DAL.dalPhotoClass.DelPhotoClass(p);
        }

        /*查询照片分类*/
        public static System.Data.DataSet GetPhotoClass(string strWhere)
        {
            return DAL.dalPhotoClass.GetPhotoClass(strWhere);
        }

        /*根据条件分页查询照片分类*/
        public static System.Data.DataTable GetPhotoClass(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPhotoClass.GetPhotoClass(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的照片分类*/
        public static System.Data.DataSet getAllPhotoClass()
        {
            return DAL.dalPhotoClass.getAllPhotoClass();
        }
    }
}
