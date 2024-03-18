namespace PIS.Service
{

    using PIS.Interface;
    using PIS.Models;
    using System.Collections.Generic;

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

        public void AddReview(string text, int id)
        {
            string username = _sessionService.Get<string>("Username");
            Review newReview = new Review(0, username, text, id);
            _reviewRepository.AddReview(newReview);
        }

        public List<ReviewModel> GetAllReviews()
        {
            List<ReviewModel> reviewModelList = new List<ReviewModel>();
            var reviewList = _reviewRepository.GetAllReview();

            foreach (var review in reviewList)
            {
                ReviewModel reviewModel;

                reviewModel = new ReviewModel
                {
                    Username = review.Username,
                    ReviewText = review.ReviewText,
                    Tour = _tourRepository.GetTourById(review.TourId)
                };

                reviewModelList.Add(reviewModel);
            }

            return reviewModelList;
        }

        public List<ReviewModel> GetAllReviewsByAttrectionId(int attractionId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewModel> GetAllReviewsByTourId(int tourId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewModel> GetAllReviewsByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
