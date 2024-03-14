namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using WebKurs.Models;

    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;
        private readonly SessionManager _sessionManager;

        public RegistrationController(IRegistrationService registrationService, SessionManager sessionManager)
        {
            _registrationService = registrationService;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionManager.Get<bool>("IsLoggedIn");
            return View(new RegModel());
        }

        public IActionResult Register(RegModel model)
        {
            ViewData["IsLoggedIn"] = _sessionManager.Get<bool>("IsLoggedIn");
            var registrationResult = _registrationService.Registration(model.Username, model.Password, model.Email,model.Error);

            if (!registrationResult)
            {
                return View("Index", model);
            }
            _sessionManager.Set("Email", model.Email);

            return View();
        }
    }
}
