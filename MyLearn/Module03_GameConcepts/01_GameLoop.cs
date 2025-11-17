using System;
using System.Threading;

namespace MyLearn.Module03_GameConcepts
{
    /// <summary>
    /// Урок 11: Игровой цикл (Game Loop)
    /// 
    /// Концепции Unity без самого Unity:
    /// - Игровой цикл (аналог Update)
    /// - DeltaTime - время между кадрами
    /// - Игровые объекты и их обновление
    /// </summary>
    public class GameLoopLesson
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Урок 11: Игровой цикл ===\n");

            Console.WriteLine("Игровой цикл - это сердце любой игры.");
            Console.WriteLine("Он постоянно обновляет состояние игры (60 раз в секунду).\n");

            // Пример 1: Простой счетчик кадров
            Example1_SimpleLoop();

            // Пример 2: DeltaTime
            Example2_DeltaTime();

            // Пример 3: Игровые объекты
            Example3_GameObjects();
        }

        static void Example1_SimpleLoop()
        {
            Console.WriteLine("--- Пример 1: Простой игровой цикл ---\n");

            Console.WriteLine("Игровой цикл работает примерно так:");
            Console.WriteLine(@"
while (игра_запущена)
{
    Обработать_ввод();
    Обновить_игру();
    Отрисовать();
}
");

            Console.WriteLine("Запускаем цикл на 5 кадров...\n");

            for (int frame = 1; frame <= 5; frame++)
            {
                Console.WriteLine($"Кадр {frame}: Обновление игры...");
                Thread.Sleep(100); // Имитация работы
            }

            Console.WriteLine("\nНажмите Enter...");
            Console.ReadLine();
        }

        static void Example2_DeltaTime()
        {
            Console.Clear();
            Console.WriteLine("--- Пример 2: DeltaTime ---\n");

            Console.WriteLine("DeltaTime - время между кадрами.");
            Console.WriteLine("Используется для плавного движения независимо от FPS.\n");

            // Симуляция движения
            float position = 0f;
            float speed = 5f; // единиц в секунду

            Console.WriteLine($"Начальная позиция: {position}");
            Console.WriteLine($"Скорость: {speed} единиц/сек\n");

            DateTime lastTime = DateTime.Now;

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100); // ~10 FPS

                DateTime currentTime = DateTime.Now;
                float deltaTime = (float)(currentTime - lastTime).TotalSeconds;
                lastTime = currentTime;

                // Движение с учетом deltaTime
                position += speed * deltaTime;

                Console.WriteLine($"Кадр {i + 1}: deltaTime={deltaTime:F3}s, позиция={position:F2}");
            }

            Console.WriteLine("\n💡 Без deltaTime движение зависело бы от FPS!");
            Console.WriteLine("Нажмите Enter...");
            Console.ReadLine();
        }

        static void Example3_GameObjects()
        {
            Console.Clear();
            Console.WriteLine("--- Пример 3: Игровые объекты ---\n");

            // Создаем игровые объекты
            var player = new SimpleGameObject("Игрок", 0, 0);
            var enemy = new SimpleGameObject("Враг", 10, 5);

            Console.WriteLine("Создали игровые объекты:");
            player.Display();
            enemy.Display();

            Console.WriteLine("\nЗапускаем игровой цикл (10 кадров)...\n");

            DateTime lastTime = DateTime.Now;

            for (int frame = 1; frame <= 10; frame++)
            {
                Thread.Sleep(100);

                DateTime currentTime = DateTime.Now;
                float deltaTime = (float)(currentTime - lastTime).TotalSeconds;
                lastTime = currentTime;

                Console.WriteLine($"--- Кадр {frame} ---");

                // Обновляем объекты
                player.Update(deltaTime);
                enemy.Update(deltaTime);

                // Проверяем расстояние
                float distance = player.DistanceTo(enemy);
                Console.WriteLine($"Расстояние между объектами: {distance:F2}\n");
            }

            Console.WriteLine("Финальные позиции:");
            player.Display();
            enemy.Display();

            Console.WriteLine("\n✅ Упражнение:");
            Console.WriteLine("1. Добавьте скорость движения к SimpleGameObject");
            Console.WriteLine("2. Сделайте так, чтобы игрок двигался к врагу");
            Console.WriteLine("3. Остановите движение когда расстояние < 1");
        }
    }

    // Простой игровой объект
    public class SimpleGameObject
    {
        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        private Random random = new Random();

        public SimpleGameObject(string name, float x, float y)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public void Update(float deltaTime)
        {
            // Случайное движение
            X += (float)(random.NextDouble() - 0.5) * deltaTime * 2;
            Y += (float)(random.NextDouble() - 0.5) * deltaTime * 2;
        }

        public float DistanceTo(SimpleGameObject other)
        {
            float dx = X - other.X;
            float dy = Y - other.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public void Display()
        {
            Console.WriteLine($"  {Name}: ({X:F2}, {Y:F2})");
        }
    }
}