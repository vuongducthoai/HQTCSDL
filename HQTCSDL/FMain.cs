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

        private void button2_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng mới của form FKhachHang
            FKhachHang fKhachHang = new FKhachHang();

            // Hiển thị form FKhachHang
            fKhachHang.ShowDialog(); // Dùng ShowDialog nếu bạn muốn hiển thị như một hộp thoại
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FDanhMuc fDanhMuc = new FDanhMuc();

            // Hiển thị form FKhachHang
            fDanhMuc.ShowDialog(); // Dùng ShowDialog nếu bạn muốn hiển thị như một hộp thoại
        }
    }
}
