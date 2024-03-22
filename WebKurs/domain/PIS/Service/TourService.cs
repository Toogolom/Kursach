namespace PIS.Service
{
    using PIS.Interface;
    using System;
    using System.Collections.Generic;

    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;

        private readonly IAttractionRepository _attractionRepository;

        public TourService(ITourRepository tourRepository, IAttractionRepository attractionRepository)
        {
            _tourRepository = tourRepository;
            _attractionRepository = attractionRepository;
        }

        public List<Tour> GetAllTours()
        {
            return _tourRepository.GetAllTours();
        }

        public List<Tour> GetAllToursByAllId(List<int> tourIdList)
        {
            return _tourRepository.GetAllToursByAllId(tourIdList);
        }

        public List<Attraction> GetAllAttractionForTour(int tourId)
        {
            var attractionIds = _tourRepository.GetAllAttractionByTourId(tourId);
            var attractions = new List<Attraction>();
            foreach (var attractionId in attractionIds)
            {
                var attraction = _attractionRepository.GetAttractionById(attractionId);
                attractions.Add(attraction);
            }
            return attractions;
        }

        public Dictionary<Attraction, DateTime> GetAttractionDateForTour(int id)
        {
            var AttractionDate = new Dictionary<Attraction, DateTime>();

            var attractionDateById = _tourRepository.GetAttractionDateByTourId(id);

            foreach (var kvp in attractionDateById)
            {
                var attraction = _attractionRepository.GetAttractionById(kvp.Key);
                if (attraction != null)
                {
                    AttractionDate.Add(attraction, kvp.Value);
                }
            }

            return AttractionDate;

        }
    }
}
