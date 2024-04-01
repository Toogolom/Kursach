namespace PIS.Service
{

    using PIS.Interface;
    using PIS.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ReviewService : IReviewService
    {
        private readonly ISessionService _sessionService;

        private readonly IUserRepository _userRepository;

        private readonly IReviewRepository _reviewRepository;

        private readonly ITourRepository _tourRepository;

        public ReviewService(ISessionService sessionService, IUserRepository userRepository, IReviewRepository reviewRepository, ITourRepository tourRepository)
        {
            _sessionService = sessionService;
            _userRepository = userRepository;
            _reviewRepository = reviewRepository;
            _tourRepository = tourRepository;
        }

        public async Task AddReviewAsync(string text, string id)
        {
            string username = _sessionService.Get<string>("Username");
            Review newReview = new Review(username, text, id);
            await _reviewRepository.AddReview(newReview);
        }

        public async Task<List<ReviewModel>> GetAllReviews()
        {
            List<ReviewModel> reviewModelList = new List<ReviewModel>();
            var reviewList = await _reviewRepository.GetAllReview();

            foreach (var review in reviewList)
            {
                ReviewModel reviewModel;

                reviewModel = new ReviewModel
                {
                    Username = review.Username,
                    ReviewText = review.ReviewText,
                    Tour = await _tourRepository.GetTourById(review.TourId)
                };

                reviewModelList.Add(reviewModel);
            }

            return reviewModelList;
        }
    }
}
