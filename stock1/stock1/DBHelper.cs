using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Stock
{
    public class DBHelper
    {
        static string strConn = ConfigurationManager.AppSettings["strConn"];
        /// <summary>
        ///查询
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="Param">参数</param>
        /// <returns>返回DataTable</returns>
        public static DataTable GetDataTable(string sql,Dictionary<string,object> Param)
        {
            DataSet ds = null;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    if (Param!=null)
                    {
                        foreach (KeyValuePair<string,object> item in Param)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        sda.Fill(ds);
                    }
                }
                
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="Param">参数</param>
        /// <returns>返回DataTable</returns>
        public static DataTable GetDataTable(string sql, Dictionary<string, object> Param,int StartNum,int EndNum)
        {
            DataSet ds = null;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format("select * from ({0}) as fa where fa.num>{1} and fa.num <={2}", sql, StartNum, EndNum);
                    cmd.CommandType = CommandType.Text;
                    if (Param != null)
                    {
                        foreach (KeyValuePair<string, object> item in Param)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        sda.Fill(ds);
                    }
                }

            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取单个值，如：行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="Param">参数</param>
        /// <returns>返回一行一列</returns>
        public static object GetScalar(string sql, Dictionary<string, object> Param)
        {
            object obj = null;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    if (Param != null)
                    {
                        foreach (KeyValuePair<string, object> item in Param)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                   obj= cmd.ExecuteScalar();

                }

            }
            return obj;
        }

        /// <summary>
        /// 增加、修改、删除
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="Param">参数</param>
        /// <returns>返回受影响行数</returns>
        public static int GetNonQuery(string sql, Dictionary<string, object> Param)
        {
            int obj = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    if (Param != null)
                    {
                        foreach (KeyValuePair<string, object> item in Param)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                       obj = cmd.ExecuteNonQuery();

                }

            }
            return obj;
        }
        
    }
}
