# ❓ Frequently Asked Questions (FAQ)

## General Questions

### Do I need programming experience?

No, the course starts from the very basics. If you've never programmed before - start with Module 1.

### How long will it take to learn?

With 10-15 hours of study per week - approximately 4-5 months to complete all modules.

### Do I need a paid version of Rider?

No, you can use Visual Studio Community (free). Rider is recommended but not required. Rider is free for students.

### Which Unity version should I use?

It's recommended to use the latest LTS (Long Term Support) version. At the time of course creation - Unity 2022.3 LTS.

## Technical Questions

### Rider doesn't see the Unity project

**Solution:**

1. File → Settings → Languages & Frameworks → Unity Engine
2. Check the path to Unity
3. Regenerate project files in Unity
4. Restart Rider

### Error "using Unity; not found"

**Solution:**

1. Make sure the script is in the Assets folder
2. Wait for Unity to compile
3. Regenerate project files (Edit → Preferences → External Tools)

### Script doesn't work in Unity

**Check:**

1. Is the script attached to a GameObject?
2. Are there compilation errors in Console?
3. Is the class name the same as the file name?
4. Does the class inherit from MonoBehaviour?

### Breakpoints don't trigger

**Solution:**

1. Make sure Rider is connected to Unity (Attach to Unity Process)
2. Unity must be in Play mode
3. Check that the code is actually being executed

## Learning Questions

### Can I skip modules?

Not recommended. Each module builds on the knowledge of the previous ones. If you have experience, you can quickly skim familiar topics.

### What if I don't understand a topic?

1. Reread the material
2. Run examples and experiment
3. Watch additional videos on YouTube
4. Ask a question on Unity Forum or Discord
5. Return to the topic later

### Do I need to complete all exercises?

Yes! Practice is critical. Without exercises, you won't solidify the material.

### How can I verify if my solution is correct?

Some modules have a Solutions folder with ready-made solutions. But try it yourself first!

## Project Questions

### Which project should I start with?

Start with Flappy Bird Clone (Project 1) - it's the simplest and quickest.

### Where can I get assets (graphics, sounds)?

**Free Resources:**

- [Unity Asset Store](https://assetstore.unity.com/) (has free items)
- [itch.io](https://itch.io/game-assets/free) - free assets
- [OpenGameArt](https://opengameart.org/) - open graphics
- [Freesound](https://freesound.org/) - free sounds

### Can I modify the projects?

Of course! In fact, it's recommended. Add your own ideas and features.

### The project doesn't work, what should I do?

1. Check Console for errors
2. Make sure all Scripts are attached
3. Check component settings
4. Compare with the example solution

## Career Questions

### Достаточно ли этого курса для работы?

Этот курс дает фундамент. Для работы нужно:

- Завершить все проекты
- Создать свои Games
- Изучить дополнительные темы (сетевой код, оптимизация, и т.д.)
- Собрать портфолио

### Что изучать после курса?

**Следующие шаги:**

1. Продвинутые patterns проектирования
2. Multiplayer и Networking
3. Продвинутая оптимизация
4. Shader programming
5. AI и NavMesh
6. Процедурная генерация
7. Мобильная разработка

### Где искать работу?

- Unity Connect
- LinkedIn
- Remote game dev jobs
- Фриланс платформы (Upwork, Freelancer)
- Локальные студии

## Problems с производительностью

### Unity/Rider работает медленно

**Оптимизация:**

1. Закройте ненужные программы
2. Увеличьте RAM (минимум 8GB, рекомендуется 16GB)
3. Используйте SSD
4. Отключите антивирус для папки проекта
5. Уменьшите качество в Unity (Edit → Project Settings → Quality)

### Долгая компиляция скриптов

**Решения:**

1. Разбейте большие Files на маленькие
2. Используйте Assembly Definitions
3. Отключите Auto Refresh (Edit → Preferences)
4. Обновите Unity до последней версии

## Дополнительные вопросы

### Можно ли использовать этот курс для обучения других?

Да, материалы можно использовать в образовательных целях с указанием источника.

### Будут ли обновления курса?

Курс будет обновляться при выходе новых версий Unity и появлении новых best practices.

### Как связаться с автором?

Создайте Issue в репозитории или задайте вопрос в Unity Forum.

### Есть ли сертификат по окончании?

Нет официального сертификата, но вы получите знания и портфолио проектов, что важнее.

---

**Не нашли ответ на свой вопрос?**

Задайте его в:

- [Unity Forum](https://forum.unity.com/)
- [Stack Overflow](https://stackoverflow.com/questions/tagged/unity3d)
- [Discord Unity](https://discord.gg/unity)
