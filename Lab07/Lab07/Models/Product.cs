using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float? Price { get; set; }
        public float? salePrice { get; set; }
        public byte? Status { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; }
    }
}
