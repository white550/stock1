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

namespace stock1.Customer
{
    public partial class CustomerList : Form
    {
        //静态对象传递数据（被修改的）
        public static CustomerModel cm = new CustomerModel();
        public static int num = 0;
        public CustomerList()
        {
            InitializeComponent();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            num = 1;
            CustomerAddAndEdit cus = new CustomerAddAndEdit();
            cus.ShowDialog();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取被选中的内容
            
            cm.Id1 = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            cm.CName1 = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cm.Phone1 = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cm.Address1 = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            
            num = 0;
            CustomerAddAndEdit cus = new CustomerAddAndEdit();
            cus.ShowDialog();
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            cx();
            
        }
        private void cx()
        {
            string sql = "select *from Customer";
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql, null);

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取选择的id
            string id = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


            //定义sql语句并执行
            string sql = string.Format("delete from Customer where Id = {0}",id);
            int b = DBHelper.GetNonQuery(sql, null);
            if (b > 0)
            {
                MessageBox.Show("删除成功");

            }
            else
            {
                MessageBox.Show("删除失败");
            }

            //执行重新查询的方法
            cx();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;
            string sql = string.Format("select * from Customer where CName like'%{0}%'",name);
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql, null);

        }
    }
}
