using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace _106LibrarySystem
{
    public class DatabaseHelper
    {
        private static readonly string databaseFileName = "LibraryDatabase.db";
        private static readonly string source = $"Data Source={Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

        public static User GetUserByID(int userID)
        {
            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM users WHERE ID = @ID";
                return connection.QueryFirstOrDefault<User>(selectQuery, new { ID = userID });
            }
        }

        public static void UpdateUser(User user)
        {
            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();
                string updateQuery = @"
                    UPDATE users
                    SET UserName = @UserName, 
                        FirstName = @FirstName, 
                        LastName = @LastName, 
                        EmailAddress = @EmailAddress,
                        PhoneNumber = @PhoneNumber, 
                        Password = @Password, 
                        Role = @Role
                    WHERE ID = @ID
                ";

                connection.Execute(updateQuery, user);
            }
        }
    }
}
