using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Blog")]
    public class Blog
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte? Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
}
