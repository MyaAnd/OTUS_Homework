using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW_ConsoleApp.Entities
{
    public enum OrderStatus { Created , Delivered }

    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public User UserData { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public OrderInfo OrderInformation { get; set; }
    }
}
