using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebCalc.Helpers;

namespace WebCalc.Managers
{
    public class OperationManager : IOperationResultRepository
    {
        public IEnumerable<OperationResult> GetAll()
        {
            var items = new List<OperationResult>();

            // Подключиться к БД 
            // Вытащить все записи
            var records = DBHelper.GetAllFromTable("OperationResult");

            // Разобрать то, что вытащили и превратить в OperationResult
            foreach(IDictionary<int, object> record in records)
            {
                items.Add(
                    new OperationResult()
                    {
                        Id = (int)record[0],
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

        public IEnumerable<OperationResult> GetAll(bool flag)
        {
            return GetAll();
        }

        public IDictionary<string, int> GetTop(int limit = 3)
        {
            throw new NotImplementedException();
        }

        public OperationResult Load(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(OperationResult entity)
        {
            var fields = new List<object>()
            {
                entity.OperationName,
                entity.Arguments, 
                entity.Result, 
                entity.ExecutionTime,
                entity.ExecutionDate.ToString("MM-dd-yyyy HH:mm:ss")

            };
            DBHelper.InsertTable("OperationResult", fields);
        }

        public void Update(OperationResult entity)
        {
            throw new NotImplementedException();
        }
    }
}