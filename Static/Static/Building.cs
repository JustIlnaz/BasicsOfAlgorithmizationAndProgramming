using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    internal class Building 
    {
        // это айди
        private static int lastBuildingNumber = 0;

        
        public int BuildingNumber { get; private set; }
        public double Height { get; set; }
        public int Floors { get; set; }
        public int Apartments { get; set; }
        public int Entrances { get; set; }

        
        public Building(double height, int floors, int apartments, int entrances)
        {
            BuildingNumber = ++lastBuildingNumber; // Генерация id
            Height = height;
            Floors = floors;
            Apartments = apartments;
            Entrances = entrances;
        }

        
        public double GetFloorHeight() => Height / Floors;

        public int GetApartmentsPerEntrance() => Apartments / Entrances;

        public int GetApartmentsPerFloor() => Apartments / (Floors * Entrances);

        
        public void PrintInfo()
        {
            Console.WriteLine($"Здание #{BuildingNumber}:");
            Console.WriteLine($"  Высота: {Height} м");
            Console.WriteLine($"  Этажей: {Floors}");
            Console.WriteLine($"  Квартир: {Apartments}");
            Console.WriteLine($"  Подъездов: {Entrances}");
            Console.WriteLine($"  Высота этажа: {GetFloorHeight():F2} м");
            Console.WriteLine($"  Квартир в подъезде: {GetApartmentsPerEntrance()}");
            Console.WriteLine($"  Квартир на этаже: {GetApartmentsPerFloor()}");
        }
    }
}

