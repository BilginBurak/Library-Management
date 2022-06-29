using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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



        public static string srConnectionString = "server=localhost;database=School; integrated security=SSPI;persist security info=False; Trusted_Connection=Yes;";

        public static DataSet db_Select_Query(string strQuery, bool blsetCommit = false)
        {
            //System.IO.File.AppendAllText(@"C:\temp\dbcon2.txt", strQuery + "\r\n\r\n");

            DataSet dSet = new DataSet();
            if (strQuery.Length < 5)
                return dSet;

            if (blsetCommit == true)
            {
                strQuery = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " + Environment.NewLine + " " + strQuery;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(srConnectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter DA = new SqlDataAdapter(strQuery, connection))
                    {
                        DA.Fill(dSet);
                    }
                }
                return dSet;
            }
            catch (Exception E)
            {
                insertIntoTblSqlErrors(strQuery + " " + E.Message.ToString());
                return dSet;
            }
        }

        public static DataTable selectTable(string strQuery, bool blsetCommit = false)
        {
            //System.IO.File.AppendAllText(@"C:\temp\dbcon.txt", strQuery + "\r\n\r\n");

            DataTable dSet = new DataTable();
            if (strQuery.Length < 5)
                return dSet;

            if (blsetCommit == true)
            {
                strQuery = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " + Environment.NewLine + " " + strQuery;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(srConnectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter DA = new SqlDataAdapter(strQuery, connection))
                    {
                        DA.Fill(dSet);
                    }
                }
                return dSet;
            }
            catch (Exception E)
            {
                insertIntoTblSqlErrors(strQuery + " " + E.Message.ToString());
                return dSet;
            }
        }

        public static DataRow db_Select_DataRow(string strQuery, bool blsetCommit = false)
        {
            //System.IO.File.AppendAllText(@"C:\temp\dbcon.txt", strQuery + "\r\n\r\n");

            DataRow drw = null;
            if (strQuery.Length < 5)
                return drw;

            if (blsetCommit == true)
            {
                strQuery = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " + Environment.NewLine + " " + strQuery;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(srConnectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter DA = new SqlDataAdapter(strQuery, connection))
                    {
                        using (DataTable drTemp = new DataTable())
                        {
                            DA.Fill(0, 1, drTemp);
                            if (drTemp.Rows.Count > 0)
                                drw = drTemp.Rows[0];
                        }
                    }
                }
                return drw;
            }
            catch (Exception E)
            {
                insertIntoTblSqlErrors(strQuery + " " + E.Message.ToString());
                return drw;
            }
        }

        public static int updateDeleteInsert(string strQuery, bool blsetCommit = false, int irRetryCount = 1)
        {
            bool blResult = false;

            for (int i = 0; i < irRetryCount; i++)
            {
                // System.IO.File.AppendAllText(@"C:\temp\dbcon2.txt", strQuery + "\r\n\r\n");

                if (strQuery.Length < 5)
                    return 0;

                //using (StreamWriter w = File.AppendText("c:\\log.txt"))
                //{
                //    w.WriteLine(strQuery);
                //    w.Close();
                //}

                if (blsetCommit == true)
                {
                    strQuery = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " + Environment.NewLine + " " + strQuery;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(srConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(strQuery, connection))
                        {
                            return command.ExecuteNonQuery();
                        }
                    }

                    blResult = true;
                    break;
                }
                catch (Exception E)
                {
                    insertIntoTblSqlErrors(strQuery + " " + E.Message.ToString());
                }

                System.Threading.Thread.Sleep(1000);
            }

            return 0;
        }

        public static DataTable cmd_SelectQuery(string srCommandText, List<string> lstParameterNames, IList<object> lstParameters, bool blsetCommit = false)
        {
            //  System.IO.File.AppendAllText(@"C:\temp\dbcon2.txt", srCommandText + "\r\n\r\n");

            if (blsetCommit == true)
            {
                srCommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " + Environment.NewLine + " " + srCommandText;
            }

            DataTable dsCmdPara = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(Dbaseconnection.srConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(srCommandText, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        for (int i = 0; i < lstParameterNames.Count; i++)
                        {
                            cmd.Parameters.AddWithValue(lstParameterNames[i], lstParameters[i].ToString());
                        }
                        using (SqlDataAdapter sqlDa = new SqlDataAdapter(cmd))
                        {
                            sqlDa.Fill(dsCmdPara);
                            return dsCmdPara;
                        }
                    }
                }
            }
            catch (Exception E)
            {
                insertIntoTblSqlErrors(srCommandText + " " + E.Message.ToString());
            }
            return dsCmdPara;
        }

        public static bool cmd_UpdateDeleteQuery(string srCommandText, List<string> lstParameterNames, IList<object> lstParameters)
        {
            //   System.IO.File.AppendAllText(@"C:\temp\dbcon2.txt", srCommandText + "\r\n\r\n");

            try
            {
                using (SqlConnection connection = new SqlConnection(Dbaseconnection.srConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(srCommandText, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        for (int i = 0; i < lstParameterNames.Count; i++)
                        {
                            cmd.Parameters.AddWithValue(lstParameterNames[i], lstParameters[i].ToString());
                        }
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception E)
            {
                insertIntoTblSqlErrors(srCommandText + " " + E.Message.ToString());
            }
            return false;
        }

        static string srCommandTextSqlError = " insert into tblSqlErrors values(@ErrorQueryString,@StackTrace) ";
        private static void insertIntoTblSqlErrors(string srErrorQuery)
        {
            cmd_UpdateDeleteQuery(srCommandTextSqlError, new List<string> { "@ErrorQueryString", "@StackTrace" }, new List<object> { srErrorQuery, Environment.StackTrace.ToString() });
        }

        public static int rowsAffectedUpdate(string strQuery, bool blsetCommit = false)
        {
            int irAffected = 0;

            // System.IO.File.AppendAllText(@"C:\temp\dbcon2.txt", strQuery + "\r\n\r\n");

            if (strQuery.Length < 5)
                return irAffected;

            //using (StreamWriter w = File.AppendText("c:\\log.txt"))
            //{
            //    w.WriteLine(strQuery);
            //    w.Close();
            //}

            if (blsetCommit == true)
            {
                strQuery = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " + Environment.NewLine + " " + strQuery;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(srConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(strQuery, connection))
                    {
                        irAffected = command.ExecuteNonQuery();
                    }
                }

                return irAffected;
            }
            catch (Exception E)
            {
                insertIntoTblSqlErrors(strQuery + " " + E.Message.ToString());
                return irAffected;
            }
        }



    }
}
