using Library_Management.Classes;
using Library_Management.UserController;
using Library_Management.Windows;
using Library_Management;
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
using System.Timers;
using System.Data;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for adminMainWindow.xaml
    /// </summary>
    public partial class adminMainWindow : Window
    {
        public adminMainWindow()
        {
            InitializeComponent();
        }

        private void Admin_control_panel_Loaded(object sender, RoutedEventArgs e)
        {
            Random randomforactive = new();
            int rndact = randomforactive.Next(10, 80);
            actLbl.Content = rndact.ToString();
        

            refreshifo();

        }
       
        private void refreshifo()
        {
            int totalbook = Convert.ToInt32(Dbaseconnection.selectTable("select Sum(AmountofStock) from tblBooks").Rows[0][0].ToString());
            int borrowedbooksnumber = Convert.ToInt32(Dbaseconnection.selectTable("select COUNT (userıd) from tblEscrowbooks").Rows[0][0].ToString());
            brwLbl.Content = borrowedbooksnumber;
            ttlLbl1.Content = totalbook;

        }

        private void bookListBtn_Click(object sender, RoutedEventArgs e)
        {
            bookListBtn.Background = new SolidColorBrush(Color.FromRgb(38, 126, 166));
            userManagementBtninMain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            escrowManagementBtninMain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            extrabtn1inmain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            extrabtn2inmain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            //AddUserClassw(ContentGrd, new Library_Management.UserController.ucStudentSearch());
            
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


        private void userManagementBtninMain_Click(object sender, RoutedEventArgs e)
        {
            userManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(38, 126, 166));
            bookListBtn.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            escrowManagementBtninMain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            extrabtn1inmain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            extrabtn2inmain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            bookListBtn.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            refreshifo();
        }

        private void escrowManagementBtninMain_Click(object sender, RoutedEventArgs e)
        {
            escrowManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(38, 126, 166));
            bookListBtn.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            userManagementBtninMain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            extrabtn1inmain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            extrabtn2inmain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            refreshifo();
        }

        private void extrabtn1inmain_Click(object sender, RoutedEventArgs e)
        {
            extrabtn1inmain.Background = new SolidColorBrush(Color.FromRgb(38, 126, 166));
            bookListBtn.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            userManagementBtninMain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            escrowManagementBtninMain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            extrabtn2inmain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            refreshifo();
        }

        private void extrabtn2inmain_Click(object sender, RoutedEventArgs e)
        {
            extrabtn2inmain.Background = new SolidColorBrush(Color.FromRgb(38, 126, 166));
            bookListBtn.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            userManagementBtninMain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            escrowManagementBtninMain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            extrabtn1inmain.Background = new SolidColorBrush(Color.FromArgb(50, 144, 193, 190));
            refreshifo();
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
            AddUserClassw(teacherconfirmgrd, new Library_Management.Windows.uc_teacher_confirmation());
        }


        private void Add_New_User_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(addusergrd, new Library_Management.Windows.uc_user_add()); refreshifo();
        }

        private void tab_user_edit_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(editusergrd, new Library_Management.Windows.uc_edit_user()); refreshifo();
        }

        private void tabitem_deleteuser_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(deleteusergrd, new Library_Management.Windows.uc_clear_user()); refreshifo();
        }

        private void tabitem_add_book_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(addbookgrd, new Library_Management.Windows.uc_book_add()); refreshifo();
        }

        private void tab_edit_book_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(editbookgrd, new Library_Management.Windows.uc_edit_book()); refreshifo();
        } 

        private void tab_delete_book_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(clearbookgrd, new Library_Management.Windows.uc_clear_book()); refreshifo();
        }

        private void tabitem_overduebooks_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(overduegrd, new Library_Management.Windows.uc_overdue_books()); refreshifo();

        }

        private void tab_LendBook_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(lendbookgrd, new Library_Management.Windows.uc_lend_book()); refreshifo();
        }

        private void tab_Returnbook_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(returnbookgrd, new Library_Management.Windows.uc_return_book()); refreshifo();
        }

        private void settingsgrd_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(settingsgrd, new Library_Management.Windows.uc_settings()); refreshifo();

        }

        

        private void tab_logout_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tab_welcome.Focus();
            MessageBoxResult result = MessageBox.Show("Log Out?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                LoginWindow loginWindow = new LoginWindow();
                this.Close();
                loginWindow.Show();
            }
        }

        private void tab_returnconf_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(returnconfgrd, new Library_Management.Windows.uc_return_confirm()); refreshifo();

        }
        private void tab_deletedbook_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(deletedbooksgrd, new Library_Management.Windows.uc_deleted_book()); refreshifo();

        }
    }
}
