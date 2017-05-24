using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    public class DivideOperation : IOperationArgs
    {
        public string Name
        {
            get { return "divide"; }
        }

        public double Calc(IEnumerable<int> args)
        {
            return 0;
        }

        public double Calc(int x, int y)
        {
            return x / y;
        }
    }
}
