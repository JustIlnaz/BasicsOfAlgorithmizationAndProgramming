using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
        public class Manager :Employee
    {
        public int TeamSize { get; set; }

        public Manager(string name, int age, double salary, int teamSize)
         : base(name, age, salary)
        {
            TeamSize = teamSize;
        }

        
        public override double CalculateBonus()
        {
            return Salary * 0.10 + TeamSize * 500;
        }
    }
}

