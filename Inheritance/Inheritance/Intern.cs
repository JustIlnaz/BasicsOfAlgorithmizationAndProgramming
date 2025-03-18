using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Intern : Employee
    {
        public string University { get; set; }

        public Intern(string name, int age, double salary, string university)
          : base(name, age, salary)
        {
            University = university;
        }

        public override double CalculateBonus()
        {
            return Salary * 0.03;
        }
    }
}
