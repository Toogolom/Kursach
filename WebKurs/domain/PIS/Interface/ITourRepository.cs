using PIS.Models;

namespace PIS.Interface
{
    public interface ITourRepository
    {
        public Task AddTour(string name, string description, double price, DateTime startDate, DateTime endDate, Dictionary<string,DateTime> AttractionDate);

        public Task<List<Tour>> GetAllTours();

        public Task<List<Tour>> GetAllByNameTours(string namePart);

        public Task<Tour> GetTourById(string id);

        public Task<bool> UpdateTour(TourModel tour);

        public Task<Dictionary<string, DateTime>> GetAttractionDateByTourId(string id);

        public Task<List<string>> GetAllAttractionByTourId(string tourId);

        public Task<List<Tour>> GetAllToursByAllId(List<string> tourIdList);

        public Task DeleteTour(string id);
    }
}
