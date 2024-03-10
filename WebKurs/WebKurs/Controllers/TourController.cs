﻿using Microsoft.AspNetCore.Mvc;
using PIS.Memory;
using PIS;
using PIS.Interface;

namespace WebKurs.Controllers
{
    public class TourController : Controller
    {
        public ITourRepository _tourRepository;
        public IAttractionRepository _attractionRepository;

        public TourController(ITourRepository tourRepository, IAttractionRepository attractionRepository)
        {
            _tourRepository = tourRepository;
            _attractionRepository = attractionRepository;
        }

        public IActionResult Index()
        {
            var tour = _tourRepository.GetAllTours();
            return View(tour);
        }

        public IActionResult DetailsTour(int tourId)
        {
            var attractionIds = _tourRepository.GetAllAttractionByTourId(tourId);
            var attractions = new List<Attraction>();
            foreach (var attractionId in attractionIds)
            {
                var attraction = _attractionRepository.GetAttractionById(attractionId);
                attractions.Add(attraction);
            }
            return View(attractions);
        }
    }
}
