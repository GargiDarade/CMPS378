using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libraryManagementSystem
{
    [Serializable]
    public class Book
    {
        //vars to store book info
        string title;
        string author;
        int copies;
        List<string> checkoutNameList;
        public Book()
        {
            title = "";
            author = "";
            copies = 1; //default 1 copy
            checkoutNameList = new List<string>();
        }
        public Book(string bookTitle, string bookAuthor, int noOfCopies)
        {
            title = bookTitle;
            author = bookAuthor;
            copies = noOfCopies;
            checkoutNameList = new List<string>();
        }

        //properties with get set methodes
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int Copies
        {
            get { return copies; }
            set { copies = value; }
        }
        public List<string> CheckoutNameList
        {
            get { return checkoutNameList; }
            set { checkoutNameList = value; }
        }
    }
}
