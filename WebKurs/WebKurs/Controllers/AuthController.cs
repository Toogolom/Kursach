namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using WebKurs.Models;

    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        private readonly ISessionService _sessionService;

        private readonly IUserService _userService;

        public AuthController(IAuthenticationService authenticationService, SessionService sessionService, IUserService userservice)
        {
            _authenticationService = authenticationService;
            _sessionService = sessionService;
            _userService = userservice;
        }

        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            return View(new AuthModel());
        }

        public IActionResult Entrance(AuthModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            if (!_authenticationService.Authenticate(model.Email, model.Password, model.Error))
            {
                return View("Index", model);
            }

            _sessionService.Set("Email", model.Email);

            var username = _userService.GetUsernameByEmail(model.Email);

            _sessionService.Set("Username", username);
            _sessionService.Set("IsLoggedIn", true);

            return RedirectToAction("Index", "Home");
        }
    }
}
