using System;
using System.Collections.Generic;

namespace OrdersMicroservice.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
