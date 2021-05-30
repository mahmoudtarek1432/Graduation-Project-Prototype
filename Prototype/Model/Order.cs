using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Model
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int Table { get; set; }


        public string Date { get; set; }


        public string additionalInfo { get; set; }

        public List<MenuItem> items { get; set; }

        public List<OrderItems> Orderitems { get; set; }
    }
}
