using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW_ConsoleApp.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }
        public ICollection<OrderInfo> OrderInfos { get; } = new List<OrderInfo>();
    }
}
