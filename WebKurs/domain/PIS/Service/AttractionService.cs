namespace PIS.Service
{
    using PIS.Interface;
    using PIS.Models;
    using System;
    public class AttractionService : IAttractionService
    {
        private readonly IAttractionRepository _attractionRepository;

        public AttractionService(IAttractionRepository attractionRepository)
        {
            _attractionRepository = attractionRepository;
        }

        public List<Attraction> GetAllAttraction()
        {
            return _attractionRepository.GetAllAttractions();
        }

        public List<Attraction> GetAllAttractionsByCityId(int cityId)
        {
            return _attractionRepository.GetAllAttractionsByCityId(cityId);
        }

        public List<Attraction> GetAllAtractionByPartName(string partName)
        {
            return _attractionRepository.GetAllAttractionsByName(partName);
        }

        public bool AddAttraction(AttractionModel model)
        {
            _attractionRepository.AddAttraction(model.AttractionName, model.AttractionDescription, model.AttractionPhotoUrl, model.CityId);
            return true;
        }

        public bool UpdateAttraction(AttractionModel model)
        {
            if (model.AttractionPhotoUrl == null || model.AttractionDescription == null || model.AttractionName == null)
            {
                return false;
            }

            Attraction attraction = _attractionRepository.GetAttractionById(model.AttractionId);

            attraction.AttractionName = model.AttractionName;
            attraction.AttractionDescription = model.AttractionDescription;
            attraction.AttractionPhotoUrl = model.AttractionPhotoUrl;
            attraction.CityId = model.CityId;

            return true;
        }

        public Attraction GetAttractionById(int id)
        {
            return _attractionRepository.GetAttractionById(id);
        }

        public void DeleteAttrationById(int id)
        {
            _attractionRepository.DeleteAttractionById(id);
        }
    }
}
