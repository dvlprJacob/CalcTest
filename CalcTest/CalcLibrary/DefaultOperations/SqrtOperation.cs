using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    class SqrtOperation : CalcLibrary.IOperation
    {
        public string Name { get { return "sqrt"; } }

        public double Calc(double x)
        {
            return Math.Sqrt(x);
        }

        public double Calc(int x)
        {
            return Math.Sqrt(x);
        }

        public double Calc(double x, double y)
        {
            return 0;
        }

        public int Calc(int x, int y)
        {
            return 0;
        }

        double IOperation.Calc(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
