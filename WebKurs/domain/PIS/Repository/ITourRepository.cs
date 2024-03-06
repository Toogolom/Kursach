namespace PIS.Repository
{
    public interface ITourRepository
    {
        public List<Tour> GetAllTours();

        public List<Tour> GetAllByNameTours(string namePart);
    }
}
