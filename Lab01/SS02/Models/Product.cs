namespace SS02.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime YearRelease { get; set; } = DateTime.Now;
        public double Price { get; set; }
    }
}
