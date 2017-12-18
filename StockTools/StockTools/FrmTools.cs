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

namespace StockTools
{
    public partial class FrmTools : Form
    {
        private DataSet dsall;
        //private static String mysqlcon = "database=storage_db;Password=equery!@#*();User ID=root;server=54.217.254.166";

        private DataBaseTools dbtools = new DataBaseTools();

        public FrmTools()
        {
            InitializeComponent();
            //构造数据源（或从数据库中查询）  
            DataTable ADt = new DataTable();
            DataColumn ADC1 = new DataColumn("disp_name", typeof(string));
            DataColumn ADC2 = new DataColumn("table_name", typeof(string));
            ADt.Columns.Add(ADC1);
            ADt.Columns.Add(ADC2);

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

            dbtools.OpenConn();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
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

                dsall = dbtools.MySqlDataSet(strQuerySQL, szTableName);


                System.Data.DataTable table = new DataTable();
                System.Data.DataColumn column = new DataColumn();

                column.ColumnName = "NO.";
                column.AutoIncrement = true;
                column.AutoIncrementSeed = 1;
                column.AutoIncrementStep = 1;

                table.Columns.Add(column);
                table.Merge(dsall.Tables[0]);

                //dataGridView1.DataSource = dsall.Tables[szTableName];
                dataGridView1.DataSource = table;
                dataGridView1.Columns["NO."].DisplayIndex = 0;//调整列顺序


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                dbtools.CloseConn();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int amount = Int32.Parse(textAmount.Text);
            int skuNum = Int32.Parse(textSKU.Text);

            string updateSql = "update commstock_stock set age=" + amount + " where commodity_id=skuNum ";

            dbtools.MySqlExecuteNonQuery(updateSql);

        }

    }
}
