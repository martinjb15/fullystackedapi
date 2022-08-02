using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fullystackedapi.Models.insurance
{
    public class CustomerDetail
    {
        // create db entrys
        [Key]
        public int generatedKeyId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }
    }
}
