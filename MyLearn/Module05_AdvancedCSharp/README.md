# Модуль 5: Продвинутый C#

## 🎯 Цели модуля

Освоить продвинутые концепции C# для создания сложных игровых систем.

## 📚 Содержание

### 1. Delegates и Events
- Что такое делегаты
- Action и Func
- Создание событий
- Подписка и отписка
- Event-driven архитектура

### 2. Lambda выражения
- Синтаксис lambda
- Использование с делегатами
- Замыкания (closures)

### 3. LINQ (Language Integrated Query)
- Where, Select, OrderBy
- First, Last, Any, All
- Aggregate функции
- Применение в играх

### 4. Generics (Обобщения)
- Generic классы
- Generic методы
- Ограничения (constraints)
- Generic коллекции

### 5. Extension Methods
- Создание расширений
- Расширения для Unity типов

### 6. Async/Await
- Асинхронное программирование
- Task и async методы
- Загрузка ресурсов

## 🎮 Практические примеры

```csharp
// Events - Система событий
public class GameEvents
{
    public static event Action<int> OnEnemyKilled;
    public static event Action OnPlayerDeath;
    public static event Action<string> OnItemCollected;
    
    public static void EnemyKilled(int reward)
    {
        OnEnemyKilled?.Invoke(reward);
    }
}

// Подписка на события
public class ScoreManager : MonoBehaviour
{
    void OnEnable()
    {
        GameEvents.OnEnemyKilled += AddScore;
    }
    
    void OnDisable()
    {
        GameEvents.OnEnemyKilled -= AddScore;
    }
    
    void AddScore(int points)
    {
        score += points;
    }
}

// LINQ - Поиск врагов
List<Enemy> enemies = FindObjectsOfType<Enemy>().ToList();

// Найти ближайшего врага
Enemy closest = enemies
    .OrderBy(e => Vector3.Distance(transform.position, e.transform.position))
    .FirstOrDefault();

// Найти всех врагов с HP < 50
var weakEnemies = enemies.Where(e => e.health < 50).ToList();

// Generic Object Pool
public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> pool = new Queue<T>();
    private T prefab;
    
    public T Get()
    {
        if (pool.Count > 0)
            return pool.Dequeue();
        else
            return GameObject.Instantiate(prefab);
    }
    
    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}

// Extension Methods
public static class TransformExtensions
{
    public static void ResetTransform(this Transform transform)
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
}

// Использование
transform.ResetTransform();

// Async/Await - Загрузка сцены
public async void LoadSceneAsync(string sceneName)
{
    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    
    while (!operation.isDone)
    {
        float progress = operation.progress;
        UpdateLoadingBar(progress);
        await Task.Yield();
    }
}
```

## 💡 Ключевые паттерны

### Event-Driven Architecture
```csharp
// Центральная система событий
public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    
    public event Action<int> OnScoreChanged;
    public event Action<float> OnHealthChanged;
    public event Action OnGameOver;
    
    public void TriggerScoreChange(int newScore)
    {
        OnScoreChanged?.Invoke(newScore);
    }
}
```

### Generic Singleton
```csharp
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }
}

// Использование
public class GameManager : Singleton<GameManager>
{
    // Ваш код
}
```

## ⏱️ Время изучения

Рекомендуемое время: **2 недели**

## 🚀 Следующий шаг

[Модуль 6: Rider для Unity](../Module06_RiderTips/)
