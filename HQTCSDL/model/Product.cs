using System;
using System.Data;
using System.Data.SqlClient; // Sử dụng SqlClient cho SQL Server
using System.IO;

namespace HQTCSDL.model
{
    internal class Product
    {
        My_DB db = new My_DB();

        // Thêm sản phẩm
        public bool AddProduct(string name, MemoryStream image, string des, decimal price)
        {
            // Thay MySqlCommand bằng SqlCommand và thay đổi cú pháp cho SQL Server
            SqlCommand cmd = new SqlCommand("EXEC ADD_PRODUCT @name, @image, @des, @price", db.getConnection);
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = image.ToArray(); // Sử dụng VarBinary cho hình ảnh
            cmd.Parameters.Add("@des", SqlDbType.VarChar).Value = des;
            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = price;

            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }

        // Lấy tất cả sản phẩm
        public DataTable getAllProducts()
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT IdProduct, NameProduct, Image, Price FROM VIEW_PRODUCT_INFORMATION", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Thay MySqlDataAdapter bằng SqlDataAdapter
            try
            {
                db.openConnection();
                adapter.Fill(dataTable);
                db.closeConnection();
                return dataTable;
            }
            catch (Exception)
            {
                db.closeConnection();
            }
            return null;
        }

        // Lấy sản phẩm theo ID
        public DataTable getProductById(int id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT IdProduct, NameProduct, Description, Price FROM VIEW_PRODUCT_INFORMATION WHERE IdProduct = @id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id; // Thay MySqlDbType.Int32 bằng SqlDbType.Int

            SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Thay MySqlDataAdapter bằng SqlDataAdapter
            try
            {
                db.openConnection();
                adapter.Fill(dataTable);
                db.closeConnection();
                return dataTable;
            }
            catch (Exception)
            {
                db.closeConnection();
            }
            return null;
        }
    }
}
