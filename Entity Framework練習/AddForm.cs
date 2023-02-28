using Entity_Framework練習.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Entity_Framework練習
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            var context = new ProductsModel();
            var num = (context.ProductTable.Count()+1).ToString();
            textBox1.Text = "P" + num.PadLeft(3, '0');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductTable data = new ProductTable()
            {
                ProductID = textBox1.Text.Trim(),
                ProductName = textBox2.Text.Trim(),
                Amount = int.Parse(textBox3.Text.Trim()),
                Price = int.Parse(textBox4.Text.Trim()),
                ProductType = comboBox1.Text.Trim(),
            };
            try
            {
                ProductsModel context = new ProductsModel();
                context.ProductTable.Add(data);
                context.SaveChanges();
                MessageBox.Show("存檔完成");
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤 {ex.ToString()}");
            }
        }

        private void ClearTextBoxes()
        {
            var context = new ProductsModel();
            var num = (context.ProductTable.Count() + 1).ToString();
            textBox1.Text = "P" + num.PadLeft(3, '0');
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
