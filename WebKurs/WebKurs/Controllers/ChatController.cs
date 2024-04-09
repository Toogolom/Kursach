using Microsoft.AspNetCore.Mvc;
using PIS.Interface;
using PIS.Models;
using System.Threading.Tasks;

namespace WebKurs.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly ISessionService _sessionService;

        public ChatController(IChatService chatService, ISessionService sessionService)
        {
            _chatService = chatService;
            _sessionService = sessionService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var messages = await _chatService.GetAllMessage();

            var model = new ChatModel
            {
                Messages = messages
            };

            return View(model);
        }

        public async Task<IActionResult> SendMessage(string text)
        {
            await _chatService.AddMessage(text);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> LikeMessage(string messageId)
        {
            await _chatService.LikeMessage(messageId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DislikeMessage(string messageId)
        {
            await _chatService.DislikeMessage(messageId);
            return Ok();
        }

        public async Task<IActionResult> UnLikeMessage(string messageId)
        {
            await _chatService.UnLikeMessage(messageId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UnDislikeMessage(string messageId)
        {
            await _chatService.UnDislikeMessage(messageId);
            return Ok();
        }
    }
}
