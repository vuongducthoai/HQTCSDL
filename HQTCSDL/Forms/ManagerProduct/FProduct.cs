using HQTCSDL.Forms.ManagerProduct.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL.Forms.ManagerProduct
{
    public partial class FProduct : Form
    {
        public FProduct()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddProduct form = new AddProduct();
            form.ShowDialog();
        }
    }
}
