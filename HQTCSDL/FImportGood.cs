using HQTCSDL.model;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
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

namespace HQTCSDL
{
    public partial class FImportGood : Form
    {
        My_DB db = new My_DB();
        public FImportGood()
        {
            InitializeComponent();
        }

        private void FImportGood_Load(object sender, EventArgs e)
        {
            dtgrvImportBill.AllowUserToAddRows = false;
            LoadCatalogs();
            LoadProducts();
            Loadsupplyers();
        }

        private void Loadsupplyers()
        {
            Supplyer supplyers = new Supplyer();

            cbxSupplier.Items.Clear(); // Xóa các mục hiện tại

            DataTable supplyerData = supplyers.GetAllSupplyers();
            if (supplyerData != null)
            {
                foreach (DataRow row in supplyerData.Rows)
                {
                    var supplyer = new Supplyer
                    {
                        IdSupplier = Convert.ToInt32(row["IdSupplier"]),
                        NameSupplier = row["NameSupplier"].ToString(),
                        Phone = row["Phone"].ToString(),
                    };
                    cbxSupplier.Items.Add(supplyer); // Thêm đối tượng Customer vào ComboBox
                }
            }

            cbxSupplier.DisplayMember = "NameSupplier"; // Tạm thời hiển thị tên khách hàng
            cbxSupplier.ValueMember = "IdSupplier"; // Giá trị sẽ là IdCustomer
        }

        private void LoadCatalogs()
        {
            string query = "SELECT IdCategory, NameCategory FROM Category"; // Lấy danh mục
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.getConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            cbxcatalog.Items.Clear(); // Xóa các mục hiện tại

            // Thêm item "All"
            cbxcatalog.Items.Add(new Catalog { IdCategory = 0, NameCategory = "All" }); // 0 để biểu thị cho tất cả

            foreach (DataRow row in dataTable.Rows)
            {
                var catalog = new Catalog
                {
                    IdCategory = Convert.ToInt32(row["IdCategory"]),
                    NameCategory = row["NameCategory"].ToString()
                };
                cbxcatalog.Items.Add(catalog); // Thêm đối tượng Catalog vào ComboBox
            }

            cbxcatalog.DisplayMember = "NameCategory"; // Hiển thị tên danh mục
            cbxcatalog.SelectedIndex = 0; // Đặt mặc định là "All"
        }

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

            foreach (DataGridViewRow row in dtgrvImportBill.Rows)
            {
                int existingProductId = Convert.ToInt32(row.Cells["id"].Value);
                string existingSize = row.Cells["size"].Value.ToString();
                string existingColor = row.Cells["color"].Value.ToString();

                if (existingProductId == productId && existingSize == size && existingColor == color)
                {
                    // Tăng số lượng sản phẩm lên
                    int currentQuantity = Convert.ToInt32(row.Cells["quantity"].Value);
                    row.Cells["quantity"].Value = currentQuantity + quantity;

                    productExists = true;
                    break; // Thoát vòng lặp vì đã tìm thấy sản phẩm cần cập nhật
                }
            }

            // Nếu sản phẩm chưa tồn tại, thêm sản phẩm mới vào DataGridView
            if (!productExists)
            {
                int rowIndex = dtgrvImportBill.Rows.Add(productId, productName, size, color, quantity);
                DataGridViewRow newRow = dtgrvImportBill.Rows[rowIndex];
                newRow.Cells["btnDelete"].Value = "Xóa"; // Văn bản hiển thị trên nút
                newRow.Cells["btnDelete"].Style.BackColor = Color.Red; // Màu nền cho nút
                newRow.Cells["btnDelete"].Style.ForeColor = Color.White;
            }

        }

