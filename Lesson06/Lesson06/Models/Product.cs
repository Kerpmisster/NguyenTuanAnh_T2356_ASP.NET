using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson06.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Cấm được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(150)")]
        public byte Image { get; set; }
        [Required(ErrorMessage = "Cấm được để trống")]
        public float Price { get; set; }
        public float SalePrice { get; set; }
        public byte Status { get; set; }
        [StringLength(1000)]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Cấm được để trống")]
        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }
        public Category Category { get; set; }
    }
}
