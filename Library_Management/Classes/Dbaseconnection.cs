using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Classes
{
    public class Dbaseconnection
    {
        //public static string DbAdress = @"Data Source= " + Environment.CurrentDirectory + "\\Database\\book.db; Version=3;New=False;Compress=True;Read Only=False;";
        public static string DbAdress = @"Data Source= C:\\Users\\Burak\\Desktop\\Kutuphane\\Library_Management\\Library_Management\\bin\\Debug\\Database\\book.db; Version=3;New=False;Compress=True;Read Only=False;";
        public static string DbConState;
       

        public static void DbConTest()
        {

            using (SQLiteConnection conn = new SQLiteConnection(DbAdress))
            {

                if(conn.State == System.Data.ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                        DbConState = "Database Connection Successful";
                    }
                    catch (Exception)
                    {
                        DbConState = "Database Connection Error!";
                    }
                }
                else { DbConState = "Database Connection Successful"; }
            }
        }


    }
}
