using PIS.Models;

namespace PIS.Interface
{
    public interface IReviewService
    {
        public Task<List<ReviewModel>> GetAllReviews();

        public Task AddReviewAsync(string text, string id);


    }
}
