namespace PIS.Service
{
    using PIS.Interface;
    using PIS.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;

        private readonly IAttractionRepository _attractionRepository;

        public TourService(ITourRepository tourRepository, IAttractionRepository attractionRepository)
        {
            _tourRepository = tourRepository;
            _attractionRepository = attractionRepository;
        }

        public async Task<List<Tour>> GetAllToursAsync()
        {
            return await _tourRepository.GetAllTours();
        }

        public async Task<Tour> GetTourByIdAsync (string id)
        {
            return await _tourRepository.GetTourById(id);
        }

        public async Task<List<Tour>> GetAllToursByAllIdAsync(List<string> tourIdList)
        {
            return await _tourRepository.GetAllToursByAllId(tourIdList);
        }

        public async Task<List<Attraction>> GetAllAttractionForTour(string tourId)
        {
            var attractionIds = await _tourRepository.GetAllAttractionByTourId(tourId);
            var attractions = new List<Attraction>();
            foreach (var attractionId in attractionIds)
            {
                var attraction = await _attractionRepository.GetAttractionById(attractionId);
                attractions.Add(attraction);
            }
            return attractions;
        }

        public async Task<Dictionary<Attraction, DateTime>> GetAttractionDateForTour(string id)
        {
            var AttractionDate = new Dictionary<Attraction, DateTime>();

            var attractionDateById = await _tourRepository.GetAttractionDateByTourId(id);

            foreach (var kvp in attractionDateById)
            {
                var attraction = await _attractionRepository.GetAttractionById(kvp.Key);
                if (attraction != null)
                {
                    AttractionDate.Add(attraction, kvp.Value);
                }
            }

            return AttractionDate;

        }

        public async Task<bool> AddTourAsync (TourModel model)
        {
            if (model.TourName == null || model.TourPrice == null || model.AttractionDate == null || model.EndDate == null || model.StartDate == null || model.AttractionDate.Count == 0)
            {
                return false;
            }

            await _tourRepository.AddTour(model.TourName, model.TourDescription, model.TourPrice, model.StartDate, model.EndDate, model.AttractionDate);

            return true;
        }

        public async Task<bool> UpdateTourAsync(TourModel model)
        {
            if (model.TourId == null || model.TourName == null || model.TourPrice == null || model.AttractionDate == null || model.EndDate == null || model.StartDate == null)
            {
                return false;
            }

            return await _tourRepository.UpdateTour(model);
        }

        public async Task<List<Tour>> GetAllTourByPartNameAsync(string partName)
        {
            return await _tourRepository.GetAllByNameTours(partName);
        }

        public async Task DeleteTour(string tourId)
        {
            await _tourRepository.DeleteTour(tourId);
        }
    }
}
