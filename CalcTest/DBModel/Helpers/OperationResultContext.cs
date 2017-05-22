using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalc.Managers;

namespace DBModel.Helpers
{
    class OperationResultContext : DbContext
    {
        public OperationResultContext():base("EFConnection")
        { }

        public DbSet<OperationResult> OperationResults { get; set; }
    }
}
