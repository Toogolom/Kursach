namespace WebKurs.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using PIS;
    using PIS.Interface;
    using PIS.Service;
    using System.Threading.Tasks;
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

        public async Task<IActionResult> SearchUser(string query)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<User> userList = new List<User>();

            if (query == null)
            {
                userList = await _userService.GetAllUsers();
                return View(userList);
            }

            userList = await _userService.GetAllUsersByUsername(query);
            return View(userList);
        }

        public async Task<IActionResult> UpdateUser(UserModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (model.Username != null && model.Email != null && await _userService.UpdateUser(model))
            {
                ViewBag.Message = "Данные пользователя обновлены";
                var email = _sessionService.Get<string>("Email");
                _sessionService.Set("Username", _userService.GetUsernameByEmail(email));
                return View(model);
            }

            var user = await _userService.GetUserById(model.UserId);
            
            model.Username = user.Username;
            model.Email = user.Email;
            return View(model);
        }
    }
}
