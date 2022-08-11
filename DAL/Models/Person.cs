using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("Broker")]
        public int BrokerID { get; set; }

        public Broker Broker { get; set; }
    }
}
