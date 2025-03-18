
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Circle circle = new Circle(5`       );
            Rectangle rectangle = new Rectangle(4, 6);

          
            Console.WriteLine(circle);
            Console.WriteLine(rectangle);

            
            double totalArea = circle + rectangle;
            Console.WriteLine($"Сумма площадей: {totalArea}");

            
            if (circle > rectangle)
            {
                Console.WriteLine("Круг больше прямоугольника.");
            }
            else if (circle < rectangle)
            {
                Console.WriteLine("Круг меньше прямоугольника.");
            }
            else
            {
                Console.WriteLine("Площади равны.");
            }
        }
    }
}
