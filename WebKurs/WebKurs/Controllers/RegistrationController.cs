namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;

    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
    
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(string email, string username,string password)
        {
            var newuUser = _registrationService.Registration(email, username, password); 
            return View();
        }
    }
}
