using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class FKhachHang : Form
    {
        My_DB db = new My_DB(); // Tạo đối tượng MY_DB

        public FKhachHang()
        {
            InitializeComponent();
            LoadCustomerData();
        }
        private void LoadCustomerData()
        {
            try
            {
                db.openConnection();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Customer", db.getConnection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView_Customer.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection(); // Mở kết nối

                using (SqlCommand command = new SqlCommand("AddCustomer", db.getConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số vào stored procedure
                    command.Parameters.AddWithValue("@FullName", txt_Name.Text);
                    command.Parameters.AddWithValue("@Address", txt_Address.Text);
                    command.Parameters.AddWithValue("@Loyalty", int.Parse(txt_Loyalty.Text));
                    command.Parameters.AddWithValue("@Phone", txt_Phone.Text);
                    command.Parameters.AddWithValue("@StartDay", dtp_StartDay.Value);
                    command.Parameters.AddWithValue("@YearOfBirth", int.Parse(txt_YearOfBirth.Text));

                    // Thực thi lệnh
                    command.ExecuteNonQuery();
                    MessageBox.Show("Khách hàng đã được thêm thành công!");

                    // Làm mới danh sách sau khi thêm
                    LoadCustomerData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
        }



        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection(); // Mở kết nối

                using (SqlCommand command = new SqlCommand("deleted_customer", db.getConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdCustomer", int.Parse(txt_Id.Text));

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Khách hàng đã được xóa thành công!");
                        LoadCustomerData(); // Làm mới danh sách sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để xóa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection(); // Mở kết nối

                using (SqlCommand command = new SqlCommand("UpdateCustomer", db.getConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdCustomer", int.Parse(txt_Id.Text));
                    command.Parameters.AddWithValue("@FullName", txt_Name.Text);
                    command.Parameters.AddWithValue("@Address", txt_Address.Text);
                    command.Parameters.AddWithValue("@Loyalty", int.Parse(txt_Loyalty.Text));
                    command.Parameters.AddWithValue("@Phone", txt_Phone.Text);
                    command.Parameters.AddWithValue("@StartDay", dtp_StartDay.Value);
                    command.Parameters.AddWithValue("@YearOfBirth", int.Parse(txt_YearOfBirth.Text));

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Khách hàng đã được cập nhật thành công!");
                        LoadCustomerData(); // Làm mới danh sách sau khi sửa
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để cập nhật!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
        }


        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LoadCustomerData(); // Gọi lại phương thức để làm mới danh sách
            MessageBox.Show("Danh sách khách hàng đã được làm mới.");
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection(); // Mở kết nối

                string searchTerm = txt_TimKiem.Text.Trim(); // Lấy giá trị từ TextBox

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.search_ten(@CustomerName, @PhoneNumber)", db.getConnection))
                {
                    // Nếu searchTerm là một số điện thoại (khoảng trắng và có độ dài hợp lệ), truyền vào @PhoneNumber
                    if (string.IsNullOrEmpty(searchTerm))
                    {
                        MessageBox.Show("Vui lòng nhập tên hoặc số điện thoại để tìm kiếm.");
                        return; // Dừng lại nếu không có giá trị
                    }

                    // Gán giá trị cho các tham số
                    string phoneNumber = IsPhoneNumber(searchTerm) ? searchTerm : null;
                    string customerName = !IsPhoneNumber(searchTerm) ? searchTerm : null;

                    command.Parameters.AddWithValue("@CustomerName", (object)customerName ?? DBNull.Value); // Gán giá trị cho @CustomerName
                    command.Parameters.AddWithValue("@PhoneNumber", (object)phoneNumber ?? DBNull.Value); // Gán giá trị cho @PhoneNumber

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView_Customer.DataSource = dt; // Gán dữ liệu cho DataGridView

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng nào!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
        }

        private bool IsPhoneNumber(string input)
        {
            // Kiểm tra xem chuỗi chỉ chứa số và có độ dài hợp lệ
            return input.All(char.IsDigit) && input.Length >= 8 && input.Length <= 15; // Điều chỉnh độ dài tùy theo yêu cầu
        }


        private void dataGridView_Customer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu hàng được chọn hợp lệ
            {
                // Lấy thông tin từ hàng đã chọn
                DataGridViewRow row = dataGridView_Customer.Rows[e.RowIndex];

                txt_Id.Text = row.Cells["IdCustomer"].Value.ToString(); // Thay 'IdCustomer' bằng tên cột thực tế
                txt_Name.Text = row.Cells["FullName"].Value.ToString();
                txt_Address.Text = row.Cells["Address"].Value.ToString();
                txt_Loyalty.Text = row.Cells["Loyalty"].Value.ToString();
                txt_Phone.Text = row.Cells["Phone"].Value.ToString();
                dtp_StartDay.Value = Convert.ToDateTime(row.Cells["StartDay"].Value);
                txt_YearOfBirth.Text = row.Cells["YearOfBirth"].Value.ToString();
            }
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
