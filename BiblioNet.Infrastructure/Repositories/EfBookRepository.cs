
using BiblioNet.Application.Repositories;
using BiblioNet.Core.Models;
using BiblioNet.Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;

namespace BiblioNet.Infrastructure.Repositories
{
    public class EfBookRepository : IBookRepository
    {
        private readonly BiblioNetContext _context;

        public EfBookRepository(BiblioNetContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            _context.Books.Add(book.fromBookToBookDAL());
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task DeleteByIdAsync(long id)
        {
            var book = await _context.Books.FindAsync(id);

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var result =  _context.Books.AsNoTracking().Select(Converter.fromBookDALToBook);
            return await Task.FromResult(result.ToList());
        }

        public async Task<Book> GetByIdAsync(long id)
        {
            var book = await _context.Books.FindAsync(id);

            return book.fromBookDALToBook();
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            var savedBook = await _context.Books.FindAsync(book.Id);

            savedBook.Title = book.Title;
            savedBook.Description = book.Description;

            await _context.SaveChangesAsync();

            return savedBook.fromBookDALToBook();
        }
    }
}
