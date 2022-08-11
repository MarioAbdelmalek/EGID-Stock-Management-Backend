using BLL;
using DAL;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockManagement.HubConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagement
{
    public class TimerService : BackgroundService
    {
        IServiceProvider serviceProvider;
        private readonly IHubContext<StockHub> stockHub;

        public TimerService(IServiceProvider serviceProvider, IHubContext<StockHub> stockHub)
        {
            this.serviceProvider = serviceProvider;
            this.stockHub = stockHub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var hostedService = scope.ServiceProvider.GetRequiredService<IStockService>();
                    hostedService.updateStockPrice();
                    var updatedStockList = hostedService.GetAllStocks();
                    var updatedOrderList = hostedService.GetUpdatedOrders();

                    if(updatedOrderList.Count != 0)
                    {
                        await stockHub.Clients.All.SendAsync("UpdateOrders", Newtonsoft.Json.JsonConvert.SerializeObject(updatedOrderList));
                    }

                    await stockHub.Clients.All.SendAsync("UpdateStockPrices", Newtonsoft.Json.JsonConvert.SerializeObject(updatedStockList));
                }
                await Task.Delay(new TimeSpan(0, 0, 10));
            }
        }
    }
}
