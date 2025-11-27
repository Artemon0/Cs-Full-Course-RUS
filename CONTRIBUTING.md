# 🤝 Contributing to the Project

Thank you for interest in improving the course! Your contribution is welcome.

## How to Help

### 🐛 Report a Bug

Found a bug in code or documentation?

1. Check if an Issue hasn't been created yet
2. Create a new Issue with a description:
   - What doesn't work
   - Expected behavior
   - Steps to reproduce
   - Screenshots (if applicable)

### 💡 Suggest an Improvement

Have an idea on how to improve the course?

1. Create an Issue with the "enhancement" tag
2. Describe your suggestion
3. Explain why it's useful

### 📝 Fix a Bug

1. Fork the repository
2. Create a branch: `git checkout -b fix/error-description`
3. Make your changes
4. Commit: `git commit -m "Fix: fix description"`
5. Push: `git push origin fix/error-description`
6. Create a Pull Request

### ✨ Add New Content

Want to add a new lesson or example?

1. Fork the repository
2. Create a branch: `git checkout -b feature/new-feature`
3. Add content
4. Follow the existing code style
5. Add comments in English
6. Create a Pull Request

## Code Standards

### C# Code

```csharp
// ✅ Correct
public class PlayerController : MonoBehaviour
{
    // Comments in English
    private float speed = 5f;

    void Update()
    {
        // Clear variable names
        float horizontal = Input.GetAxis("Horizontal");
    }
}

// ❌ Wrong
public class pc:MonoBehaviour{
private float s=5f;
void Update(){float h=Input.GetAxis("Horizontal");}}
```

### Comments

- All comments in English
- Explain "why", not "what"
- Add usage examples
- Point out common errors

### Lesson Structure

```csharp
/// <summary>
/// Lesson X: Title
///
/// In this lesson you will learn:
/// - Point 1
/// - Point 2
/// </summary>
public class LessonName
{
    // Code with comments
}

/*
 * ========================================
 * EXERCISES
 * ========================================
 *
 * 1. Exercise 1
 * 2. Exercise 2
 *
 * ========================================
 * ВАЖНЫЕ МОМЕНТЫ
 * ========================================
 *
 * Ключевые концепции
 *
 * ========================================
 * ЧАСТЫЕ Errors
 * ========================================
 *
 * Типичные Problems
 */
```

## Что нужно проекту

### Высокий приоритет

- [ ] Завершить Модуль 2 (ООП)
- [ ] Создать примеры для Модуля 3
- [ ] Добавить решения exercises
- [ ] Проверить код на Errors

### Средний приоритет

- [ ] Создать Unity проекты для Модуля 7
- [ ] Добавить видео-туториалы
- [ ] Создать интерактивные Testы
- [ ] Перевести на английский

### Низкий приоритет

- [ ] Добавить темную тему для документации
- [ ] Создать мобильную версию
- [ ] Добавить систему достижений

## Процесс ревью

1. Создаете Pull Request
2. Автоматические проверки
3. Ревью от мейнтейнеров
4. Внесение правок (если нужно)
5. Мердж в main

## Стиль коммитов

```
Тип: Краткое описание

Подробное описание (опционально)

Fixes #123
```

### Типы коммитов

- `Fix:` - исправление Errors
- `Feature:` - новая функциональность
- `Docs:` - изменения в документации
- `Style:` - форматирование кода
- `Refactor:` - рефакторинг
- `Test:` - добавление Testов
- `Chore:` - обновление зависимостей

### Examples

```
Fix: Исправлена ошибка в примере с циклами

Добавлена Check на null в методе SpawnEnemy

Fixes #42
```

```
Feature: Добавлен урок по LINQ

Создан новый файл 03_LINQ.cs с примерами
использования LINQ в игровой разработке
```

## Code поведения

### Наши стандарты

✅ Будьте уважительны  
✅ Принимайте конструктивную критику  
✅ Фокусируйтесь на том, что лучше для сообщества  
✅ Помогайте новичкам

❌ Не используйте оскорбительный язык  
❌ Не публикуйте личную информацию других  
❌ Не троллите и не провоцируйте

## Вопросы?

Если у вас есть вопросы о процессе вклада:

1. Проверьте [FAQ](FAQ.md)
2. Создайте Issue с вопросом
3. Спросите в Discord сообществе

## Благодарности

Спасибо всем, кто вносит вклад в проект! 🎉

Ваше имя будет добавлено в список контрибьюторов.

---

**Помните:** Даже небольшой вклад важен! Исправление опечатки или улучшение комментария - это тоже помощь проекту.
