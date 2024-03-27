namespace WebKurs.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using PIS;
    using PIS.Interface;
    using PIS.Service;
    using WebKurs.Models;

    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private readonly ISessionService _sessionService;

        public UserController(IUserService userService, ISessionService sessionService)
        {
            _userService = userService;
            _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchUser(string query)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<User> userList = new List<User>();

            if (query == null)
            {
                userList = _userService.GetAllUsers();
                return View(userList);
            }

            userList = _userService.GetAllUsersByUsername(query);
            return View(userList);
        }

        public IActionResult UpdateUser(UserModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (model.Username != null && model.Email != null && _userService.UpdateUser(model))
            {
                ViewBag.Message = "Данные пользователя обновлены";
                return View(model);
            }
            var user = _userService.GetUserById(model.UserId);

            model.Username = user.UserName;
            model.Email = user.Email;
            return View(model);
        }

    }
}
