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
    }
}
