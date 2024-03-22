namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS;
    using PIS.Interface;

    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ISessionService _sessionService;
        private readonly ITourService _tourService;

        public ReviewController(IReviewService reviewService, ISessionService sessionService, ITourService tourService)
        {
            _reviewService = reviewService;
            _sessionService = sessionService;
            _tourService = tourService;
        }

        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var model = _reviewService.GetAllReviews();

            return View(model);
        }

        public IActionResult AddReview()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<Tour> tours = _tourService.GetAllTours();
            
            return View(tours);
        }

        public IActionResult AddReviewResult(string Reviewtext, int id)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");s

            _reviewService.AddReview(Reviewtext, id);
            ViewBag.Message = "Отзыв успешно добавлен";

            return View();
        }
    }
}
