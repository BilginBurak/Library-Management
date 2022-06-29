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
    /// Interaction logic for uc_borrow_book.xaml
    /// </summary>
    public partial class uc_borrow_book : UserControl
    {
        public uc_borrow_book()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            refreshdatagrid();
            

        }

        private void clearall()
        {
            booktitle_txtbx1.Text = "";
            author_txtbx.Text = "";
            ısbn_txtbx.Text = "";
            txtbx_search.Text = "";
            datagrd_booklist.SelectedIndex = -1;
            escrowdate_txtbx.Text = "";
            duedate_txtbx.Text = "";
            refreshdatagrid();
        }

     
        private void refreshdatagrid()
        {
            string srQuery; 


            srQuery = $@"SELECT bookıd, amountofstock, BookName, Author, Genre, publisher,pagenumber,publishdate,ISBN FROM tblBooks where (amountofstock>0 and (bookname like '%"+ txtbx_search.Text + "%' or author like '½" + txtbx_search.Text + "%'))  ORDER BY BookId";

            //srQuery = $@" SELECT * FROM tblEscrowBooks ORDER BY UserId";
            DataTable dtData = Dbaseconnection.selectTable(srQuery);
            DataView dvData = new DataView(dtData);
            datagrd_booklist.ItemsSource = dvData;
            result_lbl.Content = "Total " + Convert.ToInt32(datagrd_booklist.Items.Count) + " books found";


        }


        private void datagrd_booklist_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (datagrd_booklist.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_booklist.SelectedItem as DataRowView;


                booktitle_txtbx1.Text = drv["BookName"].ToString();
                author_txtbx.Text = drv["Author"].ToString();
                ısbn_txtbx.Text = drv["ISBN"].ToString();
                
                escrowdate_txtbx.Text = drv["Genre"].ToString();
                duedate_txtbx.Text = drv["publisher"].ToString();
            }
        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            clearall();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbx_search.Text == "")
            {
                lbl_textbx.Visibility = Visibility.Visible;
            }
            else
            {
                lbl_textbx.Visibility = Visibility.Hidden;
                
            }
            refreshdatagrid();
        }

       


        private void btnborrow_Click(object sender, RoutedEventArgs e)
        {
            Dbaseconnection.selectTable("update tblusers  set escrowlimit = '" + Dbaseconnection.selectTable("select TotalBook from tblSettings").Rows[0][0].ToString() + "' - (select count(username) from tblEscrowBooks where Username = '" + PublicMethods.loggedUserName + "') where username ='" + PublicMethods.loggedUserName + "' and userrank<1");
            if (datagrd_booklist.SelectedIndex > -1)
            {
                DataRowView drv = datagrd_booklist.SelectedItem as DataRowView;

                string escrowlimit, UserId, Username, NameSurname, Phone, srQuery="", srQuery1, srQuery2, hwmanyday;
                UserId = Dbaseconnection.selectTable("SELECT userId FROM tblUsers  WHERE userName = '" + PublicMethods.loggedUserName + "' ").Rows[0][0].ToString();
                Username = PublicMethods.loggedUserName;
                NameSurname = Dbaseconnection.selectTable("SELECT NameSurname FROM tblUsers  WHERE userName = '" + PublicMethods.loggedUserName + "' ").Rows[0][0].ToString();
                Phone = Dbaseconnection.selectTable("SELECT phone FROM tblUsers  WHERE userName = '" + PublicMethods.loggedUserName + "' ").Rows[0][0].ToString();
                escrowlimit= Dbaseconnection.selectTable("SELECT escrowlimit FROM tblUsers  WHERE userName = '" + PublicMethods.loggedUserName + "' ").Rows[0][0].ToString();
                hwmanyday = Dbaseconnection.selectTable("select TotalDay from tblSettings").Rows[0][0].ToString();
                srQuery2 = $@" UPDATE tblBooks SET AmountofStock=(AmountofStock-1) WHERE BookId='" + drv["BookId"].ToString() + "'";
                srQuery1 = $@" UPDATE tblUsers SET escrowlimit=(escrowlimit-1) WHERE (UserId='" + UserId + "' and userrank<1)";
                
               


                if (Convert.ToInt32(drv["AmountofStock"].ToString()) > 0)       //stock contol
                {
                    if (Convert.ToInt32(escrowlimit) < 1) MessageBox.Show("Escrow limit is full. Process not completed");  //user limit control

                    else
                    {
                        if (Convert.ToInt32(PublicMethods.loggedUserRank) < 1)    //student stock + student limit decrease
                        {


                        
                                srQuery = $@" insert into tblEscrowBooks (UserId, Username, NameSurname, Phone, BookId, BookName, Author, ISBN, EscrowDate, Deadline, Contact) values ('" + UserId + "', '" + Username + "', '" + NameSurname + "', '" + Phone + "', '" + drv["BookId"].ToString() + "', '" + drv["BookName"].ToString() + "', '" + drv["Author"].ToString() + "', '" + drv["ISBN"].ToString() + "', GETDATE(), DATEADD(DAY," + hwmanyday + ",GETDATE()),'0')";

                            MessageBox.Show("Please remember to return it within " + hwmanyday + " days", "Progress Complete", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                        else //teacher 
                        {
                            srQuery = $@" insert into tblEscrowBooks (UserId, Username, NameSurname, Phone, BookId, BookName, Author, ISBN, EscrowDate,  Contact) values ('" + UserId + "', '" + Username + "', '" + NameSurname + "', '" + Phone + "', '" + drv["BookId"].ToString() + "', '" + drv["BookName"].ToString() + "', '" + drv["Author"].ToString() + "', '" + drv["ISBN"].ToString() + "', GETDATE(), '0')";

                            MessageBox.Show("Progress completed");
                        }
                        Dbaseconnection.updateDeleteInsert(srQuery);
                        Dbaseconnection.updateDeleteInsert(srQuery1); Dbaseconnection.updateDeleteInsert(srQuery2);
                       
                    }
                    
                    
                    //MessageBox.Show("Book lended to \" " + drvuser["NameSurname"].ToString() + " \"", drvbook["BookName"].ToString());
                    
                }

                else MessageBox.Show("We are currently unable to lend this book to \"" + NameSurname + "\". \"" + drv["BookName"].ToString() + "\" is out of stock", drv["BookName"].ToString());
                

            
                refreshdatagrid();

            

                

            }
            else MessageBox.Show("Please select a book");
        }
    }
}
