using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.Helpers;
using WebCalc.Managers;



namespace DBModel.Managers
{
    public class EFOperResultRepository : IOperationResultRepository
    {
        public IEnumerable<OperationResult> GetAll()
        {
            using (var context = new OperationResultContext())
            {
                return context.OperationResults.ToList();
            }
        }

        public OperationResult Load(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(OperationResult entity)
        {
            using (var context = new OperationResultContext())
            {
                context.OperationResults.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(OperationResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
