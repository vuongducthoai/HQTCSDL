using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.model
{
    internal class Product
    {
        My_DB db = new My_DB();
        public bool AddProduct(string name,MemoryStream image,string des,decimal price)
        {
            SqlCommand cmd = new SqlCommand("EXEC ADD_PRODUCT @name,@image,@des,@price",db.getConnection);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@image", SqlDbType.Image).Value = image.ToArray();
            cmd.Parameters.Add("@des", SqlDbType.NVarChar).Value = des;
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
        public DataTable getAllProducts()
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT " +
                "IdProduct,NameProduct,Image,Price " +
                "FROM VIEW_PRODUCT_INFORMATION", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public DataTable getProductById(int id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT " +
                "IdProduct,NameProduct,Description,Price " +
                "FROM VIEW_PRODUCT_INFORMATION WHERE IdProduct = @id", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
