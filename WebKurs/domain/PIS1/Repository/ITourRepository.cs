namespace PIS.Repository
{
    public interface ITourRepository
    {
        List<Tour> GetAllTours();

        List<Tour> GetAllByNameTours(string namePart);
    }
}
