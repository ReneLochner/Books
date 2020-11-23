using Books.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Core.Contracts
{
    public interface IBookRepository
    {
        Task AddRangeAsync(IEnumerable<Book> books);
        void DeleteBook(Book selectedBook);
        Task<Book[]> GetBooksByFilterAsync(string filterText);
        Task<string[]> GetAllPublishersAsync();
    }
}