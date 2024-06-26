﻿namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS;
    using PIS.Interface;
    using PIS.Models;
    using System.Collections.Generic;
    using WebKurs.Models;

    public class AccountController : Controller
    {
        private readonly ISessionService _sessionService;

        private readonly IUserService _userService;

        private readonly IOrderService _orderService;

        private readonly IMailingService _mailingService;


        public AccountController(SessionService sessionService, IUserService userService, IOrderService orderService, IMailingService mailingService)
        {
            _sessionService = sessionService;
            _userService = userService;
            _orderService = orderService;
            _mailingService = mailingService;
        }

        public async Task<IActionResult> Index()
        {
            _sessionService.Set("IsLoggedIn", true);
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");


            string email = _sessionService.Get<String>("Email");
            User user = await _userService.GetUserByEmail(email);

            _sessionService.Set("Username", user.Username);

            UserModel userModel = new UserModel
            {
                Email = user.Email,
                Username = user.Username,
            };

            var mailing = await _mailingService.GetAllMailing();

            var viewModel = new { UserModel = userModel, Mailing = mailing  };

            return View(viewModel);
        }

        public async Task<IActionResult> Order()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsLogPage"] = true;
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var model = await _orderService.GetAllOrdersByUsername(_sessionService.Get<string>("Username"));

            return View(model);
        }

        
        public async Task<IActionResult> UpdateProfile(UserModel model)
        {
            var user = await _userService.GetUserByEmail(_sessionService.Get<string>("Email"));
            model.UserId = user.UserId;
            return RedirectToAction("UpdateUser", "User", model);
        }

        public async Task<IActionResult> UpdatePassword(string password, string newPassword) 
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");
            Dictionary<string, string> Error = new Dictionary<string, string>();

            if (password == null && newPassword == null)
            {
                return View(Error);
            }
           
            if (await _userService.UpdatePassword(newPassword, password, Error))
            {
                ViewBag.Message = "Пароль успешно обновлен";
            }
                

            return View(Error);
        }

        public IActionResult Exit()
        {
            _sessionService.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}
