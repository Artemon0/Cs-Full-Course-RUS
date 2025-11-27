using System;
using System.Collections.Generic;

namespace MyLearn.Module01_CSharpBasics
{
    /// <summary>
    /// Lesson 6: Methods
    /// 
    /// В этом уроке вы изучите:
    /// - Что такое методы и зачем они нужны
    /// - Создание методов
    /// - Параметры и аргументы
    /// - Возвращаемые значения
    /// - Перегрузка методов
    /// - Параметры по умолчанию
    /// </summary>
    public class Methods
    {
        // Для запуска этого урока раскомментируйте Main и закомментируйте Main в других файлах

        // ========================================
        // 1. ПРОСТЫЕ МЕТОДЫ БЕЗ ПАРАМЕТРОВ
        // ========================================

        // Метод без параметров и без возвращаемого значения
        static void PrintWelcome()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("  Добро пожаловать в игру!");
            Console.WriteLine("=================================");
        }

        static void PrintGameOver()
        {
            Console.WriteLine("\n💀 GAME OVER 💀");
            Console.WriteLine("Попробуйте еще раз!");
        }

        // ========================================
        // 2. МЕТОДЫ С ПАРАМЕТРАМИ
        // ========================================

        // Метод с одним параметром
        static void PrintPlayerName(string name)
        {
            Console.WriteLine($"Игрок: {name}");
        }

        // Метод с несколькими параметрами
        static void PrintPlayerStats(string name, int health, int level)
        {
            Console.WriteLine($"\n--- Статистика игрока ---");
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Здоровье: {health}");
            Console.WriteLine($"Level: {level}");
        }

        // Метод для атаки
        static void Attack(string attacker, string target, int damage)
        {
            Console.WriteLine($"⚔️ {attacker} атакует {target}!");
            Console.WriteLine($"💥 Нанесено {damage} урона!");
        }

        // ========================================
        // 3. МЕТОДЫ С ВОЗВРАЩАЕМЫМ ЗНАЧЕНИЕМ
        // ========================================

        // Метод возвращает int
        static int CalculateDamage(int baseDamage, int strength)
        {
            int totalDamage = baseDamage + strength;
            return totalDamage;
        }

        // Метод возвращает bool
        static bool IsAlive(int health)
        {
            return health > 0;
        }

        // Метод возвращает string
        static string GetRank(int score)
        {
            if (score >= 10000)
                return "S";
            else if (score >= 7500)
                return "A";
            else if (score >= 5000)
                return "B";
            else if (score >= 2500)
                return "C";
            else
                return "D";
        }

        // Метод возвращает float
        static float CalculateHealthPercent(int currentHealth, int maxHealth)
        {
            return (float)currentHealth / maxHealth * 100;
        }

        // ========================================
        // 4. МЕТОДЫ С НЕСКОЛЬКИМИ ВОЗВРАЩАЕМЫМИ ЗНАЧЕНИЯМИ
        // ========================================

        // Использование out параметров
        static void GetPlayerInfo(out string name, out int level, out int health)
        {
            name = "Герой";
            level = 10;
            health = 100;
        }

        // Использование кортежей (tuple)
        static (int health, int mana, int stamina) GetResourceValues()
        {
            return (100, 50, 75);
        }

        // ========================================
        // 5. ПЕРЕГРУЗКА МЕТОДОВ
        // ========================================

        // Разные версии метода Heal
        static void Heal(int amount)
        {
            Console.WriteLine($"💚 Восстановлено {amount} HP");
        }

        static void Heal(int amount, string target)
        {
            Console.WriteLine($"💚 {target} восстановил {amount} HP");
        }

        static void Heal(int amount, string target, bool isCritical)
        {
            if (isCritical)
            {
                amount *= 2;
                Console.WriteLine($"✨ Критическое исцеление!");
            }
            Console.WriteLine($"💚 {target} восстановил {amount} HP");
        }

        // ========================================
        // 6. ПАРАМЕТРЫ ПО УМОЛЧАНИЮ
        // ========================================

        static void SpawnEnemy(string type = "Гоблин", int health = 50, int level = 1)
        {
            Console.WriteLine($"👹 Появился {type}!");
            Console.WriteLine($"   HP: {health}, Level: {level}");
        }

