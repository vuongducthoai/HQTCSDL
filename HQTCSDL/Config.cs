using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL
{
    internal static class Config
    {
        private static int idUser = 0;
        private static int roleAccount = 0; // 0 : Admin; 1:Staff
        private static string uname = "";
        private static string password = "";
        public static void setID(int id)
        {
            idUser = id;
        }
        public static int getID() { 
            return idUser;
        }
        public static int getRole() { 
            return roleAccount;
        }
        public static void setRole(int role) { 
            roleAccount = role;
        }
        public static string getPassword()
        {
            return password;
        }
        public static void setPassword(string passwordD)
        {
            password = passwordD;
        }

        public static string getUsername()
        {
            return uname;
        }

        public static void setUname(String uname1)
        {
            uname = uname1;
        }

    }
}
