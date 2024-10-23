using HQTCSDL.Forms.ManagerProduct.Page.Page;
using HQTCSDL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL.Forms.ManagerProduct.Page
{
    public partial class Product_Infors : Form
    {
        private int id;
        private Product_Infor product_Infor = new Product_Infor();
        public Product_Infors(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddProductInfor form = new AddProductInfor(id);
            form.ShowDialog();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                textId.Text = id.ToString();
                dataGridView1.DataSource = product_Infor.getProductInforByIDProduct(id);
                dataGridView1.Columns["IdPInfor"].HeaderText = "Mã biến thể";
                dataGridView1.Columns["Color"].HeaderText = "Màu Sắc";
                dataGridView1.Columns["Size"].HeaderText = "Kích cỡ";
                dataGridView1.Columns["Quantity"].HeaderText = "Số lượng";
            }
            catch { }
        }
        private void Product_Infor_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void unlock()
        {
            textSize.Enabled = true;
            textColor.Enabled = true;
        }
        private void Lock()
        {
            textSize.Enabled = false;
            textColor.Enabled = false;
        }
        private void Reset()
        {
            textSize.Value = 1;
            textColor.Text = "";
            textIDP.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idProduct = dataGridView1.Rows[e.RowIndex].Cells["IdPInfor"].Value.ToString();
                int idPInfor = Convert.ToInt32(idProduct);
                DataTable table = product_Infor.SearchProductInfor(id,idPInfor);
                textIDP.Text = idProduct;
                textColor.Text = table.Rows[0]["Color"].ToString();
                textSize.Value =(int)table.Rows[0]["Size"];
                unlock();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (textIDP.Text.Trim().Length > 0)
            {
                try
                {
                    int size = Convert.ToInt32(textSize.Text);
                    int idPInfor = Convert.ToInt32(textIDP.Text);
                    string color = textColor.Text;
                    if (product_Infor.UpdateProductInfor(id, idPInfor, size, color))
                    {
                        MessageBox.Show("Sửa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                        Lock();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textIDP.Text.Trim().Length > 0)
            {
                try
                {
                    int idPInfor = Convert.ToInt32(textIDP.Text);
                    DialogResult result = MessageBox.Show("Bạn có chắt muốn xóa", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (product_Infor.DeleteProductInfor(id, idPInfor))
                        {
                            MessageBox.Show("Xóa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reset();
                            Lock();
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
