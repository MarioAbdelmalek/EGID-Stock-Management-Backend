using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IStockRepository
    {
        List<Stock> GetAllStocks();
        List<Order> GetAllOrders();
        List<Order> GetUpdatedOrders(DateTime dateTime);
        Order GetOrderByID(int ID);
        void UpdateOrder(Order order);
        void DeleteOrder(int ID);
        public void updateStockPrice();
        List<Broker> GetAllBrokers();
        List<Person> GetAllClients();
        void CreateOrder(Order order);
    }
}
