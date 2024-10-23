using HQTCSDL.Forms.ManagerInforUser;
using HQTCSDL.Forms.ManagerProduct;
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
            mydb.openConnection();
            mydb.closeConnection();
            Config.setID(1);
            Config.setRole(0);
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
            }
            catch { }
        }
    }
}
