using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��������ҵ���߼���*/
    public class bllWebLink{
        /*�����������*/
        public static bool AddWebLink(ENTITY.WebLink webLink)
        {
            return DAL.dalWebLink.AddWebLink(webLink);
        }

        /*����linkId��ȡĳ���������Ӽ�¼*/
        public static ENTITY.WebLink getSomeWebLink(int linkId)
        {
            return DAL.dalWebLink.getSomeWebLink(linkId);
        }

        /*������������*/
        public static bool EditWebLink(ENTITY.WebLink webLink)
        {
            return DAL.dalWebLink.EditWebLink(webLink);
        }

        /*ɾ����������*/
        public static bool DelWebLink(string p)
        {
            return DAL.dalWebLink.DelWebLink(p);
        }

        /*��ѯ��������*/
        public static System.Data.DataSet GetWebLink(string strWhere)
        {
            return DAL.dalWebLink.GetWebLink(strWhere);
        }

        /*����������ҳ��ѯ��������*/
        public static System.Data.DataTable GetWebLink(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalWebLink.GetWebLink(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���������*/
        public static System.Data.DataSet getAllWebLink()
        {
            return DAL.dalWebLink.getAllWebLink();
        }
    }
}
