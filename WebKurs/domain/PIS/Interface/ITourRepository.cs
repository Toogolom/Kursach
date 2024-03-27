namespace PIS.Interface
{
    public interface ITourRepository
    {
        public void AddTour(string name, string description, double price, DateTime startDate, DateTime endDate, Dictionary<int,DateTime> AttractionDate);

        public List<Tour> GetAllTours();

        public List<Tour> GetAllByNameTours(string namePart);

        public Tour GetTourById(int id);

        public Dictionary<int, DateTime> GetAttractionDateByTourId(int id);

        public List<int> GetAllAttractionByTourId(int tourId);

        public List<Tour> GetAllToursByAllId(List<int> tourIdList);

        public void DeleteTour(int id);
    }
}
