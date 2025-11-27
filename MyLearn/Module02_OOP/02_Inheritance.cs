using System;
using System.Collections.Generic;

namespace MyLearn.Module02_OOP
{
    /// <summary>
    /// Lesson 2: Inheritance and Polymorphism
    /// 
    /// В этом уроке вы изучите:
    /// - Что такое inheritance
    /// - Базовые и производные classes
    /// - Ключевые слова virtual и override
    /// - Polymorphism
    /// - Ключевое слово base
    /// </summary>

    // ========================================
    // БАЗОВЫЙ КЛАСС
    // ========================================

    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }

        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            Damage = damage;
        }

        // Virtual метод - может быть переопределен в наследниках
        public virtual void Attack(Character target)
        {
            Console.WriteLine($"{Name} атакует {target.Name}!");
            target.TakeDamage(Damage);
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;

            Console.WriteLine($"{Name} получил {damage} урона. HP: {Health}/{MaxHealth}");

            if (Health <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            Console.WriteLine($"💀 {Name} погиб!");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"\n--- {Name} ---");
            Console.WriteLine($"HP: {Health}/{MaxHealth}");
            Console.WriteLine($"Урон: {Damage}");
        }
    }

    // ========================================
    // ПРОИЗВОДНЫЕ КЛАССЫ - ВРАГИ
    // ========================================

    // Warrior наследуется от Character
    public class Warrior : Character
    {
        public int Armor { get; set; }

        // Constructor вызывает конструктор базового класса через base
        public Warrior(string name, int health, int damage, int armor)
            : base(name, health, damage)
        {
            Armor = armor;
        }

        // Override - переопределяем метод базового класса
        public override void TakeDamage(int damage)
        {
            int reducedDamage = damage - Armor;
            if (reducedDamage < 1) reducedDamage = 1;

            Console.WriteLine($"🛡️ Броня {Name} поглощает {Armor} урона!");

            // Вызываем метод базового класса
            base.TakeDamage(reducedDamage);
        }

        // Новый метод, специфичный для Warrior
        public void ShieldBash(Character target)
        {
            Console.WriteLine($"🛡️ {Name} бьет щитом!");
            int bashDamage = Damage / 2;
            target.TakeDamage(bashDamage);
        }
    }

    public class Mage : Character
    {
        public int Mana { get; set; }
        public int MaxMana { get; set; }

        public Mage(string name, int health, int damage, int mana)
            : base(name, health, damage)
        {
            Mana = mana;
            MaxMana = mana;
        }

        public override void Attack(Character target)
        {
            if (Mana >= 20)
            {
                Console.WriteLine($"✨ {Name} использует магию!");
                Mana -= 20;
                int magicDamage = Damage * 2;
                target.TakeDamage(magicDamage);
            }
            else
            {
                Console.WriteLine($"❌ {Name} недостаточно маны!");
                base.Attack(target);
            }
        }

        public void Heal(Character target)
        {
            if (Mana >= 30)
            {
                Mana -= 30;
                int healAmount = 50;
                target.Health += healAmount;
                if (target.Health > target.MaxHealth)
                    target.Health = target.MaxHealth;

                Console.WriteLine($"💚 {Name} исцеляет {target.Name} на {healAmount} HP!");
            }
            else
            {
                Console.WriteLine($"❌ Недостаточно маны для исцеления!");
            }
        }
    }

    public class Rogue : Character
    {
        public int CritChance { get; set; }

        public Rogue(string name, int health, int damage, int critChance)
            : base(name, health, damage)
        {
            CritChance = critChance;
        }

        public override void Attack(Character target)
        {
            Random random = new Random();
            bool isCrit = random.Next(0, 100) < CritChance;

            if (isCrit)
            {
                Console.WriteLine($"💥 {Name} наносит критический удар!");
                int critDamage = Damage * 3;
                target.TakeDamage(critDamage);
            }
            else
            {
                base.Attack(target);
            }
        }

        public void Stealth()
        {
            Console.WriteLine($"👤 {Name} входит в режим невидимости!");
            CritChance += 50;
        }
    }

    // ========================================
    // ИЕРАРХИЯ ВРАГОВ
    // ========================================

    public class EnemyCharacter : Character
    {
        public int GoldReward { get; set; }
        public int ExpReward { get; set; }

        public EnemyCharacter(string name, int health, int damage, int gold, int exp)
            : base(name, health, damage)
        {
            GoldReward = gold;
            ExpReward = exp;
        }

        public override void Die()
        {
            base.Die();
            Console.WriteLine($"💰 Награда: {GoldReward} золота, {ExpReward} опыта");
        }
    }

    public class GoblinEnemy : EnemyCharacter
    {
        public GoblinEnemy() : base("Гоблин", 50, 10, 10, 25)
        {
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"🗡️ {Name} быстро атакует!");
            base.Attack(target);
        }
    }

    public class OrcEnemy : EnemyCharacter
    {
        public OrcEnemy() : base("Орк", 100, 20, 25, 50)
        {
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"🪓 {Name} наносит мощный удар!");
            base.Attack(target);
        }
    }

    public class DragonEnemy : EnemyCharacter
    {
        public DragonEnemy() : base("Дракон", 500, 75, 1000, 500)
        {
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"🔥 {Name} дышит огнем!");
            base.Attack(target);
        }

        public void FlyAway()
        {
            Console.WriteLine($"🐉 {Name} улетает в небо!");
        }
    }

    // ========================================
    // ИЕРАРХИЯ ОРУЖИЯ
    // ========================================

    public class WeaponItem
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Durability { get; set; }

        public WeaponItem(string name, int damage)
        {
            Name = name;
            Damage = damage;
            Durability = 100;
        }

        public virtual void Use()
        {
            Console.WriteLine($"⚔️ Использовано: {Name}");
            Durability -= 10;

            if (Durability <= 0)
            {
                Console.WriteLine($"❌ {Name} сломалось!");
            }
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Name} - Урон: {Damage}, Прочность: {Durability}%");
        }
    }

    public class SwordWeapon : WeaponItem
    {
        public int CritBonus { get; set; }

        public SwordWeapon(string name, int damage, int critBonus) : base(name, damage)
        {
            CritBonus = critBonus;
        }

        public override void Use()
        {
            Console.WriteLine($"⚔️ Взмах мечом {Name}!");
            base.Use();
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  Бонус крита: +{CritBonus}%");
        }
    }

    public class BowWeapon : WeaponItem
    {
        public int Range { get; set; }

        public BowWeapon(string name, int damage, int range) : base(name, damage)
        {
            Range = range;
        }

        public override void Use()
        {
            Console.WriteLine($"🏹 Выстрел из {Name}!");
            base.Use();
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  Дальность: {Range}м");
        }
    }

    public class StaffWeapon : WeaponItem
    {
        public int ManaBonus { get; set; }

        public StaffWeapon(string name, int damage, int manaBonus) : base(name, damage)
        {
            ManaBonus = manaBonus;
        }

        public override void Use()
        {
            Console.WriteLine($"🪄 Магическая атака {Name}!");
            base.Use();
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  Бонус маны: +{ManaBonus}");
        }
    }

    // ========================================
    // ДЕМОНСТРАЦИЯ
    // ========================================

    public class InheritanceDemo
    {
        // Для запуска этого урока раскомментируйте Main и закомментируйте Main в других файлах
        public static void RunDemo()
        {
            Console.WriteLine("=== Lesson 2: Inheritance and Polymorphism ===\n");

            // ========================================
            // 1. БАЗОВОЕ НАСЛЕДОВАНИЕ
            // ========================================

            Console.WriteLine("--- Базовое inheritance ---");

            Character baseChar = new Character("Базовый персонаж", 100, 20);
            Warrior warrior = new Warrior("Воин", 150, 25, 10);
            Mage mage = new Mage("Маг", 80, 30, 100);
            Rogue rogue = new Rogue("Разcombatник", 90, 35, 25);

            baseChar.DisplayInfo();
            warrior.DisplayInfo();
            mage.DisplayInfo();
            rogue.DisplayInfo();

            // ========================================
            // 2. ПОЛИМОРФИЗМ
            // ========================================

            Console.WriteLine("\n--- Polymorphism ---");

            // Все classes можно хранить как Character
            List<Character> party = new List<Character>
            {
                warrior,
                mage,
                rogue
            };

            Console.WriteLine("Группа героев:");
            foreach (Character hero in party)
            {
                Console.WriteLine($"- {hero.Name} ({hero.GetType().Name})");
            }

            // ========================================
            // 3. ПЕРЕОПРЕДЕЛЕНИЕ МЕТОДОВ
            // ========================================

            Console.WriteLine("\n--- Переопределение методов ---");

            EnemyCharacter goblin = new GoblinEnemy();

            Console.WriteLine("Воин атакует гоблина:");
            warrior.Attack(goblin);

            Console.WriteLine("\nМаг атакует гоблина:");
            mage.Attack(goblin);

            Console.WriteLine("\nРазcombatник атакует гоблина:");
            rogue.Attack(goblin);

            // ========================================
            // 4. СПЕЦИАЛЬНЫЕ СПОСОБНОСТИ
            // ========================================

            Console.WriteLine("\n--- Специальные способности ---");

            EnemyCharacter orc = new OrcEnemy();

            warrior.ShieldBash(orc);
            mage.Heal(warrior);
            rogue.Stealth();
            rogue.Attack(orc);

            // ========================================
            // 5. ИЕРАРХИЯ ВРАГОВ
            // ========================================

            Console.WriteLine("\n--- Hierarchy врагов ---");

            List<EnemyCharacter> enemies = new List<EnemyCharacter>
            {
                new GoblinEnemy(),
                new OrcEnemy(),
                new DragonEnemy()
            };

            Console.WriteLine("Враги на уровне:");
            foreach (EnemyCharacter enemy in enemies)
            {
                Console.WriteLine($"{enemy.Name} - HP: {enemy.Health}, Урон: {enemy.Damage}");
            }

            // ========================================
            // 6. БОЙ С РАЗНЫМИ ВРАГАМИ
            // ========================================

            Console.WriteLine("\n--- Бой с разными врагами ---");

            Warrior heroWarrior = new Warrior("Герой", 200, 40, 15);

            foreach (EnemyCharacter enemy in enemies)
            {
                Console.WriteLine($"\n⚔️ Бой с {enemy.Name}!");

                while (heroWarrior.Health > 0 && enemy.Health > 0)
                {
                    heroWarrior.Attack(enemy);

                    if (enemy.Health > 0)
                    {
                        enemy.Attack(heroWarrior);
                    }
                }

                if (heroWarrior.Health <= 0)
                {
                    Console.WriteLine("\n💀 Герой погиб!");
                    break;
                }

                Console.WriteLine();
            }

            // ========================================
            // 7. ИЕРАРХИЯ ОРУЖИЯ
            // ========================================

            Console.WriteLine("\n--- Hierarchy оружия ---");

            List<WeaponItem> weapons = new List<WeaponItem>
            {
                new SwordWeapon("Экскалибур", 50, 15),
                new BowWeapon("Длинный лук", 35, 50),
                new StaffWeapon("Посох мудрости", 45, 30)
            };

            Console.WriteLine("Доступное оружие:");
            foreach (WeaponItem weapon in weapons)
            {
                weapon.DisplayInfo();
            }

            Console.WriteLine("\nИспользование оружия:");
            foreach (WeaponItem weapon in weapons)
            {
                weapon.Use();
            }

            // ========================================
            // 8. ПОЛИМОРФИЗМ В ДЕЙСТВИИ
            // ========================================

            Console.WriteLine("\n--- Polymorphism в действии ---");

            // Можем хранить разные типы в одном массиве
            Character[] characters = new Character[]
            {
                new Warrior("Танк", 200, 30, 20),
                new Mage("Целитель", 100, 25, 150),
                new Rogue("Ассасин", 120, 40, 30),
                new GoblinEnemy(),
                new OrcEnemy()
            };

            Console.WriteLine("Все персонажи атакуют первого врага:");
            EnemyCharacter targetEnemy = new DragonEnemy();

            foreach (Character character in characters)
            {
                if (character is EnemyCharacter)
                {
                    Console.WriteLine($"  {character.Name} - враг, пропускаем");
                }
                else
                {
                    character.Attack(targetEnemy);
                }
            }
        }
    }
}

