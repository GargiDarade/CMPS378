using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace libraryManagementSystem
{
    //this class will have book collection in the list will have following functions
    // 1 Add a Book, 2 Edit a Book, 3 Search a Book, 4 Delete a Book, 5 check out book, 6 check in book, 7 save collection to file, 8 load collection from file
    class BookCollection
    {
        // Creating a List of Books
        List<Book> bookList;
        string fileName;
        public BookCollection(string file)
        {
            bookList = new List<Book>();
            fileName = file;
        }

        //properties with get set methodes
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public List<Book> BookList
        {
            get { return bookList; }
            set { bookList = value; }
        }


        //returns total count of books in collection
        public int totalBooks()
        {
            int res = 0;
            res = bookList.Count;
            return res;
        }

        //adds book to the collection, returns 0 on success
        // returns -1 on error
        public int addBook(Book book)
        {
            int res = 0;
            Book resBook = null;
            if (book.Title != "" && book.Author != "" && book.Title != null && book.Author != null)
            {
                //make sure book is not in collection then add
                if (searchBook(ref resBook, book.Title, 0) != 0)
                {
                    bookList.Add(book);
                }
                else
                {
                    res = -1;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        //edits given book in the collection, returns 0 on success
        // returns -1 on error
        // search is based on title of book
        //once found based on old title both title and author can be changed
        public int editBook(Book book, string title)
        {
            int res = 0;
            Book resBook = null;
            if (title != "" && book != null && book.Title != "")
            {
                //make sure book is in the collection then edit
                if (searchBook(ref resBook, title, 0) == 0)
                {
                    resBook.Title = book.Title;
                    resBook.Author = book.Author;
                    resBook.Copies = book.Copies;
                    resBook.CheckoutNameList.Clear();
                    foreach (string chkName in book.CheckoutNameList)
                        resBook.CheckoutNameList.Add(chkName);
                }
                else
                {
                    res = -1;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        //check out given book in the collection, returns 0 on success
        // returns -1 on error
        // search is based on title of book
        //once found if copies are available will be rented
        public int checkOutBook(Book book, string personName)
        {
            int res = 0;
            //int noOfBooks = 0;
            Book resBook = null;
            if (personName != "" && book != null && book.Title != "")
            {
                //make sure book is in the collection then edit
                if (searchBook(ref resBook, book.Title, 0) == 0)
                {
                    //noOfBooks=resBook.Copies;
                    //copy is available can rent
                    if (resBook.CheckoutNameList.Count < resBook.Copies)
                    {
                        resBook.CheckoutNameList.Add(personName);
                    }
                    else
                    {
                        res = -1;
                    }
                }
                else
                {
                    res = -1;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        //check in given book in the collection, returns 0 on success
        // returns -1 on error
        // search is based on title of book
        //once found name of rented person is removed
        public int checkInBook(Book book, string personName)
        {
            int res = 0;
            //int noOfBooks = 0;
            Book resBook = null;
            if (personName != "" && book != null && book.Title != "")
            {
                //make sure book is in the collection then edit
                if (searchBook(ref resBook, book.Title, 0) == 0)
                {
                    if (!resBook.CheckoutNameList.Remove(personName))
                    {
                        res = -1;
                    }
                }
                else
                {
                    res = -1;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        //deletes book from the collection, returns 0 on success
        // returns -1 on error
        //deleteOnType = 0 delete on title, deleteOnType = 1 delete on author, deleteOnType = 2 delete on index
        public int deleteBook(string bookInfo, int deleteOnType)
        {
            int res = 0;
            Book found = null;
            if (deleteOnType == 0)
            {
                found = bookList.FirstOrDefault(o => o.Title == bookInfo);
                if (found != null) bookList.Remove(found);
                else res = -1;
            }
            else if (deleteOnType == 1)
            {
                found = bookList.FirstOrDefault(o => o.Author == bookInfo);
                if (found != null) bookList.Remove(found);
                else res = -1;
            }
            else if (deleteOnType == 2 && bookList.Count >= Convert.ToInt32(bookInfo))
            {
                found = bookList[Convert.ToInt32(bookInfo) - 1];
                bookList.Remove(found);
            }
            else res = -1;


            return res;
        }

        //search book from the collection based on title or author or index, returns 0 on success
        // returns -1 on error
        //searchType = 0 search on title, searchType = 1 search on author, searchType = 2 search on index
        public int searchBook(ref Book resBook, string bookInfo, int searchType)
        {
            int res = 0;
            Book found = null;
            if (searchType == 0)
            {
                found = bookList.FirstOrDefault(o => o.Title == bookInfo);
                if (found != null) resBook = found;
                else res = -1;
            }
            else if (searchType == 1)
            {
                found = bookList.FirstOrDefault(o => o.Author == bookInfo);
                if (found != null) resBook = found;
                else res = -1;
            }
            else if (searchType == 2 && bookList.Count >= Convert.ToInt32(bookInfo))
            {
                resBook = bookList[Convert.ToInt32(bookInfo) - 1];
            }
            else res = -1;

            return res;
        }


        //search book from the collection based on sub string of title or author, returns count of books found on success
        //and list of books
        // returns 0 on not found and collection will be null.
        //searchType = 0 search on title, searchType = 1 search on author
        public List<Book> searchBook(string bookInfo, int searchType, ref int foundCount)
        {
            int res = 0;
            List<Book> found = null;
            if (searchType == 0)
            {
                found = bookList.FindAll(o => o.Title.Contains(bookInfo));
                if (found != null) res = found.Count;
            }
            else if (searchType == 1)
            {
                found = bookList.FindAll(o => o.Author.Contains(bookInfo));
                if (found != null) res = found.Count;
            }
            foundCount = res;
            return found;
        }

        //save collection to file, returns 0 on success
        // returns -1 on error
        public int saveCollection(string fileName)
        {
            int res = 0;
            WriteToXmlFile<List<Book>>(fileName, BookList, false);
            return res;
        }


        //load collection from file , returns 0 on success
        // returns -1 on error
        public int loadCollection(string fileName)
        {
            int res = 0;
            BookList = ReadFromXmlFile<List<Book>>(fileName);
            return res;
        }

        /// <summary>
        /// Writes the given object instance to an XML file.
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [XmlIgnore] attribute.</para>
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        /// <summary>
        /// Reads an object instance from an XML file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the XML file.</returns>
        public static T ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
