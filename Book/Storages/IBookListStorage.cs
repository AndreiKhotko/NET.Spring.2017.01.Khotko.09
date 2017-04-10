using System.Collections.Generic;

namespace Book.Storages
{
    public interface IBookListStorage
    {
        void SaveStorage(List<Book> storage);
        void LoadStorage(out List<Book> storage);
    }
}
