using System;

namespace MyLearn.Module01_CSharpBasics
{
    /// <summary>
    /// Lesson 1: Variables and Data Types в C#
    /// 
    /// В этом уроке вы изучите:
    /// - Что такое variables и зачем они нужны
    /// - Основные типы данных (int, float, string, bool)
    /// - Как объявлять и инициализировать variables
    /// - Константы и их использование
    /// </summary>
    public class Variables
    {
        // Для запуска этого урока раскомментируйте Main и закомментируйте Main в других файлах
        public static void RunDemo()
        {
            Console.WriteLine("=== Lesson 1: Variables and Data Types ===\n");

            // ========================================
            // 1. ЦЕЛЫЕ ЧИСЛА (int)
            // ========================================
            // int используется для целых чисел (без дробной части)
            // Диапазон: от -2,147,483,648 до 2,147,483,647

            int playerHealth = 100;           // Здоровье игрока
            int enemyCount = 5;               // Количество врагов
            int score = 0;                    // Очки игрока

            Console.WriteLine($"Здоровье игрока: {playerHealth}");
            Console.WriteLine($"Количество врагов: {enemyCount}");
            Console.WriteLine($"Очки: {score}\n");

            // ========================================
            // 2. ЧИСЛА С ПЛАВАЮЩЕЙ ТОЧКОЙ (float)
            // ========================================
            // float используется для чисел с дробной частью
            // Важно: добавляйте 'f' в конце числа!

            float moveSpeed = 5.5f;           // Скорость движения
            float jumpForce = 7.2f;           // Сила прыжка
            float damage = 15.5f;             // Урон оружия

            Console.WriteLine($"Скорость движения: {moveSpeed}");
            Console.WriteLine($"Сила прыжка: {jumpForce}");
            Console.WriteLine($"Урон: {damage}\n");

            // ========================================
            // 3. СТРОКИ (string)
            // ========================================
            // string используется для текста

            string playerName = "Герой";      // Имя игрока
            string weaponName = "Меч";        // Название оружия
            string enemyType = "Зомби";       // Тип врага

            Console.WriteLine($"Имя игрока: {playerName}");
            Console.WriteLine($"Оружие: {weaponName}");
            Console.WriteLine($"Враг: {enemyType}\n");

            // ========================================
            // 4. ЛОГИЧЕСКИЕ ЗНАЧЕНИЯ (bool)
            // ========================================
            // bool может быть только true (истина) или false (ложь)

            bool isPlayerAlive = true;        // Жив ли игрок
            bool hasKey = false;              // Есть ли ключ
            bool isGamePaused = false;        // Игра на паузе

            Console.WriteLine($"Игрок жив: {isPlayerAlive}");
            Console.WriteLine($"Есть ключ: {hasKey}");
            Console.WriteLine($"Игра на паузе: {isGamePaused}\n");

            // ========================================
            // 5. ИЗМЕНЕНИЕ ЗНАЧЕНИЙ
            // ========================================

            Console.WriteLine("--- Изменение значений ---");

            score = 100;                      // Присваиваем новое значение
            Console.WriteLine($"Новые очки: {score}");

            score = score + 50;               // Увеличиваем на 50
            Console.WriteLine($"Очки после бонуса: {score}");

            playerHealth = playerHealth - 20; // Уменьшаем здоровье
            Console.WriteLine($"Здоровье после урона: {playerHealth}\n");

            // ========================================
            // 6. КОНСТАНТЫ (const)
            // ========================================
            // Константы - это значения, которые нельзя изменить

            const int MAX_HEALTH = 100;       // Максимальное здоровье
            const float GRAVITY = 9.81f;      // Гравитация
            const string GAME_VERSION = "1.0.0";

            Console.WriteLine($"Максимальное здоровье: {MAX_HEALTH}");
            Console.WriteLine($"Гравитация: {GRAVITY}");
            Console.WriteLine($"Версия игры: {GAME_VERSION}\n");

            // MAX_HEALTH = 200; // ОШИБКА! Константу нельзя изменить

            // ========================================
            // 7. ДРУГИЕ ПОЛЕЗНЫЕ ТИПЫ
            // ========================================

            double preciseNumber = 3.14159265359;  // Более точные числа
            char grade = 'A';                      // Один символ
            byte smallNumber = 255;                // Маленькие числа (0-255)
            long bigNumber = 9999999999;           // Очень большие числа

            Console.WriteLine($"Точное число: {preciseNumber}");
            Console.WriteLine($"Оценка: {grade}");
            Console.WriteLine($"Маленькое число: {smallNumber}");
            Console.WriteLine($"Большое число: {bigNumber}\n");

            // ========================================
            // 8. ИГРОВОЙ ПРИМЕР: СИСТЕМА ЗДОРОВЬЯ
            // ========================================

            Console.WriteLine("=== Игровой пример: Система здоровья ===");

            int currentHealth = 100;
            int maxHealth = 100;
            string characterName = "Рыцарь";
            bool isAlive = true;

            Console.WriteLine($"{characterName} - Здоровье: {currentHealth}/{maxHealth}");

            // Получаем урон
            int damageReceived = 30;
            currentHealth = currentHealth - damageReceived;
            Console.WriteLine($"Получен урон {damageReceived}! Здоровье: {currentHealth}/{maxHealth}");

            // Лечение
            int healAmount = 20;
            currentHealth = currentHealth + healAmount;
            Console.WriteLine($"Исцеление на {healAmount}! Здоровье: {currentHealth}/{maxHealth}");

            // Проверка жив ли персонаж
            isAlive = currentHealth > 0;
            Console.WriteLine($"Персонаж жив: {isAlive}\n");

            // ========================================
            // 9. VAR - АВТОМАТИЧЕСКОЕ ОПРЕДЕЛЕНИЕ ТИПА
            // ========================================

            // Можно использовать var, и компилятор сам определит тип
            var autoInt = 42;              // Это int
            var autoFloat = 3.14f;         // Это float
            var autoString = "Привет";     // Это string
            var autoBool = true;           // Это bool

            Console.WriteLine($"autoInt: {autoInt} (тип: {autoInt.GetType()})");
            Console.WriteLine($"autoFloat: {autoFloat} (тип: {autoFloat.GetType()})");
            Console.WriteLine($"autoString: {autoString} (тип: {autoString.GetType()})");
            Console.WriteLine($"autoBool: {autoBool} (тип: {autoBool.GetType()})");
        }
    }
}

