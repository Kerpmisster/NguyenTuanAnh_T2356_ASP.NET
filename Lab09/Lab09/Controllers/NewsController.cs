using Lab09.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab09.Controllers
{
    public class NewsController : Controller
    {
        private readonly DevXuongMocContext _context;
        public NewsController(DevXuongMocContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Lấy tin tức lớn nhất (theo ID đầu tiên và Status == 1)
            var latestNews = await _context.News
                .Where(n => n.Status == 1)  // Lọc theo Status (giả sử 1 là tin tức còn hoạt động)
                .OrderBy(n => n.Id)  // Sắp xếp theo ID nhỏ nhất (ID đầu tiên)
                .FirstOrDefaultAsync();

            // Lấy 4 tin tức nhỏ (không bao gồm tin tức lớn nhất và có Status == 1)
            var otherNews = await _context.News
                .Where(n => n.Status == 1)  // Lọc theo Status
                .Where(n => n.Id != latestNews.Id)  // Loại trừ tin tức lớn nhất
                .OrderByDescending(n => n.CreatedDate)  // Sắp xếp theo ngày tạo của tin tức
                .Take(4)
                .ToListAsync();

            var viewModel = new NewsViewModel
            {
                LatestNews = latestNews,
                OtherNews = otherNews
            };

            return View(viewModel);
        }

        // Action Detail
        public async Task<IActionResult> Detail(int id)
        {
            var news = await _context.News
                .Where(n => n.Id == id)
                .FirstOrDefaultAsync();

            if (news == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy tin tức
            }

            return View(news); // Trả về View chi tiết tin tức
        }
    }
}
