using System;
using System.IO;
using System.Collections.Generic;

namespace Book.Storages
{
    public class BinaryFileStorage : IBookListStorage
    {
        private readonly string filePath;

        public BinaryFileStorage(string filePath)
        {
            this.filePath = filePath;
        }
        public void SaveStorage(List<Book> storage)
        {
            if (storage == null)
                throw new ArgumentNullException();
            
            using (var writer = new BinaryWriter(File.OpenWrite(filePath)))
            {
                foreach (var book in storage)
                {
                    writer.Write(book.Name);
                    writer.Write(book.Author);
                    writer.Write(book.Genre);
                    writer.Write(book.PageCount);
                }
            }
        }

        public void LoadStorage(out List<Book> storage)
        {
            using (var binaryReader = new BinaryReader(File.OpenRead(filePath)))
            {
                storage = new List<Book>();

                while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                {
                    var name = binaryReader.ReadString();
                    var author = binaryReader.ReadString();
                    var genre = binaryReader.ReadString();
                    var pageCount = binaryReader.ReadInt32();

                    Book book = new Book(name, author, genre, pageCount);

                    if (!storage.Contains(book))
                        storage.Add(book);
                }
            }
        }
    }
}
