using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcLibrary;
using Output = System.Console;

namespace Console
{
    class Program
    {
        //Console.EXE "3" "2" f5
        static void Main(string[] args)
        {
            var test = new Calc();
            double result = 0;

            if (args.Length == 3)
            {
                int x;
                int.TryParse(args[0], out x);

                int y;
                int.TryParse(args[1], out y);

                var operation = args[2];

                if (operation == "sum")
                {
                    result = test.Execute("sum",new object[] { (object)x, (object)y });
                }
                else if (operation == "divide")
                {
                    result = test.Divide(x, y);
                }
                else if(operation == "pow")
                {
                    result = test.Pow(x, y);
                }
                else if(operation == "multiply")
                {
                    result = test.Multiply(x, y);
                }

                Output.WriteLine($"{x} {operation} {y} = {result}");
            }
            if(args.Length == 2)
            {
                int x;
                int.TryParse(args[0], out x);

                var operation = args[1];

                if (operation == "sqrt")
                {
                    result = test.Sqrt(x);
                }
                else if (operation == "abs")
                {
                    result = test.Abs(x);
                }

                Output.WriteLine($"{operation} ({x}) = {result}");
            }
            
            System.Console.ReadKey();
        }
    }
}
