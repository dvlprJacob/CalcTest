using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.DefaultOperations
{
    class PowOperation : CalcLibrary.IOperationArgs
    {
        public string Name { get { return "pow"; } }

        public double Calc(int x, int y)
        {
            return Math.Pow(x, y);
        }
        public double Calc(IEnumerable<int> args)
        {
            var tmp = args.ToList();
            double result = tmp[0];
            for(int i=1;i<tmp.Count;i++)
            {
                result = Math.Pow(result, tmp[i]);
            }
            return result;
        }
    }
}
