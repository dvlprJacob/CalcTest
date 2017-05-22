using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalc.Managers;

namespace DBModel.Helpers
{
    class UserContext : DbContext
    {
        public UserContext():base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
}
