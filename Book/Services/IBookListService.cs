using System;
using System.Collections.Generic;

namespace Book.Services
{
    public interface IBookListService
    {
        void AddBook(Book book);
        void RemoveBook(Book book);
        Book FindBookByTag(Predicate<Book> predicate);
        void SortBooksByTag(IComparer<Book> comparer);
    }
}
