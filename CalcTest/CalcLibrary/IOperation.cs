using System.Collections.Generic;

namespace CalcLibrary
{
    public interface IOperation
    {
        string Name { get; }

        double Calc(int x, int y);
    }

    public interface IOperationArgs : IOperation
    {
        double Calc(IEnumerable<int> args);
    }
}
