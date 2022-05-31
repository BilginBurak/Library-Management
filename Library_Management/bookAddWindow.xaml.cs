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
using System.Windows.Shapes;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for bookAddWindow.xaml
    /// </summary>
    public partial class bookAddWindow : Window
    {
        public bookAddWindow()
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

        //private void publicDate_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    txtblck_date_inCover.Text = publicDate_txtbox.Text;
        //}

        private void isbn_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtblck_isbn_inCover.Text = isbn_txtbox.Text;
        }

        private void addBookWindow_clear_btn_Click(object sender, RoutedEventArgs e)
        {
                       
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete all data?", "Sure?", MessageBoxButton.YesNo,MessageBoxImage.Question, MessageBoxResult.No);
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
                summary_txtbox.Text = "";
                publicDate_datepicker.Text = "";
            }
            
           



           
        }

        private void publicDate_datepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txtblck_date_inCover.Text = publicDate_datepicker.Text;

        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9_-]+");   //this is only number for date, number etc.
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
