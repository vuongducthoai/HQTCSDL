using HQTCSDL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL.Forms.Login
{
    public partial class Register : Form
    {
        Account account = new Account();
        public Register()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string uName = textUName.Text;
                string pW = textuP.Text;
                string pWs = textUP1.Text;
                string name = textName.Text;
                int yearOB = (int)numericUpDown1.Value;
                string address = richTextBox1.Text;
                MemoryStream pic = new MemoryStream();
                if (pW.Trim() != pWs.Trim()) {
                    MessageBox.Show("Không trùng password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
                if (account.CreateAccount(uName,pW,name,pic,yearOB,address,"S"))
                {
                    MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FLogin currentForm = Application.OpenForms.OfType<FLogin>().FirstOrDefault();
                    currentForm.reset();
                    currentForm.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Có lỗi gì đó xãy ra", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Form currentForm = Application.OpenForms.OfType<FLogin>().FirstOrDefault();
                if (currentForm.Visible == false)
                    Application.Exit();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FLogin currentForm = Application.OpenForms.OfType<FLogin>().FirstOrDefault();
                currentForm.reset();
                currentForm.Show();
                this.Close();
            }
            catch { }
        }
    }
}
