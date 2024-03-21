using Microsoft.AspNetCore.Mvc;
using PIS;
using PIS.Interface;
using WebKurs.Models;

namespace WebKurs.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISessionService _sessionService;

        private readonly IUserService _userService;

        private readonly IOrderService _orderService;


        public AccountController(SessionService sessionService, IUserService userService, IOrderService orderService)
        {
            _sessionService = sessionService;
            _userService = userService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            _sessionService.Set("IsLoggedIn", true);
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");


            string email = _sessionService.Get<String>("Email");
            User user = _userService.GetUserByEmail(email);

            _sessionService.Set("Username", user.UserName);

            return View(new UserModel
            {
                Email = user.Email,
                Username = user.UserName,
            });
        }

        public IActionResult Order()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsLogPage"] = true;
            ViewData["Username"] = _sessionService.Get<string>("Username");

            var model = _orderService.GetAllOrdersByUsername();

            return View(model);
        }

        
        public IActionResult UpdateProfile(RegModel model, string newPassword)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
           
            if (model.Username != null && _userService.UpdateUser(model))
            {
                model = _userService.GetRegModel(model);
                ViewBag.Message = "Данные пользователя обновлены";
                return View(model);
            }
            model = _userService.GetRegModel(model);
            return View(model);
        }

        public IActionResult UpdatePassword(string password, string newPassword) 
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            Dictionary<string, string> Error = new Dictionary<string, string>();

            if (password == null && newPassword == null)
            {
                return View(Error);
            }
           
            if (_userService.UpdatePassword(newPassword, password, Error))
                ViewBag.Message = "Пароль успешно обновлен";
            return View(Error);
        }

        public IActionResult Exit()
        {
            _sessionService.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}
