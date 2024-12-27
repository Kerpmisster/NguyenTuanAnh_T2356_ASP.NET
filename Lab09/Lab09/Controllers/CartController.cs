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
            //var cartInSession = HttpContext.Session.GetString("My-Cart");
            //if(cartInSession != null)
            //{
            //    carts = JsonConvert.DeserializeObject<List<Cart>>(cartInSession);
            //}
            //base.OnActionExecuting(context);
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
            float total = 0;
            foreach (var i in carts)
            {
                total += i.Quantity*i.Price;
            }
            ViewBag.Total = total;
            return View(carts);
        }
        public IActionResult Add(int id)
        {
            var item = carts.FirstOrDefault(c => c.Id == id);
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
                    Id = id,
                    Name = p.Title,
                    Price = (float)p.PriceNew.Value,
                    Quantity = 1,
                    Image = p.Image,
                    Total = (float)p.PriceNew.Value
                });
            }
            HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
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
            if (carts.Any(c => c.Id == id))
            {
                carts.Where(c => c.Id == id).First().Quantity = quantity;
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

                float total = carts.Sum(item => item.Quantity * item.Price);
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
                var order = new Order();
                order.NameReciver = form["NameReciver"];
                order.Email = form["Email"];
                order.Phone = form["Phone"];
                order.Address = form["Address"];
                order.Notes = form["Notes"];
                order.IdPayment = long.Parse(form["IdPayment"]);
                order.OrdersDate = DateTime.Now;

                var dataMember = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("Member"));
                order.IdCustomer = dataMember.Id;

                decimal total = 0;
                foreach (var item in carts)
                {
                    total += item.Quantity * (decimal)item.Price;
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
                    od.IdProduct = item.Id;
                    od.Qty = item.Quantity;
                    od.Price = (decimal)item.Price;
                    od.Total = (decimal)item.Total;
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
