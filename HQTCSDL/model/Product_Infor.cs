using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL.model
{
    internal class Product_Infor
    {
        My_DB db = new My_DB();
        public DataTable getProductInforByIDProduct(int id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT " +
                "IdPInfor ,Color, Size, Quantity " +
                "FROM VIEW_PRODUCT_INFORMATION" +
                " WHERE IdProduct = @ID", db.getConnection);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
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
        public bool AddProductInfor(int idProduct, int size, string color, int quantity)
        {
            SqlCommand cmd = new SqlCommand("EXEC ADD_PRODUCT_INFOR @ID_PRODUCT,@SIZE,@COLOR,@QUANITY", db.getConnection);
            cmd.Parameters.Add("@ID_PRODUCT", SqlDbType.Int).Value = idProduct;
            cmd.Parameters.Add("@SIZE", SqlDbType.Int).Value = size;
            cmd.Parameters.Add("@COLOR", SqlDbType.VarChar).Value = color;
            cmd.Parameters.Add("@QUANITY", SqlDbType.Int).Value = quantity;
            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {   
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
        public DataTable SearchProductInfor(int id_Product,int id_PInfor)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT" +
                " Color, Size FROM VIEW_PRODUCT_INFORMATION " +
                "WHERE IdProduct = @IDP AND IdPInfor = @IDPINFOR", db.getConnection);
            cmd.Parameters.Add("@IDP", SqlDbType.Int).Value = id_Product;
            cmd.Parameters.Add("@IDPINFOR", SqlDbType.Int).Value = id_PInfor;
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
        public bool UpdateProductInfor(int idProduct,int idProductInfor,int Size,string color,int quantity)
        {
            SqlCommand cmd = new SqlCommand("EXEC UPDATE_PRODUCT_INFOR @idP,@idP_infor,@size,@color,@quantity", db.getConnection);
            cmd.Parameters.Add("@idP", SqlDbType.Int).Value = idProduct;
            cmd.Parameters.Add("@idP_infor", SqlDbType.Int).Value = idProductInfor;
            cmd.Parameters.Add("@Size", SqlDbType.Int).Value = Size;
            cmd.Parameters.Add("@color", SqlDbType.VarChar).Value = color;
            cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;
            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
        public bool UpdateProductInfor(int idProduct, int idProductInfor, int Size, string color)
        {
            SqlCommand cmd = new SqlCommand("EXEC UPDATE_PRODUCT_INFOR @idP,@idP_infor,@size,@color", db.getConnection);
            cmd.Parameters.Add("@idP", SqlDbType.Int).Value = idProduct;
            cmd.Parameters.Add("@idP_infor", SqlDbType.Int).Value = idProductInfor;
            cmd.Parameters.Add("@Size", SqlDbType.Int).Value = Size;
            cmd.Parameters.Add("@color", SqlDbType.VarChar).Value = color;
            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
        public bool DeleteProductInfor(int idProduct, int idProductInfor)
        {
            SqlCommand cmd = new SqlCommand("EXEC DELETE_PRODUCT_INFOR @idP,@idP_infor", db.getConnection);
            cmd.Parameters.Add("@idP", SqlDbType.Int).Value = idProduct;
            cmd.Parameters.Add("@idP_infor", SqlDbType.Int).Value = idProductInfor;
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
