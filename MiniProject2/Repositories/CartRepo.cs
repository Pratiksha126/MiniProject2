using Microsoft.EntityFrameworkCore;
using MiniProject2.Data;
using MiniProject2.Models;

namespace MiniProject2.Repositories
{
    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDbContext _db;

        public CartRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void RemoveCartItem(int cartItemId, int userId)
        {
            var cartItem = _db.CartItemss.FirstOrDefault(ci => ci.CartItemId == cartItemId && ci.UserId == userId);
            if (cartItem != null)
            {
                _db.CartItemss.Remove(cartItem);
                _db.SaveChanges();
            }
        }

            public void AddToCart(CartItems cartItem)
        {
            _db.CartItemss.Add(cartItem);
            _db.SaveChanges();

        }

        public int GetCartItemCount(int userId)
        {
            return _db.CartItemss.Count(ci => ci.UserId == userId);
        }

        public List<CartItems> GetCartItems(int userId)
        {
            return _db.CartItemss
        .Include(ci => ci.Product)  // Ensure Product is included
        .Where(ci => ci.UserId == userId)
        .ToList();

        }

        //public void RemoveCartItem(int cartItemId, int userId)
        //{
        //    _db.CartItemss.Remove(cartItem);
        //    _db.SaveChanges();

        //}
    }
}
