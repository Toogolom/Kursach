using PIS.Models;

namespace PIS.Interface
{
    public interface IAttractionRepository
    {
        public Task<List<Attraction>> GetAllAttractions();

        public Task<List<Attraction>> GetAllAttractionsByName(string namePart);

        public Task<bool> UpdateAttraction(AttractionModel model);

        public Task<List<Attraction>> GetAllAttractionsByCityId(string cityId);

        public Task<Attraction> GetAttractionById(string id);

        public Task AddAttraction(string name, string description, string URL, string cityId);

        public Task DeleteAttractionById(string id);
    }
}
