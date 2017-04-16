using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderItemsID { get; set; }
        public int OrderID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual Order Order { get; set; }
    }
}