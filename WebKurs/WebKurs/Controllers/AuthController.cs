namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using System.Threading.Tasks;
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

        public async Task<IActionResult> Entrance(UserModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (! await _authenticationService.AuthenticateAsync(model.Email, model.Password, model.Error))
            {
                return View("AuthIndex", model);
            }

            _sessionService.Set("Email", model.Email);

            var username = await _userService.GetUsernameByEmail(model.Email);

            var user = await _userService.GetUserByEmail(model.Email);

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

        public async Task<IActionResult> Register(UserModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");


            if (!await _authenticationService.RegistrationAsync(model.Username, model.Password, model.Email, model.Error))
            {
                return View("RegIndex", model);
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


        public async Task<IActionResult> SendCodeToEmailAsync(string email)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            string code = await _authenticationService.SendVerifyCodeToEmailAsync(email);
            

            _sessionService.Set("Code", code);

            return Json(new { success = code != null, email });
        }
    }
}
