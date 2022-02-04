using System.ComponentModel.DataAnnotations.Schema;

namespace JamOrder.Data.Entities
{
    [Table("TokenLog")]
    public class TokenLog : BaseEntity
    {
        public string CustomerId { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}