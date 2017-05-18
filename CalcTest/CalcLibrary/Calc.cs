using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Collections;

namespace CalcLibrary
{
    public class Calc
    {
        public string ExtendDllDirectory { get; set; }

        public Calc() : this("")
        { }

        /// <summary>
        /// 
        /// </summary>
        public Calc(string extendDllDirectory)
        {
            Operations = new List<IOperation>();

            var types = new List<Type>();

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
                        Operations.Add(oper);
                    }
                }
            }
        }


        /// <summary>
        /// Список  доступных операций
        /// </summary>
        public IList<IOperation> Operations { get; private set; }

        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <param name="IOperation">Название операции, реализующий IOperation</param>
        /// <param name="args">Аргументы операции</param>
        /// <returns></returns>
        public object Execute(IOperation operation, object[] args)
        {
            //находим опер в списке доступных иначе возвращ ошибку,если нашли - разбираем аргументы,
            //вызываем саму опер и возвр результат

            if (operation == null)
                return null;
            var oper = Operations.FirstOrDefault(it => it.Name == operation.Name); // лямбда-выражение

            //Если не нашли
            if (oper == null)
            {
                return "Error";
            }
            // если нашли, вызываем саму операцию
            double result = 0;
            //разбираем аргументы
            int x;
            int.TryParse(args[0].ToString(), out x);

            int y;
            int.TryParse(args[1].ToString(), out y);

            result = oper.Calc(x, y);

            return result;
        }

        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <param name="IOperationArgs">Название операции, реализующий IOperationArgs</param>
        /// <param name="args">Аргументы операции</param>
        /// <returns></returns>
        public object Execute(IOperationArgs operation, object[] args)
        {
            //находим опер в списке доступных иначе возвращ ошибку,если нашли - разбираем аргументы,
            //вызываем саму опер и возвр результат

            var oper = Operations.FirstOrDefault(it => it.Name == operation.Name); // лямбда-выражение

            //Если не нашли
            if (oper == null)
            {
                return "Error";
            }
            // если нашли, вызываем саму операцию
            double result = 0;

            var operArgs = oper as IOperationArgs;
            if (operArgs != null)
            {

                result = operArgs.Calc(
                    args.Select(it => int.Parse(it.ToString()))
                    );

            }
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
            var oper = Operations.FirstOrDefault(x => x.Name == operation);
            if (oper is IOperationArgs)
                return Execute(oper as IOperationArgs, args);
            return Execute(oper, args);
        }

        [Obsolete("Не использовать")]
        public int Sum(int x, int y)
        {
            // return 0; - для первого теста

            var r = Execute("sum", new object[] { x, y });
            return int.Parse(r.ToString());
        }

        public double Divide(int x, int y)
        {
            var r = Execute("divide", new object[] { x, y });
            return int.Parse(r.ToString());
        }
    }
}
