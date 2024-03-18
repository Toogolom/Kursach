namespace PIS.Memory
{
    using PIS;
    using PIS.Interface;
    using System;
    using System.Collections.Generic;

    public class ReviewRepository : IReviewRepository
    {
        private readonly List<Review> reviews = new List<Review>
        {
            new Review(1, "toog1", "Great experience!", 1),
            new Review(2, "toog2", "Beautiful place to visit.", 2),
            new Review(3, "toog3", "Amazing views!", 3),
            new Review(4, "toog2", "Nice!", 1),
            new Review(5, "toog1", "Good!", 2),
        };
        public List<Review> GetAllReview()
        {
            return reviews;
        }

        public void AddReview(Review review)
        {
           review.ReviewId = reviews.Count + 1;
           reviews.Add(review);
        }

        public List<Review> GetAllReviewsByUsername(string username)
        {
            return reviews.Where(review => review.Username.Equals(username))
                .ToList();
        }
    }
}
