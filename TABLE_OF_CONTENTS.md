# 📑 Содержание курса

## 📄 Documentation

### Начало работы
- [README.md](README.md) - Главная страница курса
- [QUICKSTART.md](QUICKSTART.md) - Быстрый старт (5 минут)
- [GETTING_STARTED.md](GETTING_STARTED.md) - Полное руководство по началу работы
- [PROJECT_OVERVIEW.md](PROJECT_OVERVIEW.md) - Обзор проекта

### Справочные материалы
- [CHEATSHEET.md](CHEATSHEET.md) - Шпаргалка по C# для Unity
- [FAQ.md](FAQ.md) - Часто задаваемые вопросы
- [RESOURCES.md](RESOURCES.md) - Дополнительные ресурсы
- [PROGRESS_CHECKLIST.md](PROGRESS_CHECKLIST.md) - Детальный чек-лист прогресса

### Для контрибьюторов
- [CONTRIBUTING.md](CONTRIBUTING.md) - Как помочь проекту
- [LICENSE.md](LICENSE.md) - Лицензия

---

## 📚 Модуль 1: C# Basics (2-3 недели)

### Lessonи
1. [01_Variables.cs](MyLearn/Module01_CSharpBasics/01_Variables.cs) - Variables и типы данных
   - int, float, string, bool
   - Константы
   - var и автоопределение типа
   - Игровой пример: система здоровья

2. [02_Operators.cs](MyLearn/Module01_CSharpBasics/02_Operators.cs) - Operators
   - Арифметические operators
   - Operators сравнения
   - Логические operators
   - Игровой пример: калькулятор урона

3. [03_Conditionals.cs](MyLearn/Module01_CSharpBasics/03_Conditionals.cs) - Conditional Statements
   - if/else
   - switch/case
   - Тернарный оператор
   - Игровой пример: система диалогов

4. [04_Loops.cs](MyLearn/Module01_CSharpBasics/04_Loops.cs) - Loops
   - for, while, do-while
   - foreach
   - break и continue
   - Игровой пример: система спавна врагов

5. [05_Collections.cs](MyLearn/Module01_CSharpBasics/05_Collections.cs) - Коллекции
   - Arrays
   - List<T>
   - Dictionary<TKey, TValue>
   - Queue и Stack
   - Игровой пример: продвинутый инвентарь

6. [06_Methods.cs](MyLearn/Module01_CSharpBasics/06_Methods.cs) - Methods
   - Создание методов
   - Параметры и возвращаемые значения
   - Перегрузка методов
   - ref и out параметры
   - Игровой пример: боевая система

### Навигация
- [README модуля](MyLearn/Module01_CSharpBasics/README.md)
- [Следующий модуль →](MyLearn/Module02_OOP/README.md)

---

## 📚 Module 2: OOP in C# (3-4 недели) ✅ ГОТОВ

### Lessonи
1. [01_Classes.cs](MyLearn/Module02_OOP/01_Classes.cs) - Classes and Objects ✅
   - Fields и свойства
   - Constructorы
   - Methods класса
   - Статические члены
   - Игровой пример: система персонажей

2. [02_Inheritance.cs](MyLearn/Module02_OOP/02_Inheritance.cs) - Inheritance ✅
   - Базовые и производные classes
   - virtual и override
   - base keyword
   - Polymorphism
   - Игровой пример: иерархия врагов и оружия

3. [03_Interfaces.cs](MyLearn/Module02_OOP/03_Interfaces.cs) - Interfaceы ✅
   - Создание интерфейсов
   - Implementation интерфейсов
   - Абстрактные classes
   - Множественная реализация
   - Игровой пример: IDamageable, IInteractable, ICollectable

4. [04_Patterns.cs](MyLearn/Module02_OOP/04_Patterns.cs) - Паттерны ✅
   - Singleton (GameManager, AudioManager)
   - Factory (EnemyFactory)
   - Observer (EventSystem)
   - Object Pool (BulletPool)
   - Command (CommandManager)
   - Игровой пример: комбинирование паттернов

