using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Timers;
using AutoMapper;
using BLL.ModelsDto;
using Microsoft.AspNetCore.SignalR;

namespace BLL
{
    public class StockService : IStockService
    {

        IStockRepository stockRepository;
        private readonly IMapper mapper;
        public static DateTime dateTime = DateTime.Now;

        public StockService(IStockRepository stockRepository, IMapper mapper)
        {
            this.stockRepository = stockRepository;
            this.mapper = mapper;
        }

        public void updateStockPrice()
        {
            stockRepository.updateStockPrice();
        }

        public List<OrderDto> GetAllOrders()
        {
            var mappedOrderList =  stockRepository.GetAllOrders();
            return mapper.Map<List<OrderDto>>(mappedOrderList);
        }

        public List<StockDto> GetAllStocks()
        {
            var mappedStockList =  stockRepository.GetAllStocks();
            return mapper.Map<List<StockDto>>(mappedStockList);
        }

        public OrderDto GetOrderByID(int ID)
        {
            var mappedOrder = stockRepository.GetOrderByID(ID);
            return mapper.Map<OrderDto>(mappedOrder);
        }

        public void UpdateOrder(int ID, double newPrice)
        {
            OrderDto oldOrder = GetOrderByID(ID);
            if(oldOrder != null)
            {
                oldOrder.Price = newPrice;
                oldOrder.LastUpdateTime = DateTime.Now;
                stockRepository.UpdateOrder(mapper.Map<Order>(oldOrder));
            }
        }

        public void DeleteOrder(int ID)
        {
            stockRepository.DeleteOrder(ID);
        }

        public void CreateOrder(CreateOrderDto newOrder)
        {

             double totalPrice = newOrder.Price * newOrder.Quantity;

             Random clientOrBroker = new Random();
             int clientOrBrokerRand = clientOrBroker.Next(0, 2);

             if (clientOrBrokerRand == 0)
             {
                 double brokerCommission = totalPrice * 0.01;

                 Random brokerRand = new Random();
                 List <BrokerDto> brokerList = GetAllBrokers();
                 int brokerRandNum = brokerRand.Next(0, brokerList.Count);

                 OrderDto d = new OrderDto { StockID = newOrder.StockID, Quantity = newOrder.Quantity, Price = newOrder.Price, Commission = brokerCommission, BrokerID = brokerList[brokerRandNum].ID, LastUpdateTime = DateTime.Now};
                 stockRepository.CreateOrder(mapper.Map<Order>(d));
            }

             else
             {
                 double clientCommission = totalPrice * 0.02;

                 Random clientRand = new Random();
                 List<PersonDto> clientList = GetAllClients();
                 int clientRandNum = clientRand.Next(0, clientList.Count);

                 OrderDto d = new OrderDto { StockID = newOrder.StockID, Quantity = newOrder.Quantity, Price = newOrder.Price, Commission = clientCommission, ClientID = clientList[clientRandNum].ID, LastUpdateTime = DateTime.Now};
                 stockRepository.CreateOrder(mapper.Map<Order>(d));
            }


        }

        public List<BrokerDto> GetAllBrokers()
        {
            var mappedBrokerList = stockRepository.GetAllBrokers();
            return mapper.Map<List<BrokerDto>>(mappedBrokerList);
        }

        public List<PersonDto> GetAllClients()
        {
            var mappedClientList = stockRepository.GetAllClients();
            return mapper.Map<List<PersonDto>>(mappedClientList);
        }

        public List<OrderDto> GetUpdatedOrders()
        {
            var mappedUpdatedOrderList = stockRepository.GetUpdatedOrders(dateTime);

            foreach(Order o in mappedUpdatedOrderList)
            {
                if(o.LastUpdateTime > dateTime)
                {
                    dateTime = o.LastUpdateTime;
                }
            }
            return mapper.Map<List<OrderDto>>(mappedUpdatedOrderList);
        }
    }
}
