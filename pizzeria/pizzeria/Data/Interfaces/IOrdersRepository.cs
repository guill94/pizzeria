using pizzeria.Models;

namespace pizzeria.Data.Interfaces
{
    public interface IOrdersRepository
    {
        Task StoreOrder(List<CartItem> items, string userId, int id = 0);

        Task<List<Order>> GetOrdersAdmin(string userId, string userRole);

        Task<List<Order>> GetOrderByUserId(string userId);

        Task<Order> GetOrderById(int Id);

        Task<OrderDetail> GetOrderDetailsById(int IdOrd, int IdProd);

        Task<List<OrderDetail>> GetOrderDetailsByOrderId(int Id);

        Task UpdateOrder(List<OrderDetail> orderDetails);

        Task DeleteOrder(int Id);

        Task DeleteOrderDetails(int IdOrd, int IdProd);
    }
}
