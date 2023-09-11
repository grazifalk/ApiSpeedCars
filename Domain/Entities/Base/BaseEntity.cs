using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
