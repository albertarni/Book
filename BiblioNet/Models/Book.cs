using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioNet.Models
{
    [Table("Books")]
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
