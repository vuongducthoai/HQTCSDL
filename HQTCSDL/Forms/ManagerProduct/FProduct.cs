using HQTCSDL.Forms.ManagerProduct.Page;
using HQTCSDL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL.Forms.ManagerProduct
{
    public partial class FProduct : Form
    {
        Product product = new Product();
        public FProduct()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddProduct form = new AddProduct();
            form.ShowDialog();
            LoadTableAllProduct();
            textSearch.Text = "";
        }

        private void FProduct_Load(object sender, EventArgs e)
        {
            LoadTableAllProduct();
        }
        private void LoadTableAllProduct()
        {
            try
            {
                dataGridView1.DataSource = product.getAllProducts();
                dataGridView1.Columns["IdProduct"].HeaderText = "Mã Sản Phẩm";
                dataGridView1.Columns["NameProduct"].HeaderText = "Tên Sản Phẩm";
                dataGridView1.Columns["Image"].HeaderText = "Ảnh";
                dataGridView1.Columns["OriginalColumnName"].HeaderText = "Giá";
                DataGridViewImageColumn picol1 = (DataGridViewImageColumn)dataGridView1.Columns["Image"];
                picol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
            catch { }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idProduct = dataGridView1.Rows[e.RowIndex].Cells["IdProduct"].Value.ToString();
                int id = Convert.ToInt32(idProduct);

            }
        }
    }
}
