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
    /// Interaction logic for uc_overdue_books.xaml
    /// </summary>
    public partial class uc_overdue_books : UserControl
    {
        public uc_overdue_books()
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

            srQuery = $@"SELECT  * FROM tblEscrowBooks  WHERE ((NameSurname LIKE'%" + txtbx_search.Text + "%' OR BookName LIKE'%" + txtbx_search.Text + "%'  OR Author LIKE'%" + txtbx_search.Text + "%' OR Phone LIKE'%" + txtbx_search.Text + "%' ) AND Deadline<GETDATE()) ORDER BY UserId";


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
            chckbx_contact.IsChecked = false;
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
                chckbx_contact.IsChecked = Convert.ToBoolean(drv["Contact"]);


                if (chckbx_contact.IsChecked == true) btnEdit.Content = "Revoke";
                else btnEdit.Content = "Contact";

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (datagrd_duedatebook.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_duedatebook.SelectedItem as DataRowView;

                string srQuery2;
                if (chckbx_contact.IsChecked == true)
                {
                    srQuery2 = $@" UPDATE tblEscrowBooks SET Contact=0  WHERE (UserId='" + drv["UserId"].ToString() + "' and BookId='" + drv["BookId"].ToString()+"')";
                    
                }
                else srQuery2 = $@" UPDATE tblEscrowBooks SET Contact=1  WHERE (UserId='" + drv["UserId"].ToString() + "' and BookId='" + drv["BookId"].ToString() + "')";



                Dbaseconnection.updateDeleteInsert(srQuery2);
                cleartxtboks();
                btnEdit.Content = "Contact";
                refreshdatagrid();
                


            }
            else MessageBox.Show("Please select a user");
        }
    
    }
}