        static int CalculateFinalDamage(int baseDamage, float multiplier = 1.0f, int bonus = 0)
        {
            return (int)(baseDamage * multiplier) + bonus;
        }

        // ========================================
        // 7. REF ПАРАМЕТРЫ
        // ========================================

        static void TakeDamage(ref int health, int damage)
        {
            health -= damage;
            if (health < 0)
                health = 0;
        }

        static void AddExperience(ref int currentExp, ref int level, int expGained)
        {
            currentExp += expGained;
            int expNeeded = level * 100;

            while (currentExp >= expNeeded)
            {
                currentExp -= expNeeded;
                level++;
                Console.WriteLine($"🎉 Level повышен! Новый уровень: {level}");
                expNeeded = level * 100;
            }
        }

        // ========================================
        // 8. ИГРОВЫЕ МЕТОДЫ - ПРИМЕРЫ
        // ========================================

        static bool CanAfford(int playerGold, int itemPrice)
        {
            return playerGold >= itemPrice;
        }

        static void BuyItem(ref int playerGold, string itemName, int price)
        {
            if (CanAfford(playerGold, price))
            {
                playerGold -= price;
                Console.WriteLine($"✅ Куплено: {itemName} за {price} золота");
                Console.WriteLine($"Осталось золота: {playerGold}");
            }
            else
            {
                Console.WriteLine($"❌ Недостаточно золота для покупки {itemName}");
                Console.WriteLine($"Нужно: {price}, Есть: {playerGold}");
            }
        }

        static int RollDice(int sides = 6)
        {
            Random random = new Random();
            return random.Next(1, sides + 1);
        }

        static bool CheckCriticalHit(int chance = 20)
        {
            Random random = new Random();
            return random.Next(1, 101) <= chance;
        }

        static void DisplayInventory(List<string> items)
        {
            Console.WriteLine("\n📦 Инвентарь:");
            if (items.Count == 0)
            {
                Console.WriteLine("  Пусто");
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {items[i]}");
            }
        }

        static string GetHealthStatus(int health, int maxHealth)
        {
            float percent = (float)health / maxHealth * 100;

            if (percent >= 80)
                return "💚 Отлично";
            else if (percent >= 50)
                return "💛 Нормально";
            else if (percent >= 20)
                return "🧡 Плохо";
            else
                return "❤️ Критично";
        }

        // ========================================
        // MAIN - ДЕМОНСТРАЦИЯ ВСЕХ МЕТОДОВ
        // ========================================
        // Для запуска этого урока используйте Program.cs (главное меню)
        // Или раскомментируйте Main ниже и закомментируйте Main в Program.cs

        // public static void Main()
        // {
        //     RunDemo();
        // }

