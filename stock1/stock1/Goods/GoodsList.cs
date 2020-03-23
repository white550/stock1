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
    public partial class GoodsList : Form
    {
        public static GoodsModel gd = new GoodsModel();
        public static int num = 0;
        public GoodsList()
        {
            InitializeComponent();
        }

        private void GoodsList_Load(object sender, EventArgs e)
        {
            //初始化dataGridView
            ShowGoods();

            //给下拉框物品编号显示数据
            string sql = "select Id,GoodsID from Goods";
            DataTable dt = DBHelper.GetDataTable(sql, null);
            DataRow dtRow = dt.NewRow();
            //下拉框初始化
            dtRow["Id"] = "0";
            dtRow["GoodsID"] = "不限";
            dt.Rows.InsertAt(dtRow, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "GoodsID";
            comboBox1.ValueMember = "Id";

            //给下拉框物品名称显示数据
            string sql1 = "select Id,GName from Goods";
            DataTable dt1 = DBHelper.GetDataTable(sql1, null);
            DataRow dtRow1 = dt1.NewRow();
            //下拉框初始化
            dtRow1["Id"] = "0";
            dtRow1["GName"] = "不限";
            dt1.Rows.InsertAt(dtRow1, 0);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "GName";
            comboBox2.ValueMember = "Id";
            //给下拉框商品类型显示数据
            string sql2 = "select Id,CName from Category";
            DataTable dt2 = DBHelper.GetDataTable(sql2, null);
            DataRow dtRow2 = dt2.NewRow();
            //下拉框初始化
            dtRow2["Id"] = "0";
            dtRow2["CName"] = "不限";
            dt2.Rows.InsertAt(dtRow2, 0);
            comboBox3.DataSource = dt2;
            comboBox3.DisplayMember = "CName";
            comboBox3.ValueMember = "Id";
        }
        private void ShowGoods()
        {
            //先清空数据显示控件的基本的内容
            this.dataGridView1.DataSource = null;
            //查询的sql语句
            string sql = string.Format("select  GoodsID 商品编号,GName 商品名称,UnitPrice 单价,Manufacture 生产厂家,c.CName 类型 from Goods g,Category c where g.CategoryId=c.Id");
            //给显示控件绑定数据源
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql, null);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取需要删除的某行的信息Id
            string selectedId = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string sql = string.Format("delete from Goods where GoodsID='{0}'", selectedId);
            //定义一个变量用来存储操作数据库的影响的行数
            MessageBox.Show("确定删除吗？", "删除信息", MessageBoxButtons.YesNo);
            if (DialogResult.No.Equals(false))
            {
                int num = DBHelper.GetNonQuery(sql, null);
                if (num >= 0)
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
            ShowGoods();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取界面中三个下拉框的信息
            string goodsId = comboBox1.Text;//商品编号
            string goodsName = comboBox2.Text;//商品名称
            string goodsType = comboBox3.Text;//商品的类型
            //进行查询的数据的sql语句
            string sql = "";
            if (goodsId != "不限" && goodsName == "不限" && goodsType == "不限")
            {
                sql = string.Format("select GoodsID 商品编号,GName 商品名称,UnitPrice 单价,Manufacture 生产厂家,c.CName 类型 from Goods g,Category c where g.CategoryId=c.Id and g.GoodsID='{0}'", goodsId);
            }
            else if (goodsId != "不限" && goodsName != "不限" && goodsType == "不限")
            {
                sql = string.Format("select GoodsID 商品编号,GName 商品名称,UnitPrice 单价,Manufacture 生产厂家,c.CName 类型 from Goods g,Category c where g.CategoryId=c.Id and g.GoodsID='{0}' and GName='{1}'", goodsId, goodsName);
            }
            else if (goodsId != "不限" && goodsName != "不限" && goodsType != "不限")
            {
                sql = string.Format("select GoodsID 商品编号,GName 商品名称,UnitPrice 单价,Manufacture 生产厂家,c.CName 类型 from Goods g,Category c where g.CategoryId=c.Id and g.GoodsID='{0}' and GName='{1}' and c.CName='{2}'", goodsId, goodsName, goodsType);
            }
            else if (goodsId != "不限" && goodsName == "不限" && goodsType != "不限")
            {
                sql = string.Format("select GoodsID 商品编号,GName 商品名称,UnitPrice 单价,Manufacture 生产厂家,c.CName 类型 from Goods g,Category c where g.CategoryId=c.Id and g.GoodsID='{0}' and c.CName='{1}'", goodsId, goodsType);
            }
            else if (goodsId == "不限" && goodsName == "不限" && goodsType != "不限")
            {
                sql = string.Format("select GoodsID 商品编号,GName 商品名称,UnitPrice 单价,Manufacture 生产厂家,c.CName 类型 from Goods g,Category c where g.CategoryId=c.Id and c.CName='{0}'", goodsType);
            }
            else if (goodsId == "不限" && goodsName != "不限" && goodsType != "不限")
            {
                sql = string.Format("select GoodsID 商品编号,GName 商品名称,UnitPrice 单价,Manufacture 生产厂家,c.CName 类型 from Goods g,Category c where g.CategoryId=c.Id and GName='{0}' and c.CName='{1}'", goodsName, goodsType);
            }
            else if (goodsId == "不限" && goodsName != "不限" && goodsType == "不限")
            {
                sql = string.Format("select GoodsID 商品编号,GName 商品名称,UnitPrice 单价,Manufacture 生产厂家,c.CName 类型 from Goods g,Category c where g.CategoryId=c.Id and GName='{0}'", goodsName);
            }
            else if ((goodsId == "不限" && goodsName == "不限" && goodsType == "不限"))
            {
                sql = string.Format("select GoodsID 商品编号,GName 商品名称,UnitPrice 单价,Manufacture 生产厂家,c.CName 类型 from Goods g,Category c where g.CategoryId=c.Id");
            }
            //指定数据源
            this.dataGridView1.DataSource = DBHelper.GetDataTable(sql, null);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            num = 1;
            DepotAddAndEdit dem = new DepotAddAndEdit();
            dem.ShowDialog();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            gd.GoodsID = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            gd.GName = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            gd.UnitPrice = double.Parse(this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            gd.Manufacture = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            
            
            num = 0;
            DepotAddAndEdit dem = new DepotAddAndEdit();
            dem.ShowDialog();

        }
    }
}