        private void cbxcatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxcatalog.SelectedItem != null)
            {
                Catalog selectedCatalog = (Catalog)cbxcatalog.SelectedItem; // Lấy đối tượng Catalog

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

        private void dtgrvImportBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == dtgrvImportBill.Columns["btnDelete"].Index)
            {
                // Xác nhận trước khi xóa
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?",
                                                        "Xác nhận xóa",
                                                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Xóa hàng đã chọn
                    dtgrvImportBill.Rows.RemoveAt(e.RowIndex);
                }
            }

        }

        private void cbxSupplier_TextUpdate(object sender, EventArgs e)
        {
            string searchText = cbxSupplier.Text.ToLower();

            cbxSupplier.Items.Clear(); // Xóa các mục hiện tại

            Supplyer supplyers = new Supplyer();
            DataTable supplyerData = supplyers.GetAllSupplyers();

            foreach (DataRow row in supplyerData.Rows)
            {
                var supplyer = new Supplyer
                {
                    IdSupplier = Convert.ToInt32(row["IdSupplier"]),
                    NameSupplier = row["NameSupplier"].ToString(),
                    Phone = row["Phone"].ToString(),
                };

                if (supplyer.NameSupplier.ToLower().Contains(searchText) || supplyer.Phone.Contains(searchText))
                {
                    cbxSupplier.Items.Add(supplyer);
                }
            }

            // Hiển thị lại ComboBox với danh sách khách hàng lọc được
            cbxSupplier.DroppedDown = true;
            cbxSupplier.Select(cbxSupplier.Text.Length, 0);
        }

        private int GetProductInforId(int productId, int size, string color, SqlTransaction transaction)
        {
            string query = "SELECT IdPInfor FROM Product_Infor WHERE IdProduct = @IdProduct AND Size = @Size AND Color = @Color";
            SqlCommand cmd = new SqlCommand(query, db.getConnection, transaction); // Gán transaction vào command
            cmd.Parameters.AddWithValue("@IdProduct", productId);
            cmd.Parameters.AddWithValue("@Size", size);
            cmd.Parameters.AddWithValue("@Color", color);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1; // Kiểm tra kết quả null trước khi chuyển đổi
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn trong DataGridView
            if (dtgrvImportBill.Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để nhập!");
                return;
            }

            if (cbxSupplier.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                return;
            }

            decimal total;
            if (!decimal.TryParse(txtTotal.Text, out total))
            {
                MessageBox.Show("Số tiền không hợp lệ!");
                return;
            }

            // Lấy giá trị từ ComboBox cho nhà cung cấp
            Supplyer selectedSupplier = (Supplyer)cbxSupplier.SelectedItem;
            int idSup = selectedSupplier.IdSupplier;

            // Chuẩn bị thông tin hiển thị cho người dùng
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Thông tin hóa đơn nhập:");
            sb.AppendLine($"Nhà cung cấp: {cbxSupplier.Text}");
            sb.AppendLine($"Tổng tiền: {total}");

            // Thêm chi tiết sản phẩm từ DataGridView
            sb.AppendLine("\nChi tiết sản phẩm:");
            foreach (DataGridViewRow row in dtgrvImportBill.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua hàng mới
                string productName = row.Cells["name"].Value.ToString();
                int quantity = (int)row.Cells["quantity"].Value;

                sb.AppendLine($"- {productName}, Số lượng: {quantity}");
            }

            // Hiển thị thông tin hóa đơn và yêu cầu xác nhận
            DialogResult dialogResult = MessageBox.Show(sb.ToString(), "Xác nhận nhập hàng", MessageBoxButtons.OKCancel);
            if (dialogResult != DialogResult.OK)
            {
                return; // Nếu người dùng không nhấn OK, thoát
            }

            db.openConnection();

            using (SqlTransaction transaction = db.getConnection.BeginTransaction())
            {
                try
                {
                    // 1. Gọi thủ tục để tạo đơn hàng
                    int newOrderId;

                    using (SqlCommand cmd = new SqlCommand("CreatePurchaseOrder", db.getConnection, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_IdSupplier", idSup);
                        cmd.Parameters.AddWithValue("@p_Total", total);
                        cmd.Parameters.Add("@p_NewOrderId", SqlDbType.Int).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        newOrderId = (int)cmd.Parameters["@p_NewOrderId"].Value;
                    }

                    // 2. Gọi thủ tục để thêm chi tiết đơn hàng
                    foreach (DataGridViewRow row in dtgrvImportBill.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int productId = Convert.ToInt32(row.Cells["id"].Value);
                        int size = Convert.ToInt32(row.Cells["size"].Value);
                        string color = row.Cells["color"].Value.ToString();
                        int quantity = Convert.ToInt32(row.Cells["quantity"].Value);

                        int productInforId = GetProductInforId(productId, size, color, transaction);

                        using (SqlCommand cmd = new SqlCommand("AddPurchaseOrderDetail", db.getConnection, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@p_IdPInfor", productInforId);
                            cmd.Parameters.AddWithValue("@p_Quantity", quantity);
                            cmd.Parameters.AddWithValue("@p_NewOrderId", newOrderId);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Commit transaction
                    transaction.Commit();
                    MessageBox.Show("Nhập hàng thành công!");
                    dtgrvImportBill.Rows.Clear();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
                finally
                {
                    db.closeConnection(); // Đảm bảo kết thúc kết nối
                }
            }

    }
        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            dtgrvManageImportGoods.DataSource = null;

            DateTime fromDate = dtpkFrom.Value.Date;  // Lấy ngày bắt đầu
            DateTime toDate = dtpkTo.Value.Date.AddDays(1).AddTicks(-1);  // Lấy ngày kết thúc (bao gồm cả ngày đó)

            string query = $"SELECT * " +
                           $"FROM view_purchasebill " +
                           $"WHERE Date BETWEEN '{fromDate:yyyy-MM-dd HH:mm:ss}' AND '{toDate:yyyy-MM-dd HH:mm:ss}'";

            SqlCommand command = new SqlCommand(query, db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dtgrvManageImportGoods.DataSource = dt;
        }

        private bool DeleteBill(int id)
        {
            db.openConnection();
            string query = "DELETE FROM purchase_order WHERE IdPOder = @IdBill;";

            using (SqlCommand command = new SqlCommand(query, db.getConnection))
            {
                command.Parameters.AddWithValue("@IdBill", id);
                int rowsAffected = command.ExecuteNonQuery();

                // Trả về true nếu xóa thành công, false nếu không tìm thấy hóa đơn
                return rowsAffected > 0;
            }
        }
        private void btnDeleteImportBill_Click(object sender, EventArgs e)
        {
            if (dtgrvManageImportGoods.SelectedRows.Count > 0)
            {
                int billId = Convert.ToInt32(dtgrvManageImportGoods.SelectedRows[0].Cells["IdPOder"].Value);

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    DeleteBill(billId);
                    btnHoanTat_Click(sender,e);
                    dtgrvDetailImport.DataSource = null;// Tải lại danh sách hóa đơn
                }
            }
        }

        private void dtgrvManageImportGoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int billId = Convert.ToInt32(dtgrvManageImportGoods.Rows[e.RowIndex].Cells["IdPOder"].Value);
            LoadPurchaseDetails(billId);
        }

        private void LoadPurchaseDetails(int billId)
        {
            dtgrvDetailImport.DataSource = null;

            string query = $"SELECT * FROM view_purchasedetail WHERE IdPurchase = {billId}";

            SqlCommand command = new SqlCommand(query, db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dtgrvDetailImport.DataSource = dt;
        }

    }
}

