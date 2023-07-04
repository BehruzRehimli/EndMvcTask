using HomeworkPustok.Areas.Manage.ViewModels;
using HomeworkPustok.DAL;
using HomeworkPustok.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkPustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly PustokDbContext _context;
        private readonly SignInManager<AppUser> _singInManager;

        public AccountController(UserManager<AppUser> userManager, PustokDbContext context,SignInManager<AppUser> singInManager)
        {
            _userManager = userManager;
            _context = context;
            _singInManager = singInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreatAdmin()
        {
            var admin = new AppUser() { 
            Fullname="Admin",
            UserName="admin1"
            };
            var result = await _userManager.CreateAsync(admin,"admin123");
            string str = string.Empty;
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    str += item.Description;
                }
                return Content(str);
            }

            return Content("Yaradildi");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVM admin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var resultuser=await _userManager.FindByNameAsync(admin.Username);
            if (resultuser==null)
            {
                ModelState.AddModelError("", "Username or Password is incorrect!");
                return View();
            }
            var result = await _singInManager.PasswordSignInAsync(resultuser, admin.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is incorrect!");
                return View();
            }
            return RedirectToAction("Index", "home");
        }
    }
}
