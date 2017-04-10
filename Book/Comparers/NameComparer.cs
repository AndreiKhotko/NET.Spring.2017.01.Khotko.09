using System;
using System.Collections.Generic;

namespace Book.Comparers
{
    public class NameComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException();

            return string.CompareOrdinal(x.Name, y.Name);
        }
    }
}
