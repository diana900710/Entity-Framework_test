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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Entity_Framework練習
{
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'productDataSet.ProductTable' 資料表。您可以視需要進行移動或移除。
            this.productTableTableAdapter.Fill(this.productDataSet.ProductTable);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = comboBox1.Text.ToString();
            var context = new ProductsModel();
            var list = context.ProductTable.SingleOrDefault((X) => X.ProductID == result);
            label7.Text = list.ProductID;
            label8.Text = list.ProductName;
            label9.Text = list.Amount.ToString();
            label10.Text = list.Price.ToString();
            label11.Text = list.ProductType;
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

                ////刪除 David
                data.ProductTable.Remove(u);

                ////儲存變更
                data.SaveChanges();
            }
            try
            {
                MessageBox.Show("刪除商品資料完成");
                ClearLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤 {ex.ToString()}");
            }
        }

        private void ClearLabel()
        {
            label7.Text = "無";
            label8.Text = "無";
            label9.Text = "無";
            label10.Text = "無";
            label11.Text = "無";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
