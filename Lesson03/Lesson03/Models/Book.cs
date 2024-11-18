using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson03.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set;}
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }
        public List<Book> GetBooksList()
        {
            List<Book> books = new List<Book>() 
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "~/Image/Product/chi-pheo.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 2,
                    Title = "Chí Phèo",
                    AuthorId = 2,
                    GenreId = 2,
                    Image = "~/Image/Product/chi-pheo.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 3,
                    Title = "Chí Phèo",
                    AuthorId = 3,
                    GenreId = 3,
                    Image = "~/Image/Product/chi-pheo.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 4,
                    Title = "Chí Phèo",
                    AuthorId = 4,
                    GenreId = 4,
                    Image = "~/Image/Product/chi-pheo.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                },
            };
            return books;
        }
        public Book GetBookById(int id)
        {
            Book book = this.GetBooksList().FirstOrDefault(x => x.Id == id);
            return book;
        }
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value = "1", Text = "Nam Cao"},
            new SelectListItem{Value = "2", Text = "Ngô Tất Tố"},
            new SelectListItem{Value = "3", Text = "Adamkhoom"},
            new SelectListItem{Value = "4", Text = "Thiền sư Thích Nhất Hạnh"},
        };
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value = "1", Text = "Truyện tranh"},
            new SelectListItem{Value = "2", Text = "Văn học đương đại"},
            new SelectListItem{Value = "3", Text = "Phật học phổ thông"},
            new SelectListItem{Value = "4", Text = "Truyện cười"},
        };
    }
}
