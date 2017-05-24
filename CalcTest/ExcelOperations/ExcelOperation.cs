using CalcLibrary;

namespace ExcelOperations
{
    public class ExcelOperation : IOperation
    {
        public string Name => "excel";

        public double Calc(int x, int y)
        {
            return x * x + y * y + x - y;
        }
    }
}
