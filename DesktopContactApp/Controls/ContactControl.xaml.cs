using DesktopContactApp.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactApp.Controls
{
    /// <summary>
    /// ContactControl.xaml 的互動邏輯
    /// </summary>
    public partial class ContactControl : UserControl
    {
        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = (ContactControl)d;
            Contact contact = (Contact)e.NewValue;
            if (control != null)
            {
                control.tblName.Text = contact.Name;
                control.tblEmail.Text = contact.Email;
                control.tblPhone.Text = contact.Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
