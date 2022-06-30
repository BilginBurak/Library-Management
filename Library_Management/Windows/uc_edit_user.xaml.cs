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
    /// Interaction logic for uc_edit_user.xaml
    /// </summary>
    public partial class uc_edit_user : UserControl
    {
        public uc_edit_user()
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
                cmbbx_userrank.Items.Add("Teacher (Not Verify)");
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

            }
            refreshdatagrid();
        }


        private void clearall()
        {
            txtbx_search.Text = "";
            email_txtbx.Text = "";
            phone_txtbx.Text = "";
            username_txtbx.Text = "";
            namesurname_txtbx.Text = "";
            escrowlimit_txtbx.Text = "";
            cmbbx_userrank.SelectedIndex = -1;
            refreshdatagrid();
        }
        private void refreshdatagrid()
        {
            string srQuery;
            srQuery = $@"SELECT  * FROM tblUsers WHERE (NameSurname LIKE'%" + txtbx_search.Text + "%'  OR UserName LIKE'%" + txtbx_search.Text + "%'  OR Email LIKE'%" + txtbx_search.Text + "%'  OR Phone LIKE'%" + txtbx_search.Text + "%') ORDER BY UserId";
            //srQuery = $@" SELECT * FROM tblUsers ORDER BY UserId");
            DataTable dtData = Dbaseconnection.selectTable(srQuery);
            DataView dvData = new DataView(dtData);
            datagrd_edituser.ItemsSource = dvData;
            result_lbl.Content = "Total " + Convert.ToInt32(datagrd_edituser.Items.Count) + " result found";

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            clearall();
        }

        private void datagrd_teacherconfirm_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (datagrd_edituser.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_edituser.SelectedItem as DataRowView;
                namesurname_txtbx.Text = drv["NameSurname"].ToString();
                email_txtbx.Text = drv["Email"].ToString();
                username_txtbx.Text = drv["UserName"].ToString();
                phone_txtbx.Text = drv["Phone"].ToString();
                escrowlimit_txtbx.Text = drv["escrowlimit"].ToString();
                if (drv["UserRank"].ToString() == "1") cmbbx_userrank.SelectedIndex = 1;
                else if (drv["UserRank"].ToString() == "0") cmbbx_userrank.SelectedIndex = 0;
                else if (drv["UserRank"].ToString() == "2") cmbbx_userrank.SelectedIndex = 2;
                else cmbbx_userrank.SelectedIndex = 3;
            }

            //refreshdatagrid();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (datagrd_edituser.SelectedIndex > -1)
            {

                    DataRowView drv = datagrd_edituser.SelectedItem as DataRowView;
                var vrResult = PublicMethods.checkUserName(username_txtbx.Text);

                if (username_txtbx.Text != "")
                {
                    if (username_txtbx.Text != drv["UserName"].ToString())
                    {
                        vrResult = PublicMethods.checkUserName(username_txtbx.Text);
                        if (vrResult.blResult == false)
                        {
                            MessageBox.Show("Error: " + vrResult.srMsg);
                            return;
                        }
                    }

                    if (email_txtbx.Text != drv["Email"].ToString())
                    {

                        vrResult = PublicMethods.checkEmail(email_txtbx.Text);
                        if (vrResult.blResult == false)
                        {
                            MessageBox.Show("Error: " + vrResult.srMsg);
                            return;
                        }
                    }

                    MessageBoxResult result = MessageBox.Show("Are you sure? This user's information will have changed", "Sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

                    if (result == MessageBoxResult.Yes)
                    {
                        int userrank = 0;
                        if (cmbbx_userrank.SelectedIndex == 0) userrank = 0;
                        else if (cmbbx_userrank.SelectedIndex == 1) userrank = 1;
                        else if (cmbbx_userrank.SelectedIndex == 2) userrank = 2;
                        else userrank = -1;
                        string srQuery2;

                        srQuery2 = $@" UPDATE tblUsers SET UserName='" + username_txtbx.Text + "', UserRank='" + userrank + "', Email='" + email_txtbx.Text + "', Phone='" + phone_txtbx.Text + "', NameSurname='" + namesurname_txtbx.Text + "', EscrowLimit='"+ escrowlimit_txtbx.Text +"'        WHERE UserId='" + drv["UserId"].ToString() + "'";
                        Dbaseconnection.updateDeleteInsert(srQuery2);

                        
                    }
                    clearall(); 
            
                }
 
            }
            else MessageBox.Show("Please select a user");
        }
    }
}
