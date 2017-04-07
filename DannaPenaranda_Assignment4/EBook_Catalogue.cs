using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Author Danna Penaranda
//Created on 4/9/2014
//This is a concept, or is a relationship of the parent class Book_Catalogue. For this class we to add
//an attribute datatype doube for the fileSize. The constructor adds the parent class constructor with :base
//In the EBook_Catalogue we added another parameter: double aFileSize
//****Disclamer: This is assignment 5. As I ran out of time I realized I didn't change the name of
// my project, because I didn't want to try something
//that will break my project due to broken links****
    class EBook_Catalogue:Book_Catalogue//class will inherit all the atrributes, properties that
    {                                   //Book_Catalogue had.
        private double fileSize;//Here the unique attribute will go

        //constructor for this class following the 6 constructor parameter
        public EBook_Catalogue(string aCallNumber, string aAuthorName, string aGenre, int aNumberPages,
                string aPublisher, string aBookTitle, double aFileSize):base ( aCallNumber, aAuthorName,  aGenre,
           aNumberPages, aPublisher, aBookTitle)
       
        {
            fileSize = aFileSize;

        }

        //accessor that is unique to an ebook
        public double FileSize
        {
            set { fileSize = value; }
            get { return fileSize;}
        }

        //for each value of the EBook_Catalogue object is given as a string, override the parent class, thanks to 
        //.ToString, each time it is used.
        public override string ToString()
        {
            return base.ToString();
        }

    }

