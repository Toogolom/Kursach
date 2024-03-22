namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult UpdateUser()
        {
            return View();
        }

        public IActionResult DeleteUser()
        {
            return View();
        }
    }
}
