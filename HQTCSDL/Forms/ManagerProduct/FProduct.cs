using HQTCSDL.Forms.ManagerProduct.Page;
using HQTCSDL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HQTCSDL.Forms.ManagerProduct
{
    public partial class FProduct : Form
    {
        private int chedo = 0; //bam sua
        Product product = new Product();
        Service service = new Service();
        string imagePath = Path.Combine(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName).Parent.FullName,"HQTCSDL", "image", "Untitled-1-3.png");

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
                dataGridView1.RowTemplate.Height = 60;
                dataGridView1.DataSource = product.getAllProducts();
                dataGridView1.Columns["IdProduct"].HeaderText = "Mã Sản Phẩm";
                dataGridView1.Columns["NameProduct"].HeaderText = "Tên Sản Phẩm";
                dataGridView1.Columns["Image"].HeaderText = "Ảnh";
                dataGridView1.Columns["price"].HeaderText = "Giá";
                DataGridViewImageColumn picol1 = (DataGridViewImageColumn)dataGridView1.Columns[2];
                picol1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            }
            catch (Exception ex){
             
            }
        }
        private void Reset()
        {
            textId.Text = "";
            textName.Text = "";
            textSearch.Text = "";
            textDes.Text = "";
            Price.Value = 0;
            idVoucher.Text = "";
            pictureBox1.Image = Image.FromFile(imagePath);
            textName.Enabled = false;
            textDes.Enabled = false;
            Price.Enabled = false;
            btn_sua.Text = "Sửa";
            btnNhap.Visible = false;
            LoadTableAllProduct();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idProduct = dataGridView1.Rows[e.RowIndex].Cells["IdProduct"].Value.ToString();
                int id = Convert.ToInt32(idProduct);
                DataTable table = product.getProductById(id);
                textId.Text = id.ToString();
                textName.Text = table.Rows[0]["NameProduct"].ToString();
                textDes.Text = table.Rows[0]["Description"].ToString();
                Price.Value = (decimal)table.Rows[0]["Price"];
                pictureBox1.Image = service.ByteArrayToImage((byte[])table.Rows[0]["Image"]);
                idVoucher.Text = table.Rows[0]["idVoucher"].ToString();
            }
        }

        private void click_Change()
        {

            textName.Enabled = true;
            textDes.Enabled = true;
            Price.Enabled = true;
            btn_sua.Text = "Gửi";
            btnNhap.Visible = true;

        }
        private void click_Submit()
        {
            try
            {
                int id = Convert.ToInt32(textId.Text);
                string name = textName.Text;
                string des = textDes.Text;
                decimal price = Price.Value;
                MemoryStream pic = new MemoryStream();
                try
                {
                    using (Bitmap tempImage = new Bitmap(pictureBox1.Image))
                    {
                        tempImage.Save(pic, pictureBox1.Image.RawFormat);
                    }
                }
                catch
                {
                    MessageBox.Show("Images are problematic", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (product.updateProduct(id, name, pic,des, price))
                {
                    MessageBox.Show("Cập nhập thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có gì để cập nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textName.Enabled = false;
            textDes.Enabled = false;
            Price.Enabled = false;
            btn_sua.Text = "Sửa";
            btnNhap.Visible = false;
            LoadTableAllProduct();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                if (chedo == 0)
                {
                    click_Change();
                }
                else
                {
                    click_Submit();
                }
                chedo = 1 - chedo;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                int id = Convert.ToInt32(textId.Text.Trim());
                try
                {
                    if (product.deleteProduct(id))
                    {
                        MessageBox.Show("Xóa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không có gì để xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Reset();
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
                if ((opf.ShowDialog() == DialogResult.OK))
                {
                    pictureBox1.Image = Image.FromFile(opf.FileName);
                }
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                int id = Convert.ToInt32(textId.Text.Trim());
                Product_Infors form = new Product_Infors(id);
                form.Show();
            }
        }
    }
}
