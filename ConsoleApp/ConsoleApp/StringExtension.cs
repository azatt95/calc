using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class StringExtension
    {
        /// <summary>
        /// Конвертирует строку в число
        /// Если не удалось - вернет NaN
        /// </summary>
        /// <param name="input">Строка</param>
        /// <returns></returns>
        public static double ToDouble(this string input)
        {
            double result;
            if (!double.TryParse(input, out result))
                return double.NaN;

            return result;
        }
    }
}
