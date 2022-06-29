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
    /// Interaction logic for uc_return_book.xaml
    /// </summary>
    public partial class uc_return_book : UserControl
    {
        public uc_return_book()
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

            srQuery = $@"SELECT  * FROM tblEscrowBooks  WHERE (NameSurname LIKE'%" + txtbx_search.Text + "%' OR BookName LIKE'%" + txtbx_search.Text + "%'  OR Author LIKE'%" + txtbx_search.Text + "%' OR Phone LIKE'%" + txtbx_search.Text + "%' )  ORDER BY UserId";


            //srQuery = $@" SELECT * FROM tblEscrowBooks ORDER BY UserId";
            DataTable dtData = Dbaseconnection.selectTable(srQuery);
            DataView dvData = new DataView(dtData);
            datagrd_duedatebook.ItemsSource = dvData;
            total_lbl.Content = "Total " + Convert.ToInt32(datagrd_duedatebook.Items.Count) + " result found";

        }
        private void cleartxtbox()
        {
            name_surname_txtbx2.Text = "";
            booktitle_txtbx2.Text = "";
            txtbx_search.Text = "";
            refreshdatagrid();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            cleartxtbox();
            
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
                name_surname_txtbx2.Text = drv["NameSurname"].ToString();
                booktitle_txtbx2.Text = drv["BookName"].ToString();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (datagrd_duedatebook.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_duedatebook.SelectedItem as DataRowView;

                string srQuery2, srQuery1, srQuery0;
                srQuery0 = $@" delete from tblescrowbooks where (BookId= '"+ drv["BookId"].ToString() + "' and UserId='" + drv["UserId"].ToString() + "')";
                srQuery1 = $@" UPDATE tblBooks SET AmountofStock=(AmountofStock+1) WHERE BookId='" + drv["BookId"].ToString() + "'";
                
                srQuery2 = $@" UPDATE tblUsers SET escrowlimit=(escrowlimit+1) WHERE (UserId='" + drv["UserId"].ToString() + "' and userrank<1)";
                
               
                //if (chckbx_contact.IsChecked == true)
                //{
                //    srQuery2 = $@" UPDATE tblEscrowBooks SET Contact=0  WHERE UserId='" + drv["UserId"].ToString() + "'";

                //}
                //else srQuery2 = $@" UPDATE tblEscrowBooks SET Contact=1  WHERE UserId='" + drv["UserId"].ToString() + "'";

                Dbaseconnection.updateDeleteInsert(srQuery0);
                Dbaseconnection.updateDeleteInsert(srQuery1);

                Dbaseconnection.updateDeleteInsert(srQuery2);
                cleartxtbox();
                
               



            }
            else MessageBox.Show("Please select a user");
        }
    }
}
