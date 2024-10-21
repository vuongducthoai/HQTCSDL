using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT " +
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
            catch (Exception ex)
            {
               
                db.closeConnection();
            }
            return null;
        }
        public DataTable getProductById(int id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT " +
                "IdProduct,NameProduct,Image,Description,Price,idVoucher " +
                "FROM VIEW_PRODUCT_INFORMATION WHERE IdProduct = @id", db.getConnection);
            cmd.Parameters.Add("@id",SqlDbType.Int).Value = id;
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

        public DataTable SearchProduct(string name,decimal? price_start,decimal? price_end,int? id_category)
        { 
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("EXEC SEARCH_PRODUCT" +
                " @name,@price_start,@price_end,@id_ca", db.getConnection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price_start",  (Object)price_start??DBNull.Value);
            cmd.Parameters.AddWithValue("@price_end", (Object)price_end ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id_ca", (Object)id_category ?? DBNull.Value);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            try
            {   
                db.openConnection();
                adapter.Fill(dataTable);
                db.closeConnection();
                return dataTable;

            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public bool updateProduct(int id,string name,MemoryStream pic,string des,decimal price)
        {
            SqlCommand cmd = new SqlCommand("EXEC UPDATE_PRODUCT @ID,@NAME,@IMAGE,@PRICE,@DES,@ID_VOUCHER", db.getConnection);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NAME", name);
            cmd.Parameters.AddWithValue("@IMAGE", pic.ToArray());  
            cmd.Parameters.AddWithValue("@PRICE", price);
            cmd.Parameters.AddWithValue("@DES", des);   
            cmd.Parameters.AddWithValue("@ID_VOUCHER", DBNull.Value);
            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
        public bool AddVoucher(int id,int? id_voucher)
        {
            SqlCommand cmd = new SqlCommand("EXEC UPDATE_PRODUCT @ID,@NAME,@IMAGE,@PRICE,@DES,@ID_VOUCHER", db.getConnection);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.Add("@NAME",SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Parameters.Add("@IMAGE", SqlDbType.VarBinary).Value = DBNull.Value;
            cmd.Parameters.Add("@PRICE", SqlDbType.Decimal).Value = DBNull.Value;
            cmd.Parameters.Add("@DES", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Parameters.AddWithValue("@ID_VOUCHER", (Object)id_voucher ?? DBNull.Value);
            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
        public bool deleteProduct(int id)
        {
            SqlCommand cmd = new SqlCommand("EXEC DELETE_PRODUCT @ID", db.getConnection);
            cmd.Parameters.AddWithValue("@ID", id);
            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
    }
}
