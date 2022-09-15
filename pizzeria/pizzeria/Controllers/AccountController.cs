using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizzeria.Data.ViewModels;
using pizzeria.Data;
using pizzeria.Models;
using System.Threading.Tasks;
using pizzeria.Data.Static;

namespace pizzeria.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
            _context = context;
        }


        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Pizzas");
                    }
                }
                TempData["Error"] = "Identifiants invalides, veuillez ressayer !";
                return View(loginVM);
            }

            TempData["Error"] = "Identifiants invalides, veuillez ressayer !";
            return View(loginVM);
        }


        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Cette email existe déjà";
                return View(registerVM);
            }

            var newUser = new AppUser()
            {
                LastName = registerVM.LastName,
                FirstName = registerVM.FirstName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };

            

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Pizzas");
        }
    }
}
