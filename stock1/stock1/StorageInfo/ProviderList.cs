using Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stock1
{
    public partial class ProviderList : Form
    {
        public ProviderList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (comboBox1.Text == "不限" && comboBox2.Text == "不限")
            {
                sql = string.Format("select a.GoodsID,a.GName,a.UnitPrice,b.DName,c.StorageNum,a.Manufacture from Goods a,Depot b,StorageInfo c ");
            }
            else if (comboBox1.Text != "不限" && comboBox2.Text == "不限")
            {
                sql = string.Format("select a.GoodsID,a.GName,a.UnitPrice,b.DName,c.StorageNum,a.Manufacture from Goods a, Depot b,StorageInfo c where a.GName = '{0}'", comboBox1.Text);

            }
            else if (comboBox1.Text == "不限" && comboBox2.Text != "不限")
            {
                sql = string.Format("select a.GoodsID,a.GName,a.UnitPrice,b.DName,c.StorageNum,a.Manufacture from Goods a, Depot b,StorageInfo c where b.DName = '{0}'", comboBox2.Text);
            }
            else
            {
                sql = string.Format("select a.GoodsID,a.GName,a.UnitPrice,b.DName,c.StorageNum,a.Manufacture from Goods a, Depot b,StorageInfo c where a.GName = '{0}' and b.DName = '{1}'", comboBox1.Text, comboBox2.Text);
            }
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql, null);
        }

        private void ProviderList_Load(object sender, EventArgs e)
        {
            StringBuilder sbSelect = new StringBuilder();
            sbSelect.Append("select a.GoodsID,a.GName,a.UnitPrice,b.DName,c.StorageNum,a.Manufacture from Goods a,Depot b,StorageInfo c ");
            DataTable dt = DBHelper.GetDataTable(sbSelect.ToString(), null);
            this.dataGridView1.DataSource = dt;
            //下拉框
            string sql = "select ID,GName from Goods";
            DataTable dd = DBHelper.GetDataTable(sql, null);
            DataRow dr = dd.NewRow();
            //下拉框初始化
            dr["ID"] = "0";
            dr["GName"] = "不限";
            dd.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dd;
            comboBox1.DisplayMember = "GName";
            comboBox1.ValueMember = "ID";
            //下拉框
            string sql1 = "select ID,DName from Depot";
            DataTable dd1 = DBHelper.GetDataTable(sql1, null);
            DataRow dr1 = dd1.NewRow();
            //下拉框初始化
            dr1["ID"] = "0";
            dr1["DName"] = "不限";
            dd1.Rows.InsertAt(dr1, 0);
            comboBox2.DataSource = dd1;
            comboBox2.DisplayMember = "DName";
            comboBox2.ValueMember = "ID";
        }
    }
}
