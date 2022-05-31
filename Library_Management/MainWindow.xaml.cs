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
using System.Timers;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            
            
        }

        private void main_window_Loaded(object sender, RoutedEventArgs e)
        {

            Random randomforactive = new();
            int rndact = randomforactive.Next(10, 80);
            actLbl.Content = rndact.ToString();
            Dbaseconnection.DbConTest();
            Dbopening.Content = Dbaseconnection.DbConState;

        }

        private void bookListBtn_Click(object sender, RoutedEventArgs e)
        {
            CallUserClss.AddUserClass(ContentGrd,new UserController.ucBookList());

            bookListBtn.Background = new SolidColorBrush(Color.FromRgb(38, 126, 166));
            userManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            escrowManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            extrabtn1inmain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            extrabtn2inmain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
        }
        
        private void userManagementBtninMain_Click(object sender, RoutedEventArgs e)
        {
            userManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(38, 126, 166));
            bookListBtn.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            escrowManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            extrabtn1inmain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            extrabtn2inmain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            
        }

        private void escrowManagementBtninMain_Click(object sender, RoutedEventArgs e)
        {
            escrowManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(38, 126, 166));
            bookListBtn.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            userManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            extrabtn1inmain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            extrabtn2inmain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
        }

        private void extrabtn1inmain_Click(object sender, RoutedEventArgs e)
        {
            extrabtn1inmain.Background = new SolidColorBrush(Color.FromRgb(38, 126, 166));
            bookListBtn.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            userManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            escrowManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190)); 
            extrabtn2inmain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
        }

        private void extrabtn2inmain_Click(object sender, RoutedEventArgs e)
        {
            extrabtn2inmain.Background = new SolidColorBrush(Color.FromRgb(38, 126, 166));
            bookListBtn.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            userManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            escrowManagementBtninMain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
            extrabtn1inmain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 190));
           
        }
    }

  


    
}
