using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    //Author: Danna Penaranda
    //Course: CIS199-01. Assignment 4.
    //Created on: April 2/2014
    //

    class Book_Catalogue
    {
        //attributes.
        private string callNumber;//private bc code outside this class cannot directly access it.
        private string bookTitle;
        private string authorName;
        private string genre;
        private int numberPages;//dataype int bc we need to be able to record number in pages not as string characters
        private string publisher;//but actual numbers
        
        //constructor
        public Book_Catalogue(string aCallNumber, string aAuthorName, string aGenre, int aNumberPages,
            string aPublisher)//constructor with 5 parameters.
        {
            callNumber = aCallNumber;
            authorName = aAuthorName;
            genre = aGenre;
            numberPages = aNumberPages;
            publisher = aPublisher;

        }
        //constructor with 6 parameters.

        public Book_Catalogue(string aCallNumber, string aAuthorName, string aGenre, int aNumberPages,
            string aPublisher, string aBookTitle)
        {
            callNumber = aCallNumber;
            authorName = aAuthorName;
            bookTitle = aBookTitle;
            genre = aGenre;
            numberPages = aNumberPages;
            publisher = aPublisher;
        }


        //accessors/properties
        public string CallNumber
        {
            set { callNumber = value; }

            get { return callNumber; }
        }

        public string BookTitle
        {
            set { bookTitle = value; }

            get { return bookTitle; }
        }

        public string AuthorName
        {
            set { authorName = value; }

            get { return authorName; }
        }

        public string Genre
        {
            set { genre = value; }

            get { return genre; }
        }

        public int NumberPages
        {
            set { numberPages = value; }

            get { return numberPages; }
        }

        public string Publisher
        {
            set { publisher = value; }

            get { return publisher; }
        }

        //do the same here and override each Student object as a string thanks to 
        //.ToString each time it is used
        public override string ToString()
        {
            return base.ToString();
        }
    }

