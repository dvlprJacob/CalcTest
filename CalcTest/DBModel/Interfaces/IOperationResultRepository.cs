using DBModel.Models;
using System.Collections.Generic;

namespace WebCalc.Managers
{
    public interface IOperationResultRepository : IBaseRepository<OperationResult>
    {
        IDictionary<string, int> GetTop(int limit = 3);
    }
}
