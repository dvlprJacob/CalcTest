using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    class DivideOperation : CalcLibrary.IOperation
    {
        public string Name { get { return "divide"; } }

        public double Calc(int x)
        {
            return 0;
        }

        public double Calc(double x)
        {
            return 0;
        }

        public double Calc(double x, double y )
        {
            if (y != 0)
                return x / y;
            else throw new DivideByZeroException();
        }
        
        public int Calc(int x,int y)
        {
            if (y != 0)
                return x / y;
            else throw new DivideByZeroException();
        }

        double IOperation.Calc(int x, int y)
        {
            if (y != 0)
                return (double)(x / y);
            else throw new DivideByZeroException();
        }
    }
}
