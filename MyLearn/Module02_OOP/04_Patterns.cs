using System;
using System.Collections.Generic;

namespace MyLearn.Module02_OOP
{
    /// <summary>
    /// Lesson 4: Design Patterns
    /// 
    /// В этом уроке вы изучите:
    /// - Singleton (Одиночка)
    /// - Factory (Фабрика)
    /// - Observer (Наблюдатель)
    /// - Object Pool (Пул объектов)
    /// - Command (Команда)
    /// </summary>

    // ========================================
    // 1. SINGLETON (ОДИНОЧКА)
    // ========================================

    /// <summary>
    /// Singleton - гарантирует, что класс имеет только один экземпляр
    /// Используется для: GameManager, AudioManager, SaveManager
    /// </summary>
    public class GameController
    {
        // Статическое поле для хранения единственного экземпляра
        private static GameController? instance;

        // Публичное свойство для доступа к экземпляру
        public static GameController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameController();
                }
                return instance;
            }
        }

        // Private конструктор - нельзя создать извне
        private GameController()
        {
            Console.WriteLine("GameManager создан");
        }

        // Игровые данные
        public int Score { get; set; }
        public int Level { get; set; }

        public void StartGame()
        {
            Score = 0;
            Level = 1;
            Console.WriteLine("🎮 Игра началась!");
        }

        public void AddScore(int points)
        {
            Score += points;
            Console.WriteLine($"💯 Очки: {Score}");
        }

        public void NextLevel()
        {
            Level++;
            Console.WriteLine($"⬆️ Level {Level}!");
        }
    }

    // Еще один пример Singleton
    public class AudioManager
    {
        private static AudioManager? instance;
        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AudioManager();
                }
                return instance;
            }
        }

        private AudioManager()
        {
            Volume = 1.0f;
        }

        public float Volume { get; set; }

        public void PlaySound(string soundName)
        {
            Console.WriteLine($"🔊 Воспроизведение: {soundName} (Громкость: {Volume})");
        }

        public void SetVolume(float volume)
        {
            Volume = volume;
            Console.WriteLine($"🔊 Громкость установлена: {Volume}");
        }
    }

    // ========================================
    // 2. FACTORY (ФАБРИКА)
    // ========================================

    /// <summary>
    /// Factory - создает объекты без указания точного класса
    /// Используется для: создание врагов, предметов, оружия
    /// </summary>

    // Base class врага
    public abstract class EnemyBase
    {
        public string Name { get; set; } = "";
        public int Health { get; set; }
        public int Damage { get; set; }

        public abstract void Attack();
    }

    // Конкретные враги
    public class GoblinUnit : EnemyBase
    {
        public GoblinUnit()
        {
            Name = "Гоблин";
            Health = 50;
            Damage = 10;
        }

        public override void Attack()
        {
            Console.WriteLine($"🗡️ {Name} быстро атакует!");
        }
    }

    public class OrcUnit : EnemyBase
    {
        public OrcUnit()
        {
            Name = "Орк";
            Health = 100;
            Damage = 20;
        }

        public override void Attack()
        {
            Console.WriteLine($"🪓 {Name} наносит мощный удар!");
        }
    }

    public class DragonUnit : EnemyBase
    {
        public DragonUnit()
        {
            Name = "Дракон";
            Health = 500;
            Damage = 75;
        }

        public override void Attack()
        {
            Console.WriteLine($"🔥 {Name} дышит огнем!");
        }
    }

    // Фабрика врагов
    public class EnemyFactory
    {
        public static EnemyBase CreateEnemy(string type)
        {
            switch (type.ToLower())
            {
                case "goblin":
                    return new GoblinUnit();
                case "orc":
                    return new OrcUnit();
                case "dragon":
                    return new DragonUnit();
                default:
                    Console.WriteLine($"⚠️ Неизвестный тип врага: {type}");
                    return new GoblinUnit(); // По умолчанию
            }
        }

        // Создание случайного врага
        public static EnemyBase CreateRandomEnemy()
        {
            Random random = new Random();
            int type = random.Next(0, 3);

            switch (type)
            {
                case 0: return new GoblinUnit();
                case 1: return new OrcUnit();
                case 2: return new DragonUnit();
                default: return new GoblinUnit();
            }
        }

        // Создание врага по уровню
        public static EnemyBase CreateEnemyForLevel(int level)
        {
            if (level <= 3)
                return new GoblinUnit();
            else if (level <= 7)
                return new OrcUnit();
            else
                return new DragonUnit();
        }
    }

    // ========================================
    // 3. OBSERVER (НАБЛЮДАТЕЛЬ)
    // ========================================

    /// <summary>
    /// Observer - объекты подписываются на события и получают уведомления
    /// Используется для: система событий, достижения, UI обновления
    /// </summary>

    // Система событий
    public class EventSystem
    {
        // Делегаты для событий
        public delegate void EnemyKilledHandler(string enemyName, int reward);
        public delegate void PlayerLevelUpHandler(int newLevel);
        public delegate void ItemCollectedHandler(string itemName);

        // События
        public static event EnemyKilledHandler? OnEnemyKilled;
        public static event PlayerLevelUpHandler? OnPlayerLevelUp;
        public static event ItemCollectedHandler? OnItemCollected;

        // Methods для вызова событий
        public static void EnemyKilled(string enemyName, int reward)
        {
            Console.WriteLine($"📢 Событие: Враг {enemyName} убит!");
            OnEnemyKilled?.Invoke(enemyName, reward);
        }

        public static void PlayerLevelUp(int newLevel)
        {
            Console.WriteLine($"📢 Событие: Игрок достиг уровня {newLevel}!");
            OnPlayerLevelUp?.Invoke(newLevel);
        }

        public static void ItemCollected(string itemName)
        {
            Console.WriteLine($"📢 Событие: Собран предмет {itemName}!");
            OnItemCollected?.Invoke(itemName);
        }
    }

    // Наблюдатели (подписчики)
    public class ScoreManager
    {
        private int score = 0;

        public ScoreManager()
        {
            // Подписываемся на события
            EventSystem.OnEnemyKilled += AddScoreForEnemy;
            EventSystem.OnItemCollected += AddScoreForItem;
        }

        private void AddScoreForEnemy(string enemyName, int reward)
        {
            score += reward;
            Console.WriteLine($"  💯 ScoreManager: +{reward} очков. Всего: {score}");
        }

        private void AddScoreForItem(string itemName)
        {
            score += 10;
            Console.WriteLine($"  💯 ScoreManager: +10 очков за {itemName}. Всего: {score}");
        }

        ~ScoreManager()
        {
            // Отписываемся от событий
            EventSystem.OnEnemyKilled -= AddScoreForEnemy;
            EventSystem.OnItemCollected -= AddScoreForItem;
        }
    }

    public class AchievementManager
    {
        private int enemiesKilled = 0;

        public AchievementManager()
        {
            EventSystem.OnEnemyKilled += CheckAchievements;
        }

        private void CheckAchievements(string enemyName, int reward)
        {
            enemiesKilled++;
            Console.WriteLine($"  🏆 AchievementManager: Убито врагов: {enemiesKilled}");

            if (enemiesKilled == 10)
            {
                Console.WriteLine($"  🎉 Достижение разблокировано: Убийца!");
            }
        }

        ~AchievementManager()
        {
            EventSystem.OnEnemyKilled -= CheckAchievements;
        }
    }

    public class UIManager
    {
        public UIManager()
        {
            EventSystem.OnPlayerLevelUp += UpdateLevelDisplay;
            EventSystem.OnItemCollected += ShowItemNotification;
        }

        private void UpdateLevelDisplay(int newLevel)
        {
            Console.WriteLine($"  📺 UIManager: Обновление UI - Level {newLevel}");
        }

        private void ShowItemNotification(string itemName)
        {
            Console.WriteLine($"  📺 UIManager: Показать уведомление - Получен {itemName}");
        }

        ~UIManager()
        {
            EventSystem.OnPlayerLevelUp -= UpdateLevelDisplay;
            EventSystem.OnItemCollected -= ShowItemNotification;
        }
    }

    // ========================================
    // 4. OBJECT POOL (ПУЛ ОБЪЕКТОВ)
    // ========================================

    /// <summary>
    /// Object Pool - переиспользование объектов вместо создания новых
    /// Используется для: пули, эффекты, враги
    /// </summary>

    public class Bullet
    {
        public bool IsActive { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }

        public void Fire(float x, float y)
        {
            IsActive = true;
            PositionX = x;
            PositionY = y;
            Console.WriteLine($"💥 Пуля выпущена на ({x}, {y})");
        }

        public void Deactivate()
        {
            IsActive = false;
            Console.WriteLine($"💥 Пуля деактивирована");
        }
    }

    public class BulletPool
    {
        private List<Bullet> pool;
        private int poolSize;

        public BulletPool(int size)
        {
            poolSize = size;
            pool = new List<Bullet>();

            // Предварительно создаем объекты
            for (int i = 0; i < poolSize; i++)
            {
                pool.Add(new Bullet());
            }

            Console.WriteLine($"🎱 Пул пуль создан. Размер: {poolSize}");
        }

        public Bullet GetBullet()
        {
            // Ищем неактивную пулю
            foreach (Bullet bullet in pool)
            {
                if (!bullet.IsActive)
                {
                    return bullet;
                }
            }

            // Если все заняты, создаем новую
            Console.WriteLine("⚠️ Пул пуль переполнен, создаем новую");
            Bullet newBullet = new Bullet();
            pool.Add(newBullet);
            return newBullet;
        }

        public void ReturnBullet(Bullet bullet)
        {
            bullet.Deactivate();
        }

        public int GetActiveCount()
        {
            int count = 0;
            foreach (Bullet bullet in pool)
            {
                if (bullet.IsActive) count++;
            }
            return count;
        }
    }

    // ========================================
    // 5. COMMAND (КОМАНДА)
    // ========================================

    /// <summary>
    /// Command - инкапсулирует действие как объект
    /// Используется для: система отмены, макросы, AI
    /// </summary>

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class PlayerCharacter
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }

        public PlayerCharacter()
        {
            X = 0;
            Y = 0;
            Health = 100;
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
            Console.WriteLine($"🏃 Игрок переместился на ({X}, {Y})");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"💔 Игрок получил {damage} урона. HP: {Health}");
        }

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"💚 Игрок восстановил {amount} HP. HP: {Health}");
        }
    }

    public class MoveCommand : ICommand
    {
        private PlayerCharacter player;
        private int dx, dy;

        public MoveCommand(PlayerCharacter player, int dx, int dy)
        {
            this.player = player;
            this.dx = dx;
            this.dy = dy;
        }

        public void Execute()
        {
            player.Move(dx, dy);
        }

        public void Undo()
        {
            player.Move(-dx, -dy);
            Console.WriteLine("↶ Отмена движения");
        }
    }

    public class DamageCommand : ICommand
    {
        private PlayerCharacter player;
        private int damage;

        public DamageCommand(PlayerCharacter player, int damage)
        {
            this.player = player;
            this.damage = damage;
        }

        public void Execute()
        {
            player.TakeDamage(damage);
        }

        public void Undo()
        {
            player.Heal(damage);
            Console.WriteLine("↶ Отмена урона");
        }
    }

    public class CommandManager
    {
        private Stack<ICommand> commandHistory = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            commandHistory.Push(command);
        }

        public void UndoLastCommand()
        {
            if (commandHistory.Count > 0)
            {
                ICommand command = commandHistory.Pop();
                command.Undo();
            }
            else
            {
                Console.WriteLine("❌ Нечего отменять");
            }
        }
    }

    // ========================================
    // ДЕМОНСТРАЦИЯ
    // ========================================

    public class PatternsDemo
    {
        // Для запуска этого урока раскомментируйте Main и закомментируйте Main в других файлах
        public static void RunDemo()
        {
            Console.WriteLine("=== Lesson 4: Design Patterns ===\n");

            // ========================================
            // 1. SINGLETON
            // ========================================

            Console.WriteLine("--- Паттерн Singleton ---");

            // Получаем единственный экземпляр
            GameController gm1 = GameController.Instance;
            GameController gm2 = GameController.Instance;

            // Это один и тот же объект
            Console.WriteLine($"gm1 == gm2: {gm1 == gm2}");

            gm1.StartGame();
            gm1.AddScore(100);
            gm2.AddScore(50); // Изменяет тот же объект
            Console.WriteLine($"Итоговые очки: {gm1.Score}");

            // AudioManager тоже Singleton
            AudioManager.Instance.SetVolume(0.8f);
            AudioManager.Instance.PlaySound("Выстрел");

            // ========================================
            // 2. FACTORY
            // ========================================

            Console.WriteLine("\n--- Паттерн Factory ---");

            // Создание врагов через фабрику
            EnemyBase enemy1 = EnemyFactory.CreateEnemy("goblin");
            EnemyBase enemy2 = EnemyFactory.CreateEnemy("orc");
            EnemyBase enemy3 = EnemyFactory.CreateEnemy("dragon");

            enemy1.Attack();
            enemy2.Attack();
            enemy3.Attack();

            // Случайный враг
            Console.WriteLine("\nСлучайные враги:");
            for (int i = 0; i < 3; i++)
            {
                EnemyBase randomEnemy = EnemyFactory.CreateRandomEnemy();
                Console.WriteLine($"Создан: {randomEnemy.Name}");
            }

            // Враги по уровню
            Console.WriteLine("\nВраги по уровню:");
            for (int level = 1; level <= 10; level += 3)
            {
                EnemyBase levelEnemy = EnemyFactory.CreateEnemyForLevel(level);
                Console.WriteLine($"Level {level}: {levelEnemy.Name}");
            }

            // ========================================
            // 3. OBSERVER
            // ========================================

            Console.WriteLine("\n--- Паттерн Observer ---");

            // Создаем наблюдателей
            ScoreManager scoreManager = new ScoreManager();
            AchievementManager achievementManager = new AchievementManager();
            UIManager uiManager = new UIManager();

            // Вызываем события
            EventSystem.EnemyKilled("Гоблин", 10);
            EventSystem.EnemyKilled("Орк", 25);
            EventSystem.ItemCollected("Зелье");
            EventSystem.PlayerLevelUp(5);

            // ========================================
            // 4. OBJECT POOL
            // ========================================

            Console.WriteLine("\n--- Паттерн Object Pool ---");

            BulletPool bulletPool = new BulletPool(5);

            // Стреляем несколько раз
            List<Bullet> activeBullets = new List<Bullet>();

            for (int i = 0; i < 7; i++)
            {
                Bullet bullet = bulletPool.GetBullet();
                bullet.Fire(i * 10, 0);
                activeBullets.Add(bullet);
            }

            Console.WriteLine($"Активных пуль: {bulletPool.GetActiveCount()}");

            // Возвращаем пули в пул
            foreach (Bullet bullet in activeBullets)
            {
                bulletPool.ReturnBullet(bullet);
            }

            Console.WriteLine($"Активных пуль после возврата: {bulletPool.GetActiveCount()}");

            // ========================================
            // 5. COMMAND
            // ========================================

            Console.WriteLine("\n--- Паттерн Command ---");

            PlayerCharacter player = new PlayerCharacter();
            CommandManager commandManager = new CommandManager();

            // Выполняем команды
            commandManager.ExecuteCommand(new MoveCommand(player, 5, 0));
            commandManager.ExecuteCommand(new MoveCommand(player, 0, 3));
            commandManager.ExecuteCommand(new DamageCommand(player, 20));
            commandManager.ExecuteCommand(new MoveCommand(player, -2, 0));

            Console.WriteLine($"\nТекущая позиция: ({player.X}, {player.Y})");
            Console.WriteLine($"Текущее здоровье: {player.Health}");

            // Отменяем последние действия
            Console.WriteLine("\nОтмена последних действий:");
            commandManager.UndoLastCommand();
            commandManager.UndoLastCommand();
            commandManager.UndoLastCommand();

            Console.WriteLine($"\nПозиция после отмены: ({player.X}, {player.Y})");
            Console.WriteLine($"Здоровье после отмены: {player.Health}");

            // ========================================
            // 6. КОМБИНИРОВАНИЕ ПАТТЕРНОВ
            // ========================================

            Console.WriteLine("\n--- Комбинирование паттернов ---");

            // Singleton + Factory + Observer
            GameController.Instance.StartGame();

            for (int i = 0; i < 3; i++)
            {
                EnemyBase enemyUnit = EnemyFactory.CreateRandomEnemy();
                Console.WriteLine($"\nСоздан враг: {enemyUnit.Name}");

                // Симулируем убийство
                EventSystem.EnemyKilled(enemyUnit.Name, enemyUnit.Damage);
                GameController.Instance.AddScore(enemyUnit.Damage);
            }
        }
    }
}

