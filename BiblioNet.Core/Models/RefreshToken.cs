namespace Timesheet.Core.Models
{
    public class RefreshToken
    {
        public int Id;
        public string Token { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ExpireDate { get; set; }
    }
}
