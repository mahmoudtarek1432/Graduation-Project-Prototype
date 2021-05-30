using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Model
{
    public class OrderItems
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("order")]
        [Required]
        public int OrderId { get; set; }


        [Required]
        [ForeignKey("item")]
        public int MenuItemId { get; set; }
        public MenuItem item { get; set; }
    }


}
