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
    /// Interaction logic for uc_welcome_admin.xaml
    /// </summary>
    public partial class uc_welcome_admin : UserControl
    {
        public uc_welcome_admin()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            refreshlist();
        }

        private void refreshlist()
        {
            //string srQuery = $@"select Bookname,deadline from tblEscrowbooks where (username= '" + PublicMethods.loggedUserName + "' and deadline<GETDATE())";

            //DataTable dtData = Dbaseconnection.selectTable(srQuery);

            //DataView dvData = new DataView(dtData);
            //dtgrd.ItemsSource = dvData;
            //dtgrd.Columns[1].Header = "Book Title";
            //dtgrd.Columns[1].Width = 350;
            //dtgrd.Columns[2].Header = "Duedate";
            //dtgrd.Columns[2].Width = 90;

            //int outdatebook = Convert.ToInt32(Dbaseconnection.selectTable("select COUNT (escrowıd) from tblEscrowbooks where (username= '" + PublicMethods.loggedUserName + "' and deadline<GETDATE())").Rows[0][0].ToString());
            //if (outdatebook > 0) dtgrd.Visibility = Visibility.Visible;

            string srQuery1 = $@"select top 30 totalread,namesurname from tblusers order by totalread desc";
            //string srQuery = $@"select Bookname,date_format(deadline, '%d %m %y') from tblEscrowbooks where (username= '" + PublicMethods.loggedUserName + "' and deadline<GETDATE())";
            ////srQuery = $@" SELECT * FROM tblEscrowBooks ORDER BY UserId";  Dbaseconnection.selectTable(srQuery);
            DataTable dtData1 = Dbaseconnection.selectTable(srQuery1);
            DataView dvData1 = new DataView(dtData1);
            dtgrdtotalread.ItemsSource = dvData1;
            dtgrdtotalread.Columns[1].Header = "Name Surname";
            dtgrdtotalread.Columns[0].Header = "Total  ";

            int borrowedbooksnumber = Convert.ToInt32(Dbaseconnection.selectTable("select COUNT (userıd) from tblEscrowbooks").Rows[0][0].ToString());
            Random random = new Random();
            int totaluser = Convert.ToInt32(Dbaseconnection.selectTable("select count(userId) from tblUsers").Rows[0][0].ToString());
            int num = random.Next(1, totaluser);
            lbl_activeuser.Content = "There are currently " + num + " active users";

            lbl_totaluser.Content = "There are " + totaluser + " users registered in the system";

            lbl_totalbook.Content = "Instant total number of books " + Convert.ToInt32(Dbaseconnection.selectTable("select Sum(AmountofStock) from tblBooks").Rows[0][0].ToString());
            lbl_totalborrow.Content = "Total " + borrowedbooksnumber.ToString() + " books borrowed";


        }

    }
}
