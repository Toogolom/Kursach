using PIS.Models;

namespace PIS.Interface
{
    public interface IAttractionService
    {
        public List<Attraction> GetAllAttractionsByCityId(int cityId);

        public List<Attraction> GetAllAtractionByPartName(string partName);

        public void AddAttraction(AttractionModel model);

        public void DeleteAttrationById(int id);
    }
}
