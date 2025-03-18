using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    abstract class Shape
    {
       
        public abstract double Area();
        public abstract double Perimeter();

       
        public static double operator +(Shape shape1, Shape shape2)
        {
            return shape1.Area() + shape2.Area();
        }

       
        public static bool operator >(Shape shape1, Shape shape2)
        {
            return shape1.Area() > shape2.Area();
        }

        public static bool operator <(Shape shape1, Shape shape2)
        {
            return shape1.Area() < shape2.Area();
        }

        
        public override string ToString()
        {
            return $"Площадь: {Area()}, Периметр: {Perimeter()}";
        }
    }
}

