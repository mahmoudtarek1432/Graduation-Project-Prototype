﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prototype.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        
        public List<MenuItem> items { get; set; }

    }
}