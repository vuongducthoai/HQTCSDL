using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HQTCSDL
{
    public class Supplyer
    {
        public int IdSupplier { get; set; }
        public string NameSupplier { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; } // Sửa lỗi từ "Áddress" thành "Address" và chuyển kiểu thành string

        My_DB db = new My_DB();

        // Lấy tất cả thông tin nhà cung cấp
        public DataTable GetAllSupplyers()
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT IdSupplier, NameSupplier, Phone FROM Supplier", db.getConnection);
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
