using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL
{
    public class Supplyer
    {
        public int IdSupplier { get; set; }
        public string NameSupplier { get; set; }
        public string Phone { get; set; }
        public int Áddress { get; set; }

        My_DB db = new My_DB();
        public DataTable GetAllSupplyers()
        {
            DataTable dataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT IdSupplier, NameSupplier, Phone FROM Supplier", db.getConnection);
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
