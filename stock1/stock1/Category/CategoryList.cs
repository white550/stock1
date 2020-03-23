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
    public partial class CategoryList : Form
    {
        public static int num = 0;
        public static CategoryModel cm = new CategoryModel();
        public CategoryList()
        {
            InitializeComponent();
        }
        private void cx()
        {
            string sql = "select*from Category";
            dataGridView1.DataSource = DBHelper.GetDataTable(sql, null);

        }
        private void CategoryList_Load(object sender, EventArgs e)
        {
            cx();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lx = this.textBox1.Text;
            string sql = string.Format("select*from Category where CName='{0}'",lx);
            dataGridView1.DataSource = DBHelper.GetDataTable(sql, null);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string sql = string.Format("delete from Category where Id={0}",id);
            int a = DBHelper.GetNonQuery(sql, null);
            if (a > 0)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            num = 1;
            CategoryAddAndEdit ca = new CategoryAddAndEdit();
            ca.ShowDialog();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            num = 0;
            cm.Id = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cm.Lx = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            CategoryAddAndEdit ca = new CategoryAddAndEdit();
            ca.ShowDialog();
        }
    }
}
