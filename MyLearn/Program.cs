using System;
using MyLearn.Module01_CSharpBasics;
using MyLearn.Module02_OOP;
using MyLearn.Module03_GameConcepts;

namespace MyLearn
{
    /// <summary>
    /// Главный файл программы с меню для выбора урока
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                                                            ║");
                Console.WriteLine("║          🎮 ОБУЧЕНИЕ C# ДЛЯ UNITY 🎮                       ║");
                Console.WriteLine("║                                                            ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine("📚 МОДУЛЬ 1: ОСНОВЫ C#");
                Console.WriteLine("  1. Переменные и типы данных");
                Console.WriteLine("  2. Операторы");
                Console.WriteLine("  3. Условные конструкции");
                Console.WriteLine("  4. Циклы");
                Console.WriteLine("  5. Массивы и коллекции");
                Console.WriteLine("  6. Методы");
                Console.WriteLine();
                Console.WriteLine("📚 МОДУЛЬ 2: ООП В C#");
                Console.WriteLine("  7. Классы и объекты");
                Console.WriteLine("  8. Наследование и полиморфизм");
                Console.WriteLine("  9. Интерфейсы и абстрактные классы");
                Console.WriteLine(" 10. Паттерны проектирования");
                Console.WriteLine();
                Console.WriteLine("📚 МОДУЛЬ 3: ИГРОВЫЕ КОНЦЕПЦИИ");
                Console.WriteLine(" 11. Игровой цикл (Game Loop)");
                Console.WriteLine(" 12. Компонентная система");
                Console.WriteLine(" 13. Система событий");
                Console.WriteLine();
                Console.WriteLine("  0. Выход");
                Console.WriteLine();
                Console.WriteLine("════════════════════════════════════════════════════════════");
                Console.Write("Выберите урок (0-13): ");

                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    continue;

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("\n❌ Неверный ввод! Нажмите любую клавишу...");
                    Console.ReadKey();
                    continue;
                }

                Console.Clear();

                try
                {
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("\n👋 До встречи! Удачи в обучении!");
                            return;

                        case 1:
                            Variables.RunDemo();
                            break;

                        case 2:
                            Operators.RunDemo();
                            break;

                        case 3:
                            Conditionals.RunDemo();
                            break;

                        case 4:
                            Loops.RunDemo();
                            break;

                        case 5:
                            Collections.RunDemo();
                            break;

                        case 6:
                            Methods.RunDemo();
                            break;

                        case 7:
                            ClassesDemo.RunDemo();
                            break;

                        case 8:
                            InheritanceDemo.RunDemo();
                            break;

                        case 9:
                            InterfacesDemo.RunDemo();
                            break;

                        case 10:
                            PatternsDemo.RunDemo();
                            break;

                        case 11:
                            GameLoopLesson.Run();
                            break;

                        case 12:
                            ComponentsLesson.Run();
                            break;

                        case 13:
                            EventsLesson.Run();
                            break;

                        default:
                            Console.WriteLine("\n❌ Неверный выбор! Выберите от 0 до 13.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n❌ Ошибка: {ex.Message}");
                }

                Console.WriteLine("\n════════════════════════════════════════════════════════════");
                Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
        }
    }
}
