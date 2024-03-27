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

        public IActionResult AuthIndex()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            return View(new UserModel());
        }

        public IActionResult Entrance(UserModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (!_authenticationService.Authenticate(model.Email, model.Password, model.Error))
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

        public IActionResult RegIndex()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            return View(new UserModel());
        }

        public IActionResult Register(UserModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var registrationResult = _authenticationService.Registration(model.Username, model.Password, model.Email, model.Error);

            if (!registrationResult)
            {
                return View("Index", model);
            }
            _sessionService.Set("Email", model.Email);
            _sessionService.Set("Username", model.Username);
            _sessionService.Set("IsLoggedIn", true);
            _sessionService.Set("IsAdmin", false);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult VerifyEmail(string code)
        {
            string storeCode = _sessionService.Get<string>("Code");
            if (storeCode == code)
            {
                return Content("success");
            }
            return Content("failure");
        }


        public IActionResult SendCodeToEmail(string email)
        {
            string code = _authenticationService.SendVerifyCodeToEmail(email);
            _sessionService.Set("Code", code);

            return Json(new { success = code != null, email = email });
        }
    }
}
