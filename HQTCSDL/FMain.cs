using HQTCSDL.Forms.Login;
using HQTCSDL.Forms.ManagerInforUser;
using HQTCSDL.Forms.ManagerProduct;
using HQTCSDL.Forms.ManagerVoucher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class FMain : Form
    {
        My_DB mydb = new My_DB();
        public FMain()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FOrder fOrder = new FOrder();
            fOrder.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FImportGood fImportGood = new FImportGood();
            fImportGood.Show();
        }
        private void FMain_Load(object sender, EventArgs e)
        {
        }

        private void btn_infor_Click(object sender, EventArgs e)
        {
            try
            {
                FInfor form = new FInfor();
                controlPanel.Controls.Clear();
                form.TopLevel = false;
                controlPanel.Controls.Add(form);
                form.BringToFront();
                form.Show();
                label1.Text = "Thông tin cá nhân";
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FProduct form = new FProduct();
                controlPanel.Controls.Clear();
                form.TopLevel = false;
                controlPanel.Controls.Add(form);
                form.BringToFront();
                form.Show();
                label1.Text = "Quản lí Sản phẩm";
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                FVoucher form = new FVoucher();
                controlPanel.Controls.Clear();
                form.TopLevel = false;
                controlPanel.Controls.Add(form);
                form.BringToFront();
                form.Show();
                label1.Text = "Quản lí Ưu đãi";
            }
            catch { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                DuyetNhanVien form = new DuyetNhanVien();
                controlPanel.Controls.Clear();
                form.TopLevel = false;
                controlPanel.Controls.Add(form);
                form.BringToFront();
                form.Show();
                label1.Text = "Duyệt Nhân Viên";
            }
            catch { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FLogin currentForm = Application.OpenForms.OfType<FLogin>().FirstOrDefault();
            currentForm.reset();
            currentForm.Show();
            this.Close();
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Form currentForm = Application.OpenForms.OfType<FLogin>().FirstOrDefault();
                if (currentForm.Visible == false)
                    Application.Exit();
            }
            catch { }
        }
    }
}
