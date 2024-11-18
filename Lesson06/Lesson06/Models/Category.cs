using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson06.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Cấm được để trống")]
        [StringLength(100)]
        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "tinyint")]
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Product> Products { get; set;}

    }
}
