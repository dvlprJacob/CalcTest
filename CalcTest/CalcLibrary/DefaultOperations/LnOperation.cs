using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    class AbsOperation : CalcLibrary.IOperation
    {
        public string Name { get { return "abs"; } }

        public double Calc(double x, int y)
        {
            return 0;
        }
        public int Calc(int x, int y)
        {
            return 0;
        }
        public double Calc(int x)
        {
            return Math.Abs(x);
        }

        public double Calc(double x)
        {
            return Math.Abs(x);
        }

        public double Calc(double x, double y)
        {
            return 0;
        }

        double IOperation.Calc(int x, int y)
        {
            return 0;
        }
    }
}
