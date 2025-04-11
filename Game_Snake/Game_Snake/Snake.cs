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
        private Position direction;

        public Snake(int startX, int startY)
        {
            Body = new List<Position> { new Position(startX, startY) };
            direction = new Position(1, 0);
        }

        public void ChangeDirection(int dx, int dy)
        {
            if (Body.Count > 1 && dx == -direction.X && dy == -direction.Y)
                return;

            direction = new Position(dx, dy);
        }

        public void Move()
        {
            var head = GetHead();
            var newHead = new Position(head.X + direction.X, head.Y + direction.Y);
            Body.Insert(0, newHead);
            Body.RemoveAt(Body.Count - 1);
        }

        public void Grow()
        {
            var tail = Body[Body.Count - 1];
            Body.Add(new Position(tail.X, tail.Y));
        }

        public Position GetHead()
        {
            return Body[0];
        }

        public bool CollidesWithWall(int width, int height)
        {
            var head = GetHead();
            return head.X <= 0 || head.X >= width - 1 || head.Y <= 0 || head.Y >= height - 1;
        }

        public bool CollidesWithSelf()
        {
            var head = GetHead();
            return Body.Skip(1).Any(p => p.X == head.X && p.Y == head.Y);
        }
    }
}
