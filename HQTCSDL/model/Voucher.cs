using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HQTCSDL.model
{
    internal class Voucher
    {
        My_DB db = new My_DB();
        public DataTable getAllVoucher()
        {
            SqlCommand cmd = new SqlCommand("select " +
                "IdVoucher,NameVoucher,Discount " +
                "from Voucher", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable getVoucherByID(int id)
        {
            SqlCommand cmd = new SqlCommand("select IdVoucher,NameVoucher,Discount from Voucher WHERE IdVoucher = @id", db.getConnection);
            cmd.Parameters.Add("@id",SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public bool AddVoucher(string name, decimal discount)
        {
            SqlCommand cmd = new SqlCommand("EXEC ADDVOUCHER @name,@discount", db.getConnection);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@discount", SqlDbType.Decimal).Value = discount;            
            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
        public bool UpdateVoucher(int id, string name, decimal discount)
        {
            SqlCommand cmd = new SqlCommand("EXEC UPDATE_VOUCHER @id,@name,@discount", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@discount", SqlDbType.Decimal).Value = discount;
            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
        public bool DeleteVoucher(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Voucher WHERE IdVoucher = @ID", db.getConnection);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
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
