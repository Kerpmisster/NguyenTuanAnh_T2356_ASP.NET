using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Banner")]
    public class Banner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string? Name { get; set; }
        public byte? Status { get; set; }
        public int Prioty { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
}
