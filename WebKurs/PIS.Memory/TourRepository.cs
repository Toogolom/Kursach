﻿namespace PIS.Memory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using global::PIS.Interface;
    using global::PIS.Models;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;

    public class TourRepository : ITourRepository
    {
        private readonly IMongoCollection<Tour> _tourCollection;

        public TourRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _tourCollection = database.GetCollection<Tour>("Tours");
        }

        public async Task AddTour(string name, string description, double price, DateTime startDate, DateTime endDate, Dictionary<string, DateTime> AttractionDate, string URL)
        {
            Tour tour = new Tour(name, description, price, startDate, endDate, AttractionDate,URL);
            await _tourCollection.InsertOneAsync(tour);
        }

        public async Task<List<Tour>> GetAllByNameTours(string s)
        {
            return await _tourCollection.Find(tour => tour.TourName.ToLower().Contains(s.ToLower()))
                .ToListAsync();
        }

        public async Task<List<Tour>> GetAllTours()
        {
            return await _tourCollection.Find(tour => true).ToListAsync();
        }

        public async Task<Dictionary<string, DateTime>> GetAttractionDateByTourId(string id)
        {
            var tour = await _tourCollection.Find(t => t.TourId == id).FirstOrDefaultAsync();
            return tour?.AttractionDate ?? new Dictionary<string, DateTime>();
        }

        public async Task<List<string>> GetAllAttractionByTourId(string id)
        {
            var tour = await _tourCollection.Find(t => t.TourId == id).FirstOrDefaultAsync();
            return tour?.AttractionDate.Keys.ToList() ?? new List<string>();
        }

        public async Task<Tour> GetTourById(string id)
        {
            return await _tourCollection.Find(tour => tour.TourId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateTour(TourModel tour)
        {
            var filter = Builders<Tour>.Filter.Eq(t => t.TourId, tour.TourId);
            var update = Builders<Tour>.Update
                .Set(t => t.TourName, tour.TourName)
                .Set(t => t.TourDescription, tour.TourDescription)
                .Set(t => t.StartDate, tour.StartDate)
                .Set(t => t.EndDate, tour.EndDate);

            var updateResult = await _tourCollection.UpdateOneAsync(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public async Task<List<Tour>> GetAllToursByAllId(List<string> tourIdList)
        {
            List<Tour> tourList = new List<Tour>();

            if (tourIdList != null)
            {
                foreach (var tourId in tourIdList)
                {
                    Tour tour = await GetTourById(tourId);
                    if (tour != null)
                    {
                        tourList.Add(tour);
                    }
                }
            }

            return tourList;
        }

        public async Task DeleteTour(string tourId)
        {
            await _tourCollection.DeleteOneAsync(tour => tour.TourId == tourId);
        }
    }
}
