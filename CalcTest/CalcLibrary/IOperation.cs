using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    public interface IOperation
    {
        string Name { get; }

        double Calc(double x);
        double Calc(int x);
        double Calc(double x, double y);
        double Calc(int x, int y);
    }
}
