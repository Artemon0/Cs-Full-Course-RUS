# Модуль 6: Rider для Unity

## 🎯 Цели модуля

Максимально эффективно использовать JetBrains Rider для Unity разработки.

## 📚 Содержание

### 1. Настройка Rider
- Установка и первый запуск
- Including к Unity
- Настройка внешнего редактора в Unity
- Рекомендуемые настройки
- Solution проблем с подключением

### 2. Debugging
- Установка breakpoints
- Step Over, Step Into, Step Out
- Watches и Evaluate Expression
- Conditional breakpoints
- Debugging корутин
- Attach to Unity Process

### 3. Горячие клавиши
```
Навигация:
- Ctrl + N: Search класса
- Ctrl + Shift + N: Search файла
- Ctrl + F12: Structure файла
- Alt + F7: Найти использования
- Ctrl + B: Перейти к определению
- Ctrl + Alt + Left/Right: Навигация назад/вперед

Редактирование:
- Ctrl + Space: Автодополнение
- Ctrl + Shift + Space: Умное автодополнение
- Ctrl + D: Дублировать linesу
- Ctrl + Y: Удалить linesу
- Ctrl + /: Комментарий
- Alt + Enter: Quick Fix

Рефакторинг:
- Ctrl + R, R: Rename
- Ctrl + R, M: Extract Method
- Ctrl + R, V: Extract Variable
- Ctrl + R, I: Inline

Unity специфичные:
- Alt + Insert: Generate Code (Unity методы)
- Ctrl + Shift + A: Find Action
```

### 4. Рефакторинг
- Rename (переименование)
- Extract Method (выделение метода)
- Extract Variable (выделение переменной)
- Change Signature (изменение сигнатуры)
- Move (перемещение кода)
- Safe Delete (безопасное удаление)

### 5. Code Generation
- Unity Event Functions (генерация Unity методов)
- Constructors
- Properties
- Override Methods
- Implement Interface

### 6. Unity Integration
- Unity Explorer (просмотр иерархии)
- Unity Console в Rider
- Unity Asset Usage
- Shader Support
- Unity Code Analysis
- Performance Indicators

### 7. Полезные фичи
- TODO Comments
- Bookmarks (закладки)
- File Structure (Structure файла)
- Code Inspection (анализ кода)
- Code Cleanup (очистка кода)
- Live Templates (шаблоны кода)

## 💡 Практические советы

### Создание Live Template для Unity
```csharp
// Шаблон для Singleton
public class $CLASS$ : MonoBehaviour
{
    public static $CLASS$ Instance { get; private set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
```

### Unity Code Snippets
```
Введите "mono" + Tab -> Создаст MonoBehaviour класс
Введите "coroutine" + Tab -> Создаст корутину
Введите "prop" + Tab -> Создаст свойство
```

### Debugging в Unity
1. Установите breakpoint (F9)
2. Запустите Unity в режиме Play
3. В Rider: Run -> Attach to Unity Process
4. Code остановится на breakpoint
5. Используйте F10 (Step Over), F11 (Step Into)

### Анализ производительности
- Rider показывает "дорогие" операции
- Предупреждения о boxing
- Предупреждения о string concatenation в Update
- Советы по оптимизации

## 🔧 Настройка проекта

### .editorconfig для Unity
```ini
root = true

[*.cs]
indent_style = space
indent_size = 4
end_of_line = crlf
charset = utf-8
trim_trailing_whitespace = true
insert_final_newline = true

# Unity naming conventions
dotnet_naming_rule.unity_serialized_field.severity = warning
dotnet_naming_rule.unity_serialized_field.symbols = unity_serialized_field
dotnet_naming_rule.unity_serialized_field.style = camel_case
```

### Полезные плагины
- Unity Support (встроен)
- .ignore (для .gitignore)
- Rainbow Brackets
- String Manipulation
- Key Promoter X (изучение горячих клавиш)

## 📊 Сравнение с Visual Studio

| Функция | Rider | Visual Studio |
|---------|-------|---------------|
| Скорость | ⚡⚡⚡ | ⚡⚡ |
| Unity интеграция | ⭐⭐⭐ | ⭐⭐ |
| Рефакторинг | ⭐⭐⭐ | ⭐⭐ |
| Кроссплатформенность | ✅ | ❌ (только Windows/Mac) |
| Цена | 💰 Платный | 💰 Community бесплатный |

## ⏱️ Time изучения

Рекомендуемое время: **1 неделя**

## 🚀 Следующий шаг

[Модуль 7: Практические Проекты](../Module07_Projects/)

