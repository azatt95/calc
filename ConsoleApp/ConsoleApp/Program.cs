﻿using CalcLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        // operation x y
        static void Main(string[] args)
        {
            Console.WriteLine("Hype Calc");

            var calc = new Calculator();

            if (args.Count() == 3)
            {
                var operation = args[0];
                var x = args[1];
                var y = args[2];
                var result = "";

                if (operation == "sum")
                {
                    result = calc.Sum(x, y);
                }

                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}
