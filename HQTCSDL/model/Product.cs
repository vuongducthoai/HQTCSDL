using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.model
{
    internal class Product
    {
        My_DB db = new My_DB();

        // Thêm sản phẩm
        public bool AddProduct(string name, MemoryStream image, string des, decimal price)
        {
            MySqlCommand cmd = new MySqlCommand("CALL ADD_PRODUCT(@name, @image, @des, @price)", db.getConnection);
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = image.ToArray();
            cmd.Parameters.Add("@des", MySqlDbType.VarChar).Value = des;
            cmd.Parameters.Add("@price", MySqlDbType.Decimal).Value = price;

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
            MySqlCommand cmd = new MySqlCommand("SELECT IdProduct, NameProduct, Image, Price FROM VIEW_PRODUCT_INFORMATION", db.getConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
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
            MySqlCommand cmd = new MySqlCommand("SELECT IdProduct, NameProduct, Description, Price FROM VIEW_PRODUCT_INFORMATION WHERE IdProduct = @id", db.getConnection);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
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
