using Library_Management.Classes;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library_Management.Windows
{
    /// <summary>
    /// Interaction logic for uc_book_add.xaml
    /// </summary>
    public partial class uc_book_add : UserControl
    {
        public uc_book_add()
        {
            InitializeComponent();
        }



        private void booktitle_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //txtblck_bookTitle_inCover.Text = booktitle_txtbox.Text;
            genre_txtbox_Copy.Text = booktitle_txtbox.Text;
        }

        private void author_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtblck_author_inCover.Text = author_txtbox.Text;
        }

        private void publisher_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtblck_Publisher_inCover.Text = publisher_txtbox.Text;
        }

       

        private void isbn_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtblck_isbn_inCover.Text = isbn_txtbox.Text;
        }

        private void addBookWindow_clear_btn_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete all data?", "Sure?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                booktitle_txtbox.Text = "";
                author_txtbox.Text = "";
                publisher_txtbox.Text = "";
                isbn_txtbox.Text = "";
                genre_txtbox.Text = "";
                lenght_txtbox.Text = "";
                language_txtbox.Text = "";
                stock_txtbox.Text = "";
                publicDate_datepicker.Text = "";
            }






        }

        private void publicDate_datepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txtblck_date_inCover.Text = publicDate_datepicker.Text;

        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9_-]+");   //this is only number for date, number etc. change previewtextinput in xaml
            e.Handled = regex.IsMatch(e.Text);
        }

       

        private void addBookWindow_btn_Click(object sender, RoutedEventArgs e)
        {
            


            var vrResult = PublicMethods.checkBookTitle(booktitle_txtbox.Text);
            if (vrResult.blResult == false)
            {

                MessageBoxResult result = MessageBox.Show("The  book title already exists. Do you want to add another book?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

                if (result == MessageBoxResult.Yes) addbookcmd();

            }
            else addbookcmd();
         



        }

        private void addbookcmd()
        {
            string srQuery2 = $@" insert into tblBooks(BookName, AmountofStock, Author, Genre, Publisher, PageNumber, PublishDate, Language, ISBN) values ('" + booktitle_txtbox.Text + "', '" + stock_txtbox.Text + "', '" + author_txtbox.Text + "', '" + genre_txtbox.Text + "', '" + publisher_txtbox.Text + "', '" + lenght_txtbox.Text + "', '" + publicDate_datepicker.Text + "', '" + language_txtbox.Text + "', '" + isbn_txtbox.Text + "')";

            //Dbaseconnection.updateDeleteInsert(srQuery2);
            var vrRegisterResult = Dbaseconnection.updateDeleteInsert(srQuery2);

            if (vrRegisterResult == 0)
            {
                //MessageBox.Show("Book added");
                MessageBox.Show("Failed to add book, please check again");

            }
            else MessageBox.Show("Book added"); //MessageBox.Show("Failed to add book, please check again");
        }

    }
    
}
