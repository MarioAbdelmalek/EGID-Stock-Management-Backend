using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDto
{
    public class CreateOrderDto
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int StockID { get; set; }
    }
}
