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

namespace stock1.Depot
{
    public partial class DepotAddAndEdit : Form
    {
        DepotModel dm = new DepotModel();
        int num;
        public DepotAddAndEdit()
        {
            InitializeComponent();
        }

        private void DepotAddAndEdit_Load(object sender, EventArgs e)
        {
             num = DepotList.num;
            if (num==0)
            {
                dm = DepotList.dm;
                this.textBox1.Text = dm.Ckm;
                this.textBox2.Text = dm.Phone;
                this.Text = "修改";
                this.button1.Visible = false;
            }
            else
            {
                this.Text = "添加";
                this.button3.Visible = false;
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           string sql = string.Format("update Depot set DName='{0}',Phone='{1}' where Id={2}", this.textBox1.Text, this.textBox2.Text, dm.Id);
            int a = DBHelper.GetNonQuery(sql, null);
            if (a > 0)
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string sql = string.Format("insert into Depot values('{0}','{1}')", this.textBox1.Text, this.textBox2.Text);
            int a = DBHelper.GetNonQuery(sql, null);
            if (a > 0)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
