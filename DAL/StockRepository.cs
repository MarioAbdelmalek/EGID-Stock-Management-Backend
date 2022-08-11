
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Models
{
    public class StockRepository : IStockRepository
    {

        private readonly PostgreSqlContext context;

        public StockRepository(PostgreSqlContext context)
        {
            this.context = context;
        }

        public void updateStockPrice()
        {

            foreach (Stock s in context.Stocks)
            {
                Random rand = new Random();
                int randNum = rand.Next(0, 100) + 1;
                s.Price = randNum;
                context.Update(s);
            }

            context.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            return context.Orders.Include("Stock").ToList();
        }

        public List<Stock> GetAllStocks()
        {
            return context.Stocks.ToList();
        }

        public void UpdateOrder(Order newOrder)
        {
            context.Orders.Update(newOrder);
            context.SaveChanges();
        }

        public void DeleteOrder(int ID)
        {
            var order = context.Orders.FirstOrDefault(t => t.ID == ID);
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public Order GetOrderByID(int ID)
        {
            return context.Orders.FirstOrDefault(t => t.ID == ID);
        }

        public List<Broker> GetAllBrokers()
        {
            return context.Brokers.ToList();
        }

        public List<Person> GetAllClients()
        {
            return context.Clients.ToList();
        }

        public void CreateOrder(Order newOrder)
        {
            context.Orders.Add(newOrder);
            context.SaveChanges();
        }

        public List<Order> GetUpdatedOrders(DateTime dateTime)
        {
            List<Order> updatedOrderList = new List<Order>();
            updatedOrderList = context.Orders.Include("Stock").Where(o => o.LastUpdateTime > dateTime).ToList();
            return updatedOrderList;
        }
    }
}
