﻿using DesktopContactApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DesktopContactApp
{
    /// <summary>
    /// NewContactWindow.xaml 的互動邏輯
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
            Owner = App.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = txbName.Text,
                Email = txbEmail.Text,
                Phone = txbPhone.Text
            };

            SQLiteHelper.InsertContact(contact);
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
