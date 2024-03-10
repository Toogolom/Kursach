namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;

    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entrance(string username, string password)
        {
            _authenticationService.Authenticate(username, password);
            return View();
        }
    }
}
