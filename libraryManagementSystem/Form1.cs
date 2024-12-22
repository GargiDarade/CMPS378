using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace libraryManagementSystem
{
    public partial class FormLibMgmt : Form
    {
        BookCollection bookcoll;
        int dgViewIndex = 0;
        bool LastRowSelected = false;
        bool editStarted = false;
        public FormLibMgmt()
        {
            InitializeComponent();
        }

        private void bindDisplayBooks(List<Book> books)
        {
            labelBooks.Text = books.Count.ToString();
            //Create a DataTable and define the columns
            DataTable table = new DataTable();
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Author", typeof(string));
            table.Columns.Add("No. Copies", typeof(int));
            table.Columns.Add("Checkout by.", typeof(string));
            //Add Rows
            if (books != null)
            {
                string names = "";
                //string name="";
                foreach (Book book in books)
                {
                    names = "";
                    for(int i=0;i<book.CheckoutNameList.Count;i++)
                    {
                        if (i == 0) names = book.CheckoutNameList[i];
                        else names = names + "," + book.CheckoutNameList[i];
                    }

                    table.Rows.Add(book.Title, book.Author, book.Copies, names); 
                }
            }
            //Binding DataGridView
            dgViewBooks.DataSource = table;
        }
        private void FormLibMgmt_Load(object sender, EventArgs e)
        {
            //comboBoxFilter
            int res;
            bookcoll = new BookCollection("../../lib.xml");
            res = bookcoll.loadCollection(bookcoll.FileName);
            bindDisplayBooks(bookcoll.BookList);
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            string filterStr = comboBoxFilter.Text;
            int count=0;
            List<Book> foundList = null;
            if (filterStr == "All")
            {
                bindDisplayBooks(bookcoll.BookList);
            }
            else if (filterStr == "Title")
            {
                foundList = bookcoll.searchBook(textBoxFilter.Text, 0, ref count);
                bindDisplayBooks(foundList);
            }
            else if (filterStr == "Author")
            {
                foundList = bookcoll.searchBook(textBoxFilter.Text, 1, ref count);
                bindDisplayBooks(foundList);
            }
        }

        private void dgViewBooks_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //show the context menu on right-click
            if (e.Button == MouseButtons.Right)
            {
                this.dgViewBooks.Rows[e.RowIndex].Selected = true;
                this.dgViewIndex = e.RowIndex;
                this.dgViewBooks.CurrentCell = this.dgViewBooks.Rows[e.RowIndex].Cells[1];
                this.contextMenuStripAction.Show(this.dgViewBooks, e.Location);
                contextMenuStripAction.Show(Cursor.Position);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure want to Delete", "confirmation", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                string title = dgViewBooks.Rows[dgViewIndex].Cells[0].Value.ToString(); // Getting the titleof book from row.
                int result = bookcoll.deleteBook(title, 0);
                if (result == 0)
                {
                    MessageBox.Show("Record Deleted Successfully");
                    buttonFilter_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Record not Deleted....Please try again.");
                }
            }
        }

        private void dgViewBooks_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //MessageBox.Show("NewRowNeeded:" + "last empty row selected New Row needed " + dgViewBooks.RowCount );

            LastRowSelected=true;
            //MessageBox.Show("NewRowNeeded:prv row " + "Title:" + dgViewBooks.Rows[dgViewBooks.RowCount - 2].Cells[0].Value.ToString() + " Author:" + dgViewBooks.Rows[dgViewBooks.RowCount - 2].Cells[1].Value.ToString());
            

        }

        private void dgViewBooks_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }
            if (LastRowSelected)
            {
                LastRowSelected = false;
                //MessageBox.Show("RowsAdded:" + "first cell start edit, New Row Adeded" + "IsNewRow" + dgViewBooks.Rows[e.RowIndex].IsNewRow.ToString());
                //if (dgViewBooks.Rows[e.RowIndex].IsNewRow) { return; }
                /*
                for (int index = e.RowIndex; index <= e.RowIndex + e.RowCount - 1; index++)
                {
                    DataGridViewRow row = dgViewBooks.Rows[index-1];
                    if(row.Cells[0].Value.ToString()=="")
                        MessageBox.Show("Please enter the Title of the book " + row.Cells[0].Value.ToString());
                    if (row.Cells[1].Value.ToString() == "")
                        MessageBox.Show("Please enter the Author of the book " + row.Cells[1].Value.ToString());

                }
                */ 
            }
        }

        private void dgViewBooks_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (LastRowSelected)
            //{
                //dgViewBooks[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Blue;
                //dgViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.Blue;
                //MessageBox.Show("CellLeave:" + e.RowIndex.ToString() + " enterd Value: " + dgViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " IsNewRow:" + dgViewBooks.Rows[e.RowIndex].IsNewRow.ToString());
            //}

        }

        private void dgViewBooks_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //dgViewBooks.Rows[e.RowIndex].Cells[0].Style.SelectionBackColor = Color.Red;
            //MessageBox.Show("RowLeave:" + e.RowIndex.ToString() + " Title:" + dgViewBooks.Rows[e.RowIndex].Cells[0].Value.ToString() + " Author:" + dgViewBooks.Rows[e.RowIndex].Cells[1].Value.ToString() + " IsNewRow:" + dgViewBooks.Rows[e.RowIndex].IsNewRow.ToString());
        }

         private void formVisibleChanged(object sender, EventArgs e)
        {
            editOrNew frm = (editOrNew)sender;
            string labelEdit = frm.Controls["labelEdit"].Text;
            if (!frm.Visible && labelEdit == "Edit")
            {
                string orgTitle = dgViewBooks.Rows[dgViewIndex].Cells[0].Value.ToString();
                //string orgAuthor = dgViewBooks.Rows[dgViewIndex].Cells[1].Value.ToString();

                string title = frm.Controls["txtBoxEdtTitle"].Text;
                string author = frm.Controls["txtBoxEdtAuth"].Text;
                string names = frm.Controls["txtBoxNames"].Text;
                string copies = frm.Controls["txtBoxCopies"].Text;
                int noCopies = Convert.ToInt32(copies);

                string[] namesArry = names.Split(',');
                                    
                //edit book
                Book resBook = null;
                resBook = new Book(title, author, noCopies);
                foreach (string name in namesArry)
                    resBook.CheckoutNameList.Add(name.Trim());
                int res = bookcoll.editBook(resBook, orgTitle);
                buttonFilter_Click(sender, e);
                frm.Dispose();
            }
            else if (!frm.Visible && labelEdit == "Add New")
            {
                string title = frm.Controls["txtBoxEdtTitle"].Text;
                string author = frm.Controls["txtBoxEdtAuth"].Text;
                string names = frm.Controls["txtBoxNames"].Text;
                string copies = frm.Controls["txtBoxCopies"].Text;
                int noCopies = Convert.ToInt32(copies);
                string[] namesArry = names.Split(',');

                //add book
                Book resBook = null;
                resBook = new Book(title, author, noCopies);
                foreach (string name in namesArry)
                    resBook.CheckoutNameList.Add(name.Trim());
                int res = bookcoll.addBook(resBook);
                buttonFilter_Click(sender, e);
                frm.Dispose();
            } if (!frm.Visible && labelEdit == "Check out")
            {
                string orgTitle = dgViewBooks.Rows[dgViewIndex].Cells[0].Value.ToString();
                Book resBook = null;
                //searchType = 0 search on title
                int res = bookcoll.searchBook(ref resBook, orgTitle, 0);
                if (res == 0)
                {
                    //found
                    res = bookcoll.checkOutBook(resBook, frm.Controls["txtBoxNames"].Text);
                }
                buttonFilter_Click(sender, e);
                frm.Dispose();
            } if (!frm.Visible && labelEdit == "Check in")
            {
                string orgTitle = dgViewBooks.Rows[dgViewIndex].Cells[0].Value.ToString();
                Book resBook = null;
                //searchType = 0 search on title
                int res = bookcoll.searchBook(ref resBook, orgTitle, 0);
                if (res == 0)
                {
                    //found
                    res = bookcoll.checkInBook(resBook, frm.Controls["txtBoxNames"].Text);
                }
                buttonFilter_Click(sender, e);
                frm.Dispose();
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editOrNew editOrNewDialog = new editOrNew();
            editOrNewDialog.VisibleChanged += formVisibleChanged;
            string title = dgViewBooks.Rows[dgViewIndex].Cells[0].Value.ToString();
            string author = dgViewBooks.Rows[dgViewIndex].Cells[1].Value.ToString();
            string noCopies = dgViewBooks.Rows[dgViewIndex].Cells[2].Value.ToString();
            string names = dgViewBooks.Rows[dgViewIndex].Cells[3].Value.ToString();
            editOrNewDialog.Controls["txtBoxEdtTitle"].Text = title;
            editOrNewDialog.Controls["txtBoxEdtAuth"].Text = author;
            editOrNewDialog.Controls["txtBoxCopies"].Text = noCopies;
            editOrNewDialog.Controls["txtBoxNames"].Text = names;
            editOrNewDialog.ShowDialog(this);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //labelEdit
            editOrNew editOrNewDialog = new editOrNew();
            editOrNewDialog.VisibleChanged += formVisibleChanged;
            editOrNewDialog.Controls["labelEdit"].Text = "Add New";
            editOrNewDialog.Controls["txtBoxCopies"].Text = "1";
            editOrNewDialog.ShowDialog(this);

        }

        private void FormLibMgmt_FormClosed(object sender, FormClosedEventArgs e)
        {
            //save book collection to xml file
            bookcoll.saveCollection(bookcoll.FileName);
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editOrNew editOrNewDialog = new editOrNew();
            editOrNewDialog.VisibleChanged += formVisibleChanged;
            editOrNewDialog.Controls["labelEdit"].Text = "Check out";
            string title = dgViewBooks.Rows[dgViewIndex].Cells[0].Value.ToString();
            string author = dgViewBooks.Rows[dgViewIndex].Cells[1].Value.ToString();
            string noCopies = dgViewBooks.Rows[dgViewIndex].Cells[2].Value.ToString();
            //string names = dgViewBooks.Rows[dgViewIndex].Cells[3].Value.ToString();
            editOrNewDialog.Controls["txtBoxEdtTitle"].Text = title;
            editOrNewDialog.Controls["txtBoxEdtAuth"].Text = author;
            editOrNewDialog.Controls["txtBoxCopies"].Text = noCopies;
            //editOrNewDialog.Controls["txtBoxNames"].Text = names;
            editOrNewDialog.ShowDialog(this);
        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editOrNew editOrNewDialog = new editOrNew();
            editOrNewDialog.VisibleChanged += formVisibleChanged;
            editOrNewDialog.Controls["labelEdit"].Text = "Check in";
            string title = dgViewBooks.Rows[dgViewIndex].Cells[0].Value.ToString();
            string author = dgViewBooks.Rows[dgViewIndex].Cells[1].Value.ToString();
            string noCopies = dgViewBooks.Rows[dgViewIndex].Cells[2].Value.ToString();
            //string names = dgViewBooks.Rows[dgViewIndex].Cells[3].Value.ToString();
            editOrNewDialog.Controls["txtBoxEdtTitle"].Text = title;
            editOrNewDialog.Controls["txtBoxEdtAuth"].Text = author;
            editOrNewDialog.Controls["txtBoxCopies"].Text = noCopies;
            //editOrNewDialog.Controls["txtBoxNames"].Text = names;
            editOrNewDialog.ShowDialog(this);
        }
    }
}
