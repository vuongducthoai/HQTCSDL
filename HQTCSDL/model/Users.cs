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
    internal class Users
    {
        My_DB db = new My_DB();
        public DataTable getUser(int id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT " +
                "IdUser,Name,Avatar,YearOfBirth,Address,Role" +
                " FROM VIEW_INFOR_USERS WHERE IdUser = @uid",db.getConnection);
            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = id;
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
        public bool updateUser(int Id,string name ,MemoryStream pic, int year,
            string address)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("EXEC UPDATE_USERS " +
                "@id,@name,@year,@avatar,@address", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@avatar", SqlDbType.Image).Value = pic.ToArray();
            cmd.Parameters.Add("@year", SqlDbType.Int).Value = year;
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
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
