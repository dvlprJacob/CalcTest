using DBModel.Models;
using System;
using System.Data.Entity;

namespace DBModel.Helpers
{
    [Obsolete("Отстой", false)]
    public class CalcContext : DbContext
    {
        public CalcContext() : base("EFConnection")
        {
        }

        public DbSet<OperationResult> OperationResults { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
