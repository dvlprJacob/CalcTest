using DBModel.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;
using WebCalc.Managers;
using DBModel.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DBModel.Managers
{
    [Obsolete("Отстой", true)]
    public class EFOperResultRepository : BaseRepository<OperationResult>, IOperationResultRepository
    {
        private DbSet<OperationResult> OperationResults { get; set; }

        public EFOperResultRepository(DbContext context) : base(context)
        {
            OperationResults = context.Set<OperationResult>();
        }

        public override IEnumerable<OperationResult> GetAll()
        {
            return OperationResults.ToList();
        }

        public override IEnumerable<OperationResult> GetAll(bool flag)
        {
            return flag ? OperationResults.Include(item=>item.Iniciator).ToList() : GetAll();
        }

        public override void Save(OperationResult entity)
        {
            OperationResults.Add(entity);
            _db.SaveChanges();
        }

        public IDictionary<string, int> GetTop(int limit = 3)
        {
            var result = new Dictionary<string, int>();

            var limitParam = new SqlParameter("@limit", limit);

            var data = _db.Database.SqlQuery<TopOp>(
                $"select top {limit} OperationName, Count(*) as [Count] from OperationResult group by [OperationName] order by [Count] desc"
            );

            foreach (var item in data)
            {
                result.Add(item.OperationName, item.Count);
            }

            return result;
        }

        private class TopOp
        {
            public string OperationName { get; set; }

            public int Count { get; set; }
        }
    }
}
