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

namespace stock1.OutStock
{
    public partial class OutStockList : Form
    {
        public OutStockList()
        {
            InitializeComponent();
        }

        private void OutStockList_Load(object sender, EventArgs e)
        {
            string sql = "select a.GoodsID,a.GName,b.DName,c.CName,d.OutNum,d.OutDate from Goods a,Depot b,Customer c,Outstock d where d.GoodsId=a.Id and d.DepotId=b.Id and d.CustomerId=c.Id";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql, null);

            string sql1 = "select Id,GName from Goods";
            DataTable dt = DBHelper.GetDataTable(sql1, null);
            DataRow dr = dt.NewRow();
            dr["Id"] = "0";
            dr["GName"] = "不限";
            dt.Rows.InsertAt(dr, 0);
            this.comboBox1.DataSource = dt;
            this.comboBox1.DisplayMember = "GName";
            this.comboBox1.ValueMember = "Id";

            string sql2 = "select Id,DName from Depot";
            DataTable dt2 = DBHelper.GetDataTable(sql2, null);
            DataRow dr2 = dt2.NewRow();
            dr2["Id"] = "0";
            dr2["DName"] = "不限";
            dt2.Rows.InsertAt(dr2, 0);
            this.comboBox2.DataSource = dt2;
            this.comboBox2.DisplayMember = "DName";
            this.comboBox2.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            if (comboBox1.Text == "不限" && comboBox2.Text == "不限")
            {
                sql = "select a.GoodsID,a.GName,b.DName,c.CName,d.OutNum,d.OutDate from Goods a,Depot b,Customer c,Outstock d where d.GoodsId=a.Id and d.DepotId=b.Id and d.CustomerId=c.Id";
            }
            else if (comboBox1.Text != "不限" && comboBox2.Text == "不限")
            {
                sql = string.Format("select a.GoodsID,a.GName,b.DName,c.CName,d.OutNum,d.OutDate from Goods a,Depot b,Customer c,Outstock d where d.GoodsId=a.Id and d.DepotId=b.Id and d.CustomerId=c.Id and a.GName='{0}'", comboBox1.Text);
            }
            else if (comboBox1.Text == "不限" && comboBox2.Text != "不限")
            {
                sql = string.Format("select a.GoodsID,a.GName,b.DName,c.CName,d.OutNum,d.OutDate from Goods a,Depot b,Customer c,Outstock d where d.GoodsId=a.Id and d.DepotId=b.Id and d.CustomerId=c.Id and b.DName='{0}'", comboBox2.Text);
            }
            else
            {
                sql = string.Format("select a.GoodsID,a.GName,b.DName,c.CName,d.OutNum,d.OutDate from Goods a,Depot b,Customer c,Outstock d where d.GoodsId=a.Id and d.DepotId=b.Id and d.CustomerId=c.Id and a.GName='{0}' and b.DName='{1}'", comboBox1.Text, comboBox2.Text);
            }
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql, null);
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutStockAddAndEdit qs = new OutStockAddAndEdit();
            qs.ShowDialog();
        }
    }
}
