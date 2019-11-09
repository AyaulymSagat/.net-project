using Microsoft.EntityFrameworkCore;
using RentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace RentCar.Data
{
    public class RentContext : DbContext
    {
        public RentContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Pasport> Pasport { get; set; }
        public DbSet<RentedCars> RentedCars { get; set; }
    }
}
