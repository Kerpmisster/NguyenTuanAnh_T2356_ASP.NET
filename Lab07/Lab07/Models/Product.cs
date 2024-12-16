using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string? Name { get; set; }
        [Required]
        public float? Price { get; set; }
        public float? salePrice { get; set; }
        public byte? Status { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [DataType(DataType.Upload)]
        public string? Image { get; set; }
        [StringLength(1500)]
        [DataType(DataType.Text)]
        public string? Description { get; set; }
        public Category Category { get; set; }
    }
}
