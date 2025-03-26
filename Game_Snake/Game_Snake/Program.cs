using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false; // скрываем курсор
            var game = new Game(30, 10); // размеры поля
            game.Run();

        }
    }
}
