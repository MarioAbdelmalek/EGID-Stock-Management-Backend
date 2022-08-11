
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.ModelsDto
{
    public class OrderDto
    {
        public long ID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Commission { get; set; }
        public DateTime LastUpdateTime { get; set; }

        [ForeignKey("StockDto")]
        public int StockID { get; set; }

        [ForeignKey("BrokerDto")]
        public int? BrokerID { get; set; }

        [ForeignKey("ClientDto")]
        public int? ClientID { get; set; }
        public StockDto Stock { get; set; }
        public BrokerDto Broker { get; set; }
        public PersonDto Client { get; set; }

    }
}
