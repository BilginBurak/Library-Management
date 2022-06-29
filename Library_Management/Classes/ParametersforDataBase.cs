using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Classes
{
    internal class ParametersforDataBase
    {

        #region Addparameters

        private string bookID=null;
        private string bookTitle=null   ;
        private string bookGenre;
        private string publishDate;
        private string authorID;

        private int publisherId;
        private int pageCount;
        private int ISBN;

        private bool escrowStatus;

        public string BookID { get => bookID; set => bookID = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public string BookGenre { get => bookGenre; set => bookGenre = value; }
        public string PublishDate { get => publishDate; set => publishDate = value; }
        public string AuthorID { get => authorID; set => authorID = value; }
        public int PublisherId { get => publisherId; set => publisherId = value; }
        public int PageCount { get => pageCount; set => pageCount = value; }
        public int ISBNcode { get => ISBN; set => ISBN = value; }
        public bool EscrowStatus { get => escrowStatus; set => escrowStatus = value; }

        #endregion
    }
}