using MiniProject2.Models;

namespace MiniProject2.Services
{
    public interface ICartService
    {
        void AddToCart(CartItems cartItem);
        int GetCartItemCount(int userId);
        List<CartItems> GetCartItems(int userId);

        void RemoveCartItem(int cartItemId, int userId);
        //void RemoveCartItem(int cartItemId, int userId);
        //void PlaceOrder(int userId, int productId, int quantity);//for order 
        //Product GetProduct(int productId);//for order 
    }
}
