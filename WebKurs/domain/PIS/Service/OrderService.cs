namespace PIS.Service
{
    using PIS.Interface;
    using System;
    using System.Collections.Generic;
    using WebKurs.Models;

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ITourRepository _tourRepository;

        private readonly IUserRepository _userRepository;

        private readonly ISessionService _sessionService;

        public OrderService(IOrderRepository orderRepository, ITourRepository tourRepository, IUserRepository userRepository, ISessionService sessionService)
        {
            _orderRepository = orderRepository;
            _tourRepository = tourRepository;
            _userRepository = userRepository;
            _sessionService = sessionService;
        }

        public void AddTourToOrder(int tourId)
        {
            List<int> tourIdList = _sessionService.Get<List<int>>("TourIdList");

            if (tourIdList == null)
            {
                tourIdList = new List<int>();
            }

            tourIdList.Add(tourId);

            _sessionService.Set("TourIdList", tourIdList);
        }

        public double CalculateTotalPrice(List<Tour> tours)
        {
            double totalPrice = 0;
            foreach(Tour tour in tours)
            {
                totalPrice += tour.TourPrice;
            }
            return totalPrice;
        }

        public OrderModel CreateOrder()
        {
            var username = _sessionService.Get<string>("Username");
            var date = DateTime.Now;
            var tourIdList = _sessionService.Get<List<int>>("TourIdList");
            List<Tour> tourList = _tourRepository.GetAllToursByAllId(tourIdList);
            var totalPrice = CalculateTotalPrice(tourList);
            return new OrderModel { 
                Username = username,
                TourList = tourList,
                TotalPrice = totalPrice,
                Date = date };
        }

        public void AddOrder(OrderModel model)
        {
            var user = _userRepository.GetUserByUsername(model.Username);
            var tourIdList = _sessionService.Get<List<int>>("TourIdList");
            _orderRepository.AddOrder(user.UserId, tourIdList, model.Date);
            _sessionService.Remove("TourIdList");
        }

        public void RemoveTourFromOrder(int tourId)
        {
            List<int> tourIdList = _sessionService.Get<List<int>>("TourIdList");

            if (tourIdList != null)
            {
                tourIdList.Remove(tourId);
                _sessionService.Set("TourIdList", tourIdList);
            }
        }
    }
}
