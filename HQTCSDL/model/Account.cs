using HQTCSDL.Forms.ManagerVoucher.Page;
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
    internal class Account
    {
        My_DB db = new My_DB(); 
        public bool checkAccount(string uName, string uPassword)
        {
            SqlCommand command = new SqlCommand("SELECT dbo.CHECK_PASSWORD(@uN, @pW)" +
                " AS IsPasswordCorrect",db.getConnectionAdmin);
            command.Parameters.Add("@uN", SqlDbType.VarChar).Value = uName;
            command.Parameters.Add("@pW", SqlDbType.VarChar).Value = uPassword;
            db.getConnectionAdmin.Open();
            object result = command.ExecuteScalar();
            db.getConnectionAdmin.Close();
            if (result != null)
            {
                return Convert.ToBoolean(result); 
            }
            else
            {
                return false; // Mật khẩu sai
            }
        }
        public bool CreateAccount(string uName, string uPassword,
            string Name,MemoryStream pic,int year,string address,string Role)
        {
            SqlCommand cmd = new SqlCommand("EXEC CREATE_ACCOUNT" +
                " @UNAME,@PW,@NAME,@AVATAR,@YEAR_OF_BIRTH,@ADDRESS,@ROLE", db.getConnectionAdmin);
            cmd.Parameters.Add("@UNAME", SqlDbType.VarChar).Value = uName;
            cmd.Parameters.Add("@PW", SqlDbType.VarChar).Value = uPassword;
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = Name;
            cmd.Parameters.Add("@AVATAR", SqlDbType.VarBinary).Value = pic.ToArray();
            cmd.Parameters.Add("@YEAR_OF_BIRTH", SqlDbType.Int).Value = year;
            cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar).Value = address;
            cmd.Parameters.Add("@ROLE", SqlDbType.VarChar).Value = Role;
            db.openConnectionAdmin();
            if (cmd.ExecuteNonQuery()> 0)
            {
                db.closeConnectionAdmin();
                return true;
            }
            db.closeConnectionAdmin();
            return false;
        }
        public bool ChangeActive(int idAc)
        {
            db.closeConnectionAdmin();
            SqlCommand cmd = new SqlCommand("UPDATE Account " +
                "SET Active = CASE WHEN Active = 1 " +
                "THEN 0 ELSE 1 END WHERE IdAccount = @ID;", db.getConnection);
            cmd.Parameters.AddWithValue("@ID", idAc);
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
