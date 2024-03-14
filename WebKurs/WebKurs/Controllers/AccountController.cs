using Microsoft.AspNetCore.Mvc;
using PIS;
using PIS.Interface;
using WebKurs.Models;

namespace WebKurs.Controllers
{
    public class AccountController : Controller
    {
        private readonly SessionManager _sessionManager;

        private readonly IUserRepository _userRepository;

        public AccountController(SessionManager sessionManager, IUserRepository userRepository)
        {
            _sessionManager = sessionManager;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            _sessionManager.Set("IsLoggedIn", true);
            ViewData["IsLoggedIn"] = _sessionManager.Get<bool>("IsLoggedIn");

            string email = _sessionManager.Get<String>("Email");
            User user = _userRepository.GetUserByEmail(email);

            _sessionManager.Set("Username", user.UserName);

            return View(new UserModel
            {
                Email = user.Email,
                Username = user.UserName,
            });
        }
    }
}
