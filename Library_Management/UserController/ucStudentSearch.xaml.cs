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
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using Library_Management.Classes;
using System.Data;
using System.Globalization;
using System.Threading;
using System.IO;

namespace Library_Management.UserController
{
    /// <summary>
    /// Interaction logic for ucStudentSearch.xaml
    /// </summary>
    public partial class ucStudentSearch : UserControl
    {
        public ucStudentSearch()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbbxshowitemselector.SelectedIndex = 1;
            //fillGridfromDatabase(booklistdtgrd);
            //comboboxslector();
            booklistdtgrd.Visibility = Visibility.Visible;
            //refreshDataGriduser();
            cmbbxforsearchscreen.Items.Add("Book Name");
            cmbbxforsearchscreen.Items.Add("Author");
            cmbbxforsearchscreen.Items.Add("Genre");
            chckbx_notbook.Visibility = Visibility.Visible;
            total_lbl.Content = "Total " + Convert.ToInt32(booklistdtgrd.Items.Count) + " result found";

        }
        public void comboboxselector()
        {

            if (cmbbxshowitemselector.SelectedIndex == 0) irPageSize = 25;
            if (cmbbxshowitemselector.SelectedIndex == 1) irPageSize = 50;
            if (cmbbxshowitemselector.SelectedIndex == 2) irPageSize = 75;
            if (cmbbxshowitemselector.SelectedIndex == 3) irPageSize = 100;
            if (cmbbxshowitemselector.SelectedIndex == 4) irPageSize = 200;

        }



        int irPageSize = 1;

        int irCountOfPages;

        int irPrevPageNumber, irNextPageNumber;


        //private void refreshDataGriduser()
        //{


        //    comboboxselector();

        //    int irSelectedIndex = cmbbxforskippage.SelectedIndex;

        //    int irRecordcount = Convert.ToInt32(Dbaseconnection.selectTable("select COUNT (*) from tblStudents").Rows[0][0].ToString());

        //    irCountOfPages = irRecordcount / irPageSize + 1;

        //    cmbbxforskippage.Items.Clear();
        //    for (int i = 1; i < irCountOfPages + 1; i++)
        //    {
        //        cmbbxforskippage.Items.Add(i);
        //    }
        //    cmbbxforskippage.SelectedIndex = irSelectedIndex;
        //    int irCurrentRecordPage = irSelectedIndex + 1;

        //    if (irCurrentRecordPage < 1)
        //        irCurrentRecordPage = 1;

        //    irPrevPageNumber = ((irCurrentRecordPage < 2) ? irCountOfPages : irCurrentRecordPage - 1);

        //    irNextPageNumber = ((irCurrentRecordPage == irCountOfPages) ? 1 : irCurrentRecordPage + 1);

        //    //previouspagebtn.Content = "Goto Page: " + irPrevPageNumber;
        //    //btnNext.Content = "Goto Page: " + irNextPageNumber;
        //    cmbbxforskippage.Text = irCurrentRecordPage.ToString();
        //    totalpagelbl.Content = irCountOfPages;




        //    string srQuery = $@"DECLARE @PageNumber AS INT
        //    DECLARE @RowsOfPage AS INT
        //    SET @PageNumber={irCurrentRecordPage}
        //    SET @RowsOfPage={irPageSize}
        //    SELECT * FROM tblStudents
        //    ORDER BY StudentId 
        //    OFFSET (@PageNumber-1)*@RowsOfPage ROWS
        //    FETCH NEXT @RowsOfPage ROWS ONLY";

        //    DataTable dtData = Dbaseconnection.selectTable(srQuery);


        //    DataView dvData = new DataView(dtData);


        //    booklistdtgrd.ItemsSource = dvData;



        //}

