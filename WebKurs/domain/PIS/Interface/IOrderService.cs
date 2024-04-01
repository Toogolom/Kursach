namespace PIS.Interface
{
    using System;
    using System.Collections.Generic;
    using WebKurs.Models;

    public interface IOrderService
    { 
        public void AddTourToOrder(string tourId);

        public double CalculateTotalPrice(List<Tour> tours);

        public Task<OrderModel> CreateOrder();

        public Task AddOrderAsync(OrderModel model);

        public Task<List<OrderModel>> GetAllOrdersByUsername();

        public void RemoveTourFromOrder(string tourId);
    }
}
