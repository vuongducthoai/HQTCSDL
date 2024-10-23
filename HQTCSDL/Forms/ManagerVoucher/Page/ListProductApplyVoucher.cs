using HQTCSDL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL.Forms.ManagerVoucher.Page
{
    public partial class ListProductApplyVoucher : Form
    {
        My_DB db = new My_DB();
        private int id;
        public ListProductApplyVoucher(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ListProductApplyVoucher_Load(object sender, EventArgs e)
        {
            LoadTableAllProduct();   
        }

        private void LoadTableAllProduct()
        {
            try
            {
                DataTable table = new DataTable();
                SqlCommand cmd = new SqlCommand("Select IdProduct,NameProduct,Image,price " +
                    "from Product where idVoucher = @id", db.getConnection);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView1.RowTemplate.Height = 60;
                dataGridView1.DataSource = table;
                dataGridView1.Columns["IdProduct"].HeaderText = "Mã Sản Phẩm";
                dataGridView1.Columns["NameProduct"].HeaderText = "Tên Sản Phẩm";
                dataGridView1.Columns["Image"].HeaderText = "Ảnh";
                dataGridView1.Columns["price"].HeaderText = "Giá";
                DataGridViewImageColumn picol1 = (DataGridViewImageColumn)dataGridView1.Columns[2];
                picol1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
