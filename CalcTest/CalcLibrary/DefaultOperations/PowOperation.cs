using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    class PowOperation : CalcLibrary.IOperation
    {
        public string Name { get { return "pow"; } }

        public double Calc(double x, int y)
        {
            return Math.Pow(x, y);
        }
        public int Calc(int x, int y)
        {
            return (int)Math.Pow(x, y);
        }
        public double Calc(int x)
        {
            return 0;
        }

        public double Calc(double x)
        {
            return 0;
        }

        public double Calc(double x, double y)
        {
            return Math.Pow(x, y);
        }

        double IOperation.Calc(int x, int y)
        {
            return Math.Pow(x, y);
        }
    }
}
