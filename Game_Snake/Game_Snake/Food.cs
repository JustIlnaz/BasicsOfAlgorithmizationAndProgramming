using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Snake
{
    internal class Food
    {
        private Random rnd = new Random();
        public Position Position { get; private set; }

        public void Generate(int width, int height, List<Position> snakeBody)
        {
            int x, y;
            do
            {
                x = rnd.Next(1, width - 1);
                y = rnd.Next(1, height - 1);
            } while (snakeBody.Exists(p => p.X == x && p.Y == y));

            Position = new Position(x, y);
        }
    }
}