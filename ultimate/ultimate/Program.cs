using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ultimate
{
    internal class Program
    {
        static Random random = new Random();
        static player player = new player();

        static void Main(string[] args)
        {
            StartGame();
        }

        static void InitializeGame()
        {
            player.Health = 100;
            player.MaxHealth = 100;
            player.Gold = 10;
            player.Potions = 2;
            player.Arrows = 5;
            player.SwordDamage = (10, 20);
            player.BowDamage = (5, 15);
        }

        static void StartGame()
        {
            InitializeGame();
            Console.WriteLine("Добро пожаловать в Числовой квест ULTIMATE!");
            for (int room = 1; room <= 15; room++)
            {
                if (player.Health <= 0) break;
                Console.WriteLine($"\n=== Комната {room} из 15 ===");
                ProcessRoom(room);
            }
            if (player.Health > 0) FightBoss();
            EndGame(player.Health > 0);
        }

        static void ProcessRoom(int roomNumber)
        {
            int eventRoll = random.Next(1, 8);
            switch (eventRoll)
            {
                case 1: FightMonster(random.Next(20, 51), random.Next(5, 16)); break;
                case 2: OpenChest(); break;
                case 3: VisitMerchant(); break;
                case 4: VisitAltar(); break;
                case 5: MeetDarkMage(); break;
                case 6: ProcessTrap(); break;
                case 7: ProcessEvent(); break;
            }
        }

        static void FightMonster(int monsterHP, int monsterAttack)
        {
            Console.WriteLine($"Вы встретили монстра! Здоровье: {monsterHP}, Атака: {monsterAttack}");
            while (player.Health > 0 && monsterHP > 0)
            {
                Console.Write("Атаковать (меч/лук): ");
                string attackType = Console.ReadLine().ToLower();
                int damage = 0;
                if (attackType == "лук" && player.Arrows > 0)
                {
                    damage = random.Next(player.BowDamage.Item1, player.BowDamage.Item2 + 1);
                    player.Arrows--;
                }
                else
                {
                    damage = random.Next(player.SwordDamage.Item1, player.SwordDamage.Item2 + 1);
                }
                monsterHP -= damage;
                Console.WriteLine($"Вы нанесли {damage} урона. У монстра осталось {Math.Max(monsterHP, 0)} HP.");
                if (monsterHP > 0)
                {
                    int monsterDamage = random.Next(1, monsterAttack + 1);
                    player.Health -= monsterDamage;
                    Console.WriteLine($"Монстр нанес {monsterDamage} урона. Ваше здоровье: {Math.Max(player.Health, 0)}");
                }
            }
        }

        static void OpenChest()
        {
            bool isCursed = random.Next(0, 2) == 0;
            Console.WriteLine(isCursed ? "Вы нашли проклятый сундук!" : "Вы нашли сундук!");
            if (isCursed)
            {
                player.Gold += 15;
                if (random.Next(0, 2) == 0)
                {
                    player.MaxHealth -= 10;
                    player.Health = Math.Min(player.Health, player.MaxHealth);
                    Console.WriteLine("Максимальное здоровье уменьшено на 10!");
                }
            }
            else
            {
                int reward = random.Next(1, 4);
                switch (reward)
                {
                    case 1: player.Gold += 10; Console.WriteLine("+10 золота"); break;
                    case 2: player.Potions += 1; Console.WriteLine("+1 зелье"); break;
                    case 3: player.Arrows += 3; Console.WriteLine("+3 стрелы"); break;
                }
            }
        }

        static void VisitMerchant()
        {
            Console.WriteLine("Торговец предлагает: 1) Зелье (10 золота) 2) 3 стрелы (5 золота)");
            Console.Write("Выберите действие (1/2/ничего): ");
            string choice = Console.ReadLine();
            if (choice == "1" && player.Gold >= 10)
            {
                player.Potions++;
                player.Gold -= 10;
            }
            else if (choice == "2" && player.Gold >= 5)
            {
                player.Arrows += 3;
                player.Gold -= 5;
            }
        }

        static void VisitAltar()
        {
            if (player.Gold >= 10)
            {
                Console.Write("Пожертвовать 10 золота: 1) Усилить меч 2) Восстановить здоровье: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    player.SwordDamage.Item1 += 5;
                    player.SwordDamage.Item2 += 5;
                    Console.WriteLine("Меч усилен!");
                }
                else if (choice == "2")
                {
                    player.Health = Math.Min(player.Health + 20, player.MaxHealth);
                    Console.WriteLine("Здоровье восстановлено!");
                }
                player.Gold -= 10;
            }
        }

        static void MeetDarkMage()
        {
            if (player.Health >= 10)
            {
                Console.WriteLine("Темный маг предлагает: отдать 10 HP за 2 зелья и 5 стрел. Согласны? (да/нет)");
                if (Console.ReadLine().ToLower() == "да")
                {
                    player.Health -= 10;
                    player.Potions += 2;
                    player.Arrows += 5;
                }
            }
        }

        static void UsePotion()
        {
            if (player.Potions > 0)
            {
                player.Health = Math.Min(player.Health + 30, player.MaxHealth);
                player.Potions--;
                Console.WriteLine("Здоровье восстановлено!");
            }
        }

        static void ShowStats()
        {
            Console.WriteLine($"Здоровье: {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"Золото: {player.Gold} | Зелья: {player.Potions} | Стрелы: {player.Arrows}");
            Console.WriteLine($"Меч: {player.SwordDamage.Item1}-{player.SwordDamage.Item2} | Лук: {player.BowDamage.Item1}-{player.BowDamage.Item2}");
        }

        static void FightBoss()
        {
            int bossHP = 100;
            int turnCounter = 0;
            Console.WriteLine("\n=== БИТВА С БОССОМ ===");
            while (player.Health > 0 && bossHP > 0)
            {
                turnCounter++;
                Console.Write("Атаковать (меч/лук/зелье): ");
                string action = Console.ReadLine().ToLower();
                if (action == "зелье") { UsePotion(); continue; }

                int damage = 0;
                if (action == "лук" && player.Arrows > 0)
                {
                    damage = random.Next(player.BowDamage.Item1, player.BowDamage.Item2 + 1);
                    player.Arrows--;
                }
                else
                {
                    damage = random.Next(player.SwordDamage.Item1, player.SwordDamage.Item2 + 1);
                }
                bossHP -= damage;
                Console.WriteLine($"Вы нанесли {damage} урона. У босса осталось {Math.Max(bossHP, 0)} HP.");

                if (bossHP > 0)
                {
                    if (random.Next(0, 3) == 0 && turnCounter % 3 == 0)
                    {
                        bossHP = Math.Min(bossHP + 10, 100);
                        Console.WriteLine("Босс восстановил 10 HP!");
                    }
                    if (random.Next(0, 3) == 0)
                    {
                        int doubleDamage = random.Next(15, 26);
                        player.Health -= doubleDamage;
                        Console.WriteLine($"Босс нанес двойной удар: {doubleDamage} урона!");
                    }
                    else
                    {
                        int bossDamage = random.Next(15, 26);
                        player.Health -= bossDamage;
                        Console.WriteLine($"Босс нанес {bossDamage} урона.");
                    }
                }
            }
        }

        static void EndGame(bool isWin)
        {
            Console.WriteLine(isWin ? "\nПоздравляем! Вы победили босса и прошли игру!" : "\nВы погибли...");
        }

        static void ProcessTrap()
        {
            int damage = random.Next(5, 21);
            player.Health -= damage;
            Console.WriteLine($"Ловушка! Вы потеряли {damage} HP. Текущее здоровье: {Math.Max(player.Health, 0)}");
        }

        static void ProcessEvent()
        {
            Console.WriteLine("Загадка: Что можно сломать, но нельзя удержать? )"); //Ответ: Обещание 
            Console.Write("Ваш ответ: ");
            if (Console.ReadLine().ToLower() == "обещание")
            {
                player.Gold += 20;
                Console.WriteLine("Верно! +20 золота");
            }
        }
    }
}