        public static void RunDemo()
        {
            Console.WriteLine("=== Lesson 6: Methods ===\n");

            // 1. Простые методы
            Console.WriteLine("--- Простые методы ---");
            PrintWelcome();
            PrintPlayerName("Артур");
            PrintPlayerStats("Артур", 100, 5);

            // 2. Methods с параметрами
            Console.WriteLine("\n--- Methods с параметрами ---");
            Attack("Рыцарь", "Дракон", 45);
            Attack("Маг", "Гоблин", 30);

            // 3. Methods с возвращаемым значением
            Console.WriteLine("\n--- Methods с возвращаемым значением ---");
            int damage = CalculateDamage(20, 15);
            Console.WriteLine($"Рассчитанный урон: {damage}");

            int playerHealth = 75;
            bool alive = IsAlive(playerHealth);
            Console.WriteLine($"Игрок жив: {alive}");

            int score = 8500;
            string rank = GetRank(score);
            Console.WriteLine($"Ранг игрока: {rank}");

            float healthPercent = CalculateHealthPercent(75, 100);
            Console.WriteLine($"Процент здоровья: {healthPercent:F1}%");

            // 4. Несколько возвращаемых значений
            Console.WriteLine("\n--- Несколько возвращаемых значений ---");
            GetPlayerInfo(out string name, out int level, out int health);
            Console.WriteLine($"Имя: {name}, Level: {level}, HP: {health}");

            var resources = GetResourceValues();
            Console.WriteLine($"HP: {resources.health}, Мана: {resources.mana}, Выносливость: {resources.stamina}");

            // 5. Перегрузка методов
            Console.WriteLine("\n--- Перегрузка методов ---");
            Heal(20);
            Heal(30, "Воин");
            Heal(25, "Маг", true);

            // 6. Параметры по умолчанию
            Console.WriteLine("\n--- Параметры по умолчанию ---");
            SpawnEnemy();                           // Все по умолчанию
            SpawnEnemy("Орк");                      // Только тип
            SpawnEnemy("Дракон", 200, 10);          // Все параметры

            int finalDamage1 = CalculateFinalDamage(50);
            int finalDamage2 = CalculateFinalDamage(50, 1.5f);
            int finalDamage3 = CalculateFinalDamage(50, 2.0f, 10);
            Console.WriteLine($"Урон: {finalDamage1}, {finalDamage2}, {finalDamage3}");

            // 7. Ref параметры
            Console.WriteLine("\n--- Ref параметры ---");
            int currentHealth = 100;
            Console.WriteLine($"Здоровье до урона: {currentHealth}");
            TakeDamage(ref currentHealth, 30);
            Console.WriteLine($"Здоровье после урона: {currentHealth}");

            int exp = 80;
            int playerLevel = 1;
            Console.WriteLine($"Level: {playerLevel}, Опыт: {exp}");
            AddExperience(ref exp, ref playerLevel, 150);
            Console.WriteLine($"Level: {playerLevel}, Опыт: {exp}");

            // 8. Игровые примеры
            Console.WriteLine("\n--- Игровые примеры ---");

            int gold = 500;
            BuyItem(ref gold, "Меч", 300);
            BuyItem(ref gold, "Броня", 400);

            Console.WriteLine("\nБросок кубика:");
            for (int i = 0; i < 5; i++)
            {
                int roll = RollDice();
                Console.WriteLine($"Бросок {i + 1}: {roll}");
            }

            Console.WriteLine("\nПроверка критического удара:");
            for (int i = 0; i < 10; i++)
            {
                bool isCrit = CheckCriticalHit(30);
                Console.WriteLine($"Атака {i + 1}: {(isCrit ? "💥 КРИТ!" : "Обычная")}");
            }

            List<string> inventory = new List<string> { "Меч", "Щит", "Зелье", "Ключ" };
            DisplayInventory(inventory);

            Console.WriteLine("\nStatus здоровья:");
            Console.WriteLine($"100/100: {GetHealthStatus(100, 100)}");
            Console.WriteLine($"60/100: {GetHealthStatus(60, 100)}");
            Console.WriteLine($"30/100: {GetHealthStatus(30, 100)}");
            Console.WriteLine($"10/100: {GetHealthStatus(10, 100)}");

            // 9. Комплексный пример
            Console.WriteLine("\n=== Комплексный пример: Бой ===");
            SimulateBattle();
        }

        // ========================================
        // КОМПЛЕКСНЫЙ ПРИМЕР: БОЕВАЯ СИСТЕМА
        // ========================================

        static void SimulateBattle()
        {
            string playerName = "Герой";
            int playerHP = 100;
            int playerAttack = 25;

            string enemyName = "Орк";
            int enemyHP = 80;
            int enemyAttack = 15;

            int round = 1;

            Console.WriteLine($"⚔️ {playerName} VS {enemyName}");
            Console.WriteLine($"{playerName}: {playerHP} HP");
            Console.WriteLine($"{enemyName}: {enemyHP} HP\n");

            while (IsAlive(playerHP) && IsAlive(enemyHP))
            {
                Console.WriteLine($"--- Раунд {round} ---");

                // Ход игрока
                bool playerCrit = CheckCriticalHit(25);
                int playerDamage = playerCrit ? playerAttack * 2 : playerAttack;

                if (playerCrit)
                    Console.WriteLine("💥 Критический удар!");

                Attack(playerName, enemyName, playerDamage);
                TakeDamage(ref enemyHP, playerDamage);
                Console.WriteLine($"{enemyName} HP: {enemyHP}");

                if (!IsAlive(enemyHP))
                {
                    Console.WriteLine($"\n🎉 {playerName} победил!");
                    break;
                }

                // Ход врага
                bool enemyCrit = CheckCriticalHit(15);
                int enemyDamage = enemyCrit ? enemyAttack * 2 : enemyAttack;

                if (enemyCrit)
                    Console.WriteLine("💥 Враг нанес критический удар!");

                Attack(enemyName, playerName, enemyDamage);
                TakeDamage(ref playerHP, enemyDamage);
                Console.WriteLine($"{playerName} HP: {playerHP}");
                Console.WriteLine($"Status: {GetHealthStatus(playerHP, 100)}");

                if (!IsAlive(playerHP))
                {
                    Console.WriteLine($"\n💀 {playerName} погиб...");
                    PrintGameOver();
                    break;
                }

                round++;
                Console.WriteLine();
            }
        }
    }
}

