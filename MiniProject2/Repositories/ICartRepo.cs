using MiniProject2.Models;

namespace MiniProject2.Repositories
{
    public interface ICartRepo
    {
        void AddToCart(CartItems cartItem);
        int GetCartItemCount(int userId);
        List<CartItems> GetCartItems(int userId);

        void RemoveCartItem(int cartItemId, int userId);
        //Order GetOrder(int orderId);//for order 
        ////Order PlaceOrder(Order order, List<OrderItem> orderItems);//for order 
        //Product GetProduct(int productId);//for order 
        //void AddOrder(Order order);//for order 

        //void SaveChanges();//For order 
    }
}
