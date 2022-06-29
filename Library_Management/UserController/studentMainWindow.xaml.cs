using Library_Management.Classes;
using Library_Management.UserController;
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

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for studentMainWindow.xaml
    /// </summary>
    public partial class studentMainWindow : Window
    {
        public studentMainWindow()
        {
            InitializeComponent();
        }

        private void Student_control_panel_Loaded(object sender, RoutedEventArgs e)
        {
            Random randomforactive = new();
            int rndact = randomforactive.Next(10, 80);
            actLbl.Content = "Number of active users in the system: " + rndact.ToString()+ "";
            Dbaseconnection.DbConTest();
            Dbopening.Content = Dbaseconnection.DbConState;
            lblforteacher.Content = PublicMethods.loggedUserName;
            if (PublicMethods.loggedUserRank == "-1") 
            {
                
                var uriSource = new Uri("C:/Users/Burak/Desktop/Kutuphane/Library_Management/Library_Management/teacher.png");
                profilphoto.Source = new BitmapImage(uriSource);
            } 
        
            int totalbook = Convert.ToInt32(Dbaseconnection.selectTable("select Sum(AmountofStock) from tblBooks").Rows[0][0].ToString());
            int borrowedbooksnumber = Convert.ToInt32(Dbaseconnection.selectTable("select COUNT(AmountofStock) from tblBooks where AmountofStock LIKE '0%'").Rows[0][0].ToString());
            brwLbl.Content ="Total Borrowed Books in Library:  " + borrowedbooksnumber+ "";
            ttlLbl1.Content = "Total Books in Library:  " + totalbook+ "";
            int outdatebook = Convert.ToInt32(Dbaseconnection.selectTable("select COUNT (escrowıd) from tblEscrowbooks where (username= '" + PublicMethods.loggedUserName + "' and deadline<GETDATE())").Rows[0][0].ToString()); 
            if (outdatebook > 0) MessageBox.Show("You have expired books, please return the books as soon as possible!", "Overdue Book Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
        }



        private void Teacher_control_panel_Loaded(object sender, RoutedEventArgs e)
        {
            Random randomforactive = new();
            int rndact = randomforactive.Next(10, 80);
            actLbl.Content = rndact.ToString();
            Dbaseconnection.DbConTest();
            Dbopening.Content = Dbaseconnection.DbConState;
            refreshifo();




        }

        private void refreshifo()
        {
            int totalbook = Convert.ToInt32(Dbaseconnection.selectTable("select Sum(AmountofStock) from tblBooks").Rows[0][0].ToString());
            int borrowedbooksnumber = Convert.ToInt32(Dbaseconnection.selectTable("select COUNT (userıd) from tblEscrowbooks").Rows[0][0].ToString());
            brwLbl.Content = "Total Borrowed Books in Library: " + borrowedbooksnumber + "";
            ttlLbl1.Content = "Total Books in Library: " + totalbook + "";

        }




        public static void AddUserClassw(Grid grd, UserControl uc)
        {
            if (grd.Children.Count > 0)
            {
                grd.Children.Clear();
                grd.Children.Add(uc);
            }
            else { grd.Children.Add(uc); }
        }








        private void searchicondckpnl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.ShowDialog();
            refreshifo();
        }



        private void tabitem_userconfirm_Loaded(object sender, RoutedEventArgs e)
        {

            refreshifo();
            //AddUserClassw(teacherconfirmgrd, new Library_Management.Windows.uc_teacher_confirmation());
        }


        private void Add_New_User_Loaded(object sender, RoutedEventArgs e)
        {
            //AddUserClassw(addusergrd, new Library_Management.Windows.uc_user_add()); refreshifo();
        }

        private void tab_user_edit_Loaded(object sender, RoutedEventArgs e)
        {
            // AddUserClassw(editusergrd, new Library_Management.Windows.uc_edit_user()); refreshifo();
        }

        private void tabitem_deleteuser_Loaded(object sender, RoutedEventArgs e)
        {
            // AddUserClassw(deleteusergrd, new Library_Management.Windows.uc_clear_user()); refreshifo();
        }

        private void tabitem_add_book_Loaded(object sender, RoutedEventArgs e)
        {
            //AddUserClassw(addbookgrd, new Library_Management.Windows.uc_book_add()); refreshifo();
        }

        private void tab_edit_book_Loaded(object sender, RoutedEventArgs e)
        {
            //AddUserClassw(editbookgrd, new Library_Management.Windows.uc_edit_book()); refreshifo();
        }

        private void tab_delete_book_Loaded(object sender, RoutedEventArgs e)
        {
            //AddUserClassw(clearbookgrd, new Library_Management.Windows.uc_clear_book()); refreshifo();
        }

        private void tabitem_overduebooks_Loaded(object sender, RoutedEventArgs e)
        {
            //AddUserClassw(overduegrd, new Library_Management.Windows.uc_overdue_books()); refreshifo();

        }

        private void tab_LendBook_Loaded(object sender, RoutedEventArgs e)
        {
            //AddUserClassw(lendbookgrd, new Library_Management.Windows.uc_lend_book()); refreshifo();
        }

        private void tab_Returnbook_Loaded(object sender, RoutedEventArgs e)
        {
            //AddUserClassw(returnbookgrd, new Library_Management.Windows.uc_return_book()); refreshifo();
        }

        private void tab_borrowbooks_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(borrowbooksgrd, new Library_Management.Windows.uc_borrow_book()); refreshifo();
        }

        private void tab_Returnbookstudent_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(Returnbookstudentgrd, new Library_Management.Windows.uc_student_return_book()); refreshifo();
        }

        private void outofdate_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(outofdatestudentgrd, new Library_Management.Windows.uc_student_outofdate_book()); refreshifo();
        }
        private void tab_logout_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tab_welcome.Focus();
            MessageBoxResult result = MessageBox.Show("Log Out?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }


        private void tab_welcome_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(welcomegrd, new Library_Management.Windows.uc_welcome_student()); refreshifo();

        }
    }
}
