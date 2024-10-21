using HQTCSDL.Forms.ManagerProduct.Page;
using HQTCSDL.Forms.ManagerVoucher.Page;
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

namespace HQTCSDL.Forms.ManagerVoucher
{
    public partial class FVoucher : Form
    {
        private Voucher voucher = new Voucher();
        public FVoucher()
        {
            InitializeComponent();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Load_Voucher()
        {
            try
            {
                dataGridView1.DataSource = voucher.getAllVoucher();
                dataGridView1.Columns["IdVoucher"].HeaderText = "Mã Ưu Đãi";
                dataGridView1.Columns["NameVoucher"].HeaderText = "Tên Ưu Đãi";
                dataGridView1.Columns["Discount"].HeaderText = "Chiết khấu";
            }
            catch { }
        }

        private void FVoucher_Load(object sender, EventArgs e)
        {
            Load_Voucher();
        }
        private void Lock()
        {
            textdiscount.Enabled = false;
            textName.Enabled = false;
        }
        private void unLock()
        {
            textdiscount.Enabled = true;
            textName.Enabled = true;
        }
        private void Reset()
        {
            textdiscount.Value = 0;
            textId.Text = "";
            textName.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddVoucher form = new AddVoucher();
            form.ShowDialog();
            Load_Voucher();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idProduct = dataGridView1.Rows[e.RowIndex].Cells["IdVoucher"].Value.ToString();
                int idPInfor = Convert.ToInt32(idProduct);
                DataTable table = voucher.getVoucherByID(idPInfor);
                textId.Text = idProduct;
                textName.Text = table.Rows[0]["NameVoucher"].ToString();
                textdiscount.Value = (decimal)table.Rows[0]["Discount"];
                unLock();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textId.Text);
                string name = textName.Text;
                decimal discount = textdiscount.Value;
                if (voucher.UpdateVoucher(id,name, discount))
                {
                    MessageBox.Show("Cập nhập thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Lock();
                    Reset();
                    Load_Voucher();
                }
                else
                {
                    MessageBox.Show("Cập nhập thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textId.Text);
                if (voucher.DeleteVoucher(id))
                {
                    MessageBox.Show("Xóa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Lock();
                    Reset();
                    Load_Voucher();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idProduct = dataGridView1.Rows[e.RowIndex].Cells["IdVoucher"].Value.ToString();
                int idPInfor = Convert.ToInt32(idProduct);
                ListProductApplyVoucher form = new ListProductApplyVoucher(idPInfor);
                form.Show();
            }
        }
    }
}
