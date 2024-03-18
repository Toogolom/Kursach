using PIS.Models;

namespace PIS.Interface
{
    public interface IReviewService
    {
        public List<ReviewModel> GetAllReviews();

        public List<ReviewModel> GetAllReviewsByUsername(string username);

        public List<ReviewModel> GetAllReviewsByAttrectionId(int attractionId);

        public List<ReviewModel> GetAllReviewsByTourId(int tourId);

        public void AddReview(string text, int id);


    }
}
