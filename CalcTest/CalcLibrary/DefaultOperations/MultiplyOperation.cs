using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    class MultiplyOperation : CalcLibrary.IOperationArgs
    {
        public string Name
        {
            get { return "multiply"; }
        }
        public double Calc(int x, int y)
        {
            return x * y;
        }
        public double Calc(IEnumerable<int> args)
        {
            double result = 1;
            foreach(var it in args)
            {
                result *= it;
            }
            return result;
        }
    }
}
