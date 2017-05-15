using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    class MultiplyOperation : CalcLibrary.IOperation
    {
        public string Name
        {
            get { return "multiply"; }
        }

        public double Calc(int x)
        {
            return 0;
        }

        public double Calc(double x)
        {
            return 0;
        }

        public int Calc(int x, int y)
        {
            return x * y;
        }
        public double Calc(double x, double y)
        {
            return x * y;
        }

        double IOperation.Calc(int x, int y)
        {
            return x * y;
        }
    }
}
