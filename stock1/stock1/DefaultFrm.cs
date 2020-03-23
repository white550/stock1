using stock1.Category;
using stock1.Customer;
using stock1.Depot;
using stock1.InStock;
using stock1.OutStock;
using stock1.Provider;
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
    public partial class DefaultFrm : Form
    {
        public DefaultFrm()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("要退出吗？", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProviderList pr = new ProviderList();
            pr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GoodsList gs = new GoodsList();
            gs.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CustomerList cus = new CustomerList();
            cus.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StorageInfoList si = new StorageInfoList();
            si.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InStockAddAndEdit ia = new InStockAddAndEdit();
            ia.ShowDialog();
        }

        private void DefaultFrm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DepotList dt = new DepotList();
            dt.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OutStockList qs = new OutStockList();
            qs.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CategoryList cl = new CategoryList();
            cl.ShowDialog();
        }
    }
}
