
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Order
    {
        public long ID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Commission { get; set; }
        public DateTime LastUpdateTime { get; set; }

        [ForeignKey("Broker")]
        public int? BrokerID { get; set; }

        [ForeignKey("Client")]
        public int? ClientID { get; set; }

        [ForeignKey("Stock")]
        public int StockID { get; set; }
        public Stock Stock { get; set; }
        public Broker Broker { get; set; }
        public Person Client { get; set; }

    }
}
