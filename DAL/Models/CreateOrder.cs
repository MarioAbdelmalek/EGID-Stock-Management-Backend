using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class CreateOrder
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int StockID { get; set; }
    }
}
