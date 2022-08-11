
using BLL.ModelsDto;
using System.Collections.Generic;

namespace BLL
{
    public interface IStockService
    {
        List<StockDto> GetAllStocks();
        List<OrderDto> GetAllOrders();
        List<OrderDto> GetUpdatedOrders();
        List<BrokerDto> GetAllBrokers();
        List<PersonDto> GetAllClients();
        void updateStockPrice();
        OrderDto GetOrderByID(int ID);
        void UpdateOrder(int ID, double newPrice);
        void DeleteOrder(int ID);
        void CreateOrder(CreateOrderDto newOrder);
    }
}
