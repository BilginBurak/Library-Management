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
    /// Interaction logic for uc_student_outofdate_book.xaml
    /// </summary>
    public partial class uc_student_outofdate_book : UserControl
    {
        public uc_student_outofdate_book()
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
                
                srQuery = $@"SELECT BookName, Author, ISBN, EscrowDate, Deadline FROM tblEscrowBooks  WHERE ((userName = '" + PublicMethods.loggedUserName+ "' ) AND Deadline<GETDATE()) ORDER BY BookId";


                //srQuery = $@" SELECT * FROM tblEscrowBooks ORDER BY UserId";
                DataTable dtData = Dbaseconnection.selectTable(srQuery);
                DataView dvData = new DataView(dtData);
                datagrd_duedatebook.ItemsSource = dvData;
                total_lbl.Content = "You have " + Convert.ToInt32(datagrd_duedatebook.Items.Count) + " expired book";
                 
                if (Convert.ToInt32(datagrd_duedatebook.Items.Count) < 1)
                {
                booktitle_txtbx1.Visibility = Visibility.Hidden;
                author_txtbx.Visibility = Visibility.Hidden;
                ısbn_txtbx.Visibility = Visibility.Hidden;
                datagrd_duedatebook.Visibility = Visibility.Hidden;
                escrowdate_txtbx.Visibility = Visibility.Hidden;
                duedate_txtbx.Visibility = Visibility.Hidden;
                late_lbl.Visibility = Visibility.Visible;
                total_lbl.Visibility = Visibility.Hidden;
                lbl1.Visibility = Visibility.Hidden;
                lbl2.Visibility = Visibility.Hidden;
                lbl3.Visibility = Visibility.Hidden;
                lbl4.Visibility = Visibility.Hidden;
                lbl5.Visibility = Visibility.Hidden;

            }

        }


        private void datagrd_duedatebook_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (datagrd_duedatebook.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_duedatebook.SelectedItem as DataRowView;
                
                
                booktitle_txtbx1.Text = drv["BookName"].ToString();
                author_txtbx.Text = drv["Author"].ToString();
                ısbn_txtbx.Text = drv["ISBN"].ToString();

                escrowdate_txtbx.Text = drv["escrowdate"].ToString();
                duedate_txtbx.Text = drv["Deadline"].ToString();
            }
        }

       

    }
}
