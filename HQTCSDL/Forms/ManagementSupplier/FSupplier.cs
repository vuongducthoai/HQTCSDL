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

namespace HQTCSDL.Forms
{
    public partial class FSupplier : Form
    {
        public FSupplier()
        {
            InitializeComponent();
        }

        Supplier supplier = new Supplier();

        private void FSupplier_Load(object sender, EventArgs e)
        {
            LoadTableAllProduct();
        }


        private void LoadTableAllProduct()
        {
            DataTable dataTable = supplier.getAllSupplier();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                dataGridViewSupplier.DataSource = dataTable;
                dataGridViewSupplier.Columns[0].Width = 50;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu hoặc kết nối cơ sở dữ liệu bị lỗi.");
            }

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string supplierName = textBoxPhone.Text;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            if(supplier.insertSupplier(supplierName, phone, address))
            {
                MessageBox.Show("Supplier đã được thêm thành công!", "Insert Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTableAllProduct();
            }
            else
            {
                MessageBox.Show("Supplier thêm thất bại!", "Insert Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int supplierId = Convert.ToInt32(textBoxId.Text);
            string supplierName = textBoxName.Text;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            if (supplier.updateSupplier(supplierId,supplierName, phone, address))
            {
                MessageBox.Show("Supplier đã được cập nhật thành công!", "Update Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTableAllProduct();
            }
            else
            {
                MessageBox.Show("Supplier cập nhất thất bại!", "Update Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxId.Text, out int supplierId))
            {
                if (supplier.deleteSupplier(supplierId) == false)
                {
                    MessageBox.Show("Supplier đã được xóa thành công!", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTableAllProduct();
                }
                else
                {
                    MessageBox.Show("Supplier đã xóa thất bại!", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ID nhà cung cấp không hợp lệ!", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxPhone.Text = "";
            textBoxAddress.Text = "";
        }

        private void dataGridViewSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                 DataGridViewRow row = dataGridViewSupplier.Rows[e.RowIndex];
                textBoxId.Text = row.Cells["IdSupplier"].Value.ToString();
                textBoxName.Text = row.Cells["NameSupplier"].Value.ToString();
                textBoxPhone.Text = row.Cells["Phone"].Value.ToString();
                textBoxAddress.Text = row.Cells["Address"].Value.ToString();
            }
        }

        private void buttonSearchSupplier_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearch.Text; 
            Supplier supplier = new Supplier();

            DataTable results = supplier.SearchSupplierByTerm(searchTerm);

            if (results != null && results.Rows.Count > 0)
            {
                dataGridViewSupplier.DataSource = results;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
            }
        }
    }
}
