using CalcLibrary;
using System;
using System.Linq;
using System.Threading;

namespace _1CLibrary
{
    public class Расчитать : IOperation
    {
        public string Name => "расчёт";

        public int MinArgsCount => 1;

        public double Execute(double[] args)
        {
            Thread.Sleep(new Random().Next(1, 10) * 1000);
            return args.Average();
        }
    }
}
