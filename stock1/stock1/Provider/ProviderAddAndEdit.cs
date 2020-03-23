using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stock1.Model;
using System.Windows.Forms;
using Stock;

namespace stock1.Provider
{
    public partial class ProviderAddAndEdit : Form
    {
        public ProviderAddAndEdit()
        {
            InitializeComponent();
        }

        ProviderModel pm =new ProviderModel();
        private void ProviderAddAndEdit_Load(object sender, EventArgs e)
        {
            int num = StorageInfoList.num;
            if (num==1)
            {
                this.button2.Visible = false;
                this.Text = "添加供货商信息";
            }
            else
            {
                pm = StorageInfoList.pm;
                this.textBox1.Text=  pm.Name;
                this.textBox2.Text = pm.Phone ;
                this.textBox3.Text = pm.Address ;
                this.button1.Visible = false;
                this.Text = "修改供货商信息";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = string.Format("update Provider set PName='{0}',Phone='{1}',Address='{2}' where Id={3}", textBox1.Text, textBox2.Text, textBox3.Text, pm.Id);
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
            string sql = string.Format("insert into Provider values('{0}','{1}','{2}')", textBox1.Text, textBox2.Text, textBox3.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
