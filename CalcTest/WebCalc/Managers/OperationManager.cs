using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCalc.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace WebCalc.Managers
{
    public class OperationManager : IOperationResultRepository
    {
        public IEnumerable<OperationResult> GetAll()
        {
            var items = new List<OperationResult>();

            // Соедениться с БД
            // Вытащить все записи
            var records = DBHelper.GetAllFromTable("OperationResult");

            // Разобрать что вытащили и конвертировать в OperationResult
            foreach(IDictionary<int,object> record in records)
            {
                items.Add(
                    new OperationResult()
                    {
                        Id = (int)record[0], // record["Id"] as long
                        OperationName = record[1].ToString(),
                        Arguments = record[2].ToString(),
                        Result = record[3] as double?,
                        ExecutionTime = (long)record[4],
                        ExecutionDate = (DateTime)record[5]
                    }
                    );
            }

            // Отдать
            return items;
        }

        public OperationResult Load(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(OperationResult entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OperationResult entity)
        {
            throw new NotImplementedException();
        }
    }
}