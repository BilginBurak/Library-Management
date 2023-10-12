using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SQLite;
using System.Windows;
using System.Data;
using Library_Management.Classes;
using Library_Management.UserController;



namespace Library_Management.Classes
{
    public class CallfromDataBase
    {
        public static bool fillGridfromDatabase(DataGrid grid)
        {
            sbyte checkdatagrid = 0;
            SQLiteConnection sQLiteConnectionfordataGrd = new SQLiteConnection(Dbaseconnection.srConnectionString);
            SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from tbl_BookList", sQLiteConnectionfordataGrd);
            try
            {
                SQLiteDataAdapter sqliteAdaptor = new SQLiteDataAdapter(sQLiteCommand);
                DataTable dataTableindatabase = new DataTable();
                sqliteAdaptor.Fill(dataTableindatabase);
                grid.ItemsSource = null; 
                grid.ItemsSource = dataTableindatabase.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            finally
            {
                sQLiteConnectionfordataGrd.Dispose();

            }
            if (checkdatagrid > 0)
                return true;
            else return false;

        }


        //this is to adding info to database from bookaddwindow
        //public static bool AddDatabasefrombookAddWindow(bookAddWindow senddata)
        //{
        //    sbyte checkdatabase = 0;
        //    SQLiteConnection sQLiteConnectionsendData = new SQLiteConnection(Dbaseconnection.DbAdress);
        //    SQLiteCommand sQLiteCommandsendData = new SQLiteCommand("Insert into tbl_BookList (BookTitle,AuthorID,Genre,PuplisherID,PublishDate,PageCount values(@BookTitle,@AuthorID,@Genre,@PuplisherID,@PublishDate,@PageCount", sQLiteConnectionsendData);

        //    //sQLiteCommandsendData.Parameters.AddWithValue("@idcode", senddata.BookID);
        //    sQLiteCommandsendData.Parameters.AddWithValue("@BookTitle", senddata.BookTitle);
        //    sQLiteCommandsendData.Parameters.AddWithValue("@AuthorID", senddata.AuthorID);

        //    //sQLiteCommandsendData.Parameters.AddWithValue("@ISBN", senddata.ISBNcode);
        //    sQLiteCommandsendData.Parameters.AddWithValue("@Genre", senddata.BookGenre);
        //    sQLiteCommandsendData.Parameters.AddWithValue("@PuplisherID", senddata.PublisherId);
        //    sQLiteCommandsendData.Parameters.AddWithValue("@PublishDate", senddata.PublishDate);
        //    sQLiteCommandsendData.Parameters.AddWithValue("@PageCount", senddata.PageCount);
        //    //sQLiteCommandsendData.Parameters.AddWithValue("@EscrowStatus", senddata.EscrowStatus);

        //    try
        //    {
        //        sQLiteConnectionsendData.Open();
        //        checkdatabase   = (sbyte)sQLiteCommandsendData.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        sQLiteConnectionsendData.Dispose();
        //    }
        //    if (checkdatabase == 0) return true; else return false;
        //}
    }
}
