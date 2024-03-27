namespace PIS.Service
{
    using PIS.Interface;
    using PIS.Models;
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

        public Tour GetTourById (int id)
        {
            return _tourRepository.GetTourById(id);
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

        public bool AddTour (TourModel model)
        {
            if (model.TourName == null || model.TourPrice == null || model.AttractionDate == null || model.EndDate == null || model.StartDate == null || model.AttractionDate.Count == 0)
            {
                return false;
            }

            if (model.StartDate > model.EndDate)
            {
                return false;
            }

            _tourRepository.AddTour(model.TourName, model.TourDescription, model.TourPrice, model.StartDate, model.EndDate, model.AttractionDate);

            return true;
        }

        public bool UpdateTour(TourModel model)
        {
            if (model.TourId == null || model.TourName == null || model.TourPrice == null || model.AttractionDate == null || model.EndDate == null || model.StartDate == null)
            {
                return false;
            }

            var tour = _tourRepository.GetTourById(model.TourId);

            tour.TourName = model.TourName;
            tour.TourPrice = model.TourPrice;
            tour.TourDescription = model.TourDescription;
            tour.StartDate = model.StartDate;
            tour.EndDate = model.EndDate;
            tour.AttractionDate = model.AttractionDate;

            return true;
        }

        public List<Tour> GetAllTourByPartName(string partName)
        {
            return _tourRepository.GetAllByNameTours(partName);
        }

        public void DeleteTour(int tourId)
        {
            _tourRepository.DeleteTour(tourId);
        }
    }
}
