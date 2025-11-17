using System;
using System.Collections.Generic;

namespace MyLearn.Module02_OOP
{
    /// <summary>
    /// Урок 3: Интерфейсы и абстрактные классы
    /// 
    /// В этом уроке вы изучите:
    /// - Что такое интерфейсы
    /// - Создание и реализация интерфейсов
    /// - Абстрактные классы
    /// - Разница между интерфейсами и абстрактными классами
    /// - Множественная реализация интерфейсов
    /// </summary>

    // ========================================
    // ИНТЕРФЕЙСЫ
    // ========================================

    // Интерфейс определяет контракт - что должен уметь класс
    public interface IDamageable
    {
        int Health { get; set; }
        int MaxHealth { get; set; }

        void TakeDamage(int damage);
        void Die();
        bool IsAlive();
    }

    public interface IHealable
    {
        void Heal(int amount);
    }

    public interface IInteractable
    {
        string InteractionText { get; }
        void Interact();
    }

    public interface ICollectable
    {
        string ItemName { get; }
        int Value { get; }
        void Collect();
    }

    public interface IMovable
    {
        float Speed { get; set; }
        void Move(float x, float y);
        void Stop();
    }

    // ========================================
    // РЕАЛИЗАЦИЯ ИНТЕРФЕЙСОВ
    // ========================================

    // Класс может реализовывать несколько интерфейсов
    public class GamePlayer : IDamageable, IHealable, IMovable
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public float Speed { get; set; }

        public GamePlayer(string name)
        {
            Name = name;
            Health = 100;
            MaxHealth = 100;
            Speed = 5.0f;
        }

