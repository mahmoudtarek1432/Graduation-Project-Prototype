using Microsoft.EntityFrameworkCore;
using Prototype.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions opt): base(opt)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItems> OrderItems { get; set; }

        public DbSet<Settings> Settings { get; set; }

    }
}
