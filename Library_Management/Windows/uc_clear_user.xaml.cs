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
    /// Interaction logic for uc_clear_user.xaml
    /// </summary>
    public partial class uc_clear_user : UserControl
    {
        public uc_clear_user()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (cmbbx_userrank.Items.Count == 0)
            {
                cmbbx_userrank.Items.Add("Student");
                cmbbx_userrank.Items.Add("Teacher");
                cmbbx_userrank.Items.Add("Admin");
            }

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
                refreshdatagrid();
            }
        }

        private void clearall()
        {
            txtbx_search.Text = "";
            email_txtbx.Text = "";
            phone_txtbx.Text = "";
            username_txtbx.Text = "";
            namesurname_txtbx.Text = "";
            cmbbx_userrank.SelectedIndex = -1;
            refreshdatagrid();
        }

        private void refreshdatagrid()
        {
            string srQuery;
            srQuery = $@"SELECT  * FROM tblUsers WHERE (NameSurname LIKE'%" + txtbx_search.Text + "%'  OR UserName LIKE'%" + txtbx_search.Text + "%'  OR Email LIKE'%" + txtbx_search.Text + "%'  OR Phone LIKE'%" + txtbx_search.Text + "%') ORDER BY UserId";
            DataTable dtData = Dbaseconnection.selectTable(srQuery);
            DataView dvData = new DataView(dtData);
            datagrd_clearuser.ItemsSource = dvData;
            result_lbl.Content = "Total " + Convert.ToInt32(datagrd_clearuser.Items.Count) + " result found";

        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            clearall();
        }

        private void datagrd_teacherconfirm_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (datagrd_clearuser.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_clearuser.SelectedItem as DataRowView;
                namesurname_txtbx.Text = drv["NameSurname"].ToString();
                email_txtbx.Text = drv["Email"].ToString();
                username_txtbx.Text = drv["UserName"].ToString();
                phone_txtbx.Text = drv["Phone"].ToString();
                if (drv["UserRank"].ToString() == "-1" || drv["UserRank"].ToString() == "1") cmbbx_userrank.SelectedIndex = 1;
                else if (drv["UserRank"].ToString() == "0") cmbbx_userrank.SelectedIndex = 0;
                else if (drv["UserRank"].ToString() == "2") cmbbx_userrank.SelectedIndex = 2;
            }

            //refreshdatagrid();
        }

        private void btnclearuser_Click(object sender, RoutedEventArgs e)
        {
            if (datagrd_clearuser.SelectedIndex > -1)
            {
                DataRowView drv = datagrd_clearuser.SelectedItem as DataRowView;

                MessageBoxResult result = MessageBox.Show("Are you sure? This User will be DELETED", "Sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

                if (result == MessageBoxResult.Yes)
                {
                    string srQuery2 = $@" DELETE FROM tblBooks WHERE BookID='" + drv["BookID"].ToString() + "'";
                    Dbaseconnection.updateDeleteInsert(srQuery2);

                    

                }
                clearall();
            }
            else MessageBox.Show("Please select a user");
        }


    }
}
