namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using WebKurs.Models;

    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View(new AuthModel());
        }

        public IActionResult Entrance(AuthModel model)
        {
            if(!_authenticationService.Authenticate(model.Email, model.Password,model.Error))
            {
                return View("Index", model);
            }
            return View();
        }
    }
}
