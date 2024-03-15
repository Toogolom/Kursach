namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using WebKurs.Models;

    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;
        private readonly ISessionService _sessionService;

        public RegistrationController(IRegistrationService registrationService, SessionService sessionService)
        {
            _registrationService = registrationService;
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
            var registrationResult = _registrationService.Registration(model.Username, model.Password, model.Email,model.Error);

            if (!registrationResult)
            {
                return View("Index", model);
            }
            _sessionService.Set("Email", model.Email);

            return RedirectToAction("Index","Account");
        }
    }
}
