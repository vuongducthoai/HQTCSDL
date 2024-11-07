using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HQTCSDL.model
{
    internal class Supplier
    {
        My_DB db = new My_DB();

        public DataTable getAllSupplier()
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Supplier_View", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            try
            {
                db.openConnection();
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }

            return dataTable;
        }


        public DataTable SearchSupplierByTerm(string term)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchSupplierByTerm(@searchTerm)", db.getConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@searchTerm", SqlDbType.NVarChar)).Value = term;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            try
            {
                db.openConnection();
                adapter.Fill(dataTable);
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                db.closeConnection();
            }

            return dataTable;
        }



        public bool insertSupplier(string name, string phone, string address)
        {
            SqlCommand cmd = new SqlCommand("InsertNewSupplier", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NameSupplier", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = phone;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value=address;
            try
            {
                db.openConnection();
                if(cmd.ExecuteNonQuery() == 1)
                {
                    db.closeConnection();
                    return true; 
                } else
                {
                    db.closeConnection();
                    return false;
                }
            }catch(SqlException ex)
            {
                MessageBox.Show("Loi khi them nha cung cap: " + ex.Message);  // Loi tu Trigger
            }
            db.closeConnection() ;
            return false;

        }

        
        public bool updateSupplier(int supplierId, string name, string phone, string address)
        {
            SqlCommand cmd = new SqlCommand("proc_EditSupplier", db.getConnection);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.Add("@idSupplier", SqlDbType.Int).Value = supplierId;
            cmd.Parameters.Add("@nameSupplier", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
           
            db.openConnection();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool deleteSupplier(int supplierId)
        {
            SqlCommand cmd = new SqlCommand("proc_DeleteSupplier", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdSupplier", SqlDbType.Int).Value = supplierId;

            try
            {
                db.openConnection();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    return true; 
                }
                else
                {
                    return false; 
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message);
                Console.WriteLine("Chi tiết lỗi: " + ex.ToString()); 
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }


    }
}
