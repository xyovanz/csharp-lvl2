using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class FixedWorker : Worker
    {
        public FixedWorker(string Name, string Surname, byte Age) : base(Name, Surname, Age) { }
        
        public override void CountSalary(double fixedSalary)
        {
            monthSalary = Convert.ToDecimal(fixedSalary);
        }
    }
}
