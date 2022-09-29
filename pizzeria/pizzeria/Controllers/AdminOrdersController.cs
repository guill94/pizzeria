using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pizzeria.Data;
using pizzeria.Data.Interfaces;
using pizzeria.Models;
using System.Security.Claims;

namespace pizzeria.Controllers
{
    public class AdminOrdersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IOrdersRepository _repo;

        public AdminOrdersController(UserManager<AppUser> userManager, AppDbContext context, IOrdersRepository repo)
        {
            _userManager = userManager;
            _context = context;
            _repo = repo;
        }



        //ORDERS
        public async Task<IActionResult> Orders()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _repo.GetOrdersAdmin(userId, userRole);

            return View(orders);
        }


        [HttpGet]
        public async Task<IActionResult> OrderEdit(int Id)
        {
            var orderDetails = await _repo.GetOrderDetailsByOrderId(Id);

            return View(orderDetails);
        }

        [HttpPost]
        public async Task<IActionResult> OrderEdit(int Id, [Bind("Amount", "UnitPrice", "IdOrder", "IdProduct")] List<OrderDetail> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                if (orderDetail.Amount == 0 || orderDetail.UnitPrice == 0)
                {
                    return View(orderDetails);
                }
            }

            await _repo.UpdateOrder(orderDetails);
            return RedirectToAction(nameof(Orders));

        }

        public async Task<IActionResult> OrderDelete(int Id)
        {
            var order = await _repo.GetOrderById(Id);

            return View(order);
        }

        public async Task<IActionResult> OrderDeleteConfirmed([Bind("idOrder")] int idOrder)
        {
            await _repo.DeleteOrder(idOrder);

            return RedirectToAction(nameof(Orders));
        }


         public async Task<IActionResult> OrderDetailsDelete([Bind("idOrder", "idProd")] int idOrder, int idProd)
         {
             var orderDetails = await _repo.GetOrderDetailsById(idOrder, idProd);

             return View(orderDetails);
         }

         public async Task<IActionResult> OrderDetailsDeleteConfirmed([Bind("idOrder", "idProd")] int idOrder, int idProd)
         {
             await _repo.DeleteOrderDetails(idOrder, idProd);

             return RedirectToAction(nameof(Orders));
         }
    }
}
