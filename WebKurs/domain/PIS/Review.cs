namespace PIS
{
    using System;

    public class Review
    {
        public int ReviewId { get; set; }

        public string Username { get; set; }

        public string ReviewText { get; set; }

        public int TourId { get; set; }

        public Review (int reviewId, string username, string reviewText, int tourId)
        {
            ReviewId = reviewId;
            Username = username;
            ReviewText = reviewText;
            TourId = tourId; ;
        }
    }
}
