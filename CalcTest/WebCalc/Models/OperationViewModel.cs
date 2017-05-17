using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalcLibrary;

using System.Web.Mvc;
using WebCalc.Models;
using System.IO;
using System.Reflection;

namespace WebCalc.Models
{
    public class OperationBeauty
    {
        public CalcLibrary.IOperation Operation { get; set; }
        public string Name { get; set; }
        public OperationBeauty(CalcLibrary.IOperation operation)
        {
            Operation = operation;
            var type = operation.GetType();
            Name = $"{type.Name}.{operation.Name}";
        }
    }
    public class OperationViewModel
    {
        // Выпадающий список доступных операций
        public IList<string> Operations { get; set; }
        // Загрузка доступных операций
        public void GetOperations()
        {
            IList<string> Operations;
            Operations = new List<string>();

            var types = new List<Type>();
            string extendDllDirectory = @"C:\Users\Jacob\Desktop\Elma\Tasks\CalcTest\WebCalc\bin\";
            var path = string.IsNullOrWhiteSpace(extendDllDirectory)
                ? Directory.GetCurrentDirectory()
                : extendDllDirectory;

            var dlls = Directory.GetFiles(path, "*.dll");
            foreach (var dll in dlls)
            {
                // загрузить ее как сборку
                var assm = Assembly.LoadFrom(dll);
                // добавить типы
                types.AddRange(assm.GetTypes());
            }

            var ioper = typeof(IOperation);
            
            foreach (var type in types)
            {
                if (type.IsInterface)
                    continue;

                var interfaces = type.GetInterfaces();

                if (interfaces.Any(i => i.FullName == ioper.FullName))
                {
                    var oper = Activator.CreateInstance(type) as IOperation;
                    if (oper != null)
                    {
                        Operations.Add(new OperationBeauty(oper).Name);
                    }
                }

            }
            this.Operations = Operations;
            return;
        }
        public string Operation { get; set; }
        public string InputData { get; set; }
        public string Result { get; set; }

    }
}