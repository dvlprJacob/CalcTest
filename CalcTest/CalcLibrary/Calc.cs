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
            var assm = Assembly.GetAssembly(typeof(IOperation));
            //
            var types = assm.GetTypes();
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
        }
            //var opers = assm.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IOperation)));
            
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
        public object Execute(string operation,object[] args)
        {
            //находим опер в списке доступных иначе возвращ ошибку,если нашли - разбираем аргументы,
            //вызываем саму опер и возвр результат

            var oper = operations.FirstOrDefault(it => it.Name == operation);

            //Если не нашли
            if(oper == null)
            {
                return "Error";
            }
            //разбир аргум-ы
            else
            {
                int x;
                int.TryParse(args[0].ToString(), out x);


                int y;
                int.TryParse(args[1].ToString(), out y);
                
                var result = oper.Calc(x, y);

                return result;
            }
        }

        [Obsolete("Не использовать")]
        public int Sum(int x, int y)
        {
            // return 0; - для первого теста

            var r = Execute("sum", new object[] { x, y });
            return (int)r;
        }
        
        public double Divide(int x,int y)
        {
            return (int)Execute("divide", new object[] { x, y });
        }
    }
}
