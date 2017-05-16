using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace CalcLibrary
{
    public class Calc
    {
        /// <summary>
        /// 
        /// </summary>
        public Calc()
        {
            Operations = new List<IOperation>();

            //var assm = Assembly.GetAssembly(typeof(IOperation));
            //var types = assm.GetTypes().ToList();
            var types = new List<Type>();

            // найти dll радом с нашим exe
            var dlls = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
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
                //проверять по нему
                //type.FullName
                //distinct
                //переписать execute, чтоб принимала IOperation
                if (type.IsInterface)
                    continue;
                var interfaces = type.GetInterfaces();
                if (interfaces.Contains(ioper))
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
        /// <param name="operation">Название операции</param>
        /// <param name="args">Аргументы операции</param>
        /// <returns></returns>
        [Obsolete]
        public object Execute(string operation, object[] args)
        {
            //находим опер в списке доступных иначе возвращ ошибку,если нашли - разбираем аргументы,
            //вызываем саму опер и возвр результат

            var oper = Operations.FirstOrDefault(it => it.Name == operation); // лямбда-выражение

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
            else
            {
                //разбираем аргументы
                int x;
                int.TryParse(args[0].ToString(), out x);

                int y;
                int.TryParse(args[1].ToString(), out y);

                result = oper.Calc(x, y);
            }
            return result;
        }
        /*
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
        */
    }
}
