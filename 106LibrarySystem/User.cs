using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106LibrarySystem
{
    internal class User
    {
        public static string UserName { get; private set; }
        public static string Email { get; private set; }
        public static string ID { get; private set; }
        public static string JoinDate { get; private set; }

        public static void SetCurrentUser(string userName, string email, string iD, string joinDate)
        {
            UserName = userName;
            Email = email;
            ID = iD;
            JoinDate = joinDate;
        }
    }
}
