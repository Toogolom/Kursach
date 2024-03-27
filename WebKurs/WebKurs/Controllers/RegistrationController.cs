namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS;
    using PIS.Interface;
    using WebKurs.Models;

    public class RegistrationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ISessionService _sessionService;

        public RegistrationController(IAuthenticationService authenticationService, SessionService sessionService)
        {
            _authenticationService = authenticationService;
            _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            return View(new UserModel());
        }

        public IActionResult Register(UserModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var registrationResult = _authenticationService.Registration(model.Username, model.Password, model.Email,model.Error);

            if (!registrationResult)
            {
                return View("Index", model);
            }
            _sessionService.Set("Email", model.Email);
            _sessionService.Set("Username", model.Username);
            _sessionService.Set("IsLoggedIn", true);
            _sessionService.Set("IsAdmin",false);

            return RedirectToAction("Index","Home");
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
