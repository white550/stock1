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

namespace stock1.InStock
{
    public partial class InStockList : Form
    {
        public InStockList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "不限" && comboBox2.Text != "不限" && comboBox3.Text != "不限")
            {
                int GoodsId = int.Parse(DBHelper.GetScalar("select Id from Goods where GName='" + comboBox1.Text + "'", null).ToString());
                int DepotId = int.Parse(DBHelper.GetScalar("select Id from Depot where DName='" + comboBox2.Text + "'", null).ToString());
                int ProviderId = int.Parse(DBHelper.GetScalar("select Id from Provider where PName='" + comboBox3.Text + "'", null).ToString());
                int InNum = int.Parse(textBox1.Text);

                string sql = string.Format("insert into InStock values({0},{1},{2},'{3}',{4})", GoodsId, DepotId, InNum, DateTime.Now.ToString(), ProviderId);
                int a = DBHelper.GetNonQuery(sql, null);
                if (a > 0)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }

                string sql1 = string.Format("select * from StorageInfo where GoodsID={0} and DepotId={1}", GoodsId, DepotId);
                string sql2;
                if (DBHelper.GetDataTable(sql1, null).Rows.Count == 0)
                {
                    sql2 = string.Format("insert into StorageInfo values({0},{1},{2})", GoodsId, DepotId, InNum);
                }
                else
                {
                    sql2 = string.Format("update StorageInfo set StorageNum={0} where GoodsID={1} and DepotId={2}", int.Parse(DBHelper.GetDataTable(sql1, null).Rows[0][3].ToString()) + InNum, GoodsId, DepotId);
                }
                int na = DBHelper.GetNonQuery(sql2, null);
                if (na > 0)
                {
                    MessageBox.Show("数据刷新成功");
                }
                else
                {
                    MessageBox.Show("数据刷新失败");
                }

            }
            else
            {
                MessageBox.Show("请输入相关信息");
            }
        }

        private void InStockList_Load(object sender, EventArgs e)
        {
            //下拉列表
            string sql = "select Id,GName from Goods";
            DataTable dt1 = DBHelper.GetDataTable(sql, null);
            DataRow dr1 = dt1.NewRow();
            dr1["Id"] = "0";
            dr1["GName"] = "不限";
            dt1.Rows.InsertAt(dr1, 0);
            this.comboBox1.DataSource = dt1;
            this.comboBox1.DisplayMember = "GName";
            this.comboBox1.ValueMember = "Id";

            sql = "select Id,DName from Depot";
            DataTable dt2 = DBHelper.GetDataTable(sql, null);
            DataRow dr2 = dt2.NewRow();
            dr2["Id"] = "0";
            dr2["DName"] = "不限";
            dt2.Rows.InsertAt(dr2, 0);
            this.comboBox2.DataSource = dt2;
            this.comboBox2.DisplayMember = "DName";
            this.comboBox2.ValueMember = "Id";

            sql = "select Id,PName from Provider";
            DataTable dt3 = DBHelper.GetDataTable(sql, null);
            DataRow dr3 = dt3.NewRow();
            dr3["Id"] = "0";
            dr3["PName"] = "不限";
            dt3.Rows.InsertAt(dr3, 0);
            this.comboBox3.DataSource = dt3;
            this.comboBox3.DisplayMember = "PName";
            this.comboBox3.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
