namespace PIS.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IOrderRepository
    {
       public List<Order> GetAllByUserId(int id);
       
       public List<int> GetAllTourByUserId(int id);

        public void AddOrder(int userId, List<int> tourId, DateTime data);
    }
}
