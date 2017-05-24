using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    class DivideOperation : CalcLibrary.IOperationArgs
    {
        public string Name { get { return "divide"; } }

        public double Calc(int x, int y)
        {
            if (y != 0)
            {
                return x * 1d / y;
            }
            else
                return double.NaN;
        }
        public double Calc(IEnumerable<int> args)
        {
            var tmp = args.ToArray();
            double result = tmp[0];
            for(int i=1;i<tmp.Count();i++)
            {
                result /= tmp[i];
            }
            return result;
        }
    }
}
