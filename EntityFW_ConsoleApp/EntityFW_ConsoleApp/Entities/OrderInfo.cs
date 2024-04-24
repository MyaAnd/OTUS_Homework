using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW_ConsoleApp.Entities
{
    public class OrderInfo
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public Order OrderData { get; set; }
        public int ProductID { get; set; }
        public Product ProductData { get; set; }
        public int Quantity { get; set; }
        public double TotalCost { get; set; }
    }
}
