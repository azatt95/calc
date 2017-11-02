using System;
using System.Linq;

namespace CalcLibrary.Operations
{
    public class SumOperation : BaseOperation
    {
        public override string Name => "sum";

        public override double Execute(double[] args)
        {
            return args.Sum();
        }
    }
}
