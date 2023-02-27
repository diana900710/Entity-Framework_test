using Entity_Framework練習.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_Framework練習
{
    public partial class UptateForm : Form
    {
        public UptateForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = comboBox1.Text.ToString();
            var context = new ProductsModel();
            var list = context.ProductTable.SingleOrDefault((X) => X.ProductID == result);
            textBox1.Text = list.ProductID;
            textBox2.Text = list.ProductName;
            textBox3.Text = list.Amount.ToString();
            textBox4.Text = list.Price.ToString();
            comboBox2.Text = list.ProductType;
        }

        private void UptateForm_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'productDataSet4.ProductTable' 資料表。您可以視需要進行移動或移除。
            this.productTableTableAdapter.Fill(this.productDataSet4.ProductTable);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = comboBox1.Text.ToString();
            var context = new ProductsModel();
            var list = context.ProductTable.SingleOrDefault((X) => X.ProductID == result);
            using (ProductsModel data = new ProductsModel())
            {
                ////先取得 David 的資料
                var u = data.ProductTable.SingleOrDefault((x) => x.ProductID == result);
                data.ProductTable.Remove(u);
                var uptate = new ProductTable();
                uptate.ProductID = textBox1.Text;
                uptate.ProductName = textBox2.Text;
                uptate.Amount = int.Parse(textBox3.Text);
                uptate.Price= int.Parse(textBox4.Text);
                uptate.ProductType = comboBox2.Text;
                data.ProductTable.Add(uptate);
                ////儲存變更
                data.SaveChanges();
            }
            try
            {
                MessageBox.Show("修改完成");
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤 {ex.ToString()}");
            }
        }
        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
