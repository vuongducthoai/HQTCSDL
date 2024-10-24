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

namespace HQTCSDL.Forms.ManagerInforUser
{
    public partial class FInfor : Form
    {
        private int cdo = 0;
        private Service service  = new Service();
        private Users user = new Users();
        public FInfor()
        {
            InitializeComponent();
        }

        private void FInfor_Load(object sender, EventArgs e)
        {
            
            DataTable dt = user.getUser(Config.getID());
            textID.Text = dt.Rows[0]["IdUser"].ToString();
            textName.Text = dt.Rows[0]["Name"].ToString();
            int yearOfBirth = Convert.ToInt32(dt.Rows[0]["YearOfBirth"]);
            textAge.Value = (DateTime.Now.Year - yearOfBirth);
            textAddress.Text = dt.Rows[0]["Address"].ToString();
            String role = dt.Rows[0]["role"].ToString();
            if (role == "A") Role.Text = "Chủ cửa hàng";
            else Role.Text = "Nhân viên";
            pictureBox1.Image = service.ByteArrayToImage((Byte[])dt.Rows[0]["Avatar"]);
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnS_Click(object sender, EventArgs e)
        {
            cdo = 1 - cdo;
            //bam sua
            if (cdo == 1)
            {
                btn1.Visible = true;
                textAddress.Enabled = true;
                textAge.Enabled = true;
                textName.Enabled = true;
                btnS.Text = "Gửi";
            }
            //bam gui
            else
            {
                try
                {
                    string name = textName.Text;
                    int Year = DateTime.Now.Year - (int)textAge.Value;
                    string address = textAddress.Text;
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
                    if (user.updateUser(Config.getID(), name, pic, Year, address))
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
                btn1.Visible = false;
                textAddress.Enabled = false;
                textAge.Enabled = false;
                textName.Enabled = false;
                btnS.Text = "Sửa";
            }
        }
    }
}
