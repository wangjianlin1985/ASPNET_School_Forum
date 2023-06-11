using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��վ����ҵ���߼���*/
    public class bllNews{
        /*�����վ����*/
        public static bool AddNews(ENTITY.News news)
        {
            return DAL.dalNews.AddNews(news);
        }

        /*����newsId��ȡĳ����վ���ż�¼*/
        public static ENTITY.News getSomeNews(int newsId)
        {
            return DAL.dalNews.getSomeNews(newsId);
        }

        /*������վ����*/
        public static bool EditNews(ENTITY.News news)
        {
            return DAL.dalNews.EditNews(news);
        }

        /*ɾ����վ����*/
        public static bool DelNews(string p)
        {
            return DAL.dalNews.DelNews(p);
        }

        /*��ѯ��վ����*/
        public static System.Data.DataSet GetNews(string strWhere)
        {
            return DAL.dalNews.GetNews(strWhere);
        }

        /*����������ҳ��ѯ��վ����*/
        public static System.Data.DataTable GetNews(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalNews.GetNews(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���վ����*/
        public static System.Data.DataSet getAllNews()
        {
            return DAL.dalNews.getAllNews();
        }
    }
}