        // Реализация IDamageable
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} получил {damage} урона. HP: {Health}/{MaxHealth}");

            if (!IsAlive())
            {
                Die();
            }
        }

        public void Die()
        {
            Console.WriteLine($"💀 {Name} погиб!");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        // Реализация IHealable
        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;
            Console.WriteLine($"💚 {Name} восстановил {amount} HP. HP: {Health}/{MaxHealth}");
        }

        // Реализация IMovable
        public void Move(float x, float y)
        {
            Console.WriteLine($"🏃 {Name} движется на ({x}, {y}) со скоростью {Speed}");
        }

        public void Stop()
        {
            Console.WriteLine($"🛑 {Name} остановился");
        }
    }

    // Враг тоже может получать урон
    public class EnemyUnit : IDamageable
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Reward { get; set; }

        public EnemyUnit(string name, int health, int reward)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            Reward = reward;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} получил {damage} урона. HP: {Health}/{MaxHealth}");

            if (!IsAlive())
            {
                Die();
            }
        }

        public void Die()
        {
            Console.WriteLine($"💀 {Name} повержен! Награда: {Reward} золота");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }

    // ========================================
    // ИНТЕРАКТИВНЫЕ ОБЪЕКТЫ
    // ========================================

    public class Door : IInteractable
    {
        public string InteractionText => "Нажмите E чтобы открыть дверь";
        private bool isOpen = false;

        public void Interact()
        {
            if (!isOpen)
            {
                isOpen = true;
                Console.WriteLine("🚪 Дверь открыта!");
            }
            else
            {
                Console.WriteLine("🚪 Дверь уже открыта");
            }
        }
    }

    public class Chest : IInteractable, ICollectable
    {
        public string InteractionText => "Нажмите E чтобы открыть сундук";
        public string ItemName { get; private set; }
        public int Value { get; private set; }
        private bool isOpened = false;

        public Chest(string item, int value)
        {
            ItemName = item;
            Value = value;
        }

        public void Interact()
        {
            if (!isOpened)
            {
                isOpened = true;
                Console.WriteLine("📦 Сундук открыт!");
                Collect();
            }
            else
            {
                Console.WriteLine("📦 Сундук уже пуст");
            }
        }

        public void Collect()
        {
            Console.WriteLine($"✨ Получено: {ItemName} ({Value} золота)");
        }
    }

    public class NPC : IInteractable
    {
        public string InteractionText => "Нажмите E чтобы поговорить";
        public string Name { get; set; }
        private string[] dialogues;
        private int currentDialogue = 0;

        public NPC(string name, string[] dialogues)
        {
            Name = name;
            this.dialogues = dialogues;
        }

        public void Interact()
        {
            Console.WriteLine($"💬 {Name}: {dialogues[currentDialogue]}");
            currentDialogue = (currentDialogue + 1) % dialogues.Length;
        }
    }

    // ========================================
    // АБСТРАКТНЫЕ КЛАССЫ
    // ========================================

    // Абстрактный класс - нельзя создать экземпляр
    public abstract class GameEntity
    {
        public string Name { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }

        public GameEntity(string name)
        {
            Name = name;
        }

        // Абстрактный метод - должен быть реализован в наследниках
        public abstract void Update();

        // Обычный метод - доступен всем наследникам
        public void SetPosition(float x, float y)
        {
            PositionX = x;
            PositionY = y;
            Console.WriteLine($"{Name} перемещен на ({x}, {y})");
        }
    }

    public class PlayerEntity : GameEntity, IDamageable
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public PlayerEntity(string name) : base(name)
        {
            Health = 100;
            MaxHealth = 100;
        }

        // Обязательно реализуем абстрактный метод
        public override void Update()
        {
            Console.WriteLine($"Обновление игрока {Name}");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public void Die()
        {
            Console.WriteLine($"💀 {Name} погиб!");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }

    public class EnemyEntity : GameEntity, IDamageable
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public EnemyEntity(string name, int health) : base(name)
        {
            Health = health;
            MaxHealth = health;
        }

        public override void Update()
        {
            Console.WriteLine($"AI обновление врага {Name}");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public void Die()
        {
            Console.WriteLine($"💀 {Name} уничтожен!");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }

    // ========================================
    // СИСТЕМА СПОСОБНОСТЕЙ
    // ========================================

    public interface IAbility
    {
        string Name { get; }
        int ManaCost { get; }
        float Cooldown { get; }

        void Use(IDamageable target);
        bool CanUse();
    }

    public class FireballAbility : IAbility
    {
        public string Name => "Огненный шар";
        public int ManaCost => 30;
        public float Cooldown => 5.0f;

        private float currentCooldown = 0;

        public void Use(IDamageable target)
        {
            if (CanUse())
            {
                Console.WriteLine($"🔥 {Name}!");
                target.TakeDamage(50);
                currentCooldown = Cooldown;
            }
        }

        public bool CanUse()
        {
            return currentCooldown <= 0;
        }
    }

    public class HealAbility : IAbility
    {
        public string Name => "Исцеление";
        public int ManaCost => 40;
        public float Cooldown => 10.0f;

        public void Use(IDamageable target)
        {
            if (target is IHealable healable)
            {
                Console.WriteLine($"💚 {Name}!");
                healable.Heal(60);
            }
        }

        public bool CanUse()
        {
            return true;
        }
    }

    // ========================================
    // ДЕМОНСТРАЦИЯ
    // ========================================

    public class InterfacesDemo
    {
        // Для запуска этого урока раскомментируйте Main и закомментируйте Main в других файлах
        public static void RunDemo()
        {
            Console.WriteLine("=== Урок 3: Интерфейсы и абстрактные классы ===\n");

            // ========================================
            // 1. БАЗОВОЕ ИСПОЛЬЗОВАНИЕ ИНТЕРФЕЙСОВ
            // ========================================

            Console.WriteLine("--- Базовое использование интерфейсов ---");

            GamePlayer player = new GamePlayer("Герой");
            EnemyUnit enemy = new EnemyUnit("Гоблин", 50, 10);

            // Оба класса реализуют IDamageable
            player.TakeDamage(20);
            enemy.TakeDamage(30);

            // Только Player реализует IHealable
            player.Heal(15);

            // ========================================
            // 2. ПОЛИМОРФИЗМ С ИНТЕРФЕЙСАМИ
            // ========================================

            Console.WriteLine("\n--- Полиморфизм с интерфейсами ---");

            // Можем хранить разные типы через интерфейс
            List<IDamageable> damageables = new List<IDamageable>
            {
                new GamePlayer("Воин"),
                new EnemyUnit("Орк", 100, 25),
                new EnemyUnit("Зомби", 80, 15),
                new GamePlayer("Маг")
            };

            Console.WriteLine("Все получают урон от взрыва:");
            foreach (IDamageable damageable in damageables)
            {
                damageable.TakeDamage(25);
            }

            // ========================================
            // 3. ИНТЕРАКТИВНЫЕ ОБЪЕКТЫ
            // ========================================

            Console.WriteLine("\n--- Интерактивные объекты ---");

            List<IInteractable> objects = new List<IInteractable>
            {
                new Door(),
                new Chest("Меч", 500),
                new NPC("Торговец", new[] { "Привет!", "Что продаем?", "До встречи!" })
            };

            foreach (IInteractable obj in objects)
            {
                Console.WriteLine($"\n{obj.InteractionText}");
                obj.Interact();
            }

            // ========================================
            // 4. ПРОВЕРКА ТИПА И ПРИВЕДЕНИЕ
            // ========================================

            Console.WriteLine("\n--- Проверка типа ---");

            IInteractable chest = new Chest("Золото", 1000);

            // Проверка с is
            if (chest is ICollectable)
            {
                Console.WriteLine("Это можно собрать!");
            }

            // Приведение с as
            ICollectable? collectable = chest as ICollectable;
            if (collectable != null)
            {
                Console.WriteLine($"Предмет: {collectable.ItemName}");
            }

            // Pattern matching (C# 7+)
            if (chest is ICollectable coll)
            {
                Console.WriteLine($"Стоимость: {coll.Value}");
            }

            // ========================================
            // 5. АБСТРАКТНЫЕ КЛАССЫ
            // ========================================

            Console.WriteLine("\n--- Абстрактные классы ---");

            List<GameEntity> entities = new List<GameEntity>
            {
                new PlayerEntity("Игрок 1"),
                new EnemyEntity("Враг 1", 50),
                new EnemyEntity("Враг 2", 75)
            };

            Console.WriteLine("Обновление всех сущностей:");
            foreach (GameEntity entity in entities)
            {
                entity.Update();
                entity.SetPosition(10, 20);
            }

            // ========================================
            // 6. СИСТЕМА СПОСОБНОСТЕЙ
            // ========================================

            Console.WriteLine("\n--- Система способностей ---");

            List<IAbility> abilities = new List<IAbility>
            {
                new FireballAbility(),
                new HealAbility()
            };

            IDamageable target = new EnemyUnit("Босс", 200, 100);

            foreach (IAbility ability in abilities)
            {
                Console.WriteLine($"\nИспользование: {ability.Name}");
                Console.WriteLine($"Стоимость маны: {ability.ManaCost}");
                Console.WriteLine($"Перезарядка: {ability.Cooldown}с");

                if (ability.CanUse())
                {
                    ability.Use(target);
                }
            }

            // ========================================
            // 7. МНОЖЕСТВЕННАЯ РЕАЛИЗАЦИЯ
            // ========================================

            Console.WriteLine("\n--- Множественная реализация ---");

            GamePlayer hero = new GamePlayer("Главный герой");

            // Player реализует несколько интерфейсов
            Console.WriteLine("Возможности героя:");

            if (hero is IDamageable)
                Console.WriteLine("✓ Может получать урон");

            if (hero is IHealable)
                Console.WriteLine("✓ Может лечиться");

            if (hero is IMovable)
                Console.WriteLine("✓ Может двигаться");

            // Используем разные интерфейсы
            (hero as IDamageable)?.TakeDamage(30);
            (hero as IHealable)?.Heal(20);
            (hero as IMovable)?.Move(5, 10);

            // ========================================
            // 8. ПРАКТИЧЕСКИЙ ПРИМЕР
            // ========================================

            Console.WriteLine("\n--- Практический пример: Боевая система ---");

            GamePlayer warrior = new GamePlayer("Воин");
            List<IDamageable> enemies = new List<IDamageable>
            {
                new EnemyUnit("Гоблин 1", 30, 5),
                new EnemyUnit("Гоблин 2", 30, 5),
                new EnemyUnit("Орк", 80, 20)
            };

            Console.WriteLine($"Воин атакует всех врагов!");

            foreach (IDamageable enemyTarget in enemies)
            {
                if (enemyTarget.IsAlive())
                {
                    enemyTarget.TakeDamage(40);
                }
            }

            // Подсчет живых врагов
            int aliveCount = 0;
            foreach (IDamageable enemyUnit in enemies)
            {
                if (enemy.IsAlive())
                    aliveCount++;
            }

            Console.WriteLine($"\nОсталось врагов: {aliveCount}");
        }
    }
}

/*
 * ========================================
 * УПРАЖНЕНИЯ
 * ========================================
 * 
 * 1. Создайте интерфейсы для RPG:
 *    - IEquippable (можно экипировать)
 *    - IUsable (можно использовать)
 *    - IStackable (можно складывать)
 *    - Реализуйте классы предметов
 * 
 * 2. Создайте систему квестов:
 *    - IQuest интерфейс
 *    - KillQuest (убить врагов)
 *    - CollectQuest (собрать предметы)
 *    - TalkQuest (поговорить с NPC)
 * 
 * 3. Создайте систему транспорта:
 *    - IVehicle интерфейс
 *    - Car, Boat, Plane классы
 *    - Каждый с уникальными методами
 * 
 * 4. Создайте абстрактный класс Projectile:
 *    - Arrow, Bullet, Fireball наследники
 *    - Абстрактный метод OnHit()
 *    - Реализуйте разное поведение
 * 
 * 5. Продвинутое задание:
 *    - Создайте систему магазина
 *    - IBuyable, ISellable интерфейсы
 *    - Разные типы товаров
 *    - Система скидок и торговли
 * 
 * ========================================
 * ВАЖНЫЕ КОНЦЕПЦИИ
 * ========================================
 * 
 * 1. Интерфейс vs Абстрактный класс:
 *    
 *    Интерфейс:
 *    - Только сигнатуры методов
 *    - Множественная реализация
 *    - Нет полей и конструкторов
 *    
 *    Абстрактный класс:
 *    - Может иметь реализацию
 *    - Только одиночное наследование
 *    - Может иметь поля и конструкторы
 * 
 * 2. Когда использовать интерфейсы:
 *    - Определение контракта
 *    - Множественная реализация нужна
 *    - Несвязанные классы должны иметь общее поведение
 * 
 * 3. Когда использовать абстрактные классы:
 *    - Общая реализация для наследников
 *    - Тесно связанные классы
 *    - Нужны поля и конструкторы
 * 
 * 4. Именование:
 *    - Интерфейсы начинаются с I
 *    - IDamageable, IMovable, IInteractable
 * 
 * ========================================
 * ЧАСТЫЕ ОШИБКИ
 * ========================================
 * 
 * 1. Попытка создать экземпляр интерфейса:
 *    IDamageable obj = new IDamageable(); // ❌
 * 
 * 2. Попытка создать экземпляр абстрактного класса:
 *    GameEntity entity = new GameEntity(); // ❌
 * 
 * 3. Не реализовали все методы интерфейса:
 *    public class Player : IDamageable
 *    {
 *        // ❌ Забыли реализовать TakeDamage()
 *    }
 * 
 * 4. Приведение без проверки:
 *    ICollectable coll = (ICollectable)obj; // ❌ Может упасть
 *    ICollectable coll = obj as ICollectable; // ✅ Безопасно
 * 
 * ========================================
 */
