using Library_Management.Classes;
using System;
using System.Collections.Generic;
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

namespace Library_Management.Windows
{
    /// <summary>
    /// Interaction logic for uc_myescrow_books.xaml
    /// </summary>
    public partial class uc_myescrow_books : UserControl
    {
        public uc_myescrow_books()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            refreshdatagrid();
            
        }


        private void refreshdatagrid()
        {
            string srQuery;

            srQuery = $@"SELECT BookName, Author, ISBN, EscrowDate, Deadline FROM tblEscrowBooks  WHERE userName = '" + PublicMethods.loggedUserName + "'  ORDER BY BookId";

            //srQuery = $@" SELECT * FROM tblEscrowBooks ORDER BY UserId";
            DataTable dtData = Dbaseconnection.selectTable(srQuery);
            DataView dvData = new DataView(dtData);
            datagrd_duedatebook1.ItemsSource = dvData;
            total_lbl.Content = "You have " + Convert.ToInt32(datagrd_duedatebook1.Items.Count) + " book";

        }


        private void datagrd_duedatebook_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (datagrd_duedatebook1.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_duedatebook1.SelectedItem as DataRowView;


                booktitle_txtbx1.Text = drv["BookName"].ToString();
                author_txtbx.Text = drv["Author"].ToString();
                ısbn_txtbx.Text = drv["ISBN"].ToString();

                escrowdate_txtbx.Text = drv["escrowdate"].ToString();
                duedate_txtbx.Text = drv["Deadline"].ToString();
            }
        }

        
    }
}
