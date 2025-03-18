using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set;}

        public Employee(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
        public virtual double CalculateBonus()
        {
            return Salary * 0.05;
        }
         public virtual void ShowInfo()
        {
            Console.WriteLine($"Имя {Name}, возраст {Age} лет,зп: {Salary}руб.");   
        }


    }
}
