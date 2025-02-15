﻿using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace Library_Management.Classes
{
    internal static class CallfromDataBaseHelpers
    {


        //this is to adding info to database from bookaddwindow
        public static bool AddDatabasefrombookAddWindow(ParametersforDataBase senddata)
        {
            sbyte checkdatabase = 0;
            SQLiteConnection sQLiteConnectionsendData = new SQLiteConnection(Dbaseconnection.srConnectionString);
            SQLiteCommand sQLiteCommandsendData = new SQLiteCommand("Insert into tbl_BookList (ID,BookTitle,AuthorID,ISBN,Genre,PuplisherID,PublishDate,PageCount,EscrowStatus values(@ID,@BookTitle,@AuthorID,@ISBN,@Genre,@PuplisherID,@PublishDate,@PageCount,@EscrowStatus", sQLiteConnectionsendData);

            sQLiteCommandsendData.Parameters.AddWithValue("@ID", senddata.BookID);
            sQLiteCommandsendData.Parameters.AddWithValue("@BookTitle", senddata.BookTitle);
            sQLiteCommandsendData.Parameters.AddWithValue("@AuthorID", senddata.AuthorID);

            sQLiteCommandsendData.Parameters.AddWithValue("@ISBN", senddata.ISBNcode);
            sQLiteCommandsendData.Parameters.AddWithValue("@Genre", senddata.BookGenre);
            sQLiteCommandsendData.Parameters.AddWithValue("@PuplisherID", senddata.PublisherId);
            sQLiteCommandsendData.Parameters.AddWithValue("@PublishDate", senddata.PublishDate);
            sQLiteCommandsendData.Parameters.AddWithValue("@PageCount", senddata.PageCount);
            sQLiteCommandsendData.Parameters.AddWithValue("@EscrowStatus", senddata.EscrowStatus);

            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sQLiteConnectionsendData.Dispose();
            }
            if (checkdatabase > 0) return true;
            else return false;
        }
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
    }
}