using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioNet.Models
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfCharacters { get; set; } 
    }
}
