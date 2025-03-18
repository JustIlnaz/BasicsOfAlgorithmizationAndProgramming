using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("Алексей", 35, 150000, 10);
            Developer developer = new Developer("Максим", 28, 120000, "C#");
            Intern intern = new Intern("Иван", 22, 40000, "МГУ");

        
            manager.ShowInfo();
            developer.ShowInfo();
            intern.ShowInfo();
        }
    }
}