/*
 * ========================================
 * УПРАЖНЕНИЯ
 * ========================================
 * 
 * 1. Создайте иерархию транспорта:
 *    - Base class Vehicle (speed, fuel)
 *    - Car : Vehicle (doors)
 *    - Motorcycle : Vehicle (hasHelmet)
 *    - Truck : Vehicle (cargoCapacity)
 *    - Переопределите метод Move() для каждого
 * 
 * 2. Создайте иерархию монстров:
 *    - Monster (базовый класс)
 *    - Zombie : Monster (медленный, много HP)
 *    - Vampire : Monster (быстрый, лечится от урона)
 *    - Ghost : Monster (может проходить сквозь стены)
 *    - Каждый должен иметь уникальную атаку
 * 
 * 3. Создайте систему магии:
 *    - Spell (базовый класс)
 *    - FireSpell : Spell (урон огнем)
 *    - IceSpell : Spell (замедление)
 *    - HealSpell : Spell (лечение)
 *    - Переопределите метод Cast()
 * 
 * 4. Создайте иерархию зданий:
 *    - Building (базовый)
 *    - House : Building (жители)
 *    - Shop : Building (товары)
 *    - Castle : Building (защита)
 * 
 * 5. Продвинутое задание:
 *    - Создайте RPG систему с классами персонажей
 *    - Warrior, Mage, Rogue, Paladin
 *    - Каждый с уникальными способностями
 *    - Система прокачки уровней
 *    - Боевая система
 * 
 * ========================================
 * ВАЖНЫЕ КОНЦЕПЦИИ
 * ========================================
 * 
 * 1. Inheritance:
 *    - Derived class получает все члены базового
 *    - Используйте : для наследования
 *    - Можно наследоваться только от одного класса
 * 
 * 2. Virtual и Override:
 *    - virtual: метод может быть переопределен
 *    - override: переопределяет виртуальный метод
 *    - Без virtual нельзя использовать override
 * 
 * 3. Base:
 *    - Вызов конструктора базового класса
 *    - Вызов методов базового класса
 *    - base.Method() внутри override
 * 
 * 4. Polymorphism:
 *    - Один интерфейс, разные реализации
 *    - Character может быть Warrior, Mage, etc.
 *    - Вызов правильного метода в runtime
 * 
 * 5. Is и As:
 *    - is: проверка типа (if (obj is Warrior))
 *    - as: безопасное приведение типа
 * 
 * ========================================
 * ЧАСТЫЕ ОШИБКИ
 * ========================================
 * 
 * 1. Забыли base() в конструкторе:
 *    public Warrior(string name) // ❌ Ошибка!
 *    public Warrior(string name) : base(name) // ✅
 * 
 * 2. Override без virtual:
 *    public void Attack() { } // в базовом
 *    public override void Attack() { } // ❌ Ошибка!
 * 
 * 3. Скрытие вместо переопределения:
 *    public new void Attack() { } // Скрывает, не переопределяет
 * 
 * 4. Вызов base после изменения состояния:
 *    Health = 0;
 *    base.TakeDamage(damage); // Может быть неправильно
 * 
 * ========================================
 */
