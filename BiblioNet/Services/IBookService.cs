using BiblioNet.Models;

namespace BiblioNet.Services
{
    public interface IBookService
    {
        public Task UpdateSecondVersionOfBooks(List<int> ids);

        Task<List<Book>> GetAllAsync();

        Task<Book> GetByIdAsync(long id);

        Task<Book> CreateAsync(Book book);

        Task<Book> UpdateAsync(Book book);

        Task DeleteByIdAsync(long id);
    }
}
