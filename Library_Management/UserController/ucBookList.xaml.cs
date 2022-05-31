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

namespace Library_Management.UserController
{
    /// <summary>
    /// Interaction logic for ucBookList.xaml
    /// </summary>
    public partial class ucBookList : UserControl
    {
        public ucBookList()
        {
            InitializeComponent();
        }

        

        private void addBookBtn_Click(object sender, RoutedEventArgs e)
        {
            bookAddWindow bookAddPg = new bookAddWindow();
            bookAddPg.ShowDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CallfromDataBase.fillGridfromDatabase(bookList_dataGrid);
        }
    }
}
