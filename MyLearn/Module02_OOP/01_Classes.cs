using System;
using System.Collections.Generic;

namespace MyLearn.Module02_OOP
{
    /// <summary>
    /// Lesson 1: Classes and Objects
    /// 
    /// В этом уроке вы изучите:
    /// - Что такое classes и объекты
    /// - Fields и свойства
    /// - Constructorы
    /// - Methods класса
    /// - Access modifiers
    /// </summary>

    // ========================================
    // ПРОСТОЙ КЛАСС
    // ========================================

    public class Player
    {
        // Fields (fields) - данные класса
        public string name;
        public int health;
        public int maxHealth;
        public int level;

        // Constructor - вызывается при создании объекта
        public Player(string playerName, int startHealth)
        {
            name = playerName;
            health = startHealth;
            maxHealth = startHealth;
            level = 1;
        }

        // Methods - действия класса
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0)
                health = 0;

            Console.WriteLine($"{name} получил {damage} урона. HP: {health}/{maxHealth}");
        }

        public void Heal(int amount)
        {
            health += amount;
            if (health > maxHealth)
                health = maxHealth;

            Console.WriteLine($"{name} восстановил {amount} HP. HP: {health}/{maxHealth}");
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"\n--- {name} ---");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"HP: {health}/{maxHealth}");
            Console.WriteLine($"Status: {(IsAlive() ? "Жив" : "Мертв")}");
        }
    }

    // ========================================
    // КЛАСС С СВОЙСТВАМИ (PROPERTIES)
    // ========================================

    public class Weapon
    {
        // Приватные поля
        private string name;
        private int damage;
        private float attackSpeed;

        // Свойства (Properties) - контролируемый доступ к полям
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Damage
        {
            get { return damage; }
            set
            {
                if (value < 0)
                    damage = 0;
                else
                    damage = value;
            }
        }

        // Автосвойство (auto-property)
        public string Type { get; set; }
        public int Durability { get; set; }

        // Свойство только для чтения
        public float DPS
        {
            get { return damage * attackSpeed; }
        }

        public Weapon(string weaponName, int weaponDamage, float speed, string weaponType)
        {
            name = weaponName;
            damage = weaponDamage;
            attackSpeed = speed;
            Type = weaponType;
            Durability = 100;
        }

        public void Attack(string target)
        {
            Console.WriteLine($"⚔️ Атака {name}!");
            Console.WriteLine($"   Цель: {target}");
            Console.WriteLine($"   Урон: {damage}");
            Console.WriteLine($"   DPS: {DPS:F1}");

            Durability -= 1;
            if (Durability <= 0)
            {
                Console.WriteLine($"❌ {name} сломалось!");
            }
        }

        public void Repair()
        {
            Durability = 100;
            Console.WriteLine($"🔧 {name} отремонтировано!");
        }
    }

    // ========================================
    // КЛАСС С РАЗНЫМИ КОНСТРУКТОРАМИ
    // ========================================

    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int GoldReward { get; set; }
        public int ExpReward { get; set; }

        // Constructor по умолчанию
        public Enemy()
        {
            Name = "Гоблин";
            Health = 50;
            Damage = 10;
            GoldReward = 10;
            ExpReward = 25;
        }

        // Constructor с параметрами
        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
            GoldReward = health / 5;
            ExpReward = health / 2;
        }

        // Constructor со всеми параметрами
        public Enemy(string name, int health, int damage, int gold, int exp)
        {
            Name = name;
            Health = health;
            Damage = damage;
            GoldReward = gold;
            ExpReward = exp;
        }

        public void Attack(Player target)
        {
            Console.WriteLine($"👹 {Name} атакует {target.name}!");
            target.TakeDamage(Damage);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;

            Console.WriteLine($"{Name} получил {damage} урона. HP: {Health}");

            if (Health <= 0)
            {
                Console.WriteLine($"💀 {Name} повержен!");
                Console.WriteLine($"   Награда: {GoldReward} золота, {ExpReward} опыта");
            }
        }
    }

    // ========================================
    // СТАТИЧЕСКИЕ ЧЛЕНЫ КЛАССА
    // ========================================

    public class GameManager
    {
        // Статические поля - общие для всех экземпляров
        public static int TotalEnemiesKilled = 0;
        public static int TotalGoldCollected = 0;
        public static float GameTime = 0f;

        // Static метод
        public static void EnemyKilled(int goldReward)
        {
            TotalEnemiesKilled++;
            TotalGoldCollected += goldReward;
            Console.WriteLine($"📊 Статистика: Убито врагов: {TotalEnemiesKilled}, Золото: {TotalGoldCollected}");
        }

        public static void DisplayStats()
        {
            Console.WriteLine("\n=== Статистика игры ===");
            Console.WriteLine($"Убито врагов: {TotalEnemiesKilled}");
            Console.WriteLine($"Собрано золота: {TotalGoldCollected}");
            Console.WriteLine($"Time игры: {GameTime:F1} сек");
        }
    }

    // ========================================
    // КЛАСС С ВЛОЖЕННЫМ КЛАССОМ
    // ========================================

    public class Inventory
    {
        // Вложенный класс
        public class Item
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public int Value { get; set; }

            public Item(string name, int quantity, int value)
            {
                Name = name;
                Quantity = quantity;
                Value = value;
            }

            public void Display()
            {
                Console.WriteLine($"  {Name} x{Quantity} ({Value} золота)");
            }
        }

        private List<Item> items;
        public int MaxSlots { get; set; }

        public Inventory(int maxSlots = 20)
        {
            items = new List<Item>();
            MaxSlots = maxSlots;
        }

        public void AddItem(string name, int quantity, int value)
        {
            // Проверяем, есть ли уже такой предмет
            Item existingItem = items.Find(i => i.Name == name);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                Console.WriteLine($"✅ Добавлено: {name} x{quantity}");
            }
            else if (items.Count < MaxSlots)
            {
                items.Add(new Item(name, quantity, value));
                Console.WriteLine($"✅ Получен новый предмет: {name} x{quantity}");
            }
            else
            {
                Console.WriteLine($"❌ Инвентарь полон! Невозможно добавить {name}");
            }
        }

        public void DisplayInventory()
        {
            Console.WriteLine($"\n📦 Инвентарь ({items.Count}/{MaxSlots}):");
            if (items.Count == 0)
            {
                Console.WriteLine("  Пусто");
                return;
            }

            foreach (var item in items)
            {
                item.Display();
            }
        }

        public int GetTotalValue()
        {
            int total = 0;
            foreach (var item in items)
            {
                total += item.Value * item.Quantity;
            }
            return total;
        }
    }

    // ========================================
    // ГЛАВНЫЙ КЛАСС С ПРИМЕРАМИ
    // ========================================

    public class ClassesDemo
    {
        // Для запуска этого урока раскомментируйте Main и закомментируйте Main в других файлах
        public static void RunDemo()
        {
            Console.WriteLine("=== Lesson 1: Classes and Objects ===\n");

            // ========================================
            // 1. СОЗДАНИЕ ОБЪЕКТОВ
            // ========================================

            Console.WriteLine("--- Создание объектов ---");

            Player player1 = new Player("Артур", 100);
            Player player2 = new Player("Мерлин", 80);

            player1.DisplayInfo();
            player2.DisplayInfo();

            // ========================================
            // 2. ИСПОЛЬЗОВАНИЕ МЕТОДОВ
            // ========================================

            Console.WriteLine("\n--- Использование методов ---");

            player1.TakeDamage(30);
            player1.Heal(20);
            player1.TakeDamage(50);

            if (player1.IsAlive())
            {
                Console.WriteLine($"{player1.name} все еще в бою!");
            }

            // ========================================
            // 3. РАБОТА СО СВОЙСТВАМИ
            // ========================================

            Console.WriteLine("\n--- Работа со свойствами ---");

            Weapon sword = new Weapon("Экскалибур", 50, 1.2f, "Меч");
            Console.WriteLine($"Оружие: {sword.Name}");
            Console.WriteLine($"Урон: {sword.Damage}");
            Console.WriteLine($"Тип: {sword.Type}");
            Console.WriteLine($"DPS: {sword.DPS:F1}");
            Console.WriteLine($"Прочность: {sword.Durability}%");

            sword.Attack("Дракон");
            sword.Attack("Орк");
            sword.Attack("Гоблин");

            // ========================================
            // 4. РАЗНЫЕ КОНСТРУКТОРЫ
            // ========================================

            Console.WriteLine("\n--- Разные конструкторы ---");

            Enemy goblin = new Enemy();
            Enemy orc = new Enemy("Орк", 100, 20);
            Enemy dragon = new Enemy("Дракон", 500, 75, 1000, 500);

            Console.WriteLine($"Враг 1: {goblin.Name} ({goblin.Health} HP)");
            Console.WriteLine($"Враг 2: {orc.Name} ({orc.Health} HP)");
            Console.WriteLine($"Враг 3: {dragon.Name} ({dragon.Health} HP)");

            // ========================================
            // 5. БОЕВАЯ СИСТЕМА
            // ========================================

            Console.WriteLine("\n--- Боевая система ---");

            Player hero = new Player("Герой", 150);
            Enemy boss = new Enemy("Босс", 200, 25, 500, 1000);

            hero.DisplayInfo();
            Console.WriteLine($"\nВраг: {boss.Name} ({boss.Health} HP)\n");

            int round = 1;
            while (hero.IsAlive() && boss.Health > 0)
            {
                Console.WriteLine($"--- Раунд {round} ---");

                // Игрок атакует
                Console.WriteLine($"⚔️ {hero.name} атакует!");
                boss.TakeDamage(30);

                if (boss.Health <= 0)
                {
                    GameManager.EnemyKilled(boss.GoldReward);
                    break;
                }

                // Враг атакует
                boss.Attack(hero);

                if (!hero.IsAlive())
                {
                    Console.WriteLine($"\n💀 {hero.name} погиб!");
                    break;
                }

                round++;
                Console.WriteLine();
            }

            // ========================================
            // 6. СТАТИЧЕСКИЕ ЧЛЕНЫ
            // ========================================

            Console.WriteLine("\n--- Статические члены ---");

            GameManager.GameTime = 125.5f;
            GameManager.DisplayStats();

            // ========================================
            // 7. ИНВЕНТАРЬ
            // ========================================

            Console.WriteLine("\n--- Система инвентаря ---");

            Inventory inventory = new Inventory(10);

            inventory.AddItem("Зелье здоровья", 5, 50);
            inventory.AddItem("Зелье маны", 3, 40);
            inventory.AddItem("Золото", 150, 1);
            inventory.AddItem("Меч", 1, 500);
            inventory.AddItem("Зелье здоровья", 2, 50);

            inventory.DisplayInventory();

            int totalValue = inventory.GetTotalValue();
            Console.WriteLine($"\nОбщая стоимость: {totalValue} золота");
        }
    }
}

