using System;
using System.Collections.Generic;
using System.Linq;
using Book.Comparers;

namespace Book
{
    public class Book
    {
        public string Name { get; }
        public string Author { get; }
        public string Genre { get; }

        public int PageCount
        {
            get { return pageCount; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Page count value is negative");

                pageCount = value;
            }
        }
        
        private int pageCount;
        
        public Book(string name, string author, string genre, int pageCount)
        {
            Name = name;
            Author = author;
            Genre = genre;
            PageCount = pageCount;
        }

        public override string ToString()
        {
            return $"Book --> {Name}, {Author}, {Genre}, {PageCount}";
        }

        public bool Equals(Book book)
        {
            if (book == null)
                throw new ArgumentNullException();

            List<IComparer<Book>> comparers = new List<IComparer<Book>>();
            comparers.Add(new NameComparer());
            comparers.Add(new AuthorComparer());
            comparers.Add(new GenreComparer());
            comparers.Add(new PageCountComparer());

            return comparers.All(comparer => comparer.Compare(this, book) == 0);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Book);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Name.GetHashCode() + Author.GetHashCode() + Genre.GetHashCode() + PageCount.GetHashCode();
            }
        }
    }
}
