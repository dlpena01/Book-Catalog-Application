using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DannaPenaranda_Assignment4
{
    public partial class Form1 : Form
    {
        //create an array to reference textboxes objects.
        TextBox[] libraryTextBoxes;
        //create an array to reference label objects of Search for a book tab.
        Label[] libraryLabels;
        //create an array to reference label objects of Select a book title tab.
        Label[] selectBookLabels;
        //create list to reference  Book_Catalogue objects
        List<Book_Catalogue> library_books;
        //globally assigning reference variable to hold  Book_Catalogue 'object'
        Book_Catalogue aBook;
        

        public Form1()
        {
            InitializeComponent();
            //creating array for textboxes and fill it the TextBoxes used for user input
            libraryTextBoxes = new TextBox[] {txtCallNumber, txtBookTitle, txtAuthorName, txtGenre, 
                                                txtNumberOfPages, txtPublisher, txtFileSize };//ass5 included txtFileSize
            //fill libraryLabels with the labels in Search for a book tab.
            libraryLabels = new Label[] {lblTab3Call, lblTab3Title, lblTab3Author, lblTab3Genre, 
                                            lblTab3Pages, lblTab3Publisher};//added lbltab3FileSize for ass5
            //fill selectBookLabels with the labels in tab "Select a book title."
            selectBookLabels = new Label[] { lblCallNumber, lblBookTitle, lblAuthorName, lblGenre, lblNumberPages,
                                             lblPublisher};//added lblFileSize from tab 2 for ass5
            //create list of object Book_Catalogue
            library_books = new List<Book_Catalogue>();
            
        }

        private bool CheckTextBoxes(TextBox[] libraryTextBoxes)
        {
            bool CheckTextBoxes = true;

            foreach(TextBox textbox in libraryTextBoxes)
            {
                if (string.IsNullOrWhiteSpace(textbox.Text))
                {
                    CheckTextBoxes = false;
                }

            }
            return CheckTextBoxes;
        }

        //click event for the btnAddCatalog

        private void btnAddToCatalog_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes(libraryTextBoxes))
            {
                if (ckboxEbook.Checked)
                {
                    AddEBookToCatalogue(txtCallNumber.Text, txtAuthorName.Text, txtGenre.Text, int.Parse(txtNumberOfPages.Text),
                               txtPublisher.Text, txtBookTitle.Text, double.Parse(txtFileSize.Text));
                }
                else
                {
                    AddBookToCatalogue(txtCallNumber.Text, txtAuthorName.Text, txtGenre.Text, int.Parse(txtNumberOfPages.Text),
                                txtPublisher.Text, txtBookTitle.Text);
                }
        
            }
              
            


            PopulateListBox(library_books, lstbxSearchTitle);
            
            
            //get ready to clear textboxes and begin a new add boox to catalogue.
            NewEntry();
          
        }


        //ass5. method requiring the 6 parameter constructor. A student object is created and the arguments
        //are used to match the attributes for the Book_Catalogue object. Then we have a reference variable
        //of the Book_Catalogue that it is added to the list
        private void AddBookToCatalogue(string aCallNumber, string aAuthorName, string aGenre, int aNumberPages,
            string aPublisher, string aBookTitle)
        {
            aBook = new Book_Catalogue(aCallNumber, aAuthorName, aGenre, aNumberPages, aPublisher, aBookTitle);

            library_books.Add(aBook);
        }


        //ass5. method requiring the 7 parameter constructor. A student object is created and the arguments
        //are used to match the attributes for the EBook_Catalogue object. Then we have a reference variable of the
        //EBook_Catalogue that is added to the list.
        private void AddEBookToCatalogue(string aCallNumber, string aAuthorName, string aGenre, int aNumberPages,
                                        string aPublisher, string aBookTitle, double aFileSize)
        {
            aBook = new EBook_Catalogue( aCallNumber, aAuthorName, aGenre, aNumberPages, aPublisher, aBookTitle,
                                            aFileSize);

            library_books.Add(aBook);
        }


        //create method to populate listbox
        private void PopulateListBox(List<Book_Catalogue> aBookCatalogueList, ListBox aBookListBox)
        {
            aBookListBox.Items.Clear();//emptying out items of the listbox

            //Use an instance such that each time it runs, it will display the book title
            //for each instance of the object Book_Catalogue in the aBookListBox
            foreach (Book_Catalogue book in aBookCatalogueList)
            {
                aBookListBox.Items.Add(book.AuthorName);
                //using property BookTitle fromF class
            }
        }

        //create method to get object Book_Catalogue to work the index position of the list library_books
        private Book_Catalogue GetABook_Catalogue(int index)
        {
            return library_books[index];
        }

        //create method for a new entry, so textboxes should be cleared, and focus on first tab
        private void NewEntry()
        {

            //uncheck the checkbox for e-book
            ckboxEbook.Checked = false;

            foreach(TextBox textbox in libraryTextBoxes)
            {
                textbox.Clear();
            }
            //outisde the loop that clears each textbox 
            //NewEntry has the focus to first textbox and first tab
            tabLibrary.SelectedIndex = 0;//invoke the name for the whole group of tabs
            txtCallNumber.Focus();

            //clear also the items being hold by the listbxTitleTab3
            lstbxTitleTab3.Items.Clear();

            //foreach loop for different labels. Those in the "Select a book title tab."
            //call titleLabels becasue they're within the tab that displays titles first.
            foreach (Label titleLabels in selectBookLabels)
            {
                titleLabels.Text = "";
            }

        }

        //create click event for the lstbxSearchTitle even if 
        //selectedIndex changes
        private void lstbxSearchTitle_SelectedIndexChanged(object sender, EventArgs e) /*<--Check*/
        {
            if (lstbxSearchTitle.SelectedIndex != -1)
            {

                //make an if when something is selected (index of lstSearchTitle>=0) in the lstSearchTitle
                //if so, display in lbls calling the GetABook_Catalogue method which returns
                //the library_Books from the lstbxSearchTitle, calling the property for each lbl
                //.CallNumber, .BookTitle so on.
                //NumberPages property has int data type, so to match the
                //.text, will have to .ToString it.


                //here if selectedIndex of the lstbxSearchTitle turns out to be of data type EBook_Catalogue
                if (GetABook_Catalogue(lstbxSearchTitle.SelectedIndex).GetType().ToString() == "EBook_Catalogue")
                {//then inside the if display the file size entered by user in the pertaining label for tab1
                    lblFileSize.Text = ((EBook_Catalogue)GetABook_Catalogue(lstbxSearchTitle.SelectedIndex)).FileSize.ToString();
                }
                else
                {//if the selection wasn't of data type EBook_Catalogue, leave the label intact.
                    lblFileSize.Text = "";
                }
                
                lblCallNumber.Text = GetABook_Catalogue(lstbxSearchTitle.SelectedIndex).CallNumber;
                lblBookTitle.Text = GetABook_Catalogue(lstbxSearchTitle.SelectedIndex).BookTitle;
                lblAuthorName.Text = GetABook_Catalogue(lstbxSearchTitle.SelectedIndex).AuthorName;
                lblGenre.Text = GetABook_Catalogue(lstbxSearchTitle.SelectedIndex).Genre;
                lblNumberPages.Text = GetABook_Catalogue(lstbxSearchTitle.SelectedIndex).NumberPages.ToString();
                lblPublisher.Text = GetABook_Catalogue(lstbxSearchTitle.SelectedIndex).Publisher;
                
                
            }
        }

        //a method created to reset 

        //**third tab**
        //create method using the Book_Catalogue objects, 
        //so as first parameter is the list, and second parameter is a 
        //rerurning varaible type string
        //to hold results. This method is only to search for a call number
        
        private List<Book_Catalogue> CriterionByCallNumber(List<Book_Catalogue> callList, string criterionValue)
        {
            List<Book_Catalogue> criterionResult = new List<Book_Catalogue>();//a new list that hold objects of Book_Catalogue 
            //called only for criterionResult

            //in each instance of the Book_Catalogue object in callList
            foreach(Book_Catalogue book in callList)
            {
                if (book.CallNumber.ToUpper() == criterionValue.ToUpper())
                {//varaible book uses property CallNumber in each instance to be 
                    //shown in upper case compares it to the value by user in upper case
                    criterionResult.Add(book);//then add each instance of that book
                }                              //to the criterionResult list
            }
            return criterionResult;//outside loop return the list
        }

        //create a method identical to CriterionByCallNumber
        //except here we want to know the 
        //criteria by book title
        //the parameters are almost the same with different names
        
        private List<Book_Catalogue> CriterionByBookTitle(List<Book_Catalogue> titleList, string criterionValue)
        {
            List<Book_Catalogue> criterionResult = new List<Book_Catalogue>();

            foreach (Book_Catalogue title in titleList)
            {
                if (title.BookTitle.ToUpper() == criterionValue.ToUpper())
                {
                    criterionResult.Add(title);
                }
            }
            return criterionResult;
        }

        //same structure of method, but here it is looking for AuthorName

        private List<Book_Catalogue> CriterionByAuthorName(List<Book_Catalogue> authorList, string criterionValue)
        {
            List<Book_Catalogue> criterionResult = new List<Book_Catalogue>();

            foreach (Book_Catalogue author in authorList)
            {
                if (author.AuthorName.ToUpper() == criterionValue.ToUpper())
                {
                    criterionResult.Add(author);
                }
            }
            return criterionResult;

        }

        //method searching by genre
        private List<Book_Catalogue> CriterionByGenre(List<Book_Catalogue> genreList, string criterionValue)
        {
            List<Book_Catalogue> criterionResult = new List<Book_Catalogue>();

            foreach (Book_Catalogue genre in genreList)
            {
                if(genre.Genre.ToUpper()==criterionValue.ToUpper())
                {
                    criterionResult.Add(genre);
                }  
            }
            return criterionResult;
        }

        //method searches by publisher
        private List<Book_Catalogue> CriterionByPublisher(List<Book_Catalogue> publisherList, string criterionValue)
        {
            List<Book_Catalogue> criterionResult = new List<Book_Catalogue>();

            foreach (Book_Catalogue publisher in publisherList)
            {
                if (publisher.Publisher.ToUpper() == criterionValue.ToUpper())
                {
                    criterionResult.Add(publisher);
                }
            }
            return criterionResult;
        }

        //this click event searches the Book_Catalogue list 
        private void button1_Click(object sender, EventArgs e)
        {
            //well need a swith statement, so we will need indexes for the criteria 0 = callnumber
            //1 = booktitle, 2 = authorname, 3=genre and 4= publisher
            const int CALL_NUMBER_INDEX = 0;
            const int BOOK_TITLE_INDEX = 1;
            const int AUTHOR_NAME_INDEX = 2;
            const int GENRE_INDEX = 3;
            const int PUBLISHER_INDEX = 4;

            

            //if statement to make sure user has selected something from combxSearch
            if (combxSearch.SelectedIndex != -1)
            {
                if(!string.IsNullOrWhiteSpace(txtSearchTerm.Text))//if so, there must be any input
                {
                    switch(combxSearch.SelectedIndex)// as swicth will help us obtain which search they opt for
                {
                    case CALL_NUMBER_INDEX://is it by call number? the const is 0, for case 0:
                        if (CriterionByCallNumber(library_books, txtSearchTerm.Text).Count > 0)
                        {//call method that delas with call number, have two arguments: the Book_Catalogue list to hold 
                            //objects and the txtsearchterm which is crucial to make any retribution. 
                            //if search by callnumber is more than 0
                            PopulateListBox(CriterionByCallNumber(library_books, txtSearchTerm.Text), lstbxTitleTab3);
                            //then call populatelstbox lstbxTitleTab3 with the rules of criterionbycallnumber, list
                            //and txtbox
                        }
                        else
                        {
                            MessageBox.Show("No call number of" + txtSearchTerm.Text + "was found.",
                                "Call number not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //if search returned 0 then, sorry there was nothing of that sort found.
                            //same structure goes on for the book title, author name, genre, 
                            //and publisher. Searching by number of pages is silly.
                        }
                        break;
                        case BOOK_TITLE_INDEX:
                        if (CriterionByBookTitle(library_books, txtSearchTerm.Text).Count > 0)
                        {
                            PopulateListBox(CriterionByBookTitle(library_books, txtSearchTerm.Text), lstbxTitleTab3);

                        }
                        else
                        {
                            MessageBox.Show("No book title of " + txtSearchTerm.Text + "was found.",
                                "Book title not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                        case AUTHOR_NAME_INDEX:
                        if (CriterionByAuthorName(library_books, txtSearchTerm.Text).Count > 0)
                        {
                            PopulateListBox(CriterionByAuthorName(library_books, txtSearchTerm.Text), lstbxTitleTab3);
                        }
                        else
                        {
                            MessageBox.Show("No author name by" + txtSearchTerm.Text + "was found.",
                                "Author name not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                        case GENRE_INDEX:
                        if (CriterionByGenre(library_books, txtSearchTerm.Text).Count > 0)
                        {
                            PopulateListBox(CriterionByGenre(library_books, txtSearchTerm.Text), lstbxTitleTab3);
                        }
                        else
                        {
                            MessageBox.Show("No genre by" + txtSearchTerm.Text + "was found.",
                                "Genre not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                        case PUBLISHER_INDEX:
                        if (CriterionByPublisher(library_books, txtSearchTerm.Text).Count > 0)
                        {
                            PopulateListBox(CriterionByPublisher(library_books, txtSearchTerm.Text), lstbxTitleTab3);
                        }
                        else
                        {
                            MessageBox.Show("No publisher by" + txtSearchTerm.Text + "was found.",
                                "Publisher not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                            //kill switch
                    }
                    
                    //user must put in txtbox a value, so that we know how to match genre with say fiction, pusblisher with
                    //maybe Pearson and so on. Otherwise we don't know how else to match that criterion with registry
                    //so we must have user input of any sort
                }
                    else
                    {
                        MessageBox.Show("Dear user, please enter a search value so that we know how to match it our catalogue.", 
                            "An error happens if you don't give us any clue in the search term box.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSearchTerm.Focus();//Wanted to have fun with the app so I was
                                            //wordy
                    }
                }//ends first if statement
            }

        //method to return a Book_Catalogue object, specifically the book title
        private Book_Catalogue GetTitle(int index)
        {
            return library_books[index];
        }

        
        private void lstbxTitleTab3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //click event for the selection of anything in the lstbxTitleTab3
            //with an if statement that tries if anything has been selected with selected.index

            if (lstbxTitleTab3.SelectedIndex != -1)
            {
                lblTab3Call.Text = GetTitle(lstbxSearchTitle.SelectedIndex).CallNumber;
                lblTab3Title.Text=GetTitle(lstbxSearchTitle.SelectedIndex).BookTitle;
                lblTab3Author.Text = GetTitle(lstbxSearchTitle.SelectedIndex).AuthorName;
                lblTab3Genre.Text = GetTitle(lstbxSearchTitle.SelectedIndex).Genre;
                lblTab3Pages.Text = GetTitle(lstbxSearchTitle.SelectedIndex).NumberPages.ToString();
                lblTab3Publisher.Text = GetTitle(lstbxSearchTitle.SelectedIndex).Publisher;
                //call my class properties/accessors, .ToString to make NumberPages a string.


                //for this if is the almost the same as for tab1 labels, except here it is the tab2.
                //we also have a label destined to display file size in tab2.
                //so we're looking if selection was indeed of data type EBook_Catalogue.
                if (GetTitle(lstbxTitleTab3.SelectedIndex).GetType().ToString() == "EBook_Catalogue")
                {//also, this time we're calling the method that uses the GetTitle method, which passes indexes
                    //from the lstbxSearchTitle to lstbxTitleTab3
                    lblTab3FileSize.Text = ((EBook_Catalogue)GetTitle(lstbxTitleTab3.SelectedIndex)).FileSize.ToString();
                }
                else
                {
                    lblTab3FileSize.Text = "";
                }
            }
        }

        
        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear button to let user clear the search, labels, txtSearchTerm, focus on cmbxSearch, 
            //clear the lstbxSearchTitle, lstbxTitleTab3,
            // use foreach loop, less work and work with the libraryLabels array
            foreach(Label labels in libraryLabels)
            {
                labels.Text = "";

            }

            combxSearch.SelectedIndex = -1;//make no focus on cmbbx
            txtSearchTerm.Text = "";//clear txtbx   
            txtSearchTerm.Focus();//

            lstbxTitleTab3.Items.Clear();//clear both lstsbxs
            lstbxSearchTitle.Items.Clear();

            //also for a new registry of books, we must clear the intermediary
            //list, that is, erasing those entries from memory

            library_books.Clear();

            NewEntry();//call method to begin a new entry


        }

        //for this method we're checking wheter the ckbxEbook was checked. If so enable
        //user to input info for the txtFileSize. Otherwise unable the txtbxFileSize, if he didn't.
        private void ckboxEbook_CheckedChanged(object sender, EventArgs e)
        {
            if (ckboxEbook.Checked)
            {
                txtFileSize.Enabled = true;
            }
            else
            {
                txtFileSize.Enabled = false;
            }
        }

            }

        }
       

        
    

