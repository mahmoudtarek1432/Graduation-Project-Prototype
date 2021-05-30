using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Model
{
    public class MenuItem
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string ItemName {get; set;}

        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category category { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
