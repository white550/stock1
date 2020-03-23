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
    public partial class DepotList : Form
    {
        public static DepotModel dm = new DepotModel();
        public static int num = 0;
        public DepotList()
        {
            InitializeComponent();
        }

        private void DepotList_Load(object sender, EventArgs e)
        {
            string sql = "select*from Depot";
          dataGridView1.DataSource=  DBHelper.GetDataTable(sql, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ckm = this.textBox1.Text;
            string sql = string.Format("select*from Depot where DName='{0}'",ckm);
            dataGridView1.DataSource = DBHelper.GetDataTable(sql, null);

        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            num = 0;
            dm.Id=int.Parse( this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dm.Ckm = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dm.Phone = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DepotAddAndEdit da = new DepotAddAndEdit();
            da.ShowDialog();

        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            num = 1;
            DepotAddAndEdit da = new DepotAddAndEdit();
            da.ShowDialog();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string sql = "delete from Depot where Id=" + id + "";
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
    }
}
