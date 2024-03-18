namespace PIS.Interface
{
    using System;
    using System.Collections.Generic;
    using WebKurs.Models;

    public interface IOrderService
    { 
        public void AddTourToOrder(int tourId);
        public double CalculateTotalPrice(List<Tour> tours);
        public OrderModel CreateOrder();
        public void RemoveTourFromOrder(int tourId);
    }
}
