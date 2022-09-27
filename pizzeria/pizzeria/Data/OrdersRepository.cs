using Microsoft.EntityFrameworkCore;
using pizzeria.Data.Interfaces;
using pizzeria.Models;

namespace pizzeria.Data
{
    public class OrdersRepository : IOrdersRepository
    {

        private readonly AppDbContext _context;

        public OrdersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrderByUserId(string userId)
        {
            var orders = await _context.Orders.Include(n => n.OrderDetails).ThenInclude(n => n.IdProductNavigation).Include(n => n.IdAppUserNavigation).Where(n => n.IdAppUser == userId).ToListAsync();

            return orders;
        }

        public async Task StoreOrder(List<CartItem> items, string userId)
        {
            var order = new Order()
            {
                IdAppUser = userId,
                OrderDate = System.DateTime.Now,
                Paid = true

            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    IdProduct = item.IdProductNavigation.IdProduct,
                    IdOrder = order.IdOrder,
                    UnitPrice = item.IdProductNavigation.ProductPrice,
                };
                await _context.OrderDetails.AddAsync(orderDetail);
            }
            await _context.SaveChangesAsync();
        }

        //ADMIN

        public async Task<List<Order>> GetOrdersAdmin(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderDetails).ThenInclude(n => n.IdProductNavigation).Include(n => n.IdAppUserNavigation).ToListAsync();

            /*var ordersQuery = from order in _context.Orders
                              select order
                              ;
            ordersQuery = ordersQuery.Include(n => n.OrderDetails).ThenInclude(n => n.Pizza).Include(n => n.User);*/

            return orders;
        }

        public async Task<Order> GetOrderById(int Id)
        {
            var order = await _context.Orders
                .Include(n => n.OrderDetails)
                .ThenInclude(n => n.IdProductNavigation)
                .Include(n => n.IdAppUserNavigation)
                .FirstOrDefaultAsync(n => n.IdOrder == Id);
            return order;
        }

        public async Task<OrderDetail> GetOrderDetailsById(int IdOrd, int IdProd)
        {
            var orderDetails = await _context.OrderDetails
                .Include(n => n.IdOrderNavigation)
                .ThenInclude(n => n.IdAppUserNavigation)
                .Include(n => n.IdProductNavigation)
                .FirstOrDefaultAsync(n => n.IdOrder == IdOrd && n.IdProduct == IdProd)
            ;
            return orderDetails;
        }



        public async Task<List<OrderDetail>> GetOrderDetailsByOrderId(int Id)
        {
            var orderDetails = await _context.OrderDetails
                .Include(n => n.IdOrderNavigation)
                .ThenInclude(n => n.IdAppUserNavigation)
                .Include(n => n.IdProductNavigation)
                .Where(n => n.IdOrder == Id)
                .ToListAsync();
            return orderDetails;
        }

        public async Task UpdateOrder(List<OrderDetail> orderDetails)
        {
            for (var i = 0; i < orderDetails.Count(); i++)
            {
                _context.Entry(orderDetails[i]).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteOrder(int Id)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(n => n.IdOrder == Id);
            _context.Orders.Remove(result);

            await _context.SaveChangesAsync();
        }


        public async Task DeleteOrderDetails(int Id)
        {
            var result = await _context.OrderDetails.FirstOrDefaultAsync(n => n.IdOrder == Id);
            _context.OrderDetails.Remove(result);

            await _context.SaveChangesAsync();
        }
    }
}
