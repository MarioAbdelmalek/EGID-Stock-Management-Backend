using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        IStockService stockService;
        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        [Route("getAllStocks")]
        [HttpGet]
        public IEnumerable<StockDto> GetAllStocks()
        {
            return stockService.GetAllStocks();
        }
    }
}
