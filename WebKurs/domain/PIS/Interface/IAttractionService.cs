using PIS.Models;

namespace PIS.Interface
{
    public interface IAttractionService
    {
        public List<Attraction> GetAllAttraction();
        public List<Attraction> GetAllAttractionsByCityId(int cityId);

        public List<Attraction> GetAllAtractionByPartName(string partName);

        public bool AddAttraction(AttractionModel model);

        public bool UpdateAttraction(AttractionModel model);

        public Attraction GetAttractionById(int id);

        public void DeleteAttrationById(int id);
    }
}
