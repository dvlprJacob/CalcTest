using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcLibrary;

namespace ExcelOperations
{
    public class ExcelOperations : IOperation
    {
        public string Name => "excel";

        public double Calc(int x, int y)
        {
            return x - (x + y) + x * y * y;
        }
    }
}
