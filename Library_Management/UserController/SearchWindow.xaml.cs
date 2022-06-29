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
using System.Windows.Shapes;

namespace Library_Management.UserController
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
        }

        private void SearchingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //CallfromDataBase.fillGridfromDatabase(datagrdforsaerchscreen);
            //cmbbx_searchwindow.Items.Add("Book Title");
            //cmbbx_searchwindow.Items.Add("Author");
            //cmbbx_searchwindow.Items.Add("Genre");

            if (PublicMethods.loggedUserRank == "1" || PublicMethods.loggedUserRank == "2")
            {
                AddUserClassw(searchwindowgrid, new Library_Management.UserController.ucAdminandTeacherSearch());

            }

            if (PublicMethods.loggedUserRank == "0" || PublicMethods.loggedUserRank == "-1")
            {
                AddUserClassw(searchwindowgrid, new Library_Management.UserController.ucStudentSearch());
            }
            
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


    
      
    }
}
