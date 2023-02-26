using BiblioNet.Dtos;
using BiblioNet.Models;
using Microsoft.AspNetCore.Mvc;
using BiblioNet.Services;

namespace BiblioNet.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _service;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _service = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateAsync([FromBody] BookCreationDto book)
        //{
        //    return Ok(await _service.CreateAsync(new Book { Title = book.Title, Description = book.Description }));
        //}
        [HttpPut]
        public async Task<IActionResult> InsertAsync([FromBody] List<int> ids)
        {
            await _service.UpdateSecondVersionOfBooks(ids);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateByIdAsync([FromBody] BookDto book)
        {
            return Ok(await _service.UpdateAsync(new Book 
            { 
                Id = book.Id,
                Title = book.Title, 
                Description = book.Description 
            }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(long id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
    }
}