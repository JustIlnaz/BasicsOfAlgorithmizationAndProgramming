using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Rectangle : Shape
    {
        public double Width, Height;

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double Area()
        {
            return Width * Height;
        }

        public override double Perimeter()
        {
            return 2 * (Width + Height);
        }

        public override string ToString()
        {
            return $"Прямоугольник (Ширина: {Width}, Высота: {Height}) - Площадь: {Area()}, Периметр: {Perimeter()}";
        }
    }

}
