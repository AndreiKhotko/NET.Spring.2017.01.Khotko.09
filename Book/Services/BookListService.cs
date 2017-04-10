using System;
using System.Collections;
using System.Collections.Generic;
using Book.UserExceptions;
using Book.Storages;

namespace Book.Services
{
    public class BookListService : IBookListService, IEnumerable<Book>
    {
        private List<Book> books;

        public BookListService()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (books.Contains(book))
                throw new DuplicateBookException($"Book {book.Name} is already in storage");

            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (!books.Contains(book))
                throw new BookNotFoundException($"Book {book.Name} was not found in storage");

            books.Remove(book);
        }
        public Book FindBookByTag(Predicate<Book> predicate) => books.Find(predicate);

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            books.Sort(comparer);
        }

        public void SaveStorage(IBookListStorage storageExtern)
        {
            storageExtern.SaveStorage(books);
        }

        public void LoadStorage(IBookListStorage storageExtern)
        {
            storageExtern.LoadStorage(out books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return ((IEnumerable<Book>)books).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
