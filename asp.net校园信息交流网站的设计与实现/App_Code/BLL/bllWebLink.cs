using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*友情链接业务逻辑层*/
    public class bllWebLink{
        /*添加友情链接*/
        public static bool AddWebLink(ENTITY.WebLink webLink)
        {
            return DAL.dalWebLink.AddWebLink(webLink);
        }

        /*根据linkId获取某条友情链接记录*/
        public static ENTITY.WebLink getSomeWebLink(int linkId)
        {
            return DAL.dalWebLink.getSomeWebLink(linkId);
        }

        /*更新友情链接*/
        public static bool EditWebLink(ENTITY.WebLink webLink)
        {
            return DAL.dalWebLink.EditWebLink(webLink);
        }

        /*删除友情链接*/
        public static bool DelWebLink(string p)
        {
            return DAL.dalWebLink.DelWebLink(p);
        }

        /*查询友情链接*/
        public static System.Data.DataSet GetWebLink(string strWhere)
        {
            return DAL.dalWebLink.GetWebLink(strWhere);
        }

        /*根据条件分页查询友情链接*/
        public static System.Data.DataTable GetWebLink(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalWebLink.GetWebLink(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的友情链接*/
        public static System.Data.DataSet getAllWebLink()
        {
            return DAL.dalWebLink.getAllWebLink();
        }
    }
}
