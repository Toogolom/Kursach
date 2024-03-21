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
            return View(new RegModel());
        }

        public IActionResult Register(RegModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
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