/*
 * ========================================
 * УПРАЖНЕНИЯ
 * ========================================
 * 
 * 1. Калькулятор опыта:
 *    - Создайте метод CalculateExpNeeded(int level)
 *    - Формула: level * 100
 *    - Создайте метод CanLevelUp(int currentExp, int level)
 *    - Проверьте несколько уровней
 * 
 * 2. Система крафта:
 *    - Создайте метод CanCraft(int wood, int stone, int iron)
 *    - Проверяет наличие ресурсов для меча (2 дерева, 1 железо)
 *    - Создайте метод CraftItem(ref int wood, ref int iron)
 *    - Вычитает ресурсы и возвращает true при успехе
 * 
 * 3. Система скидок:
 *    - Создайте метод CalculateDiscount(int price, int playerLevel)
 *    - Level 1-5: 0% скидка
 *    - Level 6-10: 10% скидка
 *    - Level 11+: 20% скидка
 *    - Верните финальную цену
 * 
 * 4. Генератор имен врагов:
 *    - Создайте метод GenerateEnemyName(string type, int level)
 *    - Examples: "Гоблин (Ур. 5)", "Орк (Ур. 10)"
 *    - Если уровень >= 10, добавьте "Элитный"
 * 
 * 5. Система лута:
 *    - Создайте метод RollLoot(int enemyLevel)
 *    - Возвращает (string itemName, int gold)
 *    - Чем выше уровень врага, тем лучше лут
 *    - Используйте Random для случайности
 * 
 * 6. Продвинутая боевая система:
 *    - Создайте метод SimulateFullBattle с параметрами обоих combatцов
 *    - Добавьте возможность использования зелий
 *    - Добавьте систему критических ударов
 *    - Добавьте систему уклонения
 * 
 * ========================================
 * ВАЖНЫЕ МОМЕНТЫ
 * ========================================
 * 
 * 1. Именование методов:
 *    - Используйте PascalCase: CalculateDamage
 *    - Начинайте с глагола: Get, Set, Calculate, Check
 *    - Имя должно описывать действие
 * 
 * 2. Принцип единственной ответственности:
 *    - Метод должен делать одну вещь
 *    - Если метод слишком большой, разбейте его
 * 
 * 3. Параметры:
 *    - Не передавайте слишком много параметров (макс 4-5)
 *    - Используйте объекты для группировки данных
 * 
 * 4. Возвращаемые значения:
 *    - void: метод ничего не возвращает
 *    - Всегда возвращайте значение, если тип не void
 *    - Используйте кортежи для нескольких значений
 * 
 * 5. Ref vs Out:
 *    - ref: параметр должен быть инициализирован
 *    - out: параметр будет инициализирован в методе
 * 
 * ========================================
 * ЧАСТЫЕ ОШИБКИ
 * ========================================
 * 
 * 1. Забыли return:
 *    static int GetValue() {
 *        int value = 10;
 *        // ❌ Забыли return!
 *    }
 * 
 * 2. Неправильный тип возврата:
 *    static int GetName() {
 *        return "Имя"; // ❌ Должен быть int!
 *    }
 * 
 * 3. Изменение параметра без ref:
 *    static void ChangeValue(int value) {
 *        value = 100; // Изменится только локальная копия!
 *    }
 * 
 * 4. Недостижимый код после return:
 *    static int GetValue() {
 *        return 10;
 *        Console.WriteLine("Test"); // ❌ Никогда не выполнится!
 *    }
 * 
 * ========================================
 */
