﻿using Library_Management.Classes;
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
    /// Interaction logic for uc_deleted_book.xaml
    /// </summary>
    public partial class uc_deleted_book : UserControl
    {
        public uc_deleted_book()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            refreshdatagrid();
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



        private void refreshdatagrid()
        {
            string srQuery;
            srQuery = $@"SELECT  * FROM tbldeletedBooks  WHERE (BookName LIKE'%" + txtbx_search.Text + "%'  OR Author LIKE'%" + txtbx_search.Text + "%' OR BookID LIKE'%" + txtbx_search.Text + "%') ORDER BY BookID";
            DataTable dtData = Dbaseconnection.selectTable(srQuery);
            DataView dvData = new DataView(dtData);
            datagrd_clearBook.ItemsSource = dvData;
            total_lbl.Content = "Total " + Convert.ToInt32(datagrd_clearBook.Items.Count) + " result found";

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtbx_search.Text = "";
            booktitle_txtbx.Text = "";
            author_txtbx.Text = "";
            genre_txtbx.Text = "";
            publisher_txtbx.Text = "";
            stock_txtbx.Text = "";

            refreshdatagrid();
        }

        private void datagrd_teacherconfirm_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (datagrd_clearBook.SelectedIndex > -1)
            {

                DataRowView drv = datagrd_clearBook.SelectedItem as DataRowView;
                booktitle_txtbx.Text = drv["BookName"].ToString();
                author_txtbx.Text = drv["Author"].ToString();
                genre_txtbx.Text = drv["Genre"].ToString();
                publisher_txtbx.Text = drv["Publisher"].ToString();
                stock_txtbx.Text = drv["DeletionDate"].ToString();
                comment_txtbx.Text = drv["Comment"].ToString();
            }

            //refreshdatagrid();
        }
    }
}
