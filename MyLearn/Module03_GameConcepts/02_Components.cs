using System;
using System.Collections.Generic;

namespace MyLearn.Module03_GameConcepts
{
    /// <summary>
    /// Lesson 12: Компонентная система
    /// 
    /// Unity использует компонентную архитектуру:
    /// - GameObject - контейнер для компонентов
    /// - Component - отдельная функциональность
    /// - Композиция вместо наследования
    /// </summary>
    public class ComponentsLesson
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Lesson 12: Компонентная система ===\n");

            Console.WriteLine("В Unity все построено на компонентах:");
            Console.WriteLine("GameObject = Transform + Renderer + Collider + Scripts\n");

            // Пример 1: Создание GameObject с компонентами
            Example1_BasicComponents();

            // Пример 2: Взаимодействие компонентов
            Example2_ComponentInteraction();
        }

        static void Example1_BasicComponents()
        {
            Console.WriteLine("--- Пример 1: Базовые компоненты ---\n");

            // Создаем игровой объект
            var player = new GameObject("Игрок");

            // Добавляем компоненты
            player.AddComponent(new TransformComponent(0, 0));
            player.AddComponent(new HealthComponent(100));
            player.AddComponent(new MovementComponent(5f));

            Console.WriteLine($"Создан объект: {player.Name}");
            Console.WriteLine($"Компонентов: {player.ComponentCount}\n");

            // Получаем компоненты
            var health = player.GetComponent<HealthComponent>();
            var movement = player.GetComponent<MovementComponent>();

            Console.WriteLine($"Здоровье: {health.CurrentHealth}/{health.MaxHealth}");
            Console.WriteLine($"Скорость: {movement.Speed}\n");

            // Используем компоненты
            health.TakeDamage(30);
            Console.WriteLine($"После урона: {health.CurrentHealth}/{health.MaxHealth}");

            health.Heal(20);
            Console.WriteLine($"После лечения: {health.CurrentHealth}/{health.MaxHealth}\n");

            Console.WriteLine("Нажмите Enter...");
            Console.ReadLine();
        }

        static void Example2_ComponentInteraction()
        {
            Console.Clear();
            Console.WriteLine("--- Пример 2: Взаимодействие компонентов ---\n");

            // Создаем врага с компонентами
            var enemy = new GameObject("Орк");
            var transform = new TransformComponent(10, 5);
            var health = new HealthComponent(50);
            var ai = new AIComponent();

            enemy.AddComponent(transform);
            enemy.AddComponent(health);
            enemy.AddComponent(ai);

            Console.WriteLine($"Создан {enemy.Name}:");
            Console.WriteLine($"  Позиция: ({transform.X}, {transform.Y})");
            Console.WriteLine($"  Здоровье: {health.CurrentHealth}\n");

            // AI компонент использует другие компоненты
            Console.WriteLine("AI обновляется 5 раз:\n");

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Кадр {i}:");
                ai.Update(enemy, 0.1f);
                Console.WriteLine();
            }

            Console.WriteLine("✅ Exercises:");
            Console.WriteLine("1. Создайте AttackComponent с уроном и кулдауном");
            Console.WriteLine("2. Создайте InventoryComponent для хранения предметов");
            Console.WriteLine("3. Сделайте так, чтобы AI использовал AttackComponent");
        }
    }

    // ========================================
    // КОМПОНЕНТНАЯ СИСТЕМА
    // ========================================

    // Base class компонента
    public abstract class Component
    {
        public GameObject? GameObject { get; set; }

        public virtual void Update(float deltaTime) { }
    }

    // GameObject - контейнер для компонентов
    public class GameObject
    {
        public string Name { get; set; }
        private List<Component> components = new List<Component>();

        public int ComponentCount => components.Count;

        public GameObject(string name)
        {
            Name = name;
        }

        public void AddComponent(Component component)
        {
            component.GameObject = this;
            components.Add(component);
        }

        public T? GetComponent<T>() where T : Component
        {
            foreach (var component in components)
            {
                if (component is T result)
                    return result;
            }
            return null;
        }

        public void Update(float deltaTime)
        {
            foreach (var component in components)
            {
                component.Update(deltaTime);
            }
        }
    }

    // ========================================
    // КОНКРЕТНЫЕ КОМПОНЕНТЫ
    // ========================================

    // Компонент позиции
    public class TransformComponent : Component
    {
        public float X { get; set; }
        public float Y { get; set; }

        public TransformComponent(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void Move(float dx, float dy)
        {
            X += dx;
            Y += dy;
        }
    }

    // Компонент здоровья
    public class HealthComponent : Component
    {
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }

        public bool IsAlive => CurrentHealth > 0;

        public HealthComponent(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth < 0) CurrentHealth = 0;

            Console.WriteLine($"  💔 Получен урон {damage}! HP: {CurrentHealth}/{MaxHealth}");

            if (!IsAlive)
            {
                Console.WriteLine($"  💀 {GameObject?.Name} погиб!");
            }
        }

        public void Heal(int amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;

            Console.WriteLine($"  💚 Восстановлено {amount} HP! HP: {CurrentHealth}/{MaxHealth}");
        }
    }

    // Компонент движения
    public class MovementComponent : Component
    {
        public float Speed { get; set; }

        public MovementComponent(float speed)
        {
            Speed = speed;
        }

        public void MoveTowards(float targetX, float targetY, float deltaTime)
        {
            var transform = GameObject?.GetComponent<TransformComponent>();
            if (transform == null) return;

            float dx = targetX - transform.X;
            float dy = targetY - transform.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance > 0.1f)
            {
                float moveDistance = Speed * deltaTime;
                transform.X += (dx / distance) * moveDistance;
                transform.Y += (dy / distance) * moveDistance;
            }
        }
    }

    // Компонент AI
    public class AIComponent : Component
    {
        private Random random = new Random();
        private float thinkTimer = 0;

        public override void Update(float deltaTime)
        {
            thinkTimer += deltaTime;

            if (thinkTimer >= 1f) // Думаем раз в секунду
            {
                Think();
                thinkTimer = 0;
            }
        }

        public void Update(GameObject gameObject, float deltaTime)
        {
            var transform = gameObject.GetComponent<TransformComponent>();
            var health = gameObject.GetComponent<HealthComponent>();

            if (transform == null || health == null) return;

            Console.WriteLine($"  🤖 AI думает...");
            Console.WriteLine($"     Позиция: ({transform.X:F1}, {transform.Y:F1})");
            Console.WriteLine($"     Здоровье: {health.CurrentHealth}/{health.MaxHealth}");

            // Простое поведение
            if (health.CurrentHealth < 20)
            {
                Console.WriteLine($"     💭 Здоровье низкое! Нужно отступить!");
            }
            else
            {
                Console.WriteLine($"     💭 Патрулирую...");
                transform.Move((float)(random.NextDouble() - 0.5), (float)(random.NextDouble() - 0.5));
            }
        }

        private void Think()
        {
            var health = GameObject?.GetComponent<HealthComponent>();
            if (health != null && health.CurrentHealth < 20)
            {
                Console.WriteLine($"  🤖 {GameObject?.Name}: Нужно отступить!");
            }
        }
    }
}
