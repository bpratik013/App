using System;
using System.Collections.Generic;

namespace App.Models
{
    public class OrderVM
    {
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string Description { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}