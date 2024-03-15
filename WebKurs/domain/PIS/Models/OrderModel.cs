using PIS;

namespace WebKurs.Models
{
    public class OrderModel
    {
        public int UserId { get; set; }

        public List<Tour> TourList { get; set; }

        public double TotalPrice { get; set; }

        public DateTime Date {  get; set; }
    }
}
