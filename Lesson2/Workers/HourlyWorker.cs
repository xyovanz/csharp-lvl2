using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class HourlyWorker : Worker
    {
        public HourlyWorker(string Name, string Surname, byte Age) : base(Name, Surname, Age) { }
        
        public override void CountSalary (double hourlyRate)
        {
            monthSalary = Convert.ToDecimal(20.8 * 8 * hourlyRate);
        }

    }
}
