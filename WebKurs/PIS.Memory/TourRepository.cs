namespace PIS.Memory
{
    using PIS;
    using PIS.Repository;

    public class TourRepository: ITourRepository
	{
		private readonly List<Tour> tours = new List<Tour>
		{
				new Tour(1, "Московский тур", "Описание тура 1", 100.0),
				new Tour(2, "Тур 2", "Описание тура 2", 150.0),
				new Tour(3, "Тур 3", "Описание тура 3", 200.0)
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
	}
}
