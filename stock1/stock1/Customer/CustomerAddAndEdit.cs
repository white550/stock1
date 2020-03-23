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
    public partial class CustomerAddAndEdit : Form
    {
        public CustomerAddAndEdit()
        {
            InitializeComponent();
        }
        CustomerModel cm1 = new CustomerModel();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
                string xm = this.textBox1.Text;
                string phone = this.textBox2.Text;
                string dz = this.textBox3.Text;
            if (xm == "" && phone == "" && dz == "")
            {
                MessageBox.Show("请保存完整");
            }

            else
            {
                string sql = string.Format("insert into Customer(CName,Address,Phone)values('{0}','{1}','{2}')", xm, dz, phone);
                int b = DBHelper.GetNonQuery(sql, null);
                if (b > 0)
                {
                    MessageBox.Show("添加成功");

                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            
           
            
        }
       
        private void CustomerAddAndEdit_Load(object sender, EventArgs e)
        {
            //初始化的界面
            int num = CustomerList.num;
            if (num==0)
            {
                cm1 = CustomerList.cm;

                textBox1.Text = cm1.CName1;
                textBox3.Text = cm1.Phone1;
                textBox2.Text = cm1.Address1;
                this.button1.Visible = false;
                this.Text = "修改";
            }
            else
            {
                this.button3.Visible = false;
                this.Text = "添加";
            }
           
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string xm = this.textBox1.Text;
            string phone = this.textBox2.Text;
            string dz = this.textBox3.Text;
            int id = cm1.Id1;
            string sql = string.Format("update Customer set CName='{0}',Address='{1}',Phone='{2}'where Id={3}",xm,dz,phone,id);
            int b = DBHelper.GetNonQuery(sql, null);
            if (b > 0)
            {
                MessageBox.Show("修改成功");

            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}
