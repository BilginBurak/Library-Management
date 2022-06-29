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
    /// Interaction logic for uc_lend_book.xaml
    /// </summary>
    public partial class uc_lend_book : UserControl
    {
        public uc_lend_book()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cleartxtbox();
        }


        private void refreshdatagridbook()
        {
            string srQuery;
            if (chckbx_contact.IsChecked == true)
                srQuery = $@"SELECT top 100 * FROM tblBooks  WHERE ( BookName LIKE'%" + txtbx_search.Text + "%'  OR Author LIKE'%" + txtbx_search.Text + "%' OR Genre LIKE'%" + txtbx_search.Text + "%' ) ORDER BY BookID";

                
           else srQuery = $@"SELECT top 100 * FROM tblBooks  WHERE (( BookName LIKE'%" + txtbx_search.Text + "%'  OR Author LIKE'%" + txtbx_search.Text + "%' OR Genre LIKE'%" + txtbx_search.Text + "%' ) AND AmountofStock!=0) ORDER BY BookID";

            //srQuery2 = $@"SELECT  * FROM tblUsers  WHERE ((NameSurname LIKE'%" + txtbx_search.Text + "%' OR NameSurname LIKE'%" + txtbx_search.Text + "%'  OR Phone LIKE'%" + txtbx_search.Text + "%' OR Phone LIKE'%" + txtbx_search.Text + "%' ) AND Deadline<GETDATE()) ORDER BY UserId";


            //srQuery = $@" SELECT * FROM tblEscrowBooks ORDER BY UserId";
            DataTable dtData = Dbaseconnection.selectTable(srQuery);
            DataView dvData = new DataView(dtData);
            datagrd_book.ItemsSource = dvData;
            total_lbl.Content = "Total " + Convert.ToInt32(datagrd_book.Items.Count) + " result found";

        }

        private void refreshdatagriduser()
        {
            string srQuery = $@"SELECT * FROM tblUsers  WHERE ( Username LIKE'%" + txtbx_searchuser.Text + "%'  OR NameSurname LIKE'%" + txtbx_searchuser.Text + "%' OR Phone LIKE'%" + txtbx_searchuser.Text + "%' ) and userrank<'"+ PublicMethods.loggedUserRank+"'  ORDER BY UserID";

            //srQuery2 = $@"SELECT  * FROM tblUsers  WHERE ((NameSurname LIKE'%" + txtbx_search.Text + "%' OR NameSurname LIKE'%" + txtbx_search.Text + "%'  OR Phone LIKE'%" + txtbx_search.Text + "%' OR Phone LIKE'%" + txtbx_search.Text + "%' ) AND Deadline<GETDATE()) ORDER BY UserId";


            //srQuery = $@" SELECT * FROM tblEscrowBooks ORDER BY UserId";
            DataTable dtData = Dbaseconnection.selectTable(srQuery);
            DataView dvData = new DataView(dtData);
            datagrd_user.ItemsSource = dvData;
            total_lbl2.Content = "Total " + Convert.ToInt32(datagrd_user.Items.Count) + " result found";

        }


        private void cleartxtbox()
        {
            name_surname_txtbx.Text = "";
            booktitle_txtbx1.Text = "";
            txtbx_searchuser.Text = "";
            txtbx_search.Text = "";
            chckbx_contact.IsChecked = false;
            refreshdatagridbook(); refreshdatagriduser();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            cleartxtbox();
            

        }

        private void txtbx_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbx_search.Text == "") lbl_textbx.Visibility = Visibility.Visible;
          
            else lbl_textbx.Visibility = Visibility.Hidden;
           
            refreshdatagridbook();
        }

        private void datagrd_book_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (datagrd_book.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_book.SelectedItem as DataRowView;
               
                booktitle_txtbx1.Text = drv["BookName"].ToString();
                


                

            }
        }
        private void datagrd_user_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (datagrd_user.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_user.SelectedItem as DataRowView;
                name_surname_txtbx.Text = drv["NameSurname"].ToString();

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drvbook = datagrd_book.SelectedItem as DataRowView;
            DataRowView drvuser = datagrd_user.SelectedItem as DataRowView;
            string srQuery2, srQuery1, srQuery0 = "";
            Dbaseconnection.selectTable("update tblusers  set escrowlimit = '" + Dbaseconnection.selectTable("select TotalBook from tblSettings").Rows[0][0].ToString() + "' - (select count(username) from tblEscrowBooks where Username = '" + drvuser["Username"].ToString() + "') where username ='" + drvuser["Username"].ToString() + "'");
            if (datagrd_book.SelectedIndex > -1 && datagrd_user.SelectedIndex > -1)
            {

               
                srQuery2 = $@" UPDATE tblBooks SET AmountofStock=(AmountofStock-1) WHERE BookId='" + drvbook["BookId"].ToString() + "'";
                srQuery1 = $@" UPDATE tblUsers SET escrowlimit=(escrowlimit-1) WHERE (UserId='" + drvuser["UserId"].ToString() + "' and userrank<1)";



                if (Convert.ToInt32(drvbook["AmountofStock"].ToString()) > 0)
                {
                    if (Convert.ToInt32(drvuser["escrowlimit"].ToString()) < 1) MessageBox.Show("Escrow limit is full. Process not completed");

                    else
                    {
                        if (Convert.ToInt32(drvuser["userrank"].ToString()) < 1)    //student stock + student limit decrease
                        {
                            
                          
                                srQuery0 = $@" insert into tblEscrowBooks (UserId, Username, NameSurname, Phone, BookId, BookName, Author, ISBN, EscrowDate, Deadline, Contact) values ('" + drvuser["UserId"].ToString() + "', '" + drvuser["Username"].ToString() + "', '" + drvuser["NameSurname"].ToString() + "', '" + drvuser["Phone"].ToString() + "', '" + drvbook["BookId"].ToString() + "', '" + drvbook["BookName"].ToString() + "', '" + drvbook["Author"].ToString() + "', '" + drvbook["ISBN"].ToString() + "', GETDATE(), DATEADD(DAY,10,GETDATE()), '0')";

                           
                        }
                        else //teacher 
                        {
                            srQuery0 = $@" insert into tblEscrowBooks (UserId, Username, NameSurname, Phone, BookId, BookName, Author, ISBN, EscrowDate,  Contact) values ('" + drvuser["UserId"].ToString() + "', '" + drvuser["Username"].ToString() + "', '" + drvuser["NameSurname"].ToString() + "', '" + drvuser["Phone"].ToString() + "', '" + drvbook["BookId"].ToString() + "', '" + drvbook["BookName"].ToString() + "', '" + drvbook["Author"].ToString() + "', '" + drvbook["ISBN"].ToString() + "', GETDATE(), '0')";

                        }

                        Dbaseconnection.updateDeleteInsert(srQuery1); Dbaseconnection.updateDeleteInsert(srQuery2);
                        Dbaseconnection.updateDeleteInsert(srQuery0);
                        MessageBox.Show("Book lended to \" " + drvuser["NameSurname"].ToString() + " \"", drvbook["BookName"].ToString());
                    }

                }
                else MessageBox.Show("We are currently unable to lend this book to \"" + drvuser["NameSurname"].ToString() + "\". \"" + drvbook["BookName"].ToString() + "\" is out of stock", drvbook["BookName"].ToString());
                    cleartxtbox();
            }
                    

            
            else MessageBox.Show("Please select one user and one book");
        }

        private void chckbx_contact_Click(object sender, RoutedEventArgs e)
        {
            booktitle_txtbx1.Text = "";
            refreshdatagridbook();
        }

        private void txtbx_searchuser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbx_searchuser.Text == "") lbl_textbx_user.Visibility = Visibility.Visible;

            else lbl_textbx_user.Visibility = Visibility.Hidden; refreshdatagriduser();
        }

       
    }
}
