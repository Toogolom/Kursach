namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS;
    using PIS.Interface;
    using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var model = await _reviewService.GetAllReviews();

            return View(model);
        }

        public async Task<IActionResult> AddReview()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<Tour> tours = await _tourService.GetAllToursAsync();
            
            return View(tours);
        }

        public async Task<IActionResult> AddReviewResult(string Reviewtext, string id)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            await _reviewService.AddReviewAsync(Reviewtext, id);
            ViewBag.Message = "Отзыв успешно добавлен";

            return View();
        }
    }
}
