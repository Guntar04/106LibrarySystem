using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace _106LibrarySystem
{
    public class OverdueBookLogger
    {
        private const string OverdueLogFileName = "overdue_log.txt";

        public static void LogOverdueBook(int userID, string bookName)
        {
            try
            {
                // Create or open the file for appending
                using (StreamWriter sw = File.AppendText(OverdueLogFileName))
                {
                    string logMessage = $"User ID: {userID}, Book Name: {bookName}, Date: {DateTime.Now}";
                    sw.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging overdue book: {ex.Message}");
            }
        }
    }
}