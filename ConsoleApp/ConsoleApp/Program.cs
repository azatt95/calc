using CalcLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        // operation x y
        static void Main(string[] args)
        {
            var calc = new Calculator();

            #region поддержка первой версии


            if (args.Count() == 3)
            {
                // старый код
            }
            #endregion

            var opers = GetLibraries();
            foreach (var op in opers)
            {
                calc.Operations.Add(op);
            }

            var count = 0;
            foreach (var oper in calc.Operations)
            {
                Console.WriteLine($"{++count}. {oper.Name}");
            }

            Console.WriteLine("select operation");

            var operKey = Console.ReadLine();
            var operId = Convert.ToInt32(operKey);
            var operation = calc.Operations.ElementAt(operId - 1);

            Console.WriteLine($"Введите {operation.MinArgsCount} и более аргументов: ");
            string x = Console.ReadLine();

            Console.WriteLine(operation.Execute(SrtingConvert(x)));

            Console.ReadKey();
        }

        static double[] SrtingConvert(string input)
        {
            var x1 = input.Replace(" ", "");
            var x2 = x1.Split(',');
            var x3 = x2.Select(s => s.ToDouble());
            var x = x3.ToArray();

            return x;
        }

        static IEnumerable<IOperation> GetLibraries()
        {
            var result = new List<IOperation>();

            // найти текущую директорию
            var dir = Environment.CurrentDirectory + "\\Exts";

            if (!Directory.Exists(dir))
                return result;

            // найти все файлы типа *.dll
            var files = Directory.GetFiles(dir, "*.dll");

            var needType = typeof(IOperation);

            foreach (var item in files)
            {
                // загрузить их
                var dll = Assembly.LoadFrom(item);
                // разобрать их по классам
                var classes = dll.GetTypes();
                // найти нужные классы
                foreach (var cl in classes)
                {
                    var interfaces = cl.GetInterfaces();
                    if (interfaces.Any(i => i == needType))
                    {
                        var instance = Activator.CreateInstance(cl) as IOperation;
                        if (instance != null)
                        {
                            result.Add(instance);
                        }
                        // вывести на экран 
                        // Console.WriteLine(cl.Name);
                    }
                }
            }

            return result;
        }
    }
}
