using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*照片业务逻辑层*/
    public class bllPhotoInfo{
        /*添加照片*/
        public static bool AddPhotoInfo(ENTITY.PhotoInfo photoInfo)
        {
            return DAL.dalPhotoInfo.AddPhotoInfo(photoInfo);
        }

        /*根据photoId获取某条照片记录*/
        public static ENTITY.PhotoInfo getSomePhotoInfo(int photoId)
        {
            return DAL.dalPhotoInfo.getSomePhotoInfo(photoId);
        }

        /*更新照片*/
        public static bool EditPhotoInfo(ENTITY.PhotoInfo photoInfo)
        {
            return DAL.dalPhotoInfo.EditPhotoInfo(photoInfo);
        }

        /*删除照片*/
        public static bool DelPhotoInfo(string p)
        {
            return DAL.dalPhotoInfo.DelPhotoInfo(p);
        }

        /*查询照片*/
        public static System.Data.DataSet GetPhotoInfo(string strWhere)
        {
            return DAL.dalPhotoInfo.GetPhotoInfo(strWhere);
        }

        /*根据条件分页查询照片*/
        public static System.Data.DataTable GetPhotoInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPhotoInfo.GetPhotoInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的照片*/
        public static System.Data.DataSet getAllPhotoInfo()
        {
            return DAL.dalPhotoInfo.getAllPhotoInfo();
        }
    }
}
