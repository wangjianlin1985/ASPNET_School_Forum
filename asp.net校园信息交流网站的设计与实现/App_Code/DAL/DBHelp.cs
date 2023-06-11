using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DBHelp
    { /// 连接字符串
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //用于缓存参数的HASH表
        //private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        ///  给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, conn, null, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 用现有的数据库连接执行一个sql命令（不返回数据集）
        /// </summary>
        /// <remarks>
        ///举例:  
        ///  int result = ExecuteNonQuery(connString, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">一个现有的数据库连接</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(SqlConnection connection, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        /// <summary>
        ///使用现有的SQL事务执行一个sql命令（不返回数据集）
        /// </summary>
        /// <remarks>
        ///举例:  
        ///  int result = ExecuteNonQuery(trans, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">一个现有的事务</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        /// <summary>
        /// 用执行的数据库连接执行一个返回数据集的sql命令
        /// </summary>
        /// <remarks>
        /// 举例:  
        ///  OleDbDataReader r = ExecuteReader(connString, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的读取器</returns>
        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] commandParameters)
        {
            //创建一个SqlCommand对象
            SqlCommand cmd = new SqlCommand();
            //创建一个SqlConnection对象
            SqlConnection conn = new SqlConnection(ConnectionString);
            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
            //因此commandBehaviour.CloseConnection 就不会执行
            try
            {
                //调用 PrepareCommand 方法，对 SqlCommand 对象设置参数
                PrepareCommand(cmd, conn, null, cmdText, commandParameters);
                //调用 SqlCommand  的 ExecuteReader 方法
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //清除参数
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                //关闭连接，抛出异常
                conn.Close();
                throw;
            }
        }
        /// <summary>
        /// 返回一个DataSet数据集
        /// </summary>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的数据集</returns>
        public static DataSet ExecuteDataSet(string cmdText, params SqlParameter[] commandParameters)
        {
            //创建一个SqlCommand对象，并对其进行初始化
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, conn, null, cmdText, commandParameters);
                //创建SqlDataAdapter对象以及DataSet
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                try
                {
                    //填充ds
                    da.Fill(ds);
                    // 清除cmd的参数集合 
                    cmd.Parameters.Clear();
                    //返回ds
                    return ds;
                }
                catch
                {
                    //关闭连接，抛出异常
                    conn.Close();
                    throw;
                }
            }
        }
        /// <summary>
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        ///例如:  
        ///  Object obj = ExecuteScalar(connString, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        ///<param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, connection, null, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 用指定的数据库连接执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  Object obj = ExecuteScalar(connString, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">一个存在的数据库连接</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(SqlConnection connection, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
        ///// <summary>
        ///// 将参数集合添加到缓存
        ///// </summary>
        ///// <param name="cacheKey">添加到缓存的变量</param>
        ///// <param name="cmdParms">一个将要添加到缓存的sql参数集合</param>
        //public static void CacheParameters(string cacheKey, params OleDbParameter[] commandParameters)
        //{
        //    parmCache[cacheKey] = commandParameters;
        //}
        ///// <summary>
        ///// 找回缓存参数集合
        ///// </summary>
        ///// <param name="cacheKey">用于找回参数的关键字</param>
        ///// <returns>缓存的参数集合</returns>
        //public static OleDbParameter[] GetCachedParameters(string cacheKey)
        //{
        //    OleDbParameter[] cachedParms = (OleDbParameter[])parmCache[cacheKey];
        //    if (cachedParms == null)
        //        return null;
        //    OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];
        //    for (int i = 0, j = cachedParms.Length; i < j; i++)
        //        clonedParms = (OleDbParameter[])((ICloneable)cachedParms).Clone();
        //    return clonedParms;
        //}
        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">Sql连接</param>
        /// <param name="trans">Sql事务</param>
        /// <param name="cmdText">命令文本,例如：Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            //判断连接的状态。如果是关闭状态，则打开
            if (conn.State != ConnectionState.Open)
                conn.Open();
            //cmd属性赋值
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            //是否需要用到事务处理
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            //添加cmd需要的存储过程参数
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// 分页使用
        /// </summary>
        /// <param name="query"></param>
        /// <param name="passCount"></param>
        /// <returns></returns>
        private static string recordID(string query, int passCount)
        {
            using (SqlConnection m_Conn = new SqlConnection(ConnectionString))
            {
                m_Conn.Open();
                SqlCommand cmd = new SqlCommand(query, m_Conn);
                string result = string.Empty;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (passCount < 1)
                        {
                            result += "," + dr.GetInt32(0);
                        }
                        passCount--;
                    }
                }
                m_Conn.Close();
                m_Conn.Dispose();
                return result.Substring(1);
            }
        }

        /// <summary>
        /// 分页使用:主键是字符串类型时候
        /// </summary>
        /// <param name="query"></param>
        /// <param name="passCount"></param>
        /// <returns></returns>
        private static string recordIDString(string query, int passCount)
        {
            using (SqlConnection m_Conn = new SqlConnection(ConnectionString))
            {
                m_Conn.Open();
                SqlCommand cmd = new SqlCommand(query, m_Conn);
                string result = string.Empty;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (passCount < 1)
                        {
                            result += ",'" + dr.GetString(0) + "'";
                        }
                        passCount--;
                    }
                }
                m_Conn.Close();
                m_Conn.Dispose();
                return result.Substring(1);
            }
        }


        /// <summary>
        /// ACCESS高效分页
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">分页容量</param>
        /// <param name="strKey">主键</param>
        /// <param name="showString">显示的字段</param>
        /// <param name="queryString">查询字符串，支持联合查询</param>
        /// <param name="whereString">查询条件，若有条件限制则必须以where 开头</param>
        /// <param name="orderString">排序规则</param>
        /// <param name="pageCount">传出参数：总页数统计</param>
        /// <param name="recordCount">传出参数：总记录统计</param>
        /// <returns>装载记录的DataTable</returns>
        public static DataTable ExecutePager(int pageIndex, int pageSize, string strKey, string showString, string queryString, string whereString, string orderString, out int pageCount, out int recordCount)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            if (string.IsNullOrEmpty(showString)) showString = "*";
            if (string.IsNullOrEmpty(orderString)) orderString = strKey + " asc ";
            using (SqlConnection m_Conn = new SqlConnection(ConnectionString))
            {
                m_Conn.Open();
                string myVw = string.Format(" ( {0} ) tempVw ", queryString);
                SqlCommand cmdCount = new SqlCommand(string.Format(" select count(*) as recordCount from {0} {1}", myVw, whereString), m_Conn);

                recordCount = Convert.ToInt32(cmdCount.ExecuteScalar());

                if ((recordCount % pageSize) > 0)
                    pageCount = recordCount / pageSize + 1;
                else
                    pageCount = recordCount / pageSize;
                SqlCommand cmdRecord;
                if (pageIndex == 1)//第一页
                {
                    cmdRecord = new SqlCommand(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, showString, myVw, whereString, orderString), m_Conn);
                }
                else if (pageIndex > pageCount)//超出总页数
                {
                    cmdRecord = new SqlCommand(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, showString, myVw, "where 1=2", orderString), m_Conn);
                }
                else
                {
                    int pageLowerBound = pageSize * pageIndex;
                    int pageUpperBound = pageLowerBound - pageSize;
                    string recordIDs = recordID(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageLowerBound, strKey, myVw, whereString, orderString), pageUpperBound);
                    string queryStringend = string.Format("select {0} from {1} where {2} in ({3}) order by {4} ", showString, myVw, strKey, recordIDs, orderString);
                    cmdRecord = new SqlCommand(queryStringend, m_Conn);

                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdRecord);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                m_Conn.Close();
                m_Conn.Dispose();
                return dt;
            }
        }



        /// <summary>
        /// ACCESS高效分页：当表的主键是字符串类型时候
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">分页容量</param>
        /// <param name="strKey">主键</param>
        /// <param name="showString">显示的字段</param>
        /// <param name="queryString">查询字符串，支持联合查询</param>
        /// <param name="whereString">查询条件，若有条件限制则必须以where 开头</param>
        /// <param name="orderString">排序规则</param>
        /// <param name="pageCount">传出参数：总页数统计</param>
        /// <param name="recordCount">传出参数：总记录统计</param>
        /// <returns>装载记录的DataTable</returns>
        public static DataTable ExecutePagerWhenPrimaryIsString(int pageIndex, int pageSize, string strKey, string showString, string queryString, string whereString, string orderString, out int pageCount, out int recordCount)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            if (string.IsNullOrEmpty(showString)) showString = "*";
            if (string.IsNullOrEmpty(orderString)) orderString = strKey + " asc ";
            using (SqlConnection m_Conn = new SqlConnection(ConnectionString))
            {
                m_Conn.Open();
                string myVw = string.Format(" ( {0} ) tempVw ", queryString);
                SqlCommand cmdCount = new SqlCommand(string.Format(" select count(*) as recordCount from {0} {1}", myVw, whereString), m_Conn);

                recordCount = Convert.ToInt32(cmdCount.ExecuteScalar());

                if ((recordCount % pageSize) > 0)
                    pageCount = recordCount / pageSize + 1;
                else
                    pageCount = recordCount / pageSize;
                SqlCommand cmdRecord;
                if (pageIndex == 1)//第一页
                {
                    cmdRecord = new SqlCommand(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, showString, myVw, whereString, orderString), m_Conn);
                }
                else if (pageIndex > pageCount)//超出总页数
                {
                    cmdRecord = new SqlCommand(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, showString, myVw, "where 1=2", orderString), m_Conn);
                }
                else
                {
                    int pageLowerBound = pageSize * pageIndex;
                    int pageUpperBound = pageLowerBound - pageSize;
                    string recordIDs = recordIDString(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageLowerBound, strKey, myVw, whereString, orderString), pageUpperBound);
                    string queryStringend = string.Format("select {0} from {1} where {2} in ({3}) order by {4} ", showString, myVw, strKey, recordIDs, orderString);
                    cmdRecord = new SqlCommand(queryStringend, m_Conn);

                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdRecord);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                m_Conn.Close();
                m_Conn.Dispose();
                return dt;
            }
        }
    }
}
