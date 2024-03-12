namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using WebKurs.Models;

    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
    
        public IActionResult Index()
        {
            return View(new RegModel());
        }

        public IActionResult Register(RegModel model)
        {
            var registrationResult = _registrationService.Registration(model.Username, model.Password, model.Email,model.Error);

            if (!registrationResult)
            {
                return View("Index", model);
            }
            return View();
        }
    }
}
