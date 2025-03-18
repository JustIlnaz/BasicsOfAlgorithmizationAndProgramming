using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Building building1 = new Building(30.5, 10, 100, 5);
            building1.PrintInfo();

            Console.WriteLine();

            Building building2 = new Building(50.0, 20, 200, 4);
            building2.PrintInfo();
        }
    }
}
