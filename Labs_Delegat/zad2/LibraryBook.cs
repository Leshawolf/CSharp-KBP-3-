using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    delegate void DelegatToSortZad2();
    class LibraryBook
    {
        public Book[] books;

        public LibraryBook(Book[] books)
        {
            this.books = books;
        }

        public void SortLibrary(DelegatToSortZad2 d)
        {
            d.Invoke();
        }
        public void SortName()
        {
            books = books.OrderBy(e => e.Name).ToArray();
        }
        public void SortAuthor()
        {
            books = books.OrderBy(e => e.Author).ToArray();
        }
        public void SortPublishing()
        {
            books = books.OrderBy(e => e.Publish).ToArray();
        }



        public override string ToString()
        {
            string s = "";
            foreach (var book in books)
            {
                s += $"Название: {book.Name}\n Автор: {book.Author}\n Издание: {book.Publish}\n\n";
            }
            return s;
        }
    }
}
