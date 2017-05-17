using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    class DivideOneOperation : IOperation
    {
        public string Name { get { return "divide"; } }

        public double Calc(int x, int y)
        {
            if(y!=0)
            {
                return x * 1d / y;
            }
            else
            {
                return double.NaN;
            }
        }
    }
}