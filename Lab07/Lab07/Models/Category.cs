using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        public byte? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Image {  get; set; }
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set;} = new List<Product>();
    }
}
