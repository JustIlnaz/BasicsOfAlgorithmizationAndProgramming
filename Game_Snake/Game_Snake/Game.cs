using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Snake
{
    internal class Game
    {
        private int Width;
        private int Height;
        private Snake snake;
        private Food food;
        private bool gameOver;
        private int score;

        public Game(int width, int height)
        {
            Width = width;
            Height = height;
            snake = new Snake(width / 2, height / 2);
            food = new Food();
            gameOver = false;
            score = 0;
        }

        public void Run()
        {
            food.Generate(Width, Height, snake.Body);

            while (!gameOver)
            {
                Draw();
                Input();
                Update();
                Thread.Sleep(100); // пауза для управления скоростью игры
            }

            GameOver();
        }

        private void Draw()
        {
            Console.Clear();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == 0 || x == Width - 1 || y == 0 || y == Height - 1)
                        Console.Write("#"); // границы поля
                    else if (snake.Body.Exists(p => p.X == x && p.Y == y))
                        Console.Write("0"); // тело змейки
                    else if (food.Position.X == x && food.Position.Y == y)
                        Console.Write("*"); // еда
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Score: {score}");
        }

        private void Input()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        snake.ChangeDirection(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.ChangeDirection(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.ChangeDirection(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.ChangeDirection(1, 0);
                        break;
                }
            }
        }

        private void Update()
        {
            snake.Move();

            if (snake.CollidesWithWall(Width, Height) || snake.CollidesWithSelf())
            {
                gameOver = true;
                return;
            }

            var head = snake.GetHead();
            if (head.X == food.Position.X && head.Y == food.Position.Y)
            {
                snake.Grow();
                score++;
                food.Generate(Width, Height, snake.Body);
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.WriteLine($"Final Score: {score}");
        }
    }
}

