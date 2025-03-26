using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Snake
{
    internal class Snake
    {
        public List<Position> Body { get; private set; }
        public int Dx { get; private set; }
        public int Dy { get; private set; }

        public Snake(int startX, int startY)
        {
            Body = new List<Position> { new Position(startX, startY) };
            Dx = 1; //начальное направление: вправо
            Dy = 0;
        }

        public void Move()
        {
            var head = GetHead();
            var newHead = new Position(head.X + Dx, head.Y + Dy);
            Body.Insert(0, newHead); // добавляем новую голову
            Body.RemoveAt(Body.Count - 1); // удаляем хвост
        }

        public void Grow()
        {
            var tail = Body[Body.Count - 1];
            Body.Add(new Position(tail.X, tail.Y)); // увеличиваем длину
        }

        public bool CollidesWithSelf()
        {
            var head = GetHead();
            for (int i = 1; i < Body.Count; i++)
            {
                if (head.X == Body[i].X && head.Y == Body[i].Y)
                    return true;
            }
            return false;
        }

        public bool CollidesWithWall(int width, int height)
        {
            var head = GetHead();
            return head.X < 0 || head.X >= width || head.Y < 0 || head.Y >= height;
        }

        public Position GetHead()
        {
            return Body[0];
        }

        public void ChangeDirection(int dx, int dy)
        {
            // запрет на поворот 180 градусов
            if (Dx != -dx || Dy != -dy)
            {
                Dx = dx;
                Dy = dy;
            }
        }
    }
}
