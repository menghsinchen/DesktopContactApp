using DesktopContactApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactApp
{
    internal class SQLiteHelper
    {
        private static string _databaseName = "ContactApp.sqlitedb";
        private static string _folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static readonly string _databasePath = Path.Combine(_folderPath, _databaseName);

        public static List<Contact> ReadContact()
        {
            List<Contact> contacts = new List<Contact>();
            using (SQLiteConnection connection = new SQLiteConnection(_databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList();
            }
            return contacts;
        }

        public static void InsertContact(Contact contact)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }
        }

        public static void UpdateContact(Contact contact)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }
        }

        public static void DeleteContact(Contact contact)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }
        }
    }
}
