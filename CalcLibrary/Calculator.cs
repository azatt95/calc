using CalcLibrary.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    public class Calculator
    {

        public Calculator()
        {
            Operations = new List<IOperation> {
                new SumOperation(),
                new SubOperation()
            };
        }

        public IList<IOperation> Operations { get; set; }

        #region Устаревшее

        public string Sum(string x, string y)
        {
            double xd;
            if (!Double.TryParse(x, out xd))
                return "error";

            double yd;
            if (!Double.TryParse(y, out yd))
                return "error";

            var sum = new SumOperation();

            var result = sum.Execute(new [] { xd, yd });

            return $"{result}";
        }

        public string Sub(string x, string y)
        {
            double xd;
            if (!Double.TryParse(x, out xd))
                return "error";

            double yd;
            if (!Double.TryParse(y, out yd))
                return "error";

            var result = xd - yd;

            return $"{result}";
        }
        
        #endregion

    }
}
