using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    public class Calc
    {
        private string ExtendDllDirectory { get; set; }

        public Calc() : this("")
        {
        }

        public Calc(string extendDllDirectory)
        {
            Operations = new List<IOperation>();

            //var assm = Assembly.GetAssembly(typeof(IOperation));
            //var types = assm.GetTypes().ToList();
            var types = new List<Type>();
            // найти длл рядом с нашим exe

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
                if (interfaces.Any(i=>i.FullName == ioper.FullName))
                {
                    var oper = Activator.CreateInstance(type) as IOperation;
                    if (oper != null)
                    {
                        Operations.Add(oper);
                    }
                }
            }
        }

        /// <summary>
        /// Список доступных операций
        /// </summary>
        public IList<IOperation> Operations { get; private set; }

        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <param name="operation">Название операции</param>
        /// <param name="args">Аргументы операции</param>
        /// <returns></returns>
        public object Execute(IOperation operation, object[] args)
        {
            if (operation == null)
                return null;

            double result = 0;

            var operArgs = operation as IOperationArgs;
            if (operArgs != null)
            {
                result = operArgs.Calc(
                    args.Select(it => int.Parse(it.ToString()))
                );
            }
            else
            {
                // разибраем аргрументы
                int x;
                int.TryParse(args[0].ToString(), out x);

                int y;
                int.TryParse(args[1].ToString(), out y);

                result = operation.Calc(x, y);
            }

            // возвращаем результат
            return result;
        }

        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <param name="operation">Название операции</param>
        /// <param name="args">Аргументы операции</param>
        /// <returns></returns>
        [Obsolete]
        public object Execute(string operation, object[] args)
        {
            // находим операцию в списке доступных
            var oper = Operations.FirstOrDefault(it => it.Name == operation);

            return Execute(oper, args);
        }

        [Obsolete("Не используйте")]
        public int Sum(int x, int y)
        {
            var r = Execute("sum", new object[] { x, y });
            return int.Parse(r.ToString());
        }

        [Obsolete("Не используйте")]
        public double Divide(int x, int y)
        {
            var r = Execute("divide", new object[] { x, y });
            return int.Parse(r.ToString());
        }
    }
}
