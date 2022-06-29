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
    /// Interaction logic for uc_return_confirm.xaml
    /// </summary>
    public partial class uc_return_confirm : UserControl
    {
        public uc_return_confirm()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            refreshdatagrid();
        }


        private void refreshdatagrid()
        {
            string srQuery;
            //srQuery = $@"SELECT  * FROM tblEscrowBooks  WHERE (NameSurname LIKE'%" + txtbx_search.Text + "%' OR BookName LIKE'%" + txtbx_search.Text + "%'  OR Author LIKE'%" + txtbx_search.Text + "%' OR Phone LIKE'%" + txtbx_search.Text + "%' ) ORDER BY UserId";

            srQuery = $@"SELECT  * FROM tblnotverified  WHERE ((NameSurname LIKE'%" + txtbx_search.Text + "%' OR BookName LIKE'%" + txtbx_search.Text + "%'  OR Author LIKE'%" + txtbx_search.Text + "%' OR Phone LIKE'%" + txtbx_search.Text + "%' )) ORDER BY EscrowID";


            //srQuery = $@" SELECT * FROM tblEscrowBooks ORDER BY UserId";
            DataTable dtData = Dbaseconnection.selectTable(srQuery);
            DataView dvData = new DataView(dtData);
            datagrd_duedatebook.ItemsSource = dvData;
            total_lbl.Content = "Total " + Convert.ToInt32(datagrd_duedatebook.Items.Count) + " result found";

        }
        private void cleartxtboks()
        {
            name_surname_txtbx.Text = "";
            author_txtbx.Text = "";
            booktitle_txtbx1.Text = "";
            phone_txtbx.Text = "";
            duedate_txtbx.Text = "";
            txtbx_search.Text = "";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            cleartxtboks();
            //txtbx_search.Text = "";
            //booktitle_txtbx1.Text = "";
            //author_txtbx.Text = "";
            //name_surname_txtbx.Text = "";
            //phone_txtbx.Text = "";
            //duedate_txtbx.Text = "";
            //chckbx_contact.IsChecked = false;
            refreshdatagrid();

        }

        private void txtbx_search_TextChanged(object sender, TextChangedEventArgs e)
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

        private void datagrd_duedatebook_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (datagrd_duedatebook.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_duedatebook.SelectedItem as DataRowView;
                name_surname_txtbx.Text = drv["NameSurname"].ToString();
                author_txtbx.Text = drv["Author"].ToString();
                phone_txtbx.Text = drv["Phone"].ToString();
                duedate_txtbx.Text = drv["Deadline"].ToString();
                booktitle_txtbx1.Text = drv["BookName"].ToString();
              

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (datagrd_duedatebook.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_duedatebook.SelectedItem as DataRowView;

                string srQuery0, srQuery1,srQuery2 = "", srQuery3;
                srQuery0 = $@" UPDATE tblUsers SET escrowlimit=(escrowlimit+1) WHERE (UserId='" + drv["UserId"].ToString() + "' and userrank<1)";
                srQuery1 = $@" UPDATE tblBooks SET AmountofStock=(AmountofStock+1) WHERE BookId='" + drv["BookId"].ToString() + "'";
                srQuery2 = $@" delete from tblescrowbooks where (EscrowID= '" + drv["EscrowID"].ToString() + "')";
                
                srQuery3 = $@" delete from tblNotVerified where (EscrowID= '" + drv["EscrowID"].ToString() + "')";


                Dbaseconnection.updateDeleteInsert(srQuery0); Dbaseconnection.updateDeleteInsert(srQuery1);
                Dbaseconnection.updateDeleteInsert(srQuery2); Dbaseconnection.updateDeleteInsert(srQuery3);
                MessageBox.Show("Book return confirmed");
                cleartxtboks();
                refreshdatagrid();



            }
            else MessageBox.Show("Please select a user");
        }


    }
}
