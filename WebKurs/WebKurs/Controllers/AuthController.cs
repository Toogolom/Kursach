namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using WebKurs.Models;

    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        private readonly SessionManager _sessionManager;

        public AuthController(IAuthenticationService authenticationService, SessionManager sessionManager)
        {
            _authenticationService = authenticationService;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionManager.Get<bool>("IsLoggedIn");
            return View(new AuthModel());
        }

        public IActionResult Entrance(AuthModel model)
        {
            ViewData["IsLoggedIn"] = _sessionManager.Get<bool>("IsLoggedIn");
            if (!_authenticationService.Authenticate(model.Email, model.Password,model.Error))
            {
                return View("Index", model);
            }

            _sessionManager.Set("Email", model.Email);

            return RedirectToAction("Index", "Account");
        }
    }
}