        private void refreshDataGridBook()
        {


            comboboxselector();

            int irSelectedIndex = cmbbxforskippage.SelectedIndex;

            int irRecordcount = Convert.ToInt32(Dbaseconnection.selectTable("select COUNT (*) from tblBooks").Rows[0][0].ToString());

            irCountOfPages = irRecordcount / irPageSize +1;

            cmbbxforskippage.Items.Clear();
            for (int i = 1; i < irCountOfPages + 1; i++)
            {
                cmbbxforskippage.Items.Add(i);
            }
            cmbbxforskippage.SelectedIndex = irSelectedIndex;
            int irCurrentRecordPage = irSelectedIndex + 1;

            if (irCurrentRecordPage < 1)
                irCurrentRecordPage = 1;

            irPrevPageNumber = ((irCurrentRecordPage < 2) ? irCountOfPages : irCurrentRecordPage - 1);

            irNextPageNumber = ((irCurrentRecordPage == irCountOfPages) ? 1 : irCurrentRecordPage + 1);

            //previouspagebtn.Content = "Goto Page: " + irPrevPageNumber;
            //btnNext.Content = "Goto Page: " + irNextPageNumber;
            cmbbxforskippage.Text = irCurrentRecordPage.ToString();
            totalpagelbl.Content = irCountOfPages;





            string srQuery;
            if (chckbx_notbook.IsChecked == true)
            {
                srQuery = $@"DECLARE @PageNumber AS INT
            DECLARE @RowsOfPage AS INT
            SET @PageNumber={irCurrentRecordPage}
            SET @RowsOfPage={irPageSize}
            SELECT * FROM tblBooks
            ORDER BY BookId 
            OFFSET (@PageNumber-1)*@RowsOfPage ROWS
            FETCH NEXT @RowsOfPage ROWS ONLY";
            }
            else
            {
                srQuery = $@"SELECT top " + irPageSize + " * FROM tblBooks WHERE BookName LIKE'%" + txtbxforsearch.Text + "%' and AmountofStock!=0";
                srQuery = $@"DECLARE @PageNumber AS INT
            DECLARE @RowsOfPage AS INT
            SET @PageNumber={irCurrentRecordPage}
            SET @RowsOfPage={irPageSize}
            SELECT * FROM tblBooks
            Where AmountofStock!=0
            ORDER BY BookId 
            OFFSET (@PageNumber-1)*@RowsOfPage ROWS
            FETCH NEXT @RowsOfPage ROWS ONLY";
            }


            DataTable dtData = Dbaseconnection.selectTable(srQuery);


            DataView dvData = new DataView(dtData);


            booklistdtgrd.ItemsSource = dvData;

            total_lbl.Content = "Total " + Convert.ToInt32(booklistdtgrd.Items.Count) + " result found";


        }

        //public static bool fillGridfromDatabase(DataGrid grid)
        //{
        //    sbyte checkdatagrid = 0;
        //    //SqliteConnection sQLiteConnectionfordataGrd = new SQLiteConnection(Dbaseconnection.DbAdress);
        //    SQLiteConnection sQLiteConnection = new SQLiteConnection(Dbaseconnection.DbAdress);
        //    SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from tbl_BookList", sQLiteConnection);
        //    try
        //    {
        //        SQLiteDataAdapter sqliteAdaptor = new SQLiteDataAdapter(sQLiteCommand);
        //        DataTable dataTableindatabase = new DataTable();
        //        sqliteAdaptor.Fill(dataTableindatabase);
        //        grid.ItemsSource = null;
        //        grid.ItemsSource = dataTableindatabase.DefaultView;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //    }

        //    finally
        //    {
        //        sQLiteConnection.Dispose();

        //    }
        //    if (checkdatagrid > 0)
        //        return true;
        //    else return false;

        //}



