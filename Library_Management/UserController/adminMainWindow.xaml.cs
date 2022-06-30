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
             
        }

       

        private void tabitem_userconfirm_Loaded(object sender, RoutedEventArgs e)
        {

            
            AddUserClassw(teacherconfirmgrd, new Library_Management.Windows.uc_teacher_confirmation());
        }


        private void Add_New_User_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(addusergrd, new Library_Management.Windows.uc_user_add());  
        }

        private void tab_user_edit_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(editusergrd, new Library_Management.Windows.uc_edit_user());  
        }

        private void tabitem_deleteuser_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(deleteusergrd, new Library_Management.Windows.uc_clear_user());  
        }

        private void tabitem_add_book_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(addbookgrd, new Library_Management.Windows.uc_book_add());  
        }

        private void tab_edit_book_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(editbookgrd, new Library_Management.Windows.uc_edit_book());  
        } 

        private void tab_delete_book_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(clearbookgrd, new Library_Management.Windows.uc_clear_book());  
        }

        private void tabitem_overduebooks_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(overduegrd, new Library_Management.Windows.uc_overdue_books());  

        }

        private void tab_LendBook_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(lendbookgrd, new Library_Management.Windows.uc_lend_book());  
        }

        private void tab_Returnbook_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(returnbookgrd, new Library_Management.Windows.uc_return_book());  
        }

        private void settingsgrd_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(settingsgrd, new Library_Management.Windows.uc_settings());  

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
            AddUserClassw(returnconfgrd, new Library_Management.Windows.uc_return_confirm());  

        }
        private void tab_deletedbook_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(deletedbooksgrd, new Library_Management.Windows.uc_deleted_book());  

        }

        private void tab_welcome_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserClassw(welcomegrd, new Library_Management.Windows.uc_welcome_admin());  

        }
    }
}
