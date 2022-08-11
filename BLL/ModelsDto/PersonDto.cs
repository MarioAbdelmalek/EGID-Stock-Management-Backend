
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.ModelsDto
{
    public class PersonDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("BrokerDto")]
        public int BrokerID { get; set; }

        public BrokerDto Broker { get; set; }
    }
}