        private void txtbxforsearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txtbxforsearch.Text == "") lblinsearchbox.Visibility = Visibility.Visible;

            else lblinsearchbox.Visibility = Visibility.Hidden;




            //int searchnumber = 50;
            //if (cmbbxshowitemselector.SelectedIndex == 0) searchnumber = 25;
            //if (cmbbxshowitemselector.SelectedIndex == 1) searchnumber = 50;
            //if (cmbbxshowitemselector.SelectedIndex == 2) searchnumber = 75;
            //if (cmbbxshowitemselector.SelectedIndex == 3) searchnumber = 100;
            //if (cmbbxshowitemselector.SelectedIndex == 4) searchnumber = 200;
            comboboxselector();

            string srQuery3;

            if (cmbbxforsearchscreen.SelectedValue == "Book Name")
            {
                //string srQuery3;
                if (chckbx_notbook.IsChecked == true)
                {
                    srQuery3 = $@"SELECT top " + irPageSize + " * FROM tblBooks WHERE BookName LIKE'%" + txtbxforsearch.Text + "%'";

                }
                else
                {
                    srQuery3 = $@"SELECT top " + irPageSize + " * FROM tblBooks WHERE BookName LIKE'%" + txtbxforsearch.Text + "%' and AmountofStock!=0";

                }

                DataTable dtData = Dbaseconnection.selectTable(srQuery3);
                DataView dvData = new DataView(dtData);
                booklistdtgrd.ItemsSource = dvData;


            }

            if (cmbbxforsearchscreen.SelectedValue == "Author")
            {
                //string srQuery3;
                if (chckbx_notbook.IsChecked == true)
                {
                    srQuery3 = $@"SELECT top " + irPageSize + " * FROM tblBooks WHERE Author LIKE'%" + txtbxforsearch.Text + "%'";

                }
                else
                {
                    srQuery3 = $@"SELECT top " + irPageSize + " * FROM tblBooks WHERE Author LIKE'%" + txtbxforsearch.Text + "%' and AmountofStock!=0";

                }

                DataTable dtData = Dbaseconnection.selectTable(srQuery3);
                DataView dvData = new DataView(dtData);
                booklistdtgrd.ItemsSource = dvData;
            }
            if (cmbbxforsearchscreen.SelectedValue == "Genre")
            {
                //string srQuery3;
                if (chckbx_notbook.IsChecked == true)
                {
                    srQuery3 = $@"SELECT top " + irPageSize + " * FROM tblBooks WHERE Genre LIKE'%" + txtbxforsearch.Text + "%'";

                }
                else
                {
                    srQuery3 = $@"SELECT top " + irPageSize + " * FROM tblBooks WHERE Genre LIKE'%" + txtbxforsearch.Text + "%' and AmountofStock!=0";

                }

                DataTable dtData = Dbaseconnection.selectTable(srQuery3);
                DataView dvData = new DataView(dtData);
                booklistdtgrd.ItemsSource = dvData;
            }

            if (cmbbxforsearchscreen.SelectedValue == "User Name")
            {

                srQuery3 = $@"SELECT top " + irPageSize + " * FROM tblStudents WHERE StudentName LIKE'%" + txtbxforsearch.Text + "%'";
                DataTable dtData = Dbaseconnection.selectTable(srQuery3);
                DataView dvData = new DataView(dtData);
                booklistdtgrd.ItemsSource = dvData;
            }
            if (cmbbxforsearchscreen.SelectedValue == "E-mail")
            {

                srQuery3 = $@"SELECT top " + irPageSize + " * FROM tblStudents WHERE Email LIKE'%" + txtbxforsearch.Text + "%'";
                DataTable dtData = Dbaseconnection.selectTable(srQuery3);
                DataView dvData = new DataView(dtData);
                booklistdtgrd.ItemsSource = dvData;
            }
            if (cmbbxforsearchscreen.SelectedValue == "Phone")
            {

                srQuery3 = $@"SELECT top " + irPageSize + " * FROM tblStudents WHERE REPLACE(PhoneNumber, '-', '') LIKE'%" + txtbxforsearch.Text + "%'";
                DataTable dtData = Dbaseconnection.selectTable(srQuery3);
                DataView dvData = new DataView(dtData);
                booklistdtgrd.ItemsSource = dvData;
            }


            totalpagelbl.Content = "1";
            cmbbxforskippage.Text = "1";


            total_lbl.Content = "Total " + Convert.ToInt32(booklistdtgrd.Items.Count) + " result found";



        }


        public void bookanduserrefreshselect()  /////this is to select books or user database from sql
        {

            refreshDataGridBook();

        }




        #region  buttons for pagination

        private void cmbbxforskippage_MouseLeave(object sender, MouseEventArgs e)
        {
            //refreshDataGriduser();
            bookanduserrefreshselect();
        }


        private void nextpagebtn_Click(object sender, RoutedEventArgs e)
        {
            cmbbxforskippage.SelectedIndex = cmbbxforskippage.SelectedIndex + 1;
            bookanduserrefreshselect();
        }

        private void previouspagebtn_Click(object sender, RoutedEventArgs e)
        {
            cmbbxforskippage.SelectedIndex = cmbbxforskippage.SelectedIndex - 1;
            bookanduserrefreshselect();
        }
        private void firstpagebtn_Click(object sender, RoutedEventArgs e)
        {
            cmbbxforskippage.SelectedIndex = 0;
            bookanduserrefreshselect();
        }
        private void lastpagebtn_Click(object sender, RoutedEventArgs e)
        {
            cmbbxforskippage.SelectedIndex = irCountOfPages - 1;
            bookanduserrefreshselect();
        }



        #endregion

        public void cmbbxshowitemselector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            bookanduserrefreshselect();

        }

        private void txtbxforsearch_KeyDown(object sender, KeyEventArgs e)
        {




        }

        private void chckbx_notbook_Click(object sender, RoutedEventArgs e)
        {
            bookanduserrefreshselect();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtbxforsearch.Text = "";
            cmbbxforsearchscreen.Text = "";
            cmbbxforskippage.SelectedIndex = 0;
            cmbbxshowitemselector.SelectedIndex = 1;
            lblsearch.Content = "Searching in:";
            totalpagelbl.Content = "1";
            cmbbxforskippage.Text = "1";
        
            bookanduserrefreshselect();
        }
    }
}
