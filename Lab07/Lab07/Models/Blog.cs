using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string? Name { get; set; }
        public byte? Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        [Required]
        [StringLength(1500)]
        [DataType(DataType.Text)]
        public string? Description { get; set; }
    }
}
