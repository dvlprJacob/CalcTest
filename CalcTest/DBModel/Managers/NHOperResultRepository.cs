using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.Models;
using WebCalc.Managers;
using NHibernate;
using DBModel.Helpers;

namespace DBModel.Managers
{
    public class NHOperResultRepository : IOperationResultRepository
    {
        public IEnumerable<OperationResult> GetAll()
        {
            var result = new List<OperationResult>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria<OperationResult>().List<OperationResult>();
            }
            return result;
        }

        public IEnumerable<OperationResult> GetAll(bool flag)
        {
            return GetAll(flag);
        }

        public IDictionary<string, int> GetTop(int limit = 3)
        {
            var result = new Dictionary<string, int>();
            var opers = GetAll();
            var groups = opers.GroupBy(o => o.OperationName)
                              .OrderByDescending(g=>g.Count())
                              .Take(limit);
            foreach(var group in groups)
            {
                result.Add(group.Key, group.Count());
            }
            return result;
        }

        public OperationResult Load(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(OperationResult entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())

            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();
            }
        }

        public void Update(OperationResult entity)
        {
            throw new NotImplementedException();
        }
        public bool Validate(string userName,string password)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return true;
            }
        }
    }
}