### Навигация
- [README модуля](MyLearn/Module02_OOP/README.md)
- [← Предыдущий модуль](MyLearn/Module01_CSharpBasics/README.md)
- [Следующий модуль →](MyLearn/Module03_UnityBasics/README.md)

---

## 📚 Модуль 3: Unity Basics (2 недели)

### Темы
- MonoBehaviour Lifecycle
- GameObject и Components
- Prefabs и Instantiate
- Coroutines
- ScriptableObjects
- Input System
- Unity Events

### Навигация
- [← Предыдущий модуль](MyLearn/Module02_OOP/README.md)
- [Следующий модуль →](MyLearn/Module04_GameMechanics/README.md)

---

## 📚 Module 4: Game Mechanics (3 недели)

### Темы
- Movement and Controls
- Система камеры
- Физика и коллизии
- Боевая система
- UI и HUD
- Анимация

### Навигация
- [README модуля](MyLearn/Module04_GameMechanics/README.md)
- [← Предыдущий модуль](MyLearn/Module03_UnityBasics/README.md)
- [Следующий модуль →](MyLearn/Module05_AdvancedCSharp/README.md)

---

## 📚 Модуль 5: Продвинутый C# (2 недели)

### Темы
- Delegates и Events
- Lambda выражения
- LINQ
- Generics
- Extension Methods
- Async/Await

### Навигация
- [README модуля](MyLearn/Module05_AdvancedCSharp/README.md)
- [← Предыдущий модуль](MyLearn/Module04_GameMechanics/README.md)
- [Следующий модуль →](MyLearn/Module06_RiderTips/README.md)

---

## 📚 Модуль 6: Rider для Unity (1 неделя)

### Темы
- Настройка Rider
- Debugging
- Горячие клавиши
- Рефакторинг
- Code Generation
- Unity Integration

### Навигация
- [README модуля](MyLearn/Module06_RiderTips/README.md)
- [← Предыдущий модуль](MyLearn/Module05_AdvancedCSharp/README.md)
- [Следующий модуль →](MyLearn/Module07_Projects/README.md)

---

## 📚 Модуль 7: Практические Проекты (4 недели)

### Проекты

#### Проект 1: Flappy Bird Clone (2D) ⭐
- Движение птицы
- Генерация труб
- Система очков
- Game Over

#### Проект 2: Top-Down Shooter (2D) ⭐⭐
- Движение персонажа
- Стрельба
- AI врагов
- Система волн

#### Проект 3: Platformer (2D) ⭐⭐⭐
- Продвинутое movement
- Wall jump
- Чекпоинты
- Несколько уровней

#### Проект 4: First-Person Shooter (3D) ⭐⭐⭐
- FPS контроллер
- Система оружия
- NavMesh AI
- Звуки и эффекты

#### Проект 5: RPG Combat System (3D) ⭐⭐⭐⭐
- Система характеристик
- Инвентарь
- Боевая система
- Система квестов

### Навигация
- [README модуля](MyLearn/Module07_Projects/README.md)
- [← Предыдущий модуль](MyLearn/Module06_RiderTips/README.md)
- [Следующий модуль →](MyLearn/Module08_Debugging/README.md)

---

## 📚 Модуль 8: Debugging и Оптимизация (2 недели)

### Темы
- Debugging и логирование
- Unity Profiler
- Memory Profiler
- Оптимизация кода
- Object Pooling
- Распространенные Errors

### Навигация
- [README модуля](MyLearn/Module08_Debugging/README.md)
- [← Предыдущий модуль](MyLearn/Module07_Projects/README.md)

---

## 🎯 Рекомендуемый путь обучения

