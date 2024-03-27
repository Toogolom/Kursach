namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;

    public class EmailController : Controller
    {
        private readonly ISessionService _sessionService;

        private readonly IEmailService _emailService;

        public EmailController(ISessionService sessionService, IEmailService emailService)
        {
            _sessionService = sessionService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            return View();
        }

        public IActionResult SendEmail(string subject, string body)
        {
            var email = "romaminorov@gmail.com";

            if (_emailService.SendEmail(email, subject, body))
            {
                TempData["Message"] = "Сообщение успешно доставлено";
            }

            return RedirectToAction("Index");
        }
    }
}
