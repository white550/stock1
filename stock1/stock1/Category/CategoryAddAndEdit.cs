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

namespace stock1.Category
{
   

    public partial class CategoryAddAndEdit : Form
    {
        CategoryModel cm1 = new CategoryModel();

        public CategoryAddAndEdit()
        {
            InitializeComponent();
        }

        private void CategoryAddAndEdit_Load(object sender, EventArgs e)
        {
            int num = CategoryList.num;
            if (num==0)
            {
                cm1 = CategoryList.cm;
               this.textBox1.Text = cm1.Lx;
                this.Text = "修改";
                this.button1.Visible = false;
            }
            else
            {
                this.Text = "添加";
                this.button2.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lx = this.textBox1.Text;
            string sql = string.Format("insert into Category values('{0}')",lx);
          int jg=  DBHelper.GetNonQuery(sql,null);
            if (jg>0)
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
            string lx = this.textBox1.Text;
            string sql = string.Format("update Category set CName='{0}'where Id={1}", lx, cm1.Id);
            int jg = DBHelper.GetNonQuery(sql, null);
            if (jg > 0)
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
