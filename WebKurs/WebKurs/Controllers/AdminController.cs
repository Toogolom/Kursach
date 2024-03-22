namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using PIS.Service;
    using WebKurs.Models;

    public class AdminController : Controller
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateUser(RegModel model, int userId)
        {
            if (model != null && _adminService.UpdateUser(model))
            {
                ViewBag.Message = "Данные пользователя обновлены";
                return View(model);
            }

            return View(model);
        }

        public IActionResult DeleteUser()
        {
            return View();
        }
    }
}
