using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Model
{
    public class Settings
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string primaryColor { get; set; }
        public string secondaryColor { get; set; }
        public int theme { get; set; }
        public int menuVersion { get; set; }
        public bool OrderUpdated { get; set; }
    }
}