```
Начало
  ↓
📖 QUICKSTART.md (5 минут)
  ↓
📚 Модуль 1: C# Basics (2-3 недели)
  ├─ 01_Variables.cs
  ├─ 02_Operators.cs
  ├─ 03_Conditionals.cs
  ├─ 04_Loops.cs
  ├─ 05_Collections.cs
  └─ 06_Methods.cs
  ↓
📚 Модуль 2: ООП (3-4 недели)
  ├─ 01_Classes.cs
  ├─ 02_Inheritance.cs
  ├─ 03_Interfaces.cs
  └─ 04_Patterns.cs
  ↓
📚 Модуль 3: Unity Basics (2 недели)
  ↓
📚 Module 4: Game Mechanics (3 недели)
  ↓
📚 Модуль 5: Продвинутый C# (2 недели)
  ↓
📚 Модуль 6: Rider (1 неделя)
  ↓
📚 Модуль 7: Проекты (4 недели)
  ├─ Flappy Bird
  ├─ Top-Down Shooter
  ├─ Platformer
  ├─ FPS
  └─ RPG System
  ↓
📚 Модуль 8: Debugging (2 недели)
  ↓
🎉 Завершение курса!
```

---

## 📊 Статистика курса

- **Всего модулей:** 8
- **Всего уроков:** 30+
- **Time обучения:** 4-5 месяцев
- **Часов в неделю:** 10-15
- **Проектов:** 5
- **Упражнений:** 50+

---

## 🔍 Быстрый поиск

### По темам

**Базовый синтаксис:**
- Variables → [01_Variables.cs](MyLearn/Module01_CSharpBasics/01_Variables.cs)
- Operators → [02_Operators.cs](MyLearn/Module01_CSharpBasics/02_Operators.cs)
- Conditions → [03_Conditionals.cs](MyLearn/Module01_CSharpBasics/03_Conditionals.cs)
- Loops → [04_Loops.cs](MyLearn/Module01_CSharpBasics/04_Loops.cs)

**Структуры данных:**
- Коллекции → [05_Collections.cs](MyLearn/Module01_CSharpBasics/05_Collections.cs)
- Methods → [06_Methods.cs](MyLearn/Module01_CSharpBasics/06_Methods.cs)

**ООП:**
- Classes → [01_Classes.cs](MyLearn/Module02_OOP/01_Classes.cs)
- Inheritance → Модуль 2
- Interfaceы → Модуль 2
- Паттерны → Модуль 2

**Unity:**
- Концепции → [Модуль 3](MyLearn/Module03_GameConcepts/README.md)
- Механики → [Модуль 4](MyLearn/Module04_GameMechanics/README.md)
- Проекты → [Модуль 7](MyLearn/Module07_Projects/README.md)

**Продвинутое:**
- Events/LINQ → [Модуль 5](MyLearn/Module05_AdvancedCSharp/README.md)
- Rider → [Модуль 6](MyLearn/Module06_RiderTips/README.md)
- Debugging → [Модуль 8](MyLearn/Module08_Debugging/README.md)

### По игровым системам

- Система здоровья → [01_Variables.cs](MyLearn/Module01_CSharpBasics/01_Variables.cs)
- Калькулятор урона → [02_Operators.cs](MyLearn/Module01_CSharpBasics/02_Operators.cs)
- Система диалогов → [03_Conditionals.cs](MyLearn/Module01_CSharpBasics/03_Conditionals.cs)
- Спавн врагов → [04_Loops.cs](MyLearn/Module01_CSharpBasics/04_Loops.cs)
- Инвентарь → [05_Collections.cs](MyLearn/Module01_CSharpBasics/05_Collections.cs)
- Боевая система → [06_Methods.cs](MyLearn/Module01_CSharpBasics/06_Methods.cs)
- Система персонажей → [01_Classes.cs](MyLearn/Module02_OOP/01_Classes.cs)

---

## 💡 Советы по навигации

1. **Начинающим:** Следуйте порядку модулей
2. **С опытом:** Переходите к интересующим темам
3. **Для справки:** Используйте [CHEATSHEET.md](CHEATSHEET.md)
4. **При проблемах:** Смотрите [FAQ.md](FAQ.md)

---

**Удачи в обучении! 🚀**

