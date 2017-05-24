using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    public class SumOperation : IOperationArgs
    {
        public string Name
        {
            get { return "sum"; }
        }

        public double Calc(IEnumerable<int> args)
        {
            return args.Sum();
        }

        public double Calc(int x, int y)
        {
            return x + y;
        }
    }
}
