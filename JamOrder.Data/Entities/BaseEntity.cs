using MicroOrm.Dapper.Repositories.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamOrder.Data.Entities
{
    public class BaseEntity
    {
        [Key, Identity]
        public Guid Id { get; set; } = Guid.NewGuid();

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreatedAt { get; set; } = DateTime.Now;

        [UpdatedAt]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset UpdatedAt { get; set; } = DateTime.Now;
    }
}