/*
 * ========================================
 * УПРАЖНЕНИЯ
 * ========================================
 * 
 * 1. Класс Character:
 *    - Создайте класс с полями: name, health, mana, strength, intelligence
 *    - Добавьте конструктор
 *    - Добавьте методы: Attack(), CastSpell(), Rest()
 *    - Создайте несколько персонажей и протестируйте
 * 
 * 2. Класс Item:
 *    - Fields: name, description, value, weight
 *    - Свойства с валидацией (value и weight не могут быть отрицательными)
 *    - Метод Display() для вывода информации
 * 
 * 3. Класс Quest:
 *    - Fields: title, description, reward, isCompleted
 *    - Methods: Start(), Complete(), Display()
 *    - Создайте систему из 3 квестов
 * 
 * 4. Класс Shop:
 *    - List товаров (используйте вложенный класс ShopItem)
 *    - Methods: AddItem(), BuyItem(), DisplayItems()
 *    - Реализуйте покупку с проверкой золота
 * 
 * 5. Класс Skill:
 *    - Fields: name, manaCost, damage, cooldown
 *    - Methods: Use(), IsReady()
 *    - Создайте несколько навыков для персонажа
 * 
 * ========================================
 * ВАЖНЫЕ КОНЦЕПЦИИ
 * ========================================
 * 
 * 1. Класс vs Объект:
 *    - Класс - это чертеж/шаблон
 *    - Объект - это конкретный экземпляр класса
 * 
 * 2. Access modifiers:
 *    - public: доступен везде
 *    - private: доступен только внутри класса
 *    - protected: доступен в классе и наследниках
 * 
 * 3. Свойства vs Fields:
 *    - Fields: прямой доступ к данным
 *    - Свойства: контролируемый доступ через get/set
 * 
 * 4. Статические члены:
 *    - Принадлежат классу, а не объекту
 *    - Общие для всех экземпляров
 *    - Доступ через имя класса
 * 
 * ========================================
 */
