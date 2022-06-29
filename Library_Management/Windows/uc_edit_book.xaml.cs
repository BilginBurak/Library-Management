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
    /// Interaction logic for uc_edit_book.xaml
    /// </summary>
    public partial class uc_edit_book : UserControl
    {
        public uc_edit_book()
        {
            InitializeComponent();
        }

        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            refreshdatagrid();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbx_search1.Text == "")
            {
                lbl_textbx.Visibility = Visibility.Visible;
            }
            else
            {
                lbl_textbx.Visibility = Visibility.Hidden;

            }
            refreshdatagrid();
            //total_lbl.Content = "total " + Convert.ToInt32(datagrd_editBook.Items.Count) + " result found";
        }



        private void refreshdatagrid()
        {
            string srQuery;
            srQuery = $@"SELECT  *  FROM tblBooks  WHERE (BookName LIKE'%" + txtbx_search1.Text + "%'  OR Author LIKE'%" + txtbx_search1.Text + "%' OR BookID LIKE'%" + txtbx_search1.Text + "%') ORDER BY BookID";
            //srQuery = $@" SELECT * FROM tblUsers ORDER BY UserId");
            DataTable dtData = Dbaseconnection.selectTable(srQuery);
            DataView dvData = new DataView(dtData);
            datagrd_editBook.ItemsSource = dvData;
            total_lbl.Content = "Total " + Convert.ToInt32(datagrd_editBook.Items.Count) + " result found";

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtbx_search1.Text = "";
            booktitle_txtbx.Text = "";
            author_txtbx.Text = "";
            genre_txtbx.Text = "";
            publisher_txtbx.Text = "";
            stock_txtbx.Text = "";
            
            refreshdatagrid();
        }

        private void datagrd_teacherconfirm_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (datagrd_editBook.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_editBook.SelectedItem as DataRowView;
                booktitle_txtbx.Text = drv["BookName"].ToString();
                author_txtbx.Text = drv["Author"].ToString();
                genre_txtbx.Text = drv["Genre"].ToString();
                publisher_txtbx.Text = drv["Publisher"].ToString();
                stock_txtbx.Text = drv["AmountofStock"].ToString();
                
            }

            //refreshdatagrid();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = datagrd_editBook.SelectedItem as DataRowView;
            var vrResult = PublicMethods.checkBookTitle(booktitle_txtbx.Text);

            if (datagrd_editBook.SelectedIndex > -1)
            {
                if (booktitle_txtbx.Text != "")
                {
                    if (booktitle_txtbx.Text != drv["BookName"].ToString())
                    {
                        vrResult = PublicMethods.checkBookTitle(booktitle_txtbx.Text);
                        if (vrResult.blResult == false)
                        {
                            MessageBox.Show("Error: " + vrResult.srMsg);
                            return;
                        }
                    }



                    MessageBoxResult result = MessageBox.Show("Are you sure? This Books's information will have changed", "Sure?", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

                    if (result == MessageBoxResult.Yes)
                    {

                        string srQuery2;

                        srQuery2 = $@" UPDATE tblBooks SET BookName='" + booktitle_txtbx.Text + "', Author='" + author_txtbx.Text + "', Genre='" + genre_txtbx.Text + "', Publisher='" + publisher_txtbx.Text + "', AmountofStock='" + stock_txtbx.Text + "'        WHERE BookID='" + drv["BookID"].ToString() + "'";
                        Dbaseconnection.updateDeleteInsert(srQuery2);

                        txtbx_search1.Text = "";
                        booktitle_txtbx.Text = "";
                        author_txtbx.Text = "";
                        genre_txtbx.Text = "";
                        publisher_txtbx.Text = "";
                        stock_txtbx.Text = "";
                    }
                    refreshdatagrid();

                }
                
            
            }
            else MessageBox.Show("Please select a book");
        }
    }
}
