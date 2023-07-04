using HomeworkPustok.Models;
using HomeworkPustok.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkPustok.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public UserManager<AppUser> UserManager { get; }
        public SignInManager<AppUser> SignInManager { get; }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginVM memberVM)
        {
            AppUser user = await _userManager.FindByNameAsync(memberVM.Username);
            if (user==null)
            {
                ModelState.AddModelError("", "Username or Password is incorrect!");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user,memberVM.Password,false,false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is incorrect!");
                return View();
            }
            return RedirectToAction("Index","home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterUserVM regVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user=new AppUser() {
                Fullname= regVM.Fullname,
                UserName=regVM.Username,
                Email=regVM.Email,
            };
            var result= await _userManager.CreateAsync(user,regVM.Password);
            if (!result.Succeeded) 
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
                return View();
            }
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index","home");
        }
        public async Task<IActionResult> Logout()
        {
             await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
