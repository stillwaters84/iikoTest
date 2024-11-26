using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iikoTest.Services.Models
{
    public class Client
    {
        [Key]
        public long ClientId { get; set; }

        public required string Username { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SystemId { get; set; }
    }
}
