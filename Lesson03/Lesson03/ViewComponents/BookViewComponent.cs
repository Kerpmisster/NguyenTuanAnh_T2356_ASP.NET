using Lesson03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson03.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();
        public IViewComponentResult Invoke()
        {
            var books = book.GetBooksList();
            return View(books);
        }
    }
}
