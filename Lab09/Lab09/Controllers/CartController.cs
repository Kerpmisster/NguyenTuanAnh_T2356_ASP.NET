using Lab09.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Lab09.Controllers
{
    public class CartController : Controller, IActionFilter
    {
        private readonly DevXuongMocContext _context;
        private List<Cart> carts = new List<Cart>();
        public CartController(DevXuongMocContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session != null)
            {
                var cartInSession = HttpContext.Session.GetString("My-Cart");
                if (!string.IsNullOrEmpty(cartInSession))
                {
                    carts = JsonConvert.DeserializeObject<List<Cart>>(cartInSession);
                }
            }
            base.OnActionExecuting(context);
        }
        public IActionResult Index()
        {
            decimal total = 0; // Use decimal instead of float to match the type of Price
            foreach (var i in carts)
            {
                total += (decimal)(i.Quantity * (i.Price ?? 0)); // Handle nullable decimal
            }
            ViewBag.Total = total;
            return View(carts);
        }
        public IActionResult Add(int id)
        {
            //var item = carts.FirstOrDefault(c => c.Id == id);
            //if (item != null)
            //{
            //    item.Quantity += 1;
            //}
            //else
            //{
            //    var p = _context.Products.Find(id);
            //    if (p == null)
            //    {
            //        return NotFound("Product not found.");
            //    }

            //    carts.Add(new Cart
            //    {
            //        Id = id,
            //        Name = p.Title,
            //        Price = p.PriceNew.Value,
            //        Quantity = 1,
            //        Image = p.Image,
            //        Total = p.PriceNew.Value
            //    });
            //}
            //HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            // Kiểm tra nếu người dùng đã đăng nhập (session có chứa "Member")
            var member = HttpContext.Session.GetString("Member");

            // Nếu người dùng đã đăng nhập, lưu giỏ hàng vào cơ sở dữ liệu
            if (!string.IsNullOrEmpty(member))
            {
                var cartItem = _context.Carts.FirstOrDefault(c => c.UserId == member && c.ProductId == id);
                if (cartItem != null)
                {
                    cartItem.Quantity += 1;
                }
                else
                {
                    var p = _context.Products.Find(id);
                    if (p == null)
                    {
                        return NotFound("Product not found.");
                    }

                    _context.Carts.Add(new Cart
                    {
                        UserId = member,  // Lưu thông tin người dùng
                        ProductId = id,
                        Name = p.Title,
                        Price = p.PriceNew.Value,
                        Quantity = 1,
                        Image = p.Image,
                        Total = p.PriceNew.Value
                    });
                }
                _context.SaveChanges();
            }
            else
            {
                // Nếu người dùng chưa đăng nhập, lưu giỏ hàng vào session
                var item = carts.FirstOrDefault(c => c.ProductId == id);
                if (item != null)
                {
                    item.Quantity += 1;
                }
                else
                {
                    var p = _context.Products.Find(id);
                    if (p == null)
                    {
                        return NotFound("Product not found.");
                    }

                    carts.Add(new Cart
                    {
                        ProductId = id,
                        Name = p.Title,
                        Price = p.PriceNew.Value,
                        Quantity = 1,
                        Image = p.Image,
                        Total = p.PriceNew.Value
                    });
                }
                HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            if (carts.Any(c => c.Id == id))
            {
                var item = carts.Where(c=>c.Id == id).First();
                carts.Remove(item);
                HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id, int quantity)
        {
            var item = carts.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                item.Quantity = quantity;
                item.Total = item.Quantity * item.Price;
                HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("My-Cart");
            return RedirectToAction("Index");
        }
        public IActionResult Orders() 
        {
            if (HttpContext.Session.GetString("Member") == null)
            {
                return Redirect("/customerlogin/index/?url=/cart/orders");
            }
            else
            {
                var dataMember = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("Member"));
                ViewBag.Customer = dataMember;
                float total = (float)carts.Sum(item => item.Quantity * item.Price);
                ViewBag.Total = total;
                var dataPay = _context.PaymentMethods.ToList();
                ViewData["IdPayment"] = new SelectList(dataPay, "Id", "Name", 1);
            }
            return View(carts);
        }
        [HttpPost]
        public async Task<IActionResult> OrderPay(IFormCollection form)
        {
            try
            {
                var dataMember = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("Member"));
                var order = new Order();
                order.NameReciver = string.IsNullOrEmpty(form["NameReciver"]) ? dataMember.Name : form["NameReciver"];
                order.Email = form["Email"];
                order.Phone = form["Phone"];
                order.Address = form["Address"];
                order.Notes = form["Notes"];
                order.IdPayment = long.Parse(form["IdPayment"]);
                order.OrdersDate = DateTime.Now;
                order.IdCustomer = dataMember.Id;

                decimal total = 0;
                foreach (var item in carts)
                {
                    total += (decimal)(item.Quantity * (decimal)item.Price);
                }
                order.TotalMoney = total;

                //tạo orderId
                var strOrderId = "DH";
                long timestamp = DateTime.Now.Ticks;
                order.IdOrders = long.Parse($"{timestamp}");

                _context.Add(order);
                await _context.SaveChangesAsync();

                //lấy id bảng orders
                var dataOrder = _context.Orders.OrderByDescending(x => x.Id).FirstOrDefault();

                foreach (var item in carts)
                {
                    Orderdetail od = new Orderdetail();
                    od.IdOrder = dataOrder.Id;
                    od.IdProduct = item.ProductId;
                    od.Qty = item.Quantity;
                    od.Price = item.Price;
                    od.Total = item.Total;
                    od.ReturnQty = 0;

                    _context.Add(od);
                    await _context.SaveChangesAsync();
                }
                HttpContext.Session.Remove("My-Cart");
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                Console.WriteLine($"Error: {ex.Message}");
                return BadRequest("An error occurred during order processing.");
            }
            return View();
        }
        [HttpGet]
        public IActionResult OrderPay()
        {
            return View();
        }
    }
}