/*
 * ========================================
 * УПРАЖНЕНИЯ
 * ========================================
 * 
 * 1. Создайте Singleton для SaveManager:
 *    - Сохранение игры
 *    - Загрузка игры
 *    - Автосохранение
 * 
 * 2. Создайте Factory для оружия:
 *    - WeaponFactory
 *    - Разные типы оружия
 *    - Создание по редкости
 * 
 * 3. Расширьте систему событий:
 *    - Добавьте новые события
 *    - Создайте новых наблюдателей
 *    - QuestManager, StatisticsManager
 * 
 * 4. Создайте Object Pool для эффектов:
 *    - ParticlePool
 *    - Разные типы эффектов
 *    - Автоматический возврат
 * 
 * 5. Продвинутое задание:
 *    - Создайте систему навыков с Command
 *    - Возможность отмены
 *    - Macroы (последовательность команд)
 *    - Сохранение истории
 * 
 * ========================================
 * КОГДА ИСПОЛЬЗОВАТЬ ПАТТЕРНЫ
 * ========================================
 * 
 * Singleton:
 * ✅ Нужен глобальный доступ
 * ✅ Только один экземпляр
 * ❌ Усложняет Testing
 * 
 * Factory:
 * ✅ Сложная логика создания
 * ✅ Много похожих объектов
 * ✅ Нужна гибкость
 * 
 * Observer:
 * ✅ Слабая связанность
 * ✅ Один-ко-многим отношения
 * ✅ Система событий
 * 
 * Object Pool:
 * ✅ Частое создание/удаление
 * ✅ Дорогие объекты
 * ✅ Оптимизация памяти
 * 
 * Command:
 * ✅ Нужна отмена операций
 * ✅ Queue операций
 * ✅ Логирование действий
 * 
 * ========================================
 * ЧАСТЫЕ ОШИБКИ
 * ========================================
 * 
 * 1. Злоупотребление Singleton:
 *    - Не делайте все classes Singleton
 *    - Используйте только когда действительно нужно
 * 
 * 2. Забыли отписаться от событий:
 *    EventSystem.OnEvent += Handler;
 *    // ❌ Забыли -= при уничтожении
 *    // Приводит к утечкам памяти
 * 
 * 3. Не возвращаете объекты в пул:
 *    Bullet bullet = pool.Get();
 *    // ❌ Забыли pool.Return(bullet)
 * 
 * 4. Слишком сложные команды:
 *    - Команды должны быть простыми
 *    - Одна команда = одно действие
 * 
 * ========================================
 */
