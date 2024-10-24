using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class FDanhMuc : Form
    {
        MY_DB db = new MY_DB(); // Tạo đối tượng MY_DB
        private int selectedProductId = 0; // Biến toàn cục để lưu ID sản phẩm đã chọn

        public FDanhMuc()
        {
            InitializeComponent();
            LoadCategories();
            LoadAllProducts();
            // Đặt giá trị ComboBox về null để nó trống khi khởi động
            cbox_DanhMuc.SelectedIndex = -1; // Đặt ComboBox trống
        }

        private void FDanhMuc_Load(object sender, EventArgs e)
        {
            // Có thể thêm mã khởi tạo ở đây nếu cần
        }

        private void LoadAllProducts()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Product", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgv_ALLProduct.DataSource = dataTable; // Gán dữ liệu vào DataGridView
            db.closeConnection();    // Kết nối sẽ tự động đóng khi ra khỏi block using
        }


        private void LoadCategories()
        {
                //db.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT IdCategory, NameCategory FROM Category", db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Thiết lập DataSource cho ComboBox
                cbox_DanhMuc.DataSource = dataTable;
                cbox_DanhMuc.DisplayMember = "NameCategory"; // Tên hiển thị trong ComboBox
                cbox_DanhMuc.ValueMember = "IdCategory"; // Giá trị của mỗi mục
                cbox_DanhMuc.SelectedIndex = -1; // Đặt ComboBox trống
                //db.closeConnection();
        }

        private void cbox_DanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_DanhMuc.SelectedValue != null)
            {
                DataRowView rowView = cbox_DanhMuc.SelectedItem as DataRowView;
                int selectedId = Convert.ToInt32(rowView["IdCategory"]);
                LoadCategoryDetails(selectedId);
            }
        }

        private void LoadCategoryDetails(int categoryId)
        {
            using (SqlConnection con = db.getConnection)
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Category WHERE IdCategory = @Id", con);
                cmd.Parameters.AddWithValue("@Id", categoryId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txt_Id.Text = reader["IdCategory"].ToString();
                    txt_Name.Text = reader["NameCategory"].ToString();
                }

                db.closeConnection();
            }
        }

        private void AddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txt_Name.Text.Trim();
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Tên danh mục không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = db.getConnection)
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("AddCategory", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@NameCategory", categoryName);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories(); // Tải lại danh sách danh mục
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }

        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Id.Text))
            {
                MessageBox.Show("Vui lòng chọn một danh mục để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int categoryId = Convert.ToInt32(txt_Id.Text);
            using (SqlConnection con = db.getConnection)
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("DeleteCategory", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdCategory", categoryId);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories(); // Tải lại danh sách danh mục
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }

        private void UpdateCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Id.Text) || string.IsNullOrEmpty(txt_Name.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int categoryId = Convert.ToInt32(txt_Id.Text);
            string categoryName = txt_Name.Text.Trim();
            using (SqlConnection con = db.getConnection)
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("UpdateCategory", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdCategory", categoryId);
                cmd.Parameters.AddWithValue("@NameCategory", categoryName);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories(); // Tải lại danh sách danh mục
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }

        private void dgv_ALLProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị ID sản phẩm từ ô của cột đầu tiên (cột chứa ID sản phẩm)
                int productId = Convert.ToInt32(dgv_ALLProduct.Rows[e.RowIndex].Cells[0].Value);
                selectedProductId = productId; // Lưu ID sản phẩm
            }
        }

        private void LinkProductToCategory_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ danh sách sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbox_DanhMuc.SelectedValue != null)
            {
                int categoryId = Convert.ToInt32(cbox_DanhMuc.SelectedValue);
                using (SqlConnection con = db.getConnection)
                {
                    db.openConnection();
                    SqlCommand cmd = new SqlCommand("LinkProductToCategory", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@IdProduct", selectedProductId);
                    cmd.Parameters.AddWithValue("@IdCategory", categoryId);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sản phẩm đã được thêm vào danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbox_DanhMuc_SelectedIndexChanged(null, null); // Tải lại danh sách sản phẩm trong danh mục
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        db.closeConnection();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một danh mục trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
