using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library_Management;

using Library_Management.Classes;
using Library_Management.UserController;


namespace Library_Management
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();

        }
        protected void LoginWindow_Closed(object sender, EventArgs e)
        {
            //if (this.UserIsAuthenticated)
            //{
            //    MainWindow mainWindow = new MainWindow();
            //    Application.Current.MainWindow = mainWindow;
            //    mainWindow.Show();
            //}
        }
        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");   //this is only number for date, number etc. change previewtextinput in xaml
            e.Handled = regex.IsMatch(e.Text);
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private class csUserRanks
        {
            public int irUserRankId { get; set; }
            public string srUserRankDisplay { get; set; }

        }

        private void initRankComboBox()
        {
            List<csUserRanks> lstUserRanks = new List<csUserRanks> { };
            lstUserRanks.Add(new csUserRanks { irUserRankId = 0, srUserRankDisplay = "Please Select User Rank" });

            foreach (DataRow drw in Dbaseconnection.selectTable("select * from tblUserRanks order by RankLevel asc").Rows)
            {
                lstUserRanks.Add(new csUserRanks
                {
                    irUserRankId = Convert.ToInt32(drw["RankId"].ToString()),
                    srUserRankDisplay = drw["UserRankDisplayName"].ToString()
                });

            }
            cmbbx_forrankchoose.ItemsSource = lstUserRanks;
            cmbbx_forrankchoose.DisplayMemberPath = "srUserRankDisplay";

            cmbbx_forrankchoose.SelectedIndex = 0;
        }




        private void loginbtn_inloginwindow_Click(object sender, RoutedEventArgs e)
        {



            string srSalt = "select PwSalt from tblUsers where Email=@Email";
            List<string> lstSaltParams = new List<string> { "@Email" };

            DataTable dtUserSalt = Dbaseconnection.cmd_SelectQuery(srSalt, lstSaltParams, new List<object> { loginUserName_txtbx.Text });




            string srSalt2 = "select PwSalt from tblUsers where UserName=@UserName";
            List<string> lstSaltParams2 = new List<string> { "@UserName" };

            DataTable dtUserSalt2 = Dbaseconnection.cmd_SelectQuery(srSalt2, lstSaltParams2, new List<object> { loginUserName_txtbx.Text });

            string srSalt3 = "select PwSalt from tblUsers where Phone=@Phone";
            List<string> lstSaltParams3 = new List<string> { "@Phone" };

            DataTable dtUserSalt3 = Dbaseconnection.cmd_SelectQuery(srSalt3, lstSaltParams3, new List<object> { loginUserName_txtbx.Text });

            if (dtUserSalt2.Rows.Count == 0 && dtUserSalt.Rows.Count == 0 && dtUserSalt3.Rows.Count == 0)
            {
                MessageBox.Show("Registered Username, Email or Phone not found");
                return;
            }

            if (dtUserSalt3.Rows.Count != 0)
            {
                string srSaltofUser = dtUserSalt3.Rows[0]["PwSalt"].ToString();

                List<string> lstLoginParams3 = new List<string> { "@Phone", "@Password" };

                string srLoginCommand = "select UserRank,Phone from tblUsers where Phone=@Phone and Password=@Password";

                string srUserHashedPw = PublicMethods.returnUserHashedPw(loginPasswd_pswdbx.Password.ToString(), srSaltofUser);

                List<object> lstLoginValues = new List<object> { loginUserName_txtbx.Text, srUserHashedPw };

                DataTable drwResult = Dbaseconnection.cmd_SelectQuery(srLoginCommand, lstLoginParams3, lstLoginValues);

                if (drwResult.Rows.Count == 0)
                {
                    MessageBox.Show("you have entered incorrect password!");
                    return;
                }
                PublicMethods.loggedPhone = drwResult.Rows[0]["Phone"].ToString();
                PublicMethods.loggedUserRank = drwResult.Rows[0]["UserRank"].ToString();
                PublicMethods.loggedUserName = Dbaseconnection.selectTable("select username from tblUsers where Phone='" + PublicMethods.loggedPhone + "'").Rows[0][0].ToString();
                //PublicMethods.loggedUserId = Dbaseconnection.selectTable("select userId from tblUsers where Phone='%" + PublicMethods.loggedPhone + "%'").Rows[0][0].ToString();
            }




            if (dtUserSalt.Rows.Count != 0)
            {
                string srSaltofUser = dtUserSalt.Rows[0]["PwSalt"].ToString();

                List<string> lstLoginParams = new List<string> { "@Email", "@Password" };

                string srLoginCommand = "select UserRank,Email from tblUsers where Email=@Email and Password=@Password";

                string srUserHashedPw = PublicMethods.returnUserHashedPw(loginPasswd_pswdbx.Password.ToString(), srSaltofUser);

                List<object> lstLoginValues = new List<object> { loginUserName_txtbx.Text, srUserHashedPw };

                DataTable drwResult = Dbaseconnection.cmd_SelectQuery(srLoginCommand, lstLoginParams, lstLoginValues);

                if (drwResult.Rows.Count == 0)
                {
                    MessageBox.Show("you have entered incorrect password!");
                    return;
                }
                PublicMethods.loggedEmail = drwResult.Rows[0]["Email"].ToString();
                PublicMethods.loggedUserRank = drwResult.Rows[0]["UserRank"].ToString();
                PublicMethods.loggedUserName = Dbaseconnection.selectTable("select username from tblUsers where Email= '" + PublicMethods.loggedEmail + "'").Rows[0][0].ToString();
            }

            if (dtUserSalt2.Rows.Count != 0)
            {
                string srSaltofUser = dtUserSalt2.Rows[0]["PwSalt"].ToString();

                List<string> lstLoginParams = new List<string> { "@UserName", "@Password" };

                string srLoginCommand = "select UserRank,UserName from tblUsers where UserName=@UserName and Password=@Password";

                string srUserHashedPw = PublicMethods.returnUserHashedPw(loginPasswd_pswdbx.Password.ToString(), srSaltofUser);

                List<object> lstLoginValues = new List<object> { loginUserName_txtbx.Text, srUserHashedPw };

                DataTable drwResult = Dbaseconnection.cmd_SelectQuery(srLoginCommand, lstLoginParams, lstLoginValues);

                if (drwResult.Rows.Count == 0)
                {
                    MessageBox.Show("you have entered incorrect password!");
                    return;
                }
                PublicMethods.loggedUserName = drwResult.Rows[0]["UserName"].ToString();
                
                PublicMethods.loggedUserRank = drwResult.Rows[0]["UserRank"].ToString();
                //PublicMethods.loggedUserId = Dbaseconnection.selectTable("select userId from tblUsers where UserName='%" + PublicMethods.loggedUserName + "%'").Rows[0][0].ToString();
               

            }
            


            if (PublicMethods.loggedUserRank == "0" || PublicMethods.loggedUserRank == "-1")
            {
                Library_Management.studentMainWindow studentMainWindow = new Library_Management.studentMainWindow();
                studentMainWindow.Show();
                studentMainWindow.lblforteacher.Content = "@" + PublicMethods.loggedUserName;
                studentMainWindow.lblforadmin.Content = Dbaseconnection.selectTable("select NameSurname from tblUsers where UserName Like '%" + PublicMethods.loggedUserName + "%'").Rows[0][0].ToString();
                Dbaseconnection.selectTable("update tblUsers set LastLogin=GETDATE() where UserName= '" + PublicMethods.loggedUserName + "'");
            }

            if (PublicMethods.loggedUserRank == "1")
            {
                Library_Management.teacherMainWindow teacherMainWindow = new Library_Management.teacherMainWindow();
                teacherMainWindow.Show();
                teacherMainWindow.lblforadmin.Content = Dbaseconnection.selectTable("select NameSurname from tblUsers where UserName Like '%" + PublicMethods.loggedUserName + "%'").Rows[0][0].ToString();
                teacherMainWindow.lblforteacher.Content = "@" + PublicMethods.loggedUserName;
                Dbaseconnection.selectTable("update tblUsers set LastLogin=GETDATE() where UserName= '" + PublicMethods.loggedUserName + "'");

            }

            if (PublicMethods.loggedUserRank == "2")
            {
                Library_Management.adminMainWindow adminMain = new Library_Management.adminMainWindow();
                //this.Close();
                adminMain.Show();
                 adminMain.lblforadmin.Content = Dbaseconnection.selectTable("select NameSurname from tblUsers where UserName Like '%" + PublicMethods.loggedUserName + "%'").Rows[0][0].ToString();
                adminMain.lbl_username.Content = "@" + PublicMethods.loggedUserName;
                Dbaseconnection.selectTable("update tblUsers set LastLogin=GETDATE() where UserName='" + PublicMethods.loggedUserName + "'");

            }

            this.Close();



        }

        private void clearlogged()
        {
            PublicMethods.loggedEmail = "";
            PublicMethods.loggedUserName = "";
            PublicMethods.loggedPhone = "";
        }





        private void rgstrbtn_inloginwindow_Click(object sender, RoutedEventArgs e)
        {

            if (loginbtn_inloginwindow.Visibility == Visibility.Visible)
            {
                if (loginUserName_txtbx.Text != "" || loginPasswd_pswdbx.Password != "")
                {
                    loginPasswd_pswdbx.Password = "";
                    loginUserName_txtbx.Text = "";




                }

                #region visible and hide items
                _lbl_phone.Visibility = Visibility.Visible;
                _txtbx_phone.Visibility = Visibility.Visible;
                _txtbx_phone.Text = "";
                _lbl_email.Visibility = Visibility.Visible;
                _txtbx_email.Visibility = Visibility.Visible;
                _txtbx_email.Text = "";

                loginPasswd_pswdbx_ext.Visibility = Visibility.Visible;
                loginPasswd_pswdbx_ext.Password = "";

                loginPasswd_lbl_ext.Visibility = Visibility.Visible;
                _lbl_NameSurname.Visibility = Visibility.Visible;
                _txtbx_NameSurname.Visibility = Visibility.Visible;
                _txtbx_NameSurname.Text = "";
                returnloginbtn_inloginwindow.Visibility = Visibility.Visible;
                loginbtn_inloginwindow.Visibility = Visibility.Hidden;
                lbl_wellcome.Visibility = Visibility.Hidden;

                icn_passwd.Visibility = Visibility.Hidden;
                icn_user.Visibility = Visibility.Hidden;
                cmbbx_forrankchoose.Visibility = Visibility.Visible;
                lbl_forcmbx.Visibility = Visibility.Visible;
                loginPasswd_pswdbx.Margin = new Thickness(78, 262, 0, 0);
                loginPasswd_lbl.Margin = new Thickness(78, 262, 0, 0);
                loginUserName_lbl.Margin = new Thickness(78, 192, 0, 0);
                loginUserName_txtbx.Margin = new Thickness(78, 192, 0, 0);
                loginUserName_lbl.Content = "Username";
                cmbbx_forrankchoose.SelectedIndex = -1;
                #endregion



            }
            else
            {

                string escrowlimit = Dbaseconnection.selectTable("select TotalBook from tblSettings").Rows[0][0].ToString();



                var vrResult = PublicMethods.checkUserName(loginUserName_txtbx.Text);
                if (vrResult.blResult == false)
                {
                    MessageBox.Show("Error: " + vrResult.srMsg);
                    return;
                }
                vrResult = PublicMethods.checkEmail(_txtbx_email.Text);
                if (vrResult.blResult == false)
                {
                    MessageBox.Show("Error: " + vrResult.srMsg);
                    return;
                }

                if (cmbbx_forrankchoose.SelectedIndex == -1)
                {
                    MessageBox.Show("Error: please pick a user rank");
                    return;
                }

                if (loginPasswd_pswdbx.Password.ToString() != loginPasswd_pswdbx_ext.Password.ToString())
                {
                    MessageBox.Show("Error: Entered passwords are not matching!");
                    return;
                }
                int userrank = 0;
                if (cmbbx_forrankchoose.SelectedIndex == 0) userrank = 0;
                else if (cmbbx_forrankchoose.SelectedIndex == 1) userrank = -1;

                int irUserSalt = new Random().Next();

                string srUserHashedPassword = PublicMethods.returnUserHashedPw(loginPasswd_pswdbx.Password.ToString(), irUserSalt.ToString());

                //write the final step save in database,

                string srInsertCmd = $@"  insert into tblUsers (UserName,Email,Password,UserRank,PwSalt,Phone,NameSurname,escrowlimit,totalread)
  values (@UserName,@Email,@Password,@UserRank,@PwSalt,@Phone,@NameSurname,@escrowlimit,@totalread)";

                List<string> lstParameterNames = new List<string> { "@UserName", "@Email", "@Password", "@UserRank", "@PwSalt", "@Phone", "@NameSurname", "@escrowlimit", "@totalread" };


                List<object> lstValues = new List<object> { loginUserName_txtbx.Text, _txtbx_email.Text, srUserHashedPassword, userrank, irUserSalt, _txtbx_phone.Text, _txtbx_NameSurname.Text, escrowlimit, "0" };

                var vrRegisterResult = Dbaseconnection.cmd_UpdateDeleteQuery(srInsertCmd, lstParameterNames, lstValues);

                if (vrRegisterResult == true)
                {
                    MessageBox.Show("Your registration is complete, you can login.");
                    #region visible and hide items
                    _lbl_phone.Visibility = Visibility.Hidden;
                    _lbl_email.Visibility = Visibility.Hidden;
                    _txtbx_email.Visibility = Visibility.Hidden;
                    _txtbx_phone.Visibility = Visibility.Hidden;
                    loginPasswd_pswdbx_ext.Visibility = Visibility.Hidden;
                    loginPasswd_lbl_ext.Visibility = Visibility.Hidden;
                    loginbtn_inloginwindow.Visibility = Visibility.Visible;
                    lbl_wellcome.Visibility = Visibility.Visible;
                    _lbl_NameSurname.Visibility = Visibility.Hidden;
                    _txtbx_NameSurname.Visibility = Visibility.Hidden;
                    icn_passwd.Visibility = Visibility.Visible;
                    icn_user.Visibility = Visibility.Visible;
                    cmbbx_forrankchoose.Visibility = Visibility.Hidden;
                    lbl_forcmbx.Visibility = Visibility.Hidden;
                    loginPasswd_pswdbx.Margin = new Thickness(99, 332, 0, 0);
                    loginPasswd_lbl.Margin = new Thickness(99, 332, 0, 0);
                    loginUserName_lbl.Margin = new Thickness(99, 242, 0, 0);
                    loginUserName_txtbx.Margin = new Thickness(99, 242, 0, 0);
                    loginUserName_lbl.Visibility = Visibility.Hidden;
                    loginPasswd_lbl.Visibility = Visibility.Hidden;
                    returnloginbtn_inloginwindow.Visibility = Visibility.Hidden;
                    loginUserName_lbl.Content = "Username, phone or e-mail";
                    #endregion

                }
                else MessageBox.Show("Error encountered during registration, please check again");
                //SearchWindow searchWindow = new SearchWindow();
                //searchWindow.Show();



            }



        }



        private void cmbbx_forrankchoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_forcmbx.Visibility = Visibility.Hidden;
        }

        private void teacher_btn_Click(object sender, RoutedEventArgs e)
        {

            Library_Management.teacherMainWindow teacherMainWindow = new Library_Management.teacherMainWindow();

            teacherMainWindow.Show();
        }

        private void student_btn_Click(object sender, RoutedEventArgs e)
        {
            Library_Management.studentMainWindow studentMainWindow = new Library_Management.studentMainWindow();
            studentMainWindow.Show();
        }

        private void returnloginbtn_inloginwindow_Click(object sender, RoutedEventArgs e)
        {
            if (loginbtn_inloginwindow.Visibility == Visibility.Hidden)
            {
                if (loginUserName_txtbx.Text != "" || loginPasswd_pswdbx.Password != "")
                {
                    loginPasswd_pswdbx.Password = "";
                    loginUserName_txtbx.Text = "";




                }

                #region visible and hide items
                _lbl_phone.Visibility = Visibility.Hidden;
                _lbl_email.Visibility = Visibility.Hidden;
                _txtbx_email.Visibility = Visibility.Hidden;
                _txtbx_phone.Visibility = Visibility.Hidden;
                loginPasswd_pswdbx_ext.Visibility = Visibility.Hidden;
                loginPasswd_lbl_ext.Visibility = Visibility.Hidden;
                loginbtn_inloginwindow.Visibility = Visibility.Visible;
                lbl_wellcome.Visibility = Visibility.Visible;
                _lbl_NameSurname.Visibility = Visibility.Hidden;
                _txtbx_NameSurname.Visibility = Visibility.Hidden;
                icn_passwd.Visibility = Visibility.Visible;
                icn_user.Visibility = Visibility.Visible;
                cmbbx_forrankchoose.Visibility = Visibility.Hidden;
                lbl_forcmbx.Visibility = Visibility.Hidden;
                loginPasswd_pswdbx.Margin = new Thickness(99, 332, 0, 0);
                loginPasswd_lbl.Margin = new Thickness(99, 332, 0, 0);
                loginUserName_lbl.Margin = new Thickness(99, 242, 0, 0);
                loginUserName_txtbx.Margin = new Thickness(99, 242, 0, 0);
                loginUserName_lbl.Content = "Username, phone or e-mail";
                returnloginbtn_inloginwindow.Visibility = Visibility.Hidden;
                #endregion

            }
            else
            {
                //SearchWindow searchWindow = new SearchWindow();
                //searchWindow.Show();
            }
        }



        #region visible or hide labels while typing
        private void _txtbx_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_txtbx_email.Text == "")
                _lbl_email.Margin = new Thickness(78, 52, 0, 0);
            else _lbl_email.Margin = new Thickness(293, 77, 0, 0);
        }

        private void _txtbx_phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_txtbx_phone.Text == "")
            {
                _lbl_phone.Content = "Phone (5_ _ _ - _ _ _ - _ _ _ _)";
                _lbl_phone.Margin = new Thickness(78, 402, 0, 0);
            }

            else
            {
                _lbl_phone.Content = "Phone";
                _lbl_phone.Margin = new Thickness(293, 427, 0, 0);
            }
        }

        private void loginPasswd_pswdbx_ext_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (loginPasswd_pswdbx_ext.Password == "")
                loginPasswd_lbl_ext.Margin = new Thickness(78, 332, 0, 0);
            else loginPasswd_lbl_ext.Margin = new Thickness(277, 357, 0, 0);
        }

        private void loginUserName_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loginbtn_inloginwindow.Visibility == Visibility.Hidden)
            {
                if (loginUserName_txtbx.Text == "")
                { loginUserName_lbl.Margin = new Thickness(78, 192, 0, 0); loginUserName_lbl.Content = "Username"; }
            else loginUserName_lbl.Margin = new Thickness(273, 217, 0, 0);
            }
            else
            {
                if (loginUserName_txtbx.Text == "")
                    loginUserName_lbl.Visibility = Visibility.Visible;
                else loginUserName_lbl.Visibility = Visibility.Hidden;
            }

        }

        private void loginPasswd_pswdbx_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (loginbtn_inloginwindow.Visibility == Visibility.Hidden)
            {
                if (loginPasswd_pswdbx.Password == "")
                    loginPasswd_lbl.Margin = new Thickness(78, 262, 0, 0);
                else loginPasswd_lbl.Margin = new Thickness(277, 287, 0, 0);
            }
            else
            {
                if (loginPasswd_pswdbx.Password == "")
                    loginPasswd_lbl.Visibility = Visibility.Visible;
                else loginPasswd_lbl.Visibility = Visibility.Hidden;
            }

        }

        private void _txtbx_NameSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_txtbx_NameSurname.Text == "") _lbl_NameSurname.Margin = new Thickness(78, 122, 0, 0);
            else _lbl_NameSurname.Margin = new Thickness(222, 147, 0, 0);
        }

        #endregion

        private void adminbbtn_Click(object sender, RoutedEventArgs e)
        {
            adminMainWindow adminMainWindow = new adminMainWindow();
            //this.Close();
            adminMainWindow.Show();
        }

        private void loginPasswd_pswdbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginPasswd_pswdbx.Password))

            {

                loginPasswd_pswdbx.SelectAll();

            }
        }

        private void loginPasswd_pswdbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                loginbtn_inloginwindow_Click(sender, e);
            }
           
        }
    }
}
