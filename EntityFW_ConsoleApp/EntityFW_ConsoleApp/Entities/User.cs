using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW_ConsoleApp.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
