namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS;
    using PIS.Interface;
    using PIS.Models;
    using PIS.Service;
    using WebKurs.Models;

    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        private readonly IUserService _userService;

        private readonly ICityService _cityService;

        private readonly ISessionService _sessionService;

        public AdminController(IAdminService adminService, IUserService userService, ISessionService sessionService, ICityService cityService)
        {
            _adminService = adminService;
            _userService = userService;
            _sessionService = sessionService;
            _cityService = cityService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchUser(string query)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");
            
            List<User> userList = new List<User>();    

            if (query == null)
            {
                userList = _userService.GetAllUsers();
                return View(userList);
            }
            
            userList = _userService.GetAllUsersByUsername(query);
            return View(userList);
        }

        public IActionResult UpdateUser(UserModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (model.Username != null && model.Email != null && _adminService.UpdateUser(model))
            {
                ViewBag.Message = "Данные пользователя обновлены";
                return View(model);
            }
            var user = _userService.GetUserById(model.UserId);

            model.Username = user.UserName;
            model.Email = user.Email;
            return View(model);
        }

        public IActionResult DeleteUser(int userId)
        {
            _adminService.DeleteUser(userId);
            return RedirectToAction("SearchUser");
        }

        public IActionResult SearchCity(string query)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<City> cityList = new List<City>();

            if (query == null)
            {
                cityList = _cityService.GetAllCity();
                return View(cityList);
            }

            cityList = _cityService.GetAllCityByPartName(query);
            return View(cityList);
        }

        public IActionResult AddCity(CityModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (model.URL == null && model.CityName == null && model.CityDescription == null)
            {
                return View();
            }

            if (_adminService.AddCity(model))
            {
                ViewBag.Message = "Город успешно добавлен";
                return View();
            }

            ViewBag.Message = "Поля не должны быть пустыми";
            return View();

        }

        public IActionResult UpdateCity(CityModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (_adminService.UpdateCity(model))
            {
                ViewBag.Message = "Данные обновлены";
                return View(model);
            }
            var city = _cityService.GetCityById(model.CityId);

            model.URL = city.PhotoUrl;
            model.CityName = city.CityName; 
            model.CityDescription = city.CityDescription;

            return View(model);
        }

        public IActionResult DeleteCity(int cityId)
        {
            _adminService.DeleteCity(cityId);
            return RedirectToAction("SearchCity");
        }

        public IActionResult AddAttraction(AttractionModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (_adminService.AddAttraction(model))
            {
                ViewBag.Message = "Достопримечательность успешно добавлена";
            }

            var cityList = _cityService.GetAllCity();
            return View(cityList);
        }
    }
}
