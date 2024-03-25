namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using WebKurs.Models;

    public class RegistrationController : Controller
    {
        private readonly IAuthenticationService _AuthenticationService;
        private readonly ISessionService _sessionService;

        public RegistrationController(IAuthenticationService AuthenticationService, SessionService sessionService)
        {
            _AuthenticationService = AuthenticationService;
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

            var registrationResult = _AuthenticationService.Registration(model.Username, model.Password, model.Email,model.Error);

            if (!registrationResult)
            {
                return View("Index", model);
            }
            _sessionService.Set("Email", model.Email);
            _sessionService.Set("Username", model.Username);

            return RedirectToAction("Index","Home");
        }
    }
}
