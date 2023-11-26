﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Dapper;

namespace _106LibrarySystem
{
    /// <summary>
    /// Interaction logic for AdminUserList.xaml
    /// </summary>
    public partial class AdminUserList : UserControl
    {
        static string databaseFileName = "LibraryDatabase.db";
        static string source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";
        public AdminUserList()
        {
            InitializeComponent();
            DisplayUserData();
        }
        private void DisplayUserData()
        {
            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();
                var users = connection.Query("SELECT * FROM users");
                userGrid.ItemsSource = users;
            }
        }
    }
}
