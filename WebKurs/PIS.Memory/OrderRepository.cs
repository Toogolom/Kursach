namespace PIS.Memory
{
    using PIS;
    using PIS.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OrderRepository : IOrderRepository
    {
        private List<Order> orders = new List<Order>
        {
            new Order(1,1,new List<int> {1,2},DateTime.Now),
            new Order(2,3,new List<int> {1,3},DateTime.Now),
            new Order(3,2,new List<int> {3,2},DateTime.Now),
            new Order(4,3,new List<int> {3,1,2},DateTime.Now),
        };
        public List<Order> GetAllByUserId(int id)
        {
            return orders.Where(order => order.UserId == id)
                         .ToList();
        }

        public List<int> GetAllTourByUserId(int id)
        {
            return orders.Where(order => order.UserId == id)
                         .SelectMany(order => order.TourId)
                         .ToList();
        }
    }
}
