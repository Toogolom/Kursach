namespace PIS.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IOrderService
    { 
        public void AddTourToOrder(int tourId);
        public double CalculateTotalPrice(List<Tour> tours);
        public Order CreateOrder();
        public void RemoveTourFromOrder(int tourId);
    }
}
