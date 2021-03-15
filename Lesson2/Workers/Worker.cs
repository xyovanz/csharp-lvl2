using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    abstract class Worker : IComparable
    {
        protected string name;
        protected string surname;
        protected byte age;
        protected decimal monthSalary;
        
        public Worker(string Name, string Surname, byte Age) 
        {
            name = Name;
            surname = Surname;
            age = Age;
        }

        public abstract void CountSalary(double salaryRate);

        public override string ToString()
        {
            return $"{name} {surname}, {age} лет, зарплата: {monthSalary:C}";
        }

        public int CompareTo(object obj)
        {
            if (monthSalary < ((Worker)obj).monthSalary) return 1;
            if (monthSalary > ((Worker)obj).monthSalary) return -1;
            return 0;
        }

    }
}
