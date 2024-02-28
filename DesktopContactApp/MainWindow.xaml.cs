using DesktopContactApp.Classes;
using SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> allContacts = new List<Contact>();

        public MainWindow()
        {
            InitializeComponent();
            RefreshContacts();
        }

        private void btnCreateNewContact_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            RefreshContacts();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterContacts();
        }

        private void lvContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void lvContacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Contact? selectedContact = lvContacts.SelectedItem as Contact;
            if (selectedContact != null)
            {
                ContactDetailsWindow window = new ContactDetailsWindow(selectedContact);
                window.ShowDialog();
                RefreshContacts();
            }
        }

        private void RefreshContacts()
        {
            allContacts = SQLiteHelper.ReadContact().OrderBy(o => o.Name).ToList();
            lvContacts.ItemsSource = allContacts;
        }

        private void FilterContacts()
        {
            List<Contact> filteredContacts = allContacts.Where(w => w.Name.Contains(txbSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            lvContacts.ItemsSource = filteredContacts;
        }
    }
}