using BiblioNet.Application.Repositories;
using BiblioNet.Core.Models;

namespace BiblioNet.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository) { _repository = repository; }
        public async Task UpdateSecondVersionOfBooks(List<int> ids)
        {
           
            foreach (int id in ids)
            {
                Book book = await _repository.GetByIdAsync(id);
                book.Title += "_2";
                await _repository.UpdateAsync(book);
            }
        }


       public async Task<List<Book>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            return await _repository.CreateAsync(book);
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            return await _repository.UpdateAsync(book);
        }

        public async Task DeleteByIdAsync(long id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}
