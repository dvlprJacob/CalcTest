using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    class MaxOperation : IOperationArgs
    {
        public string Name { get { return "max"; } }

        public double Calc(int x, int y)
        {
            return x <= y ? y : x;
        }
        public double Calc(IEnumerable<int> args)
        {
            return args.Max();
        }
    }
}
