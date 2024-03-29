﻿using DesktopContactApp.Classes;
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
    /// ContactDetailsWindow.xaml 的互動邏輯
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact contact;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            Owner = App.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;

            this.contact = contact;
            txbName.Text = contact.Name;
            txbEmail.Text = contact.Email;
            txbPhone.Text = contact.Phone;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = txbName.Text.Trim();
            contact.Email = txbEmail.Text.Trim();
            contact.Phone = txbPhone.Text.Trim();

            SQLiteHelper.UpdateContact(contact);
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            SQLiteHelper.DeleteContact(contact);
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
