using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Library_Management.UserController;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            {
                //adminMainWindow adminMainWindow = new adminMainWindow();
                //adminMainWindow.Show();

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                //SearchWindow searchWindow = new SearchWindow();
                //searchWindow.ShowDialog();

                //teacherMainWindow teacherMainWindow = new teacherMainWindow();
                //teacherMainWindow.Show();
            }
        }
    }
}
