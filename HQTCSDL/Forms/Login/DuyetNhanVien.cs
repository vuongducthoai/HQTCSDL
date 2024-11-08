using HQTCSDL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HQTCSDL.Forms.Login
{
    public partial class DuyetNhanVien : Form
    {
        My_DB mydb = new My_DB();
        Account account = new Account();
        public DuyetNhanVien()
        {
            InitializeComponent();
        }

        private void DuyetNhanVien_Load(object sender, EventArgs e)
        {

            Load_data();
        }
        private void Load_data()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select " +
                    "IdAccount,Name,Avatar,YearOfBirth,Active" +
                    " from VIEW_INFOR_USERS WHERE Role LIKE 'S'", mydb.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.RowTemplate.Height = 60;
                dataGridView1.DataSource = table;
                dataGridView1.Columns["IdAccount"].HeaderText = "Mã tài khoản";
                dataGridView1.Columns["Name"].HeaderText = "Tên nhân viên";
                dataGridView1.Columns["Avatar"].HeaderText = "Ảnh";
                dataGridView1.Columns["YearOfBirth"].HeaderText = "Năm sinh";
                dataGridView1.Columns["Active"].HeaderText = "Trạng thái";
                DataGridViewImageColumn picol1 = (DataGridViewImageColumn)dataGridView1.Columns[2];
                picol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
            catch { }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                try
                {


                    string idProduct = dataGridView1.Rows[e.RowIndex].Cells["IdAccount"].Value.ToString();
                    int id = Convert.ToInt32(idProduct);
                    DialogResult OK = MessageBox.Show("Bạn muốn thay đổi trạng thái hoạt động của tài khoản này?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (OK == DialogResult.Yes)
                    {
                        if (account.ChangeActive(id))
                        {                   
                            MessageBox.Show("Cập nhập thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Load_data();
                        }
                        else
                        {
                            MessageBox.Show("Không có gì để cập nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
