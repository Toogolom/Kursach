namespace PIS.Memory
{
    using PIS;
    using PIS.Interface;

    public class TourRepository: ITourRepository
	{
        private readonly List<Tour> tours = new List<Tour>
        {
            new Tour(1, "Московский тур", "Описание тура 1", 100.0, DateTime.Now, DateTime.Now.AddDays(7), new Dictionary<int, DateTime> { { 1, DateTime.Now.AddDays(2) }, { 2, DateTime.Now.AddDays(4) } }),
            new Tour(2, "Тур 2", "Описание тура 2", 150.0, DateTime.Now, DateTime.Now.AddDays(10), new Dictionary<int, DateTime> { { 1, DateTime.Now.AddDays(3) }, { 2, DateTime.Now.AddDays(6) } }),
            new Tour(3, "Тур 3", "Описание тура 3", 200.0, DateTime.Now, DateTime.Now.AddDays(14), new Dictionary<int, DateTime> { { 1, DateTime.Now.AddDays(5) }, { 2, DateTime.Now.AddDays(8) } })
        };

        public List<Tour> GetAllByNameTours(string s)
		{
            return tours.Where(tour => tour.TourName.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();
        }

		public List<Tour> GetAllTours()
		{
			return tours;
		}

        public Dictionary<int, DateTime> GetAttractionDateByTourId(int id)
        {
            Tour tour = tours.FirstOrDefault(t => t.TourId == id);
            return tour?.AttractionDate ?? new Dictionary<int, DateTime>();
        }

		public List<int> GetAllAttractionByTourId(int id)
		{
            var tour = tours.FirstOrDefault(t => t.TourId == id);
            return tour?.AttractionDate.Keys.ToList() ?? new List<int>();
        }

		public Tour GetTourById(int id)
		{
			return tours.FirstOrDefault(tour => tour.TourId == id);
		}

		public List<Tour> GetAllToursByAllId(List<int> tourIdList)
		{

            List<Tour> tourList = new List<Tour>();

            if (tourIdList != null)
            {
                foreach (int tourId in tourIdList)
                {
                    Tour tour = GetTourById(tourId);
                    if (tour != null)
                    {
                        tourList.Add(tour);
                    }
                }
            }

            return tourList;
        }
    }
}
