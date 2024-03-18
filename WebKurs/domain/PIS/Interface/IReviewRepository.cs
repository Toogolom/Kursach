namespace PIS.Interface
{
    using System;
    public interface IReviewRepository
    {
        public List<Review> GetAllReview();

        public List<Review> GetAllReviewsByUsername(string username);

        public void AddReview(Review review);
    }
}
