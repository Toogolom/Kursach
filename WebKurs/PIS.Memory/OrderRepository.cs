namespace PIS.Memory
{
    using global::PIS.Interface;
    using global::PIS.Models;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public OrderRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _orderCollection = database.GetCollection<Order>("Orders");
        }

        public async Task<List<Order>> GetAllByUserId(string id)
        {
            return await _orderCollection.Find(order => order.UserId == id).ToListAsync();
        }

        public async Task<List<string>> GetAllTourByUserId(string id)
        {
            var orders = await _orderCollection.Find(order => order.UserId == id).ToListAsync();
            return orders.SelectMany(order => order.TourId).ToList();
        }

        public async Task AddOrder(string userId, List<string> tourId, DateTime date)
        {
            var order = new Order(userId, tourId, date);
            await _orderCollection.InsertOneAsync(order);
        }
    }

}