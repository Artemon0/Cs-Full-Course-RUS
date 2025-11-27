# 🚀 Начало работы

## Установка необходимых инструментов

### 1. Unity Hub и Unity Editor

1. Скачайте [Unity Hub](https://unity.com/download)
2. Установите Unity LTS версию (рекомендуется 2022.3 LTS)
3. При установке выберите модули:
   - Visual Studio или Rider (если есть лицензия)
   - Documentation
   - Android Build Support (опционально)
   - WebGL Build Support (опционально)

### 2. JetBrains Rider

1. Скачайте [Rider](https://www.jetbrains.com/rider/)
2. Установите Rider
3. Активируйте лицензию (есть бесплатная версия для студентов)

**Альтернатива:** Visual Studio Community (бесплатно)

### 3. Git (опционально)

Для контроля версий:
- Windows: [Git for Windows](https://git-scm.com/download/win)
- Настройте .gitignore для Unity проектов

## Настройка Unity для работы с Rider

### Шаг 1: Including Rider к Unity

1. Откройте Unity
2. Edit → Preferences → External Tools
3. External Script Editor → выберите Rider
4. Убедитесь, что "Rider" выбран

### Шаг 2: Настройка Rider

1. Откройте Rider
2. File → Settings (Ctrl+Alt+S)
3. Build, Execution, Deployment → Toolset and Build
4. Убедитесь, что Unity обнаружен

### Шаг 3: Первый запуск

1. Создайте новый Unity проект
2. Создайте C# скрипт
3. Двойной клик по скрипту → откроется Rider
4. Rider автоматически настроит проект

## Structure обучения

### Рекомендуемый путь

```
Неделя 1-2:  Модуль 1 - C# Basics
Неделя 3-4:  Модуль 2 - ООП
Неделя 5-6:  Модуль 3 - Unity Basics
Неделя 7-9:  Модуль 4 - Игровые Механики
Неделя 10-11: Модуль 5 - Продвинутый C#
Неделя 12:   Модуль 6 - Rider
Неделя 13-16: Модуль 7 - Проекты
Неделя 17-18: Модуль 8 - Debugging
```

### Ежедневный план

**Будни (2 часа):**
- 1 час: изучение теории и примеров
- 1 час: выполнение exercises

**Выходные (4-6 часов):**
- 2 часа: повторение материала
- 2-4 часа: работа над проектами

## Первые шаги

### День 1: Знакомство с C#

1. Откройте `MyLearn/Module01_CSharpBasics/01_Variables.cs`
2. Прочитайте код и Comments
3. Запустите программу (F5 в Rider)
4. Измените значения переменных
5. Выполните упражнения в конце файла

### День 2-3: Operators и conditions

1. Изучите `02_Operators.cs`
2. Изучите `03_Conditionals.cs`
3. Создайте свой калькулятор урона
4. Реализуйте систему рангов

### День 4-5: Loops и коллекции

1. Изучите `04_Loops.cs`
2. Изучите `05_Collections.cs`
3. Создайте систему инвентаря
4. Реализуйте систему волн врагов

### День 6-7: Methods

1. Изучите `06_Methods.cs`
2. Рефакторите предыдущие упражнения
3. Создайте библиотеку игровых функций

## Полезные ресурсы

### Documentation

- [Unity Documentation](https://docs.unity3d.com/)
- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [Rider Documentation](https://www.jetbrains.com/help/rider/)

### YouTube каналы

- [Brackeys](https://www.youtube.com/c/Brackeys) - Unity туториалы
- [Code Monkey](https://www.youtube.com/c/CodeMonkeyUnity) - Unity и C#
- [Sebastian Lague](https://www.youtube.com/c/SebastianLague) - Advanced Topics

### Сообщества

- [Unity Forum](https://forum.unity.com/)
- [Reddit r/Unity3D](https://www.reddit.com/r/Unity3D/)
- [Discord Unity](https://discord.gg/unity)

### Практика

- [Unity Learn](https://learn.unity.com/) - официальные курсы
- [Catlike Coding](https://catlikecoding.com/) - продвинутые туториалы
- [Game Dev Beginner](https://gamedevbeginner.com/) - для начинающих

## Советы по обучению

### ✅ Делайте

- Пишите код сами, не копируйте
- Экспериментируйте с примерами
- Делайте заметки
- Задавайте вопросы в сообществах
- Создавайте свои мини-проекты
- Повторяйте сложные темы

### ❌ Не делайте

- Не пропускайте упражнения
- Не спешите к следующему модулю
- Не копируйте код без понимания
- Не combatтесь ошибок
- Не сдавайтесь при трудностях

## Solution проблем

### Rider не видит Unity

1. File → Settings → Languages & Frameworks → Unity Engine
2. Убедитесь, что путь к Unity правильный
3. Перезапустите Rider

### Errors компиляции

1. Проверьте синтаксис
2. Убедитесь, что все скобки закрыты
3. Проверьте using директивы
4. Используйте Alt+Enter для Quick Fix

### Unity не открывает Rider

1. Edit → Preferences → External Tools
2. Выберите Rider заново
3. Regenerate project files

## Контакты и поддержка

Если у вас возникли вопросы:
1. Проверьте документацию
2. Поищите в Google/Stack Overflow
3. Спросите в Unity Forum
4. Задайте вопрос в Discord сообществе

---

**Удачи в обучении! Вы на пути к созданию своих игр! 🎮✨**

