namespace PIS.Interface
{
    public interface ITourRepository
    {
        public List<Tour> GetAllTours();

        public List<Tour> GetAllByNameTours(string namePart);

        public Tour GetTourById(int id);

        public Dictionary<int, DateTime> GetAttractionDateByTourId(int id);

        public List<int> GetAllAttractionByTourId(int tourId);

        public List<Tour> GetAllToursByAllId(List<int> tourIdList);
    }
}
