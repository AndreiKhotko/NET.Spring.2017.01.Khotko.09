using System;
using System.Collections.Generic;

namespace Book.Comparers
{
    public class PageCountComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException();

            if (x.PageCount > y.PageCount)
                return 1;
            if (x.PageCount == y.PageCount)
                return 0;

            return -1;
        }
    }
}
