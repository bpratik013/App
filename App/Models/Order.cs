using System.Collections.Generic;

namespace App.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}