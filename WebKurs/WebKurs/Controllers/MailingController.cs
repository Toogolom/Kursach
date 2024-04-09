namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using PIS.Models;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    public class MailingController : Controller
    {
        private readonly IMailingService _mailingService;
        private readonly ISessionService _sessionService;

        public MailingController (IMailingService mailingService, ISessionService sessionService)
        {
            _mailingService = mailingService;
            _sessionService = sessionService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var mailing = await _mailingService.GetAllMailing();

            return View(mailing);
        }

        public async Task<IActionResult> AddMailing(MailingModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (model.Subject  != null)
            {
                await _mailingService.AddMailing(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> SendMailing(string id)
        {
            if (await _mailingService.SendMailing(id))
            {
                TempData["Success"] = "Рассылка разослана";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeToMailing(string email, string id)
        {
            if (await _mailingService.AddToEmailList(email, id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> UnSubscribeFromMailing(string email, string id)
        {
            if (await _mailingService.DeleteFromEmailList(email, id))
            {
                return Ok();
            }
            return BadRequest();
        }

        public async Task<IActionResult> DeleteMailing(string id)
        {
            if (await _mailingService.DeleteMailing(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
