using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HQTCSDL.model
{
    internal class Customer
    {
        public int IdCustomer { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int Loyalty { get; set; }



         My_DB db = new My_DB();

        // Lấy tất cả thông tin khách hàng
        public DataTable GetAllCustomers()
        {
            DataTable dataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT IdCustomer, FullName, Phone, Loyalty FROM Customer", db.getConnection);
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
