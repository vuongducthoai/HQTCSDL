using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HQTCSDL.model;
using MySql.Data.MySqlClient;

namespace HQTCSDL
{
    
    public partial class FOrder : Form
    {
        My_DB db = new My_DB(); // Khởi tạo kết nối cơ sở dữ liệu

        public FOrder()
        {
            InitializeComponent();
        }

        private void FOrder_Load(object sender, EventArgs e)
        {
            dtgrvOrderBill.AllowUserToAddRows = false;
            LoadCatalogs(); // Tải danh mục ngay khi Form được nạp
            LoadProducts();
            LoadCustomers();
            LoadVoucher();// Tải tất cả sản phẩm
        }

        private void LoadVoucher()
        {
            DataTable dt = new DataTable();
            string query = "Select * from Voucher";
            SqlCommand command = new SqlCommand(query, db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            try
            {
                db.openConnection();
                adapter.Fill(dt);

                if (dt != null)
                {
                    // Thêm một cột tạm thời để hiển thị tên và giảm giá
                    dt.Columns.Add("VoucherDisplay", typeof(string), "NameVoucher + ' - ' + CONVERT(Discount, 'System.String') + '%'");

                    // Thêm mục mặc định
                    DataRow defaultRow = dt.NewRow();
                    defaultRow["VoucherDisplay"] = "Chọn voucher"; // Tên mục mặc định
                    defaultRow["IdVoucher"] = DBNull.Value; // Giá trị IdVoucher mặc định
                    dt.Rows.InsertAt(defaultRow, 0); // Thêm vào đầu danh sách

                    // Thiết lập ComboBox
                    cbxVoucher.DataSource = dt;
                    cbxVoucher.DisplayMember = "VoucherDisplay"; // Hiển thị tên và giảm giá
                    cbxVoucher.ValueMember = "IdVoucher"; // Giá trị là IdVoucher

                    // Đặt SelectedIndex về 0 để chọn mục mặc định
                    cbxVoucher.SelectedIndex = 0; // Hoặc cbxVoucher.SelectedIndex = -1; nếu không muốn chọn gì
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            db.closeConnection();
        }


        private void LoadCustomers()
        {
            Customer customers = new Customer();

            cbxCustomers.Items.Clear(); // Xóa các mục hiện tại

            DataTable customerData = customers.GetAllCustomers();
            if (customerData != null)
            {
                foreach (DataRow row in customerData.Rows)
                {
                    var customer = new Customer
                    {
                        IdCustomer = Convert.ToInt32(row["IdCustomer"]),
                        FullName = row["FullName"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Loyalty = Convert.ToInt32(row["Loyalty"])
                    };
                    cbxCustomers.Items.Add(customer); // Thêm đối tượng Customer vào ComboBox
                }
            }

            cbxCustomers.DisplayMember = "FullName"; // Tạm thời hiển thị tên khách hàng
            cbxCustomers.ValueMember = "IdCustomer"; // Giá trị sẽ là IdCustomer
        }



        private void LoadCatalogs()
        {
            string query = "SELECT IdCategory, NameCategory FROM Category"; // Lấy danh mục
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.getConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            cbxCatalog.Items.Clear(); // Xóa các mục hiện tại

            // Thêm item "All"
            cbxCatalog.Items.Add(new Catalog { IdCategory = 0, NameCategory = "All" }); // 0 để biểu thị cho tất cả

            foreach (DataRow row in dataTable.Rows)
            {
                var catalog = new Catalog
                {
                    IdCategory = Convert.ToInt32(row["IdCategory"]),
                    NameCategory = row["NameCategory"].ToString()
                };
                cbxCatalog.Items.Add(catalog); // Thêm đối tượng Catalog vào ComboBox
            }

            cbxCatalog.DisplayMember = "NameCategory"; // Hiển thị tên danh mục
            cbxCatalog.SelectedIndex = 0; // Đặt mặc định là "All"
        }

        
        // Phương thức để tải sản phẩm theo danh mục
        private void LoadProductsByCategory(int categoryId)
        {
            string query = $"SELECT IdProduct, NameProduct, Price, Size, Color, Image FROM Product_View WHERE IdCategory = {categoryId}";
            LoadProducts(query);
        }

        // Phương thức để tải tất cả sản phẩm
        private void LoadProducts()
        {
            string query = "SELECT IdProduct, NameProduct, Price, Size, Color, Image FROM Product_View";
            LoadProducts(query);
        }

        private void LoadProducts(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.getConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            flowLayoutPanelProduct.Controls.Clear(); // Xóa sản phẩm cũ

            // Lưu trữ thông tin cho từng sản phẩm
            var productData = new Dictionary<string, (int id, decimal price, List<string> sizes, Dictionary<string, List<string>> sizeColorMapping, byte[] image)>();

            foreach (DataRow row in dataTable.Rows)
            {
                int productId = Convert.ToInt32(row["IdProduct"]);
                string productName = row["NameProduct"].ToString();
                decimal price = Convert.ToDecimal(row["Price"]);
                string size = row["Size"].ToString();
                string color = row["Color"].ToString();
                byte[] image = row["Image"] as byte[];

                // Nếu sản phẩm chưa có trong dictionary, khởi tạo
                if (!productData.ContainsKey(productName))
                {
                    productData[productName] = (productId, price, new List<string>(), new Dictionary<string, List<string>>(), image);
                }

                // Thêm kích thước và màu sắc vào danh sách
                if (!productData[productName].sizes.Contains(size))
                {
                    productData[productName].sizes.Add(size);
                }
                if (!productData[productName].sizeColorMapping.ContainsKey(size))
                {
                    productData[productName].sizeColorMapping[size] = new List<string>();
                }
                if (!productData[productName].sizeColorMapping[size].Contains(color))
                {
                    productData[productName].sizeColorMapping[size].Add(color);
                }
            }

            // Load sản phẩm vào UserControl
            foreach (var product in productData)
            {
                UserControlProduct productControl = new UserControlProduct();
                productControl.LoadProductData(
                    product.Value.id,
                    product.Key,
                    product.Value.price,
                    product.Value.sizes,
                    product.Value.sizeColorMapping,
                    product.Value.image
                );
                productControl.ProductAdded += OnProductAdded;
                flowLayoutPanelProduct.Controls.Add(productControl);
            }
        }
        private void OnProductAdded(int productId, string productName, string size, string color, double price, int quantity, double total)
        {
            bool productExists = false;

            foreach (DataGridViewRow row in dtgrvOrderBill.Rows)
            {
                int existingProductId = Convert.ToInt32(row.Cells["id"].Value);
                string existingSize = row.Cells["size"].Value.ToString();
                string existingColor = row.Cells["color"].Value.ToString();

                if (existingProductId == productId && existingSize == size && existingColor == color)
                {
                    // Tăng số lượng sản phẩm lên
                    int currentQuantity = Convert.ToInt32(row.Cells["quantity"].Value);
                    row.Cells["quantity"].Value = currentQuantity + quantity;

                    // Cập nhật lại cột tổng (total)
                    double updatedTotal = price * (currentQuantity + quantity);
                    row.Cells["total"].Value = updatedTotal;

                    productExists = true;
                    break; // Thoát vòng lặp vì đã tìm thấy sản phẩm cần cập nhật
                }
            }

            // Nếu sản phẩm chưa tồn tại, thêm sản phẩm mới vào DataGridView
            if (!productExists)
            {
                int rowIndex = dtgrvOrderBill.Rows.Add(productId, productName, size, color, price, quantity, total);
                DataGridViewRow newRow = dtgrvOrderBill.Rows[rowIndex];
                newRow.Cells["btnDelete"].Value = "Xóa"; // Văn bản hiển thị trên nút
                newRow.Cells["btnDelete"].Style.BackColor = Color.Red; // Màu nền cho nút
                newRow.Cells["btnDelete"].Style.ForeColor = Color.White;
            }

        }
        private void cbxCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCatalog.SelectedItem != null)
            {
                Catalog selectedCatalog = (Catalog)cbxCatalog.SelectedItem; // Lấy đối tượng Catalog

                if (selectedCatalog.IdCategory == 0) // Nếu chọn "All"
                {
                    LoadProducts(); // Tải tất cả sản phẩm
                }
                else
                {
                    int categoryId = selectedCatalog.IdCategory; // Lấy ID danh mục
                    LoadProductsByCategory(categoryId); // Tải sản phẩm theo danh mục đã chọn
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower(); // Giả sử txtSearch là TextBox chứa từ khóa tìm kiếm
            foreach (Control control in flowLayoutPanelProduct.Controls)
            {
                if (control is UserControlProduct productControl)
                {
                    bool isVisible = productControl.lblPName.Text.ToLower().Contains(searchText);
                    control.Visible = isVisible; // Hiển thị hoặc ẩn sản phẩm dựa trên từ khóa tìm kiếm
                }
            }
        }

        private void dtgrvOrderBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dtgrvOrderBill.Columns["btnDelete"].Index)
            {
                // Xác nhận trước khi xóa
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Xóa hàng đã chọn
                    dtgrvOrderBill.Rows.RemoveAt(e.RowIndex);
                }
            }
        }


        private void cbxCustomers_TextUpdate(object sender, EventArgs e)
        {
            string searchText = cbxCustomers.Text.ToLower();

            cbxCustomers.Items.Clear(); // Xóa các mục hiện tại

            Customer customers = new Customer();
            DataTable customerData = customers.GetAllCustomers();

            foreach (DataRow row in customerData.Rows)
            {
                var customer = new Customer
                {
                    IdCustomer = Convert.ToInt32(row["IdCustomer"]),
                    FullName = row["FullName"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Loyalty = Convert.ToInt32(row["Loyalty"])
                };

                if (customer.FullName.ToLower().Contains(searchText) || customer.Phone.Contains(searchText))
                {
                    cbxCustomers.Items.Add(customer);
                }
            }

            // Hiển thị lại ComboBox với danh sách khách hàng lọc được
            cbxCustomers.DroppedDown = true;
            cbxCustomers.Select(cbxCustomers.Text.Length, 0); // Đặt con trỏ văn bản
        }
        private int CreateBill(int customerId, int voucherId)
        {
            int billId = -1;
            db.openConnection();
            string query = "INSERT INTO Bill (IdCustomer, IdVoucher, IdUser) VALUES (@IdCustomer, @IdVoucher, @IdUser); SELECT SCOPE_IDENTITY() AS BillId";

            using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
            {
                cmd.Parameters.AddWithValue("@IdCustomer", customerId);
                cmd.Parameters.AddWithValue("@IdUser", Config.getID());

                // Sử dụng DBNull.Value nếu không có voucher
                if (voucherId != -1)
                    cmd.Parameters.AddWithValue("@IdVoucher", voucherId);
                else
                    cmd.Parameters.AddWithValue("@IdVoucher", DBNull.Value);

                // Thực thi lệnh và lấy Id hóa đơn mới tạo
                billId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            
            db.closeConnection();
            

            return billId; // Trả về Id của hóa đơn mới tạo
        }

        private void UpdateTotal(int idBill, decimal total)
        {
            string query = "UPDATE Bill SET TotalInvoice = @Total WHERE IdBill = @IdBill";
            db.openConnection();
            using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
            {
                // Thêm tham số cho câu truy vấn
                cmd.Parameters.AddWithValue("@Total", total);
                cmd.Parameters.AddWithValue("@IdBill", idBill);

                // Thực thi lệnh cập nhật
                cmd.ExecuteNonQuery();
            }

            db.closeConnection();
        }

        private int GetProductInforId(int productId, string size, string color, SqlTransaction transaction)
        {
            string query = "SELECT IdPInfor FROM Product_Infor WHERE IdProduct = @IdProduct AND Size = @Size AND Color = @Color";
            SqlCommand cmd = new SqlCommand(query, db.getConnection, transaction); // Gán transaction vào command
            cmd.Parameters.AddWithValue("@IdProduct", productId);
            cmd.Parameters.AddWithValue("@Size", size);
            cmd.Parameters.AddWithValue("@Color", color);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1; // Kiểm tra kết quả null trước khi chuyển đổi
        }


        private decimal GetVoucherDiscount(int voucherId)
        {
            db.openConnection();
            string query = "SELECT Discount FROM Voucher WHERE IdVoucher = @IdVoucher";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            cmd.Parameters.AddWithValue("@IdVoucher", voucherId);
            object result = cmd.ExecuteScalar();
            db.closeConnection();
            return Convert.ToDecimal(result);
            
        }

        private bool getCustomerVoucherForBill(ref int idCus, ref int idVou)
        {
            if (cbxCustomers.SelectedItem != null)
            {
                // Đảm bảo rằng bạn đang lấy IdCustomer từ đối tượng đã chọn
                Customer selectedCustomer = (Customer)cbxCustomers.SelectedItem;
                idCus = selectedCustomer.IdCustomer;

                if (cbxVoucher.SelectedIndex > 0)
                {
                    idVou = Convert.ToInt32(cbxVoucher.SelectedValue);
                }
                return true;
            }
            return false;
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            int customerId =0;  // Lấy Id của khách hàng từ form
            int voucherId =-1;
            if (!getCustomerVoucherForBill(ref customerId, ref voucherId))
            {
                MessageBox.Show("Vui lòng chọn khách hàng");
                return;
            }    // Lấy IdVoucher từ ComboBox (có thể null nếu không có voucher)
            decimal discount = 0;                      // Khởi tạo giá trị giảm giá

            // Lấy giá trị giảm giá từ voucher nếu có
            if (voucherId != -1)
            {
                discount = GetVoucherDiscount(voucherId); // Lấy discount từ voucher
            }

            // Tạo hóa đơn tạm thời
            int billId = CreateBill(customerId, voucherId);

            decimal totalBill = 0;  // Tổng tiền ban đầu chưa áp dụng giảm giá
            decimal finalBill = 0;  // Tổng tiền sau khi áp dụng giảm giá

            StringBuilder billDetails = new StringBuilder();
            billDetails.AppendLine("THÔNG TIN HÓA ĐƠN:");
            var selectedCustomer = (Customer)cbxCustomers.SelectedItem;
            billDetails.AppendLine("Khách hàng: " + selectedCustomer.FullName);

            // Duyệt qua từng sản phẩm trong DataGridView và thêm chi tiết sản phẩm vào hóa đơn
            foreach (DataGridViewRow row in dtgrvOrderBill.Rows)
            {
                if (row.IsNewRow) continue;

                string productName = row.Cells["name"].Value.ToString();
                int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                decimal price = Convert.ToDecimal(row.Cells["price"].Value);
                decimal total = price * quantity;

                billDetails.AppendLine($"-: {productName}, SL: {quantity}, Đơn giá: {price}, Thành tiền: {total}");

                totalBill += total;
            }

            // Tính toán tổng tiền cuối cùng
            if (discount > 0)
            {
                billDetails.AppendLine($"Giảm giá: {discount}%");
                finalBill = totalBill * (1 - (discount / 100));
                UpdateTotal(billId, finalBill);
            }
            else
            {
                finalBill = totalBill;
                UpdateTotal(billId, finalBill);

            }

            billDetails.AppendLine($"Tổng tiền trước giảm giá: {totalBill}");
            billDetails.AppendLine($"Tổng tiền phải thanh toán: {finalBill}");

            // Hiển thị message box xác nhận thanh toán
            DialogResult result = MessageBox.Show(billDetails.ToString(), "Xác nhận thanh toán", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            // Nếu người dùng nhấn "OK", thực hiện thanh toán
            if (result == DialogResult.OK)
            {
                ProcessPayment(billId);
            }
            else
            {
                MessageBox.Show("Thanh toán đã bị hủy.");
                DeleteBill(billId);
            }
        }

        private bool DeleteBill(int id)
        {
            db.openConnection();
            string query = "DELETE FROM Bill WHERE IdBill = @IdBill;";

            using (SqlCommand command = new SqlCommand(query, db.getConnection))
            {
                command.Parameters.AddWithValue("@IdBill", id);
                int rowsAffected = command.ExecuteNonQuery();

                // Trả về true nếu xóa thành công, false nếu không tìm thấy hóa đơn
                return rowsAffected > 0;
            }
        }
        private void ProcessPayment(int billId)
        {
            db.openConnection();
            using (SqlTransaction transaction = db.getConnection.BeginTransaction())
            {
                try
                {
                    foreach (DataGridViewRow row in dtgrvOrderBill.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int productId = Convert.ToInt32(row.Cells["id"].Value);
                        string size = row.Cells["size"].Value.ToString();
                        string color = row.Cells["color"].Value.ToString();
                        int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                        int productInforId = GetProductInforId(productId, size, color, transaction);

                        using (SqlCommand cmd = new SqlCommand("AddBillAndUpdateStock", db.getConnection, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("p_IdBill", billId);
                            cmd.Parameters.AddWithValue("p_IdPInfor", productInforId);
                            cmd.Parameters.AddWithValue("p_Quantity", quantity);

                            cmd.ExecuteNonQuery(); // Nếu có lỗi xảy ra từ SQL, sẽ ném ra exception
                        }
                    }
                    transaction.Commit();
                    MessageBox.Show("Thanh toán thành công!");
                    dtgrvOrderBill.Rows.Clear();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message); // Hiển thị lỗi từ SQL
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }


        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            LoadBills();
        }

        private void LoadBills()
        {
            dtgrvManageOrder.DataSource= null;

            DateTime fromDate = dtpkFrom.Value.Date;  
            DateTime toDate = dtpkTo.Value.Date.AddDays(1).AddTicks(-1);  

            string query = $"SELECT Distinct IdBill, CustomerName, UserName, BillDate, TotalInvoice, Voucher " +
                           $"FROM View_Bills " +
                           $"WHERE BillDate BETWEEN '{fromDate:yyyy-MM-dd HH:mm:ss}' AND '{toDate:yyyy-MM-dd HH:mm:ss}'";

            SqlCommand command = new SqlCommand(query, db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dtgrvManageOrder.DataSource = dt;
        }
        private void dtgrvManageOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Kiểm tra tên cột chính xác
                int billId = Convert.ToInt32(dtgrvManageOrder.Rows[e.RowIndex].Cells["IdBill"].Value);
                LoadBillDetails(billId);
            }
        }


        private void LoadBillDetails(int billId)
        {
            dtgrvOrderDetail.DataSource = null;

            string query = $"SELECT * FROM View_BillDetails WHERE IdBill = {billId}";

            SqlCommand command = new SqlCommand(query, db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dtgrvOrderDetail.DataSource = dt;
        }


        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dtgrvManageOrder.SelectedRows.Count > 0)
            {
                int billId = Convert.ToInt32(dtgrvManageOrder.SelectedRows[0].Cells["IdBill"].Value);

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    DeleteBill(billId);
                    LoadBills();
                    dtgrvOrderDetail.DataSource = null;// Tải lại danh sách hóa đơn
                }
            }
        }
    }
}
