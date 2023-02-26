using BiblioNet.Application.Repositories;
using BiblioNet.Core.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BiblioNet.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connection;

        public BookRepository(IConfiguration config)
        {
            _connection = config.GetConnectionString("postgreDb");
        }

        public async Task<Book> CreateAsync(Book book)
        {
            using NpgsqlConnection con = new(_connection);

            using var cmd = new NpgsqlCommand("INSERT INTO Books (Title, Description) VALUES ($1, $2) RETURNING Id", con)
            {
                Parameters =
                {
                    new() { Value = book.Title },
                    new() { Value = book.Description }
                }
            };

            con.Open();

            var bookId = await cmd.ExecuteScalarAsync();

            con.Close();

            book.Id = (long)bookId;
            return book;
        }

        public async Task DeleteByIdAsync(long id)
        {
            using NpgsqlConnection con = new(_connection);

            using var cmd = new NpgsqlCommand("DELETE FROM Books WHERE Id = $1", con)
            {
                Parameters =
                {
                    new() { Value = id }
                }
            };

            con.Open();

            await cmd.ExecuteNonQueryAsync();

            con.Close();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            using NpgsqlConnection con = new(_connection);

            string query = "SELECT Id, Title, Description FROM Books";
            using NpgsqlCommand cmd = new(query);

            cmd.Connection = con;
            con.Open();

            List<Book> books = new();

            using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    books.Add(new Book
                    {
                        Id = reader.GetInt64(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                    });
                }
            }

            con.Close();

            return books;
        }

        public async Task<Book> GetByIdAsync(long id)
        {
            using NpgsqlConnection con = new(_connection);

            using var cmd = new NpgsqlCommand("SELECT Id, Title, Description FROM Books WHERE Id = $1", con)
            {
                Parameters =
                {
                    new() { Value = id }
                }
            };

            con.Open();

            using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

            var value = await reader.ReadAsync();

            if (!value)
            {
                return null;
            }

            return new Book
            {
                Id = reader.GetInt64(0),
                Title = reader.GetString(1),
                Description = reader.GetString(2),
            };
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            using NpgsqlConnection con = new(_connection);

            using var cmd = new NpgsqlCommand("UPDATE Books SET Title = $1, Description = $2 WHERE Id = $3", con)
            {
                Parameters =
                {
                    new() { Value = book.Title },
                    new() { Value = book.Description },
                    new() { Value = book.Id }
                }
            };

            con.Open();

            await cmd.ExecuteNonQueryAsync();

            con.Close();

            return book;
        }
    }
}
