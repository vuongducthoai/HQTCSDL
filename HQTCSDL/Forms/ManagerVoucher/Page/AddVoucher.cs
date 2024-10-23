using HQTCSDL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HQTCSDL.Forms.ManagerVoucher.Page
{
    public partial class AddVoucher : Form
    {
        private Voucher voucher = new Voucher();
        public AddVoucher()
        {
            InitializeComponent();
        }

        private void AddVoucher_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textName.Text;
                decimal discount = Price.Value;
                if (voucher.AddVoucher(name, discount))
                {
                    MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }
    }
}
