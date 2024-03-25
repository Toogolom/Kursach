namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using WebKurs.Models;

    public class AuthController : Controller
    {
        private readonly IAuthenticationService _UserenticationService;

        private readonly ISessionService _sessionService;

        private readonly IUserService _userService;

        public AuthController(IAuthenticationService UserenticationService, SessionService sessionService, IUserService userservice)
        {
            _UserenticationService = UserenticationService;
            _sessionService = sessionService;
            _userService = userservice;
        }

        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            return View(new UserModel());
        }

        public IActionResult Entrance(UserModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (!_UserenticationService.Authenticate(model.Email, model.Password, model.Error))
            {
                return View("Index", model);
            }

            _sessionService.Set("Email", model.Email);

            var username = _userService.GetUsernameByEmail(model.Email);

            var user = _userService.GetUserByEmail(model.Email);

            _sessionService.Set("Username", username);
            _sessionService.Set("IsLoggedIn", true);
            _sessionService.Set("IsAdmin", user.IsAdmin);

            return RedirectToAction("Index", "Home");
        }
    }
}
