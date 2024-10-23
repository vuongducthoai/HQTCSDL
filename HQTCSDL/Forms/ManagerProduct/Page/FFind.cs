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

namespace HQTCSDL.Forms.ManagerProduct.Page
{
    public partial class FFind : Form
    {
        public decimal price_start;
        public decimal price_end ;
        public int id_category;
        My_DB db = new My_DB();
        public FFind()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            price_start = numericUpDown1.Value;
            price_end = numericUpDown2.Value;
            id_category = (int)comboBox1.SelectedValue;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FFind_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdCategory", typeof(int));
            dt.Columns.Add("NameCategory", typeof(string));
            SqlCommand cmd = new SqlCommand("SELECT IdCategory, NameCategory " +
                "FROM Category", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            DataRow newRow = dt.NewRow();
            newRow["IdCategory"] = 0;
            newRow["NameCategory"] = "null";
            dt.Rows.Add(newRow);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "NameCategory";
            comboBox1.ValueMember = "IdCategory";
            comboBox1.SelectedValue = 0;
        }
    }
}
