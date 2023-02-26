using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioNet.Infrastructure.Models
{
    [Table("Books")]
    public class BookDAL
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
