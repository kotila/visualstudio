using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using MysqlCo

namespace StockTools
{
    public partial class FrmTools : Form
    {
        private DataSet dsall;
        //private static String mysqlcon = "database=storage_db;Password=root123;User ID=root;server=localhost";
        private static String mysqlcon = "database=storage_db;Password=equery!@#*();User ID=root;server=54.217.254.166";
        private MySqlConnection conn;
        //private MysqlConnection myconn;
        private MySqlDataAdapter mDataAdapter;
        public FrmTools()
        {
            InitializeComponent();
            //构造数据源（或从数据库中查询）  
            DataTable ADt = new DataTable();
            DataColumn ADC1 = new DataColumn("disp_name", typeof(string));
            DataColumn ADC2 = new DataColumn("table_name", typeof(string));
            ADt.Columns.Add(ADC1);
            ADt.Columns.Add(ADC2);
            //for (int i = 0; i < 3; i++)
            //{
            DataRow ADR = ADt.NewRow();
            ADR[0] = "库存表";
            ADR[1] = "commstock_stock";
            ADt.Rows.Add(ADR);

            DataRow ADR1 = ADt.NewRow();
            ADR1[0] = "出库订单表";
            ADR1[1] = "process_appform";
            ADt.Rows.Add(ADR1);

            DataRow ADR2 = ADt.NewRow();
            ADR2[0] = "商品表";
            ADR2[1] = "commstock_commodity";
            ADt.Rows.Add(ADR2);
            //}


            //进行绑定  
            cmbTableList.DisplayMember = "disp_name";//控件显示的列名  
            cmbTableList.ValueMember = "table_name";//控件值的列名  
            cmbTableList.DataSource = ADt;
            cmbTableList.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(mysqlcon);

                string szTableName;
                string strQuerySQL="";

                szTableName = cmbTableList.SelectedValue.ToString();
                if (szTableName.ToLower().Trim() == "process_appform")
                {
                    string sztemp = " and state<> 'SendFinished' and state<>'Editing' and state<>'Stoped' and state<>'' and state<>'Cancel'";
                    strQuerySQL = "select id,create_time,last_opr_time,state,submit_time,tenant_id,channel_service from " + szTableName + " " +
                        "where  app_form_type='Exwarehouse'" + sztemp;

                }
                if (szTableName.ToLower().Trim() == "commstock_stock")
                {
                    strQuerySQL = "select * from " + szTableName;
                }
                if (szTableName.ToLower().Trim() == "commstock_commodity")
                {
                    strQuerySQL = "select id,name_cn,name_en,state,tenant_id from " + szTableName;

                }

                mDataAdapter = new MySqlDataAdapter(strQuerySQL, conn);
                dsall = new DataSet();
                mDataAdapter.Fill(dsall, szTableName);


                dataGridView1.DataSource = dsall.Tables[szTableName];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection(mysqlcon);
            int amount = Int32.Parse(textAmount.Text);
            int skuNum = Int32.Parse(textSKU.Text);
            MySqlCommand SqlCmd;
            //SqlCmd.Connection = conn;
            //使用数据库连接对象连接数据库 
            //conn.Open();

            SqlCmd = new MySqlCommand("update commstock_stock set age=" + amount + " where commodity_id=skuNum ", conn);
            SqlCmd.ExecuteNonQuery();
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
