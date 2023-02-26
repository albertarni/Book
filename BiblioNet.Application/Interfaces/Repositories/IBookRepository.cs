
using BiblioNet.Core.Models;

namespace BiblioNet.Application.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();

        Task<Book> GetByIdAsync(long id);

        Task<Book> CreateAsync(Book book);

        Task<Book> UpdateAsync(Book id);

        Task DeleteByIdAsync(long id);
    }
}
