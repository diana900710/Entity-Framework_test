using Entity_Framework練習.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_Framework練習
{
    public partial class ViewForm : Form
    {
        public ViewForm()
        {
            InitializeComponent();
            comboBox1.Text = "全部";
            BindData();
        }
        private void BindData()
        {
            var context = new ProductsModel();
            var list = context.ProductTable.ToList();
            dataGridView1.DataSource = list;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var context = new ProductsModel();
            var result = comboBox1.Text;
            switch (result)
            {
                case "全部":
                    dataGridView1.DataSource = context.ProductTable.ToList();
                    break;
                case "3C":
                    dataGridView1.DataSource = context.ProductTable.Where((x) => x.ProductType == result).ToList();
                    break;
                case "食品":
                    dataGridView1.DataSource = context.ProductTable.Where((x) => x.ProductType == result).ToList();
                    break;
                case "飲料":
                    dataGridView1.DataSource = context.ProductTable.Where((x) => x.ProductType == result).ToList();
                    break;
                default:
                    MessageBox.Show("錯誤!!");
                    break;
            }
        }
    }
}
