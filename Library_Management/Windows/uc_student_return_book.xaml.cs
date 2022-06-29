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
    /// Interaction logic for uc_student_return_book.xaml
    /// </summary>
    public partial class uc_student_return_book : UserControl
    {
        public uc_student_return_book()
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

            srQuery = $@"SELECT EscrowID,BookId, BookName, Author, ISBN,EscrowDate,Deadline FROM tblEscrowBooks where username='"+ PublicMethods.loggedUserName +"' ORDER BY escrowıd";

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

                escrowdate_txtbx.Text = drv["EscrowDate"].ToString();
                duedate_txtbx.Text = drv["Deadline"].ToString();
            }
        }

     
   




        private void btnborrow_Click(object sender, RoutedEventArgs e)
        {
            if (datagrd_booklist.SelectedIndex > -1)
            {
                DataRowView drv = datagrd_booklist.SelectedItem as DataRowView;

                string escrowlimit, UserId, Username, NameSurname, Phone, srQuery = "", srQuery1, srQuery2, srQuery3;
                srQuery2 = $@" UPDATE tblBooks SET AmountofStock=(AmountofStock+1) WHERE BookId='" + drv["BookId"].ToString() + "'";
                srQuery1 = $@" UPDATE tblUsers SET EscrowLimit=(escrowlimit+1) WHERE (Username='" + PublicMethods.loggedUserName + "' and userrank<1)";
                srQuery3 = $@" select count (EscrowID) from tblNotVerified WHERE (EscrowID='" + drv["EscrowID"].ToString() + "')";

                if (Convert.ToInt32(PublicMethods.loggedUserRank) < 1)
                {
                    if (Convert.ToInt32(Dbaseconnection.selectTable(srQuery3).Rows[0][0].ToString()) > 0) MessageBox.Show("Your book is awaiting approval");
                    else
                    {
                        srQuery = $@" insert into tblNotVerified select * from tblescrowbooks where (escrowId= '" + drv["EscrowID"].ToString() + "')";
                        //outdatebook = Convert.ToInt32(Dbaseconnection.selectTable("select COUNT (escrowıd) from tblEscrowbooks where (username= '" + PublicMethods.loggedUserName + "' and deadline<GETDATE())").Rows[0][0].ToString());
                        Dbaseconnection.updateDeleteInsert(srQuery);
                        MessageBox.Show("Your book return will be completed when the administrators approve.");
                    }
                    

                }
                

                else
                {
                    srQuery = $@" delete from tblescrowbooks where (escrowId= '" + drv["EscrowID"].ToString() + "')";

                    MessageBox.Show("Book return is complete");
                    Dbaseconnection.updateDeleteInsert(srQuery2); Dbaseconnection.updateDeleteInsert(srQuery1);
                    Dbaseconnection.updateDeleteInsert(srQuery);
                } 
                    
                    
                
            }

                
             else MessageBox.Show("Please select a book");


            refreshdatagrid();





            //if (datagrd_duedatebook.SelectedIndex > -1)
            //{

            //    DataRowView drv = datagrd_duedatebook.SelectedItem as DataRowView;

            //    string srQuery2, srQuery1, srQuery0;
            //    srQuery0 = $@" delete from tblescrowbooks where (BookId= '" + drv["BookId"].ToString() + "' and UserId='" + drv["UserId"].ToString() + "')";
            //    srQuery1 = $@" UPDATE tblBooks SET AmountofStock=(AmountofStock+1) WHERE BookId='" + drv["BookId"].ToString() + "'";

            //    srQuery2 = $@" UPDATE tblUsers SET escrowlimit=(escrowlimit+1) WHERE (UserId='" + drv["UserId"].ToString() + "' and userrank<1)";

            //    //if (chckbx_contact.IsChecked == true)
            //    //{
            //    //    srQuery2 = $@" UPDATE tblEscrowBooks SET Contact=0  WHERE UserId='" + drv["UserId"].ToString() + "'";

            //    //}
            //    //else srQuery2 = $@" UPDATE tblEscrowBooks SET Contact=1  WHERE UserId='" + drv["UserId"].ToString() + "'";

            //    Dbaseconnection.updateDeleteInsert(srQuery0);
            //    Dbaseconnection.updateDeleteInsert(srQuery1);

            //    Dbaseconnection.updateDeleteInsert(srQuery2);
            //    cleartxtbox();





            //}

        }
    }
}
