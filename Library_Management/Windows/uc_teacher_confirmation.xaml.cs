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
    /// Interaction logic for uc_teacher_confirmation.xaml
    /// </summary>
    public partial class uc_teacher_confirmation : UserControl
    {
        public uc_teacher_confirmation()
        {
            InitializeComponent();
        }


        private void refreshdatagrid()
        {
            string srQuery;

            srQuery = $@"SELECT  * FROM tblUsers WHERE (NameSurname LIKE'%" + txtbx_search.Text + "%'  OR UserName LIKE'%" + txtbx_search.Text + "%'  OR Email LIKE'%" + txtbx_search.Text + "%'  OR Phone LIKE'%" + txtbx_search.Text + "%') AND UserRank='-1' ORDER BY UserId";
            DataTable dtData = Dbaseconnection.selectTable(srQuery);
            DataView dvData = new DataView(dtData);
            datagrd_teacherconfirm.ItemsSource = dvData;

        }

        private void clearall()
        {
            txtbx_search.Text = "";
            email_txtbx.Text = "";
            phone_txtbx.Text = "";
            username_txtbx.Text = "";
            namesurname_txtbx.Text = "";
            
            refreshdatagrid();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            clearall();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (datagrd_teacherconfirm.SelectedIndex > -1)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure? This user will be promoted to teacher level", "Sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    string srQuery2;

                    srQuery2 = $@" UPDATE tblUsers SET UserRank='1' WHERE UserName='" + username_txtbx.Text + "'";
                    Dbaseconnection.updateDeleteInsert(srQuery2);
                }
                clearall();

            }
            else MessageBox.Show("Please select a user");
        }


        private void datagrd_teacherconfirm_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (datagrd_teacherconfirm.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_teacherconfirm.SelectedItem as DataRowView;
                namesurname_txtbx.Text = drv["NameSurname"].ToString();
                email_txtbx.Text = drv["Email"].ToString();
                username_txtbx.Text = drv["UserName"].ToString();
                phone_txtbx.Text = drv["Phone"].ToString();
            }

            //refreshdatagrid();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
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
    }
}
