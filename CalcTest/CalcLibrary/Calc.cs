using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CalcLibrary
{
    public class Calc
    {
        public Calc()
        {
            operations = new List<IOperation>();
            var assm = Assembly.GetAssembly(typeof(IOperation));
            var types = assm.GetTypes();

            //
            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                if (interfaces.Contains(typeof(IOperation)))
                {
                    var oper = Activator.CreateInstance(type) as IOperation;
                    if (oper != null)
                    {
                        operations.Add(oper);
                    }
                }
            }
            //Эквивалент foreach - var opers = assm.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IOperation)));
        }


        /// <summary>
        /// Список  доступных операций
        /// </summary>
        private IList<IOperation> operations { get; set; }

        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <param name="operation">Название операции</param>
        /// <param name="args">Аргументы операции</param>
        /// <returns></returns>
        public object Execute(string operation, object[] args)
        {
            //находим опер в списке доступных иначе возвращ ошибку,если нашли - разбираем аргументы,
            //вызываем саму опер и возвр результат

            var oper = operations.FirstOrDefault(it => it.Name == operation);

            //Если не нашли
            if (oper == null)
            {
                return "Error";
            }
            //если нашли,разбир аргум-ы
            if (args.Length == 2)
            {
                int x;
                int.TryParse(args[0].ToString(), out x);

                int y;
                int.TryParse(args[1].ToString(), out y);

                //Вызаваем саму операцию
                var result = oper.Calc(x, y);
                return result;
            }
            else if(args.Length == 1)
            {
                int x;
                int.TryParse(args[0].ToString(), out x);
                var result = oper.Calc(x);
                return result;
            }

            return null;
        }

        [Obsolete("Не использовать")]
        public int Sum(int x, int y)
        {
            // return 0; - для первого теста

            var r = Execute("sum", new object[] { x, y });
            return int.Parse(r.ToString());
        }
        public double Sum(double x, double y)
        {
            // return 0; - для первого теста

            var r = Execute("sum", new object[] { x, y });
            return double.Parse(r.ToString());
        }

        public double Divide(int x,int y)
        {
            var r = Execute("divide", new object[] { x, y });
            return int.Parse(r.ToString());
        }

        public double Divide(double x, double y)
        {
            var r = Execute("divide", new object[] { x, y });
            return double.Parse(r.ToString());
        }
        public double Sqrt(int x)
        {
            var r = Execute("sqrt", new object[] { x});
            return double.Parse(r.ToString());
        }
        public double Sqrt(double x)
        {
            var r = Execute("sqrt", new object[] { x });
            return double.Parse(r.ToString());
        }
        public int Pow(int x, int y)
        {
            var r = Execute("pow", new object[] { x, y });
            return int.Parse(r.ToString());
        }

        public double Pow(double x, double y)
        {
            var r = Execute("pow", new object[] { x, y });
            return double.Parse(r.ToString());
        }
        public int Multiply(int x, int y)
        {
            var r = Execute("multiply", new object[] { x, y });
            return int.Parse(r.ToString());
        }

        public double Multiply(double x, double y)
        {
            var r = Execute("multiply", new object[] { x, y });
            return double.Parse(r.ToString());
        }
        public double Abs(int x)
        {
            var r = Execute("abs", new object[] { x });
            return double.Parse(r.ToString());
        }
        public double Abs(double x)
        {
            var r = Execute("abs", new object[] { x });
            return double.Parse(r.ToString());
        }
    }
}
