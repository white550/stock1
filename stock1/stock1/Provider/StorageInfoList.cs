using Stock;
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

namespace stock1.Provider
{
    public partial class StorageInfoList : Form
    {
        public StorageInfoList()
        {
            InitializeComponent();
        }
        public static ProviderModel pm = new ProviderModel();
        public static int num = 0;
        DataTable dt = new DataTable();
        public void cx()
        {
            string sql = "select *from Provider";
            
            dt=DBHelper.GetDataTable(sql, null);
            dataGridView1.DataSource = dt;
        }
        private void ProviderList_Load(object sender, EventArgs e)
        {
            cx();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;
            string sql = string.Format("select *from Provider where PName like'%{0}%'",name);
            dt = DBHelper.GetDataTable(sql, null);
            dataGridView1.DataSource = dt;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string sql = "delete from Provider where Id=" + Id + "";
            int a = DBHelper.GetNonQuery(sql, null);
            if (a > 0)
            {
                MessageBox.Show("删除成功");
                string sql1 = "select * from Provider";
                this.dataGridView1.DataSource = DBHelper.GetDataTable(sql1, null);
            }
            else
            {
                MessageBox.Show("删除失败");
            }

        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            num = 1;
            ProviderAddAndEdit pr = new ProviderAddAndEdit();
            pr.ShowDialog();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            num = 0;
            pm.Id=int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            pm.Name = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            pm.Phone= this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            pm.Address= this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

            ProviderAddAndEdit pr = new ProviderAddAndEdit();
            pr.ShowDialog();
        }
    }
}
