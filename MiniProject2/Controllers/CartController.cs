using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject2.Models;
using MiniProject2.Services;

namespace MiniProject2.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            string userIdStr = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                // Redirect to login if user is not logged in or UserId is invalid
                return RedirectToAction("Login", "User");
            }

            var product = _productService.GetProductById(id);
            if (product != null)
            {
                var cartItem = new CartItems
                {
                    UserId = userId,
                    ProductId = product.ProductId,
                    Quantity = product.Stock,
                    Price = product.Price
                };
                _cartService.AddToCart(cartItem);
                var cartCount = _cartService.GetCartItemCount(userId);

                return Json(new { success = true, cartCount = cartCount });
            }
            return Json(new { success = false });
        }



        [HttpPost]
        public IActionResult RemoveFromCart(int cartItemId)
        {
            int userId = GetLoggedInUserId(); // Get user ID, implement your logic

            _cartService.RemoveCartItem(cartItemId, userId);

            // Redirect back to CartDetails or wherever appropriate
            return RedirectToAction("CartDetails");
        }

        [HttpGet]
        public IActionResult CartDetails()
        {
            /* var userId = int.Parse(HttpContext.Session.GetString("UserId"));
             var cartItems = _cartService.GetCartItems(userId);
             return View(cartItems); */
            var userIdStr = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                return RedirectToAction("Login", "User");
            }

            var cartItems = _cartService.GetCartItems(userId);
            return View(cartItems);
        }

        private int GetLoggedInUserId()
        {
            if (int.TryParse(HttpContext.Session.GetString("UserId"), out int userId))
            {
                return userId;
            }
            return 0;
        }




        // GET: CartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
