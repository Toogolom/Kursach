namespace PIS.Interface
{
    public interface ITourRepository
    {
        public List<Tour> GetAllTours();

        public List<Tour> GetAllByNameTours(string namePart);

        public List<int> GetAllAttractionByTourId(int tourId);
    }
}
