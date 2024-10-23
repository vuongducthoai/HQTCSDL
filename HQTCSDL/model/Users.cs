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
    internal class Users
    {
        My_DB db = new My_DB();

        // Lấy thông tin người dùng theo ID
        public DataTable getUser(int id)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT " +
                "IdUser, Name, Avatar, YearOfBirth, Address, Role " +
                "FROM VIEW_INFOR_USERS WHERE IdUser = @uid", db.getConnection);
            cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = id;

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

        // Cập nhật thông tin người dùng
        public bool updateUser(int Id, string name, MemoryStream pic, int year, string address)
        {
            MySqlCommand cmd = new MySqlCommand("CALL UPDATE_USERS (@id, @name, @year, @avatar, @address)", db.getConnection);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = Id;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@avatar", MySqlDbType.Blob).Value = pic.ToArray();
            cmd.Parameters.Add("@year", MySqlDbType.Int32).Value = year;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;

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
