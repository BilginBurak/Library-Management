using Library_Management.Classes;
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

namespace Library_Management.Windows
{
    /// <summary>
    /// Interaction logic for uc_user_add.xaml
    /// </summary>
    public partial class uc_user_add : UserControl
    {
        public uc_user_add()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (cmbbx_rankselect.Items.Count == 0)
            {
                cmbbx_rankselect.Items.Add("Student");
                cmbbx_rankselect.Items.Add("Teacher");
            }
            

        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vrResult = PublicMethods.checkUserName(username_txtbx.Text);
            if (vrResult.blResult == false)
            {
                MessageBox.Show("Error: " + vrResult.srMsg);
                return;
            }
            vrResult = PublicMethods.checkEmail(email_txtbx.Text);
            if (vrResult.blResult == false)
            {
                MessageBox.Show("Error: " + vrResult.srMsg);
                return;
            }

            if (cmbbx_rankselect.SelectedIndex == -1)
            {
                MessageBox.Show("Error: please pick a user rank");
                return;
            }

            if (passwd_pass.Password.ToString() != passwd_pass_ext.Password.ToString())
            {
                MessageBox.Show("Error: Entered passwords are not matching!");
                return;
            }
            int userrank = 0;
            if (cmbbx_rankselect.SelectedIndex == 0) userrank = 0;
            else if (cmbbx_rankselect.SelectedIndex == 1) userrank = 1;

            int irUserSalt = new Random().Next();
            int irUserSalt1 = new Random().Next();

            string srUserHashedPassword = PublicMethods.returnUserHashedPw(passwd_pass.Password.ToString(), irUserSalt.ToString(), irUserSalt1.ToString());

           
            string escrowlimit = Dbaseconnection.selectTable("select TotalBook from tblSettings").Rows[0][0].ToString();
            string srInsertCmd = $@"  insert into tblUsers (UserName,Email,Password,UserRank,PwSalt,Phone,NameSurname,escrowlimit,totalread,PwSalt1)
  values (@UserName,@Email,@Password,@UserRank,@PwSalt,@Phone,@NameSurname,@escrowlimit,@totalread,@PwSalt1)";

            List<string> lstParameterNames = new List<string> { "@UserName", "@Email", "@Password", "@UserRank", "@PwSalt", "@Phone", "@NameSurname", "@escrowlimit", "@totalread", "@PwSalt1" };


            List<object> lstValues = new List<object> { username_txtbx.Text, email_txtbx.Text, srUserHashedPassword, userrank, irUserSalt, phone_txtbx.Text, namesurname_txtbx.Text, escrowlimit, "0", irUserSalt1 };

            var vrRegisterResult = Dbaseconnection.cmd_UpdateDeleteQuery(srInsertCmd, lstParameterNames, lstValues);

            if (vrRegisterResult == true)
            {
                MessageBox.Show("User added");


            }
            else MessageBox.Show("Failed to add user, please check again");
            email_txtbx.Text = "";
            namesurname_txtbx.Text = "";
            phone_txtbx.Text = "";
            username_txtbx.Text = "";
            passwd_pass.Password = "";
            passwd_pass_ext.Password = "";
            cmbbx_rankselect.SelectedIndex = -1;





        }


    }
}
