# Модуль 8: Отладка и Оптимизация

## 🎯 Цели модуля

Научиться находить и исправлять ошибки, оптимизировать производительность игр.

## 📚 Содержание

### 1. Отладка
- Debug.Log и уровни логирования
- Breakpoints в Rider
- Unity Console
- Debug.DrawRay и Gizmos
- Conditional breakpoints

### 2. Профилирование
- Unity Profiler
- CPU Usage
- Memory Profiler
- GPU Usage
- Frame Debugger

### 3. Оптимизация кода
- Object Pooling
- Кэширование компонентов
- Оптимизация Update
- Избегание GetComponent в Update
- String concatenation

### 4. Оптимизация производительности
- Draw Calls
- Batching
- Occlusion Culling
- LOD (Level of Detail)
- Texture compression

### 5. Распространенные ошибки
- NullReferenceException
- MissingReferenceException
- Index out of range
- Бесконечные циклы
- Memory leaks

## 💡 Практические примеры

```csharp
// Object Pooling
public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private Queue<GameObject> pool = new Queue<GameObject>();
    
    public GameObject Get()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return Instantiate(prefab);
    }
    
    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}

// Кэширование компонентов
public class OptimizedScript : MonoBehaviour
{
    private Transform cachedTransform;
    private Rigidbody cachedRigidbody;
    
    void Awake()
    {
        cachedTransform = transform; // Кэшируем
        cachedRigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        // Используем кэшированные компоненты
        cachedTransform.position += Vector3.forward;
    }
}
```

## ⏱️ Время изучения

Рекомендуемое время: **2 недели**

## 🎉 Поздравляем!

Вы завершили полный курс C# для Unity!
