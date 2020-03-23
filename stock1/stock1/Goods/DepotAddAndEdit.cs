using Stock;
using stock1.Model;
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
    public partial class DepotAddAndEdit : Form
    {
        
        public DepotAddAndEdit()
        {
            InitializeComponent();
        }
       
       public static GoodsModel gd = GoodsList.gd;

        public string sql2 ;
        public int Id;
        private void DepotAddAndEdit_Load(object sender, EventArgs e)
        {
            string sql = "select Id,CName from Category";
            DataTable dt = DBHelper.GetDataTable(sql,null);
            DataRow dr = dt.NewRow();
            dr["Id"] = "0";
            dr["CName"] = "不限";
            dt.Rows.InsertAt(dr,0);
            this.comboBox1.DataSource = dt;
            this.comboBox1.DisplayMember = "CName";
            this.comboBox1.ValueMember = "Id";

           
            int num = GoodsList.num;
            if (num==0)
            {
                //接受从物品的主界面中获取物品的信息
              
                textBox1.Text = GoodsList.gd.GoodsID;
                textBox2.Text = GoodsList.gd.GName;
                textBox3.Text = GoodsList.gd.UnitPrice.ToString();
                 textBox4.Text=GoodsList.gd.Manufacture;
            this.sql2 = string.Format("select Id from Goods where GoodsID='{0}'", GoodsList.gd.GoodsID);
                Id = int.Parse(DBHelper.GetScalar(sql2, null).ToString());

                this.Text = "修改商品信息界面";
               this.button1.Visible = false;
            }
            else
            {
                this.Text= "添加商品信息界面";
                this.button3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select Id from Category where CName='" + comboBox1.Text + "'";
            int CategoryId = int.Parse(DBHelper.GetScalar(sql, null).ToString());
            string sql1 = string.Format("insert into Goods values('{0}','{1}','{2}','{3}',{4})", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, CategoryId);
            int a = DBHelper.GetNonQuery(sql1, null);
            if (a > 0)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string sql = "select Id from Category where CName='" + comboBox1.Text + "'";
            int CategoryId = int.Parse(DBHelper.GetScalar(sql, null).ToString());
            
            string sql1 = string.Format("update Goods set GoodsID='{0}',GName='{1}',UnitPrice='{2}',Manufacture='{3}',CategoryId={4} where Id={5}", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, CategoryId,Id);
            int a = DBHelper.GetNonQuery(sql1, null);
            if (a > 0)
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
