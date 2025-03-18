using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Developer:Employee
    {
        public string ProgrammingLanguage { get; set; }

        public Developer(string name, int age, double salary, string programmingLanguage)
           : base(name, age, salary)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        
        public override double CalculateBonus()
        {
            return Salary * 0.15;
        }
    }
}
