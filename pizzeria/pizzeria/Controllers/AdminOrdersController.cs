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
        public async Task<IActionResult> OrderEdit(int Id, [Bind("Amount", "IdOrder", "IdProduct")] List<OrderDetail> orderDetails)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            await _repo.UpdateOrder(orderDetails);
            return RedirectToAction(nameof(Orders));

        }

        public async Task<IActionResult> OrderDelete(int Id)
        {
            var order = await _repo.GetOrderById(Id);

            return View(order);
        }

        public async Task<IActionResult> OrderDeleteConfirmed(int Id)
        {
            await _repo.DeleteOrder(Id);

            return RedirectToAction(nameof(Orders));
        }


        /* public async Task<IActionResult> OrderDetailsDelete(int Id)
         {
             var orderDetails = await _repo.GetOrderDetailsById(Id);

             return View(orderDetails);
         }

         public async Task<IActionResult> OrderDetailsDeleteConfirmed(int Id)
         {
             await _repo.DeleteOrderDetails(Id);

             return RedirectToAction(nameof(Orders));
         }*/
    }
}
