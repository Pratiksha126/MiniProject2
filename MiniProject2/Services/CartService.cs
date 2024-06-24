using MiniProject2.Models;
using MiniProject2.Repositories;

namespace MiniProject2.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepo _cartRepository;

        public CartService(ICartRepo cartRepository)
        {
            _cartRepository = cartRepository;

        }

        public void AddToCart(CartItems cartItem)
        {
            _cartRepository.AddToCart(cartItem);
        }

        public int GetCartItemCount(int userId)
        {
            return _cartRepository.GetCartItemCount(userId);
        }

        public List<CartItems> GetCartItems(int userId)
        {
            return _cartRepository.GetCartItems(userId);
        }

        public void RemoveCartItem(int cartItemId, int userId)
        {
            _cartRepository.RemoveCartItem(cartItemId, userId);
        }
    }
}
