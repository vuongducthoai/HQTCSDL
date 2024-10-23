using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using HQTCSDL.model;

namespace HQTCSDL
{
    public partial class UserControlProduct : UserControl
    {
        // Lưu trữ danh sách màu sắc theo kích thước
        private Dictionary<string, List<string>> sizeToColors = new Dictionary<string, List<string>>();
        private int idProduct;
        public event Action<int, string, string, string, double, int, double> ProductAdded;
        public UserControlProduct()
        {
            InitializeComponent();
            cbxSize.DropDown += CbxSize_DropDown; // Khi mở ComboBox size
            cbxSize.SelectedIndexChanged += CbxSize_SelectedIndexChanged; // Khi chọn size
        }

        public void LoadProductData(int id, string productName, decimal price, List<string> sizes, Dictionary<string, List<string>> sizeColorMapping, byte[] imageBytes)
        {
            this.idProduct = id;
            lblPName.Text = productName;
            lblPrice.Text = price.ToString("C");
            // Hiển thị ảnh
            if (imageBytes != null && imageBytes.Length > 0)
            {
                using (var ms = new MemoryStream(imageBytes))
                {
                    ptxPImage.Image = Image.FromStream(ms);
                }
            }

            // Thêm size vào ComboBox
            cbxSize.Items.Clear();
            foreach (var size in sizes)
            {
                cbxSize.Items.Add(size);
            }

            // Lưu trữ danh sách màu sắc cho mỗi kích thước
            sizeToColors = sizeColorMapping;
        }

        private void CbxSize_DropDown(object sender, EventArgs e)
        {
            // Không cần làm gì ở đây
        }

        private void CbxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi kích thước thay đổi, cập nhật danh sách màu
            cbxColor.Items.Clear();
            if (cbxSize.SelectedItem != null)
            {
                string selectedSize = cbxSize.SelectedItem.ToString();
                if (sizeToColors.ContainsKey(selectedSize))
                {
                    foreach (var color in sizeToColors[selectedSize])
                    {
                        cbxColor.Items.Add(color);
                    }
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxSize.SelectedItem != null && cbxColor.SelectedItem != null && Convert.ToInt32(numQuantity.Value) >0)
            {
                decimal price = decimal.Parse(lblPrice.Text, System.Globalization.NumberStyles.Currency); // Đổi chuỗi giá tiền thành số
                int quantity = Convert.ToInt32(numQuantity.Value); // Lấy số lượng từ numQuantity

                ProductAdded?.Invoke(
                    this.idProduct,
                    lblPName.Text,
                    cbxSize.SelectedItem.ToString(),
                    cbxColor.SelectedItem.ToString(),
                    (double)price,
                    quantity,
                    (double)(price * quantity) // Tính tổng tiền
                );
            }
            else
            {
                MessageBox.Show("Vui lòng chọn kích thước,màu sắc và số lượng phải lớn hơn không");
            }
        }

    }
}
