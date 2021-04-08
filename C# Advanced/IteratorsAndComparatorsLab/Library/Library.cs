using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books, new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            //return new LibraryIterator(books);
            foreach (var book in books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return books.GetEnumerator();
        }

        //private class LibraryIterator : IEnumerator<Book>
        //{
        //    private readonly SortedSet<Book> books;
        //    private int currentIndex;

        //    public LibraryIterator(SortedSet<Book> books)
        //    {
        //        Reset();
        //        this.books = books;
        //    }

        //    public Book Current => books[currentIndex];

        //    object IEnumerator.Current => Current;

        //    public void Dispose() { }

        //    public bool MoveNext()
        //    {
        //        return ++currentIndex < books.Count;
        //    }

        //    public void Reset()
        //    {
        //        currentIndex = -1;
        //    }
        //}
    }
}
