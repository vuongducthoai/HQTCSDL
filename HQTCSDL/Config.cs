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

    }
}
