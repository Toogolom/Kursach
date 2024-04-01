using PIS;

namespace WebKurs.Models
{
    public class SearchViewModel
    {
        public List<City> Cities { get; set; }

        public List<Attraction> Attractions { get; set; }

        public List<Tour> Tours { get; set; }

        public bool ShowTours { get; set; }

        public bool ShowAttraction { get; set; }

        public bool ShowCity { get; set; }
    }
}
