using Library_Management.Classes;
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

namespace Library_Management.Windows
{
    /// <summary>
    /// Interaction logic for uc_settings.xaml
    /// </summary>
    public partial class uc_settings : UserControl
    {
        public uc_settings()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            book_txtbx.Text = Dbaseconnection.selectTable("select TotalBook from tblSettings").Rows[0][0].ToString();
            day_txtbx.Text = Dbaseconnection.selectTable("select TotalDay from tblSettings").Rows[0][0].ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string srQuery = $@"update tblSettings  set  totalbook ='"+ book_txtbx.Text + "', totalday='"+ day_txtbx.Text + "'";
            MessageBoxResult result = MessageBox.Show("Are you sure settings are correct?", "Settings will be applied", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes) 
            {
                Dbaseconnection.selectTable(srQuery);
                srQuery = $@"update tblUsers  set escrowlimit ='" + book_txtbx.Text + "'";
                Dbaseconnection.selectTable(srQuery);

            }

        }

        
    }
}
