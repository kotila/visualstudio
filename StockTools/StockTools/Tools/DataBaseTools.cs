using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Web;
using System.Configuration;
using System.Data;
using System.Net.Http;
namespace StockTools
{
    public class DataBaseTools
    {

        /// <summary> 
        /// Public 的摘要说明 
        /// </summary> 
        //定义一个公用成员 
        public MySqlConnection conn;

        public DataBaseTools()
        {
            // 
            // TODO: 在此处添加构造函数逻辑 
            // 
        }
        #region 建立数据库连接 
        public void OpenConn()
        {
            String strconn = ConfigurationManager.ConnectionStrings["testconn"].ToString();
            //String strconn = ConfigurationManager.ConnectionStrings["conMysql"].ToString();
            conn = new MySqlConnection(strconn);
            if (conn.State.ToString().ToLower() == "open")
            {
                //连接为打开时 
            }
            else
            {
                //连接为关闭时 
                conn.Open();
            }
        }
        #endregion
        #region 关闭并释放连接 
        public void CloseConn()
        {
            if (conn.State.ToString().ToLower() == "open")
            {
                //连接为打开时 
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion
        #region 返回DataReader，用于读取数据 
        public MySqlDataReader DataRead(string sql)
        {
            OpenConn();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        #endregion
        #region 返回一个数据集 
        public DataSet MySqlDataSet(string Sql, string tableName)
        {
            OpenConn();
            MySqlDataAdapter da;
            DataSet ds = new DataSet();
            da = new MySqlDataAdapter(Sql, conn);
            da.Fill(ds, tableName);
            CloseConn();



            return ds;
        }
        #endregion
        //返回一个数据集 
        public DataView MySqlDataSource(string Sql)
        {
            OpenConn();
            MySqlDataAdapter da;
            DataSet ds = new DataSet();
            da = new MySqlDataAdapter(Sql, conn);
            da.Fill(ds, "temp");
            CloseConn();
            return ds.Tables[0].DefaultView;
        }
        #region 执行一个SQL操作:添加、删除、更新操作 

        //执行一个SQL操作:添加、删除、更新操作 
        public void MySqlExcute(string sql)
        {
            OpenConn();
            MySqlCommand cmd;
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            CloseConn();
        }
        #endregion
        #region 执行一个SQL操作:添加、删除、更新操作，返回受影响的行 
        //执行一个SQL操作:添加、删除、更新操作，返回受影响的行 
        public int MySqlExecuteNonQuery(string sql)
        {
            OpenConn();
            MySqlCommand cmd;
            cmd = new MySqlCommand(sql, conn);
            int flag = cmd.ExecuteNonQuery();
            return flag;
        }
        #endregion

        public object MySqlExecuteScalar(string sql)
        {
            OpenConn();
            MySqlCommand cmd;
            cmd = new MySqlCommand(sql, conn);
            object obj = cmd.ExecuteScalar();
            cmd.Dispose();
            CloseConn();
            return obj;
        }

        /// <summary> 
        /// 返回DataTable对象 
        /// </summary> 
        /// <param name="sql">sql语句</param> 
        /// <returns></returns> 
        public DataTable MySqlDataTable(string sql)
        {
            OpenConn();
            DataSet ds = new DataSet();
            MySqlDataAdapter da;
            da = new MySqlDataAdapter(sql, conn);
            da.Fill(ds, "table");
            CloseConn();
            return ds.Tables["table"];
        }

        /// <summary> 
        /// 返回一个数据集的记录数 
        /// </summary> 
        /// <param name="sql">传递的sql语句必须为一个统计查询</param> 
        /// <returns></returns> 
        public int MySqlRecordCount(string sql)
        {
            //注：Sql 语句必须是一个统计查询 
            OpenConn();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            int RecordCount = -1;
            while (dr.Read())
            {
                RecordCount = int.Parse(dr[0].ToString());
            }
            CloseConn();
            return RecordCount;
        }

        /// <summary> 
        /// 自定义的功能警告 
        /// </summary> 
        /// <param name="str">弹出信息框内容</param> 
        public void SetAlert(string str)
        {
            //HttpContext.Current.Response.Write("<script language='JavaScript' type='text/JavaScript'>alert('" + str + "');</script>");

        }
        //返回上一页 
        public void AddErro(string message)
        {
            //HttpContext.Current.Response.Write("<script>alert('" + message + "');history.back(-1);</script>");
        }


        //关闭窗口 
        public void SetCloseWindow()
        {
            //HttpContext.Current.Response.Write("<script language='JavaScript' type='text/JavaScript'>window.close();</script>");
        }

        /// <summary> 
        /// 地址跳转 
        /// </summary> 
        /// <param name="str">跳转地址</param> 
        public void SetLocation(string str)
        {
            //HttpContext.Current.Response.Write("<script language='JavaScript' type='text/JavaScript'>location='" + str + "';</script>");
        }


        public string AjaxSetAlert(string str)
        {
            return "<script language='JavaScript' type='text/JavaScript'>alert('" + str + "');</script>";
        }

        //过滤非法字符 
        public string FilterStr(string Str)
        {
            Str = Str.Trim();
            Str = Str.Replace("*", "");
            Str = Str.Replace("=", "");
            Str = Str.Replace("/", "");
            Str = Str.Replace("$", "");
            Str = Str.Replace("#", "");
            Str = Str.Replace("@", "");
            Str = Str.Replace("&", "");
            return Str;
        }

        //Md5加密算法 
        //public string md5(string str)
        //{
        //    //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToLower().Substring(0, 12);
        //}
        public string RndNum(int VcodeNum)
        {
            string Vchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,Q,R,S,T,U,W,X";
            string[] VcArray = Vchar.Split(new Char[] { ',' }); //将字符串生成数组 
            string VNum = "";
            int temp = -1;

            Random rand = new Random();

            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(31);            //数组一般从0开始读取，所以这里为31*Rnd 
                if (temp != -1 && temp == t)
                {
                    return RndNum(VcodeNum);
                }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;
        }
    }
}