/*
 * ========================================
 * УПРАЖНЕНИЯ
 * ========================================
 * 
 * 1. Создайте variables для системы инвентаря:
 *    - Количество золота (int)
 *    - Количество зелий здоровья (int)
 *    - Количество зелий маны (int)
 *    - Вес инвентаря (float)
 *    - Максимальный вес (float)
 * 
 * 2. Создайте variables для характеристик персонажа:
 *    - Имя персонажа (string)
 *    - Level (int)
 *    - Опыт (int)
 *    - Сила (int)
 *    - Ловкость (int)
 *    - Интеллект (int)
 * 
 * 3. Создайте систему подсчета очков:
 *    - Начальные очки = 0
 *    - Добавьте 100 очков за убийство врага
 *    - Добавьте 50 очков за сбор монеты
 *    - Добавьте 500 очков за прохождение уровня
 *    - Выведите итоговые очки
 * 
 * 4. Создайте variables для оружия:
 *    - Название оружия (string)
 *    - Урон (float)
 *    - Скорострельность (float)
 *    - Текущие патроны (int)
 *    - Максимальные патроны (int)
 *    - Есть ли патроны (bool)
 * 
 * 5. Эксперимент:
 *    - Попробуйте присвоить int переменной значение float
 *    - Попробуйте присвоить string переменной число
 *    - Что произойдет? Почему?
 * 
 * ========================================
 * ВАЖНЫЕ ПРАВИЛА ИМЕНОВАНИЯ
 * ========================================
 * 
 * ✅ ПРАВИЛЬНО:
 * - playerHealth (camelCase для локальных переменных)
 * - MAX_HEALTH (UPPER_CASE для констант)
 * - Используйте понятные имена
 * - Начинайте с буквы
 * 
 * ❌ НЕПРАВИЛЬНО:
 * - ph (слишком короткое, непонятно)
 * - player health (пробелы запрещены)
 * - 1player (не начинайте с цифры)
 * - player-health (дефисы запрещены)
 * 
 * ========================================
 * ЧАСТЫЕ ОШИБКИ
 * ========================================
 * 
 * 1. Забыли 'f' после float числа:
 *    float speed = 5.5;  // ❌ Ошибка!
 *    float speed = 5.5f; // ✅ Правильно!
 * 
 * 2. Использование переменной до объявления:
 *    Console.WriteLine(health); // ❌ Ошибка!
 *    int health = 100;
 * 
 * 3. Попытка изменить константу:
 *    const int MAX = 100;
 *    MAX = 200; // ❌ Ошибка!
 * 
 * ========================================
 */
