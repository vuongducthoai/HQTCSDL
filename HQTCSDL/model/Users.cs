using System;
using System.Data;
using System.Data.SqlClient; // Sử dụng SqlClient cho SQL Server
using System.IO;

namespace HQTCSDL.model
{
    internal class Users
    {
        My_DB db = new My_DB();

        // Lấy thông tin người dùng theo ID
        public DataTable getUser(int id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT " +
                "IdUser, Name, Avatar, YearOfBirth, Address, Role " +
                "FROM VIEW_INFOR_USERS WHERE IdUser = @uid", db.getConnection);
            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = id; // Thay MySqlDbType.Int32 bằng SqlDbType.Int

            SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Thay MySqlDataAdapter bằng SqlDataAdapter
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
            // Thay MySqlCommand bằng SqlCommand và thay đổi cú pháp cho SQL Server
            SqlCommand cmd = new SqlCommand("EXEC UPDATE_USERS @id, @name, @year, @avatar, @address", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id; // Thay MySqlDbType.Int32 bằng SqlDbType.Int
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@avatar", SqlDbType.VarBinary).Value = pic.ToArray(); // Sử dụng VarBinary cho hình ảnh
            cmd.Parameters.Add("@year", SqlDbType.Int).Value = year;
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address;

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
