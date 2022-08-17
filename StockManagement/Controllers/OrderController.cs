using System.Collections.Generic;
using BLL;
using BLL.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IStockService stockService;
        public OrderController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        [Route("getAllOrders")]
        [HttpGet]
        public IEnumerable<OrderDto> GetAllOrders()
        {
            return stockService.GetAllOrders();
        }

        [Route("getUpdatedOrders")]
        [HttpGet]
        public IEnumerable<OrderDto> GetUpdatedOrders()
        {
            return stockService.GetUpdatedOrders();
        }

        [Route("getById")]
        [HttpGet]
        public OrderDto GetOrderByID(int ID)
        {
            return stockService.GetOrderByID(ID);
        }

        [Route("create")]
        [HttpPost]
        public void CreateOrder(CreateOrderDto newOrder)
        {
            stockService.CreateOrder(newOrder);
        }

        [Route("update")]
        [HttpPut]
        public void UpdateOrder(int ID, double newPrice)
        {
            stockService.UpdateOrder(ID, newPrice);
        }

        [Route("delete")]
        [HttpDelete]
        public void DeleteOrder(int ID)
        {
            stockService.DeleteOrder(ID);
        }
    }
}
