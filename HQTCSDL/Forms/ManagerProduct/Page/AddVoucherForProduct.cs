using HQTCSDL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HQTCSDL.Forms.ManagerProduct.Page
{
    public partial class AddVoucherForProduct : Form
    {
        private int id_product;
        My_DB db = new My_DB();
        Product product = new Product();
        public AddVoucherForProduct(int id_product)
        {
            InitializeComponent();
            this.id_product = id_product;
        }

        private void AddVoucher_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            int id_select = 0;
            dt.Columns.Add("IdVoucher", typeof(int));
            dt.Columns.Add("NameVoucher", typeof(string));
            SqlCommand cmd = new SqlCommand("SELECT IdVoucher,NameVoucher " +
                "FROM VOUCHER", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            db.openConnection();
            adapter.Fill(dt);
            DataRow newRow = dt.NewRow();
            newRow["IdVoucher"] = 0;
            newRow["NameVoucher"] = "null";
            dt.Rows.Add(newRow);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "NameVoucher";
            comboBox1.ValueMember = "IdVoucher";
            SqlCommand cmd1 = new SqlCommand("select " +
                "Product.IdVoucher,NameVoucher,Discount " +
                "from Product left join Voucher on " +
                "Product.IdVoucher = Voucher.IdVoucher " +
                "where IdProduct = @id", db.getConnection);
            cmd1.Parameters.AddWithValue("@id", id_product);
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            adapter1.Fill(dt1);
            if (dt1.Rows[0]["IdVoucher"] != DBNull.Value)
            {
                id_select = Convert.ToInt32(dt1.Rows[0]["IdVoucher"]);
                lbNameVoucher.Text = dt1.Rows[0]["NameVoucher"].ToString();
                lbDiscount.Text = dt1.Rows[0]["Discount"].ToString() +" %";
            }
            else
            {
                lbDiscount.Text = "0 %";
                lbNameVoucher.Text = "Chưa áp dụng";
            }
            comboBox1.SelectedValue = id_select;
            db.closeConnection();
        }
        private void Load_Infor()
        {
            DataTable dt1 = new DataTable();
            SqlCommand cmd1 = new SqlCommand("select " +
                "Product.IdVoucher,NameVoucher,Discount " +
                "from Product left join Voucher on " +
                "Product.IdVoucher = Voucher.IdVoucher " +
                "where IdProduct = @id", db.getConnection);
            cmd1.Parameters.AddWithValue("@id", id_product);
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            adapter1.Fill(dt1);
            if (dt1.Rows[0]["IdVoucher"] != DBNull.Value)
            {
                lbNameVoucher.Text = dt1.Rows[0]["NameVoucher"].ToString();
                lbDiscount.Text = dt1.Rows[0]["Discount"].ToString() + " %";
            }
            else
            {
                lbDiscount.Text = "0 %";
                lbNameVoucher.Text = "Chưa áp dụng";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id_voucher = (int)comboBox1.SelectedValue;
            try
            {
                if (product.AddVoucher(id_product,id_voucher))
                {
                    MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_Infor();
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
        }
    }
}
