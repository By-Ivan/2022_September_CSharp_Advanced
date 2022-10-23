using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        //public void ForEach(params Action<Book>[] action)
        //{
        //    for (int j = 0; j < action.Length; j++)
        //    {
        //        for (int i = 0; i < books.Count; i++)
        //        {
        //            action[j](books[i]);
        //        }
        //    }
        //}

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < books.Count; i++)
            {
                yield return books[i];
            }

            //return new LibraryIterator(this.books.OrderBy(x => x));
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        //private class LibraryIterator : IEnumerator<Book>
        //{
        //    private readonly List<Book> books;
        //    private int currentIndex;

        //    public LibraryIterator(IEnumerable<Book> books)
        //    {
        //        this.Reset();
        //        this.books = new List<Book>(books);
        //    }

        //    public Book Current => this.books[this.currentIndex];

        //    object IEnumerator.Current => this.Current;

        //    public void Dispose() { }

        //    public bool MoveNext() => ++this.currentIndex < this.books.Count;

        //    public void Reset() => this.currentIndex = -1;
        //}
    }
}