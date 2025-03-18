using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] dungeonMap = new string[10];
            string[] inventory = new string[5];
            int health = 100, potions = 3, gold = 0, arrows = 5;
            bool hasSword = true, hasBow = true;


            Console.WriteLine("Добро пожаловать в подземелье!");
            GenerateDungeon();
            PlayGame();


            void GenerateDungeon()
            {
                string[] possibleRooms = { "Монстр", "Ловушка", "Сундук", "Торговец", "Пустая комната" };
                for (int i = 0; i < 9; i++)
                {
                    dungeonMap[i] = possibleRooms[random.Next(possibleRooms.Length)];
                }

                dungeonMap[9] = "Босс";
            }

            void PlayGame()
            {
                for (int i = 0; i < dungeonMap.Length; i++)
                {
                    Console.WriteLine($"\nВы вошли в комнату {i + 1}: {dungeonMap[i]}");

                    switch (dungeonMap[i])
                    {
                        case "Монстр":
                            FightMonster();
                            break;
                        case "Ловушка":
                            TriggerTrap();
                            break;
                        case "Сундук":
                            OpenChest();
                            break;
                        case "Торговец":
                            VisitMerchant();
                            break;
                        case "Босс":
                            if (!FightMonster(true)) 
                            {
                                Console.WriteLine("Вы проиграли. Конец игры!");
                                return;
                            }

                            Console.WriteLine("Вы победили босса! Поздравляем!");
                            return;
                    }

                    if (health <= 0)
                    {
                        Console.WriteLine("Вы умерли. Игра окончена.");
                        return;
                    }

                    Console.WriteLine($"Здоровье: {health}, Зелья: {potions}, Золото: {gold}, Стрелы: {arrows}");
                }
            }

            bool FightMonster(bool isBoss = false)
            {
                int monsterHealth = isBoss ? 100 : random.Next(20, 51);
                Console.WriteLine($"Вы встретили {(isBoss ? "Босса" : "монстра")} с {monsterHealth} HP.");

                while (monsterHealth > 0 && health > 0)
                {
                    Console.WriteLine("Выберите оружие: 1 - Меч, 2 - Лук");
                    string choice = Console.ReadLine();
                    int damage = 0;

                    if (choice == "1" && hasSword)
                    {
                        damage = random.Next(10, 21);
                        Console.WriteLine($"Вы ударили мечом и нанесли {damage} урона.");
                    }
                    else if (choice == "2" && hasBow && arrows > 0)
                    {
                        damage = random.Next(5, 16);
                        arrows--;
                        Console.WriteLine($"Вы выстрелили из лука и нанесли {damage} урона. Осталось стрел: {arrows}");
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор!");
                        continue;
                    }

                    monsterHealth -= damage;
                    if (monsterHealth <= 0)
                    {
                        Console.WriteLine("Вы победили монстра!");
                        return true;
                    }

                    int monsterDamage = random.Next(5, 16);
                    health -= monsterDamage;
                    Console.WriteLine($"Монстр атакует и наносит {monsterDamage} урона. Ваше здоровье: {health}");

                    if (health <= 0)
                    {
                        return false;
                    }
                }

                return true;
            }

            void TriggerTrap()
            {
                int trapDamage = random.Next(10, 21);
                health -= trapDamage;
                Console.WriteLine($"Вы попали в ловушку и потеряли {trapDamage} HP!");
            }

            void OpenChest()
            {
                Console.WriteLine("Чтобы открыть сундук, решите: 5 + 3 = ?");
                string answer = Console.ReadLine();
                if (answer == "8")
                {
                    string[] rewards = { "Зелье", "Золото", "Стрелы" };
                    string reward = rewards[random.Next(rewards.Length)];

                    if (reward == "Зелье") potions++;
                    else if (reward == "Золото") gold += 50;
                    else if (reward == "Стрелы") arrows += 3;

                    Console.WriteLine($"Вы нашли: {reward}!");
                }
                else
                {
                    Console.WriteLine("Ответ неверный, сундук закрыт.");
                }
            }

                void VisitMerchant()
            {
                Console.WriteLine("У торговца можно купить зелье за 30 золота. Покупаете? (да/нет)");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "да" && gold >= 30)
                {
                    gold -= 30;
                    potions++;
                    Console.WriteLine("Вы купили зелье.");
                }
                else
                {
                    Console.WriteLine("У вас недостаточно золота или вы отказались от покупки.");
                }
            }
        }
    }
}
