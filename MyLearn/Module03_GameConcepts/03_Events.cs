using System;

namespace MyLearn.Module03_GameConcepts
{
    /// <summary>
    /// Lesson 13: Система событий
    /// 
    /// События - основа коммуникации в играх:
    /// - Слабая связанность систем
    /// - Уведомления о важных событиях
    /// - UI обновления, звуки, достижения
    /// </summary>
    public class EventsLesson
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Lesson 13: Система событий ===\n");

            Console.WriteLine("События позволяют системам общаться без прямых ссылок:");
            Console.WriteLine("Игрок убил врага → UI обновляет счет → Звук победы → Достижение\n");

            // Пример 1: Простые события
            Example1_SimpleEvents();

            // Пример 2: Игровая система событий
            Example2_GameEventSystem();
        }

        static void Example1_SimpleEvents()
        {
            Console.WriteLine("--- Пример 1: Простые события ---\n");

            var player = new EventPlayer("Герой");

            // Подписываемся на события
            player.OnHealthChanged += (current, max) =>
            {
                Console.WriteLine($"  📊 UI: Обновляю полоску здоровья {current}/{max}");
            };

            player.OnDied += (name) =>
            {
                Console.WriteLine($"  💀 GameManager: {name} погиб! Game Over!");
            };

            player.OnLevelUp += (name, level) =>
            {
                Console.WriteLine($"  ⭐ UI: {name} достиг уровня {level}!");
                Console.WriteLine($"  🎵 Audio: Играю звук повышения уровня!");
            };

            Console.WriteLine("Симуляция игры:\n");

            player.TakeDamage(30);
            player.TakeDamage(40);
            player.GainExperience(100);
            player.TakeDamage(50);

            Console.WriteLine("\nНажмите Enter...");
            Console.ReadLine();
        }

        static void Example2_GameEventSystem()
        {
            Console.Clear();
            Console.WriteLine("--- Пример 2: Игровая система событий ---\n");

            // Создаем менеджеры
            var scoreManager = new ScoreManager();
            var achievementManager = new AchievementManager();
            var audioManager = new AudioManager();

            Console.WriteLine("Система событий инициализирована\n");
            Console.WriteLine("Симуляция игровых событий:\n");

            // Генерируем события
            GameEventSystem.EnemyKilled("Гоблин", 50);
            GameEventSystem.EnemyKilled("Орк", 100);
            GameEventSystem.ItemCollected("Золото", 25);
            GameEventSystem.EnemyKilled("Дракон", 500);
            GameEventSystem.PlayerLevelUp("Герой", 2);

            Console.WriteLine($"\n📊 Финальный счет: {scoreManager.TotalScore}");
            Console.WriteLine($"🏆 Разблокировано достижений: {achievementManager.UnlockedCount}");

            Console.WriteLine("\n✅ Exercises:");
            Console.WriteLine("1. Добавьте событие OnQuestCompleted");
            Console.WriteLine("2. Создайте UIManager который слушает все события");
            Console.WriteLine("3. Добавьте систему комбо (убийства подряд)");
        }
    }

    // ========================================
    // ИГРОК С СОБЫТИЯМИ
    // ========================================

    public class EventPlayer
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public int Level { get; private set; }
        public int Experience { get; private set; }

        // События
        public event Action<int, int>? OnHealthChanged;
        public event Action<string>? OnDied;
        public event Action<string, int>? OnLevelUp;

        public EventPlayer(string name)
        {
            Name = name;
            Health = 100;
            MaxHealth = 100;
            Level = 1;
            Experience = 0;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;

            Console.WriteLine($"⚔️ {Name} получил {damage} урона!");
            OnHealthChanged?.Invoke(Health, MaxHealth);

            if (Health == 0)
            {
                OnDied?.Invoke(Name);
            }
        }

        public void GainExperience(int exp)
        {
            Experience += exp;
            Console.WriteLine($"✨ {Name} получил {exp} опыта!");

            // Проверка повышения уровня
            if (Experience >= 100)
            {
                Level++;
                Experience = 0;
                Health = MaxHealth; // Восстанавливаем здоровье

                OnLevelUp?.Invoke(Name, Level);
                OnHealthChanged?.Invoke(Health, MaxHealth);
            }
        }
    }

    // ========================================
    // ГЛОБАЛЬНАЯ СИСТЕМА СОБЫТИЙ
    // ========================================

    public static class GameEventSystem
    {
        // Делегаты
        public delegate void EnemyKilledHandler(string enemyName, int reward);
        public delegate void ItemCollectedHandler(string itemName, int quantity);
        public delegate void PlayerLevelUpHandler(string playerName, int level);

        // События
        public static event EnemyKilledHandler? OnEnemyKilled;
        public static event ItemCollectedHandler? OnItemCollected;
        public static event PlayerLevelUpHandler? OnPlayerLevelUp;

        // Methods для вызова событий
        public static void EnemyKilled(string enemyName, int reward)
        {
            Console.WriteLine($"💥 {enemyName} убит!");
            OnEnemyKilled?.Invoke(enemyName, reward);
        }

        public static void ItemCollected(string itemName, int quantity)
        {
            Console.WriteLine($"📦 Собрано: {itemName} x{quantity}");
            OnItemCollected?.Invoke(itemName, quantity);
        }

        public static void PlayerLevelUp(string playerName, int level)
        {
            Console.WriteLine($"⭐ {playerName} достиг уровня {level}!");
            OnPlayerLevelUp?.Invoke(playerName, level);
        }
    }

    // ========================================
    // МЕНЕДЖЕРЫ (ПОДПИСЧИКИ)
    // ========================================

    public class ScoreManager
    {
        public int TotalScore { get; private set; }

        public ScoreManager()
        {
            GameEventSystem.OnEnemyKilled += OnEnemyKilled;
            GameEventSystem.OnItemCollected += OnItemCollected;
            GameEventSystem.OnPlayerLevelUp += OnPlayerLevelUp;
        }

        private void OnEnemyKilled(string enemyName, int reward)
        {
            TotalScore += reward;
            Console.WriteLine($"  💯 ScoreManager: +{reward} очков. Всего: {TotalScore}");
        }

        private void OnItemCollected(string itemName, int quantity)
        {
            int points = quantity * 10;
            TotalScore += points;
            Console.WriteLine($"  💯 ScoreManager: +{points} очков. Всего: {TotalScore}");
        }

        private void OnPlayerLevelUp(string playerName, int level)
        {
            int bonus = level * 100;
            TotalScore += bonus;
            Console.WriteLine($"  💯 ScoreManager: +{bonus} бонус за уровень!");
        }
    }

    public class AchievementManager
    {
        private int enemiesKilled = 0;
        public int UnlockedCount { get; private set; }

        public AchievementManager()
        {
            GameEventSystem.OnEnemyKilled += OnEnemyKilled;
        }

        private void OnEnemyKilled(string enemyName, int reward)
        {
            enemiesKilled++;

            if (enemiesKilled == 1)
            {
                UnlockAchievement("Первая кровь");
            }
            else if (enemiesKilled == 10)
            {
                UnlockAchievement("Убийца");
            }
            else if (enemiesKilled == 100)
            {
                UnlockAchievement("Легенда");
            }

            if (enemyName == "Дракон")
            {
                UnlockAchievement("Драконоборец");
            }
        }

        private void UnlockAchievement(string name)
        {
            UnlockedCount++;
            Console.WriteLine($"  🏆 AchievementManager: Разблокировано '{name}'!");
        }
    }

    public class AudioManager
    {
        public AudioManager()
        {
            GameEventSystem.OnEnemyKilled += OnEnemyKilled;
            GameEventSystem.OnPlayerLevelUp += OnPlayerLevelUp;
        }

        private void OnEnemyKilled(string enemyName, int reward)
        {
            Console.WriteLine($"  🎵 AudioManager: *звук смерти врага*");
        }

        private void OnPlayerLevelUp(string playerName, int level)
        {
            Console.WriteLine($"  🎵 AudioManager: *эпичная музыка повышения уровня*");
        }
    }
}
