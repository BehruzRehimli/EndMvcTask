using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkPustok.Areas.Manage.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [Area("Manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
