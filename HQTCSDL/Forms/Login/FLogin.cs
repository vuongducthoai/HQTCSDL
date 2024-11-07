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

namespace HQTCSDL.Forms.Login
{
    public partial class FLogin : Form
    {
        Account account = new Account();
        My_DB my_DB = new My_DB();
        public FLogin()
        {
            InitializeComponent();
        }
        public void Appl()
        {
            if (checkBox1.Checked) {
                textuP.PasswordChar = '\0';
            }
            else
            {
                textuP.PasswordChar = '*';
            }
        }
        public void reset()
        {
            checkBox1.Checked = false;
            Appl();
            textUName.Text = "";
            textuP.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string uN = textUName.Text;
            string pW = textuP.Text;
            if (account.checkAccount(uN, pW))
            {
                SqlCommand cmd = new SqlCommand("select IdUser,Role " +
                    "from VIEW_INFOR_USERS" +
                    " WHERE UName LIKE @UN AND Password LIKE @PW",my_DB.getConnectionAdmin);
                cmd.Parameters.Add("@UN", SqlDbType.VarChar).Value = uN;
                cmd.Parameters.Add("@PW", SqlDbType.VarChar).Value = pW;
                SqlDataAdapter ap = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                ap.Fill(table);
                try
                {
                    Config.setID((int)table.Rows[0]["IdUser"]);
                    Config.setRole(table.Rows[0]["Role"].ToString().ToUpper()=="A"?1:0);
                    Config.setPassword(pW);
                    Config.setUname(uN);
                }
                catch { }
                FMain form = new FMain();
                form.Show();
                
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nhập sai tên đăng nhập hoặc mật khẩu","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Appl();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register form = new Register();
            form.Show();
        }
    }
}
