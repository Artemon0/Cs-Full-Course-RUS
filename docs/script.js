// Lessons data
const lessons = {
    1: {
        title: "Переменные и типы данных",
        titleEn: "Variables and Data Types",
        content: `
<h3>📝 Переменные и типы данных в C#</h3>

<div class="section">
<strong>Основные типы данных:</strong>
<div class="code">// Целые числа
int health = 100;
long experience = 1000000L;

// Дробные числа
float speed = 5.5f;
double damage = 15.75;

// Логический тип
bool isAlive = true;

// Символы и строки
char grade = 'A';
string playerName = "Hero";</div>

<div class="result">
<strong>Результат:</strong>
Здоровье: 100
Опыт: 1000000
Скорость: 5.5
Урон: 15.75
Жив: True
Оценка: A
Имя игрока: Hero
</div>
</div>

<div class="section">
<strong>Неявная типизация (var):</strong>
<div class="code">var level = 10;        // int
var name = "Player";   // string
var isActive = true;   // bool</div>
<p>Компилятор автоматически определяет тип переменной.</p>
</div>

<div class="section">
<strong>Константы:</strong>
<div class="code">const int MAX_HEALTH = 100;
const float GRAVITY = 9.81f;</div>
<p>Значения констант нельзя изменить после объявления.</p>
</div>
`,
        contentEn: `
<h3>📝 Variables and Data Types in C#</h3>

<div class="section">
<strong>Basic Data Types:</strong>
<div class="code">// Integer numbers
int health = 100;
long experience = 1000000L;

// Floating point numbers
float speed = 5.5f;
double damage = 15.75;

// Boolean type
bool isAlive = true;

// Characters and strings
char grade = 'A';
string playerName = "Hero";</div>

<div class="result">
<strong>Result:</strong>
Health: 100
Experience: 1000000
Speed: 5.5
Damage: 15.75
Alive: True
Grade: A
Player Name: Hero
</div>
</div>

<div class="section">
<strong>Implicit typing (var):</strong>
<div class="code">var level = 10;        // int
var name = "Player";   // string
var isActive = true;   // bool</div>
<p>The compiler automatically determines the variable type.</p>
</div>

<div class="section">
<strong>Constants:</strong>
<div class="code">const int MAX_HEALTH = 100;
const float GRAVITY = 9.81f;</div>
<p>Constant values cannot be changed after declaration.</p>
</div>
`
    },
    2: {
        title: "Операторы",
        titleEn: "Operators",
        content: `
<h3>🔢 Операторы в C#</h3>

<div class="section">
<strong>Арифметические операторы:</strong>
<div class="code">int a = 10, b = 3;
int sum = a + b;        // 13
int diff = a - b;       // 7
int product = a * b;    // 30
int quotient = a / b;   // 3
int remainder = a % b;  // 1</div>
</div>

<div class="section">
<strong>Операторы сравнения:</strong>
<div class="code">int health = 50;
bool isLow = health < 30;      // false
bool isFull = health == 100;   // false
bool notZero = health != 0;    // true
bool isHigh = health >= 50;    // true</div>
</div>

<div class="section">
<strong>Логические операторы:</strong>
<div class="code">bool hasKey = true;
bool doorOpen = false;

bool canEnter = hasKey && doorOpen;  // false (И)
bool canTry = hasKey || doorOpen;    // true (ИЛИ)
bool locked = !doorOpen;             // true (НЕ)</div>
</div>

<div class="section">
<strong>Инкремент и декремент:</strong>
<div class="code">int score = 10;
score++;  // 11 (постфиксный)
++score;  // 12 (префиксный)
score--;  // 11</div>
</div>
`,
        contentEn: `
<h3>🔢 Operators in C#</h3>

<div class="section">
<strong>Arithmetic operators:</strong>
<div class="code">int a = 10, b = 3;
int sum = a + b;        // 13
int diff = a - b;       // 7
int product = a * b;    // 30
int quotient = a / b;   // 3
int remainder = a % b;  // 1</div>
</div>

<div class="section">
<strong>Comparison operators:</strong>
<div class="code">int health = 50;
bool isLow = health < 30;      // false
bool isFull = health == 100;   // false
bool notZero = health != 0;    // true
bool isHigh = health >= 50;    // true</div>
</div>

<div class="section">
<strong>Logical operators:</strong>
<div class="code">bool hasKey = true;
bool doorOpen = false;

bool canEnter = hasKey && doorOpen;  // false (AND)
bool canTry = hasKey || doorOpen;    // true (OR)
bool locked = !doorOpen;             // true (NOT)</div>
</div>

<div class="section">
<strong>Increment and decrement:</strong>
<div class="code">int score = 10;
score++;  // 11 (postfix)
++score;  // 12 (prefix)
score--;  // 11</div>
</div>
`
    },
    3: {
        title: "Условные конструкции",
        titleEn: "Conditional Statements",
        content: `
<h3>🔀 Условные конструкции</h3>

<div class="section">
<strong>Оператор if-else:</strong>
<div class="code">int health = 75;

if (health > 80) {
    Console.WriteLine("Здоровье отличное!");
} else if (health > 50) {
    Console.WriteLine("Здоровье хорошее");
} else if (health > 20) {
    Console.WriteLine("Здоровье низкое!");
} else {
    Console.WriteLine("Критическое состояние!");
}</div>
<div class="result">Результат: Здоровье хорошее</div>
</div>

<div class="section">
<strong>Тернарный оператор:</strong>
<div class="code">int level = 15;
string rank = level >= 10 ? "Эксперт" : "Новичок";</div>
<div class="result">Результат: Эксперт</div>
</div>

<div class="section">
<strong>Оператор switch:</strong>
<div class="code">string weapon = "sword";

switch (weapon) {
    case "sword":
        Console.WriteLine("Урон: 10");
        break;
    case "bow":
        Console.WriteLine("Урон: 7");
        break;
    case "staff":
        Console.WriteLine("Урон: 12");
        break;
    default:
        Console.WriteLine("Неизвестное оружие");
        break;
}</div>
<div class="result">Результат: Урон: 10</div>
</div>
`,
        contentEn: `
<h3>🔀 Conditional Statements</h3>

<div class="section">
<strong>if-else statement:</strong>
<div class="code">int health = 75;

if (health > 80) {
    Console.WriteLine("Health is excellent!");
} else if (health > 50) {
    Console.WriteLine("Health is good");
} else if (health > 20) {
    Console.WriteLine("Health is low!");
} else {
    Console.WriteLine("Critical condition!");
}</div>
<div class="result">Result: Health is good</div>
</div>

<div class="section">
<strong>Ternary operator:</strong>
<div class="code">int level = 15;
string rank = level >= 10 ? "Expert" : "Novice";</div>
<div class="result">Result: Expert</div>
</div>

<div class="section">
<strong>Switch statement:</strong>
<div class="code">string weapon = "sword";

switch (weapon) {
    case "sword":
        Console.WriteLine("Damage: 10");
        break;
    case "bow":
        Console.WriteLine("Damage: 7");
        break;
    case "staff":
        Console.WriteLine("Damage: 12");
        break;
    default:
        Console.WriteLine("Unknown weapon");
        break;
}</div>
<div class="result">Result: Damage: 10</div>
</div>
`
    },
    4: {
        title: "Циклы",
        titleEn: "Loops",
        content: `
<h3>🔄 Циклы в C#</h3>

<div class="section">
<strong>Цикл for:</strong>
<div class="code">for (int i = 1; i <= 5; i++) {
    Console.WriteLine($"Уровень {i}");
}</div>
<div class="result">
Уровень 1
Уровень 2
Уровень 3
Уровень 4
Уровень 5
</div>
</div>

<div class="section">
<strong>Цикл while:</strong>
<div class="code">int health = 100;
int damage = 15;

while (health > 0) {
    health -= damage;
    Console.WriteLine($"Здоровье: {health}");
}</div>
<div class="result">
Здоровье: 85
Здоровье: 70
Здоровье: 55
Здоровье: 40
Здоровье: 25
Здоровье: 10
Здоровье: -5
</div>
</div>

<div class="section">
<strong>Цикл foreach:</strong>
<div class="code">string[] items = { "Меч", "Щит", "Зелье" };

foreach (string item in items) {
    Console.WriteLine($"Предмет: {item}");
}</div>
<div class="result">
Предмет: Меч
Предмет: Щит
Предмет: Зелье
</div>
</div>

<div class="section">
<strong>Операторы break и continue:</strong>
<div class="code">for (int i = 1; i <= 10; i++) {
    if (i == 5) continue;  // Пропустить 5
    if (i == 8) break;     // Остановиться на 8
    Console.WriteLine(i);
}</div>
<div class="result">1, 2, 3, 4, 6, 7</div>
</div>
`,
        contentEn: `
<h3>🔄 Loops in C#</h3>

<div class="section">
<strong>for loop:</strong>
<div class="code">for (int i = 1; i <= 5; i++) {
    Console.WriteLine($"Level {i}");
}</div>
<div class="result">
Level 1
Level 2
Level 3
Level 4
Level 5
</div>
</div>

<div class="section">
<strong>while loop:</strong>
<div class="code">int health = 100;
int damage = 15;

while (health > 0) {
    health -= damage;
    Console.WriteLine($"Health: {health}");
}</div>
</div>

<div class="section">
<strong>foreach loop:</strong>
<div class="code">string[] items = { "Sword", "Shield", "Potion" };

foreach (string item in items) {
    Console.WriteLine($"Item: {item}");
}</div>
</div>

<div class="section">
<strong>break and continue:</strong>
<div class="code">for (int i = 1; i <= 10; i++) {
    if (i == 5) continue;  // Skip 5
    if (i == 8) break;     // Stop at 8
    Console.WriteLine(i);
}</div>
<div class="result">1, 2, 3, 4, 6, 7</div>
</div>
`
    },
    5: {
        title: "Массивы и коллекции",
        titleEn: "Arrays and Collections",
        content: `
<h3>📦 Массивы и коллекции</h3>

<div class="section">
<strong>Массивы:</strong>
<div class="code">// Объявление и инициализация
int[] scores = new int[5];
scores[0] = 100;

// Инициализация с значениями
string[] weapons = { "Меч", "Лук", "Посох" };

// Длина массива
int length = weapons.Length;  // 3</div>
</div>

<div class="section">
<strong>List (динамический список):</strong>
<div class="code">List&lt;string&gt; inventory = new List&lt;string&gt;();

// Добавление элементов
inventory.Add("Зелье здоровья");
inventory.Add("Ключ");
inventory.Add("Карта");

// Удаление
inventory.Remove("Ключ");

// Количество элементов
int count = inventory.Count;  // 2</div>
</div>

<div class="section">
<strong>Dictionary (словарь):</strong>
<div class="code">Dictionary&lt;string, int&gt; stats = new Dictionary&lt;string, int&gt;();

stats["Сила"] = 10;
stats["Ловкость"] = 15;
stats["Интеллект"] = 8;

// Получение значения
int strength = stats["Сила"];  // 10

// Проверка наличия ключа
bool hasKey = stats.ContainsKey("Сила");  // true</div>
</div>
`,
        contentEn: `
<h3>📦 Arrays and Collections</h3>
<div class="section"><strong>Arrays:</strong>
<div class="code">// Declaration and initialization
int[] scores = new int[5];
scores[0] = 100;

// Initialize with values
string[] weapons = { "Sword", "Bow", "Staff" };

// Array length
int length = weapons.Length;  // 3</div></div>
<div class="section"><strong>List (dynamic list):</strong>
<div class="code">List&lt;string&gt; inventory = new List&lt;string&gt;();

// Adding elements
inventory.Add("Health Potion");
inventory.Add("Key");
inventory.Add("Map");

// Removing
inventory.Remove("Key");

// Count
int count = inventory.Count;  // 2</div></div>
<div class="section"><strong>Dictionary:</strong>
<div class="code">Dictionary&lt;string, int&gt; stats = new Dictionary&lt;string, int&gt;();

stats["Strength"] = 10;
stats["Dexterity"] = 15;
stats["Intelligence"] = 8;

// Get value
int strength = stats["Strength"];  // 10

// Check key
bool hasKey = stats.ContainsKey("Strength");  // true</div></div>
`
    },
    6: {
        title: "Методы",
        titleEn: "Methods",
        content: `
<h3>⚙️ Методы в C#</h3>

<div class="section">
<strong>Объявление метода:</strong>
<div class="code">// Метод без возвращаемого значения
void Greet(string name) {
    Console.WriteLine($"Привет, {name}!");
}

// Метод с возвращаемым значением
int Add(int a, int b) {
    return a + b;
}

// Вызов методов
Greet("Игрок");
int result = Add(5, 3);  // 8</div>
</div>

<div class="section">
<strong>Параметры по умолчанию:</strong>
<div class="code">void Attack(string target, int damage = 10) {
    Console.WriteLine($"{target} получил {damage} урона");
}

Attack("Враг");        // Урон 10
Attack("Босс", 25);    // Урон 25</div>
</div>

<div class="section">
<strong>Перегрузка методов:</strong>
<div class="code">int Calculate(int a, int b) {
    return a + b;
}

double Calculate(double a, double b) {
    return a + b;
}

string Calculate(string a, string b) {
    return a + b;
}</div>
</div>

<div class="section">
<strong>Ref и out параметры:</strong>
<div class="code">void ModifyValue(ref int value) {
    value = value * 2;
}

void GetValues(out int x, out int y) {
    x = 10;
    y = 20;
}</div>
</div>
`,
        contentEn: `
<h3>⚙️ Methods in C#</h3>
<div class="section"><strong>Method declaration:</strong>
<div class="code">// Method without return value
void Greet(string name) {
    Console.WriteLine($"Hello, {name}!");
}

// Method with return value
int Add(int a, int b) {
    return a + b;
}

// Calling methods
Greet("Player");
int result = Add(5, 3);  // 8</div></div>
<div class="section"><strong>Default parameters:</strong>
<div class="code">void Attack(string target, int damage = 10) {
    Console.WriteLine($"{target} took {damage} damage");
}

Attack("Enemy");      // Damage 10
Attack("Boss", 25);   // Damage 25</div></div>
<div class="section"><strong>Method overloading:</strong>
<div class="code">int Calculate(int a, int b) { return a + b; }
double Calculate(double a, double b) { return a + b; }
string Calculate(string a, string b) { return a + b; }</div></div>
`
    },
    7: {
        title: "Классы и объекты",
        titleEn: "Classes and Objects",
        content: `
<h3>🏗️ Классы и объекты</h3>

<div class="section">
<strong>Создание класса:</strong>
<div class="code">class Player {
    // Поля
    public string Name;
    public int Health;
    public int Level;
    
    // Конструктор
    public Player(string name, int health) {
        Name = name;
        Health = health;
        Level = 1;
    }
    
    // Методы
    public void TakeDamage(int damage) {
        Health -= damage;
        Console.WriteLine($"{Name} получил {damage} урона");
    }
    
    public void Heal(int amount) {
        Health += amount;
        Console.WriteLine($"{Name} восстановил {amount} здоровья");
    }
}</div>
</div>

<div class="section">
<strong>Создание объектов:</strong>
<div class="code">Player hero = new Player("Герой", 100);
hero.TakeDamage(20);
hero.Heal(10);

Console.WriteLine($"Здоровье: {hero.Health}");  // 90</div>
</div>

<div class="section">
<strong>Свойства (Properties):</strong>
<div class="code">class Character {
    private int health;
    
    public int Health {
        get { return health; }
        set {
            if (value < 0) health = 0;
            else if (value > 100) health = 100;
            else health = value;
        }
    }
}</div>
</div>
`,
        contentEn: `
<h3>🏗️ Classes and Objects</h3>
<div class="section"><strong>Creating a class:</strong>
<div class="code">class Player {
    // Fields
    public string Name;
    public int Health;
    public int Level;
    
    // Constructor
    public Player(string name, int health) {
        Name = name;
        Health = health;
        Level = 1;
    }
    
    // Methods
    public void TakeDamage(int damage) {
        Health -= damage;
        Console.WriteLine($"{Name} took {damage} damage");
    }
    
    public void Heal(int amount) {
        Health += amount;
        Console.WriteLine($"{Name} restored {amount} health");
    }
}</div></div>
<div class="section"><strong>Creating objects:</strong>
<div class="code">Player hero = new Player("Hero", 100);
hero.TakeDamage(20);
hero.Heal(10);

Console.WriteLine($"Health: {hero.Health}");  // 90</div></div>
<div class="section"><strong>Properties:</strong>
<div class="code">class Character {
    private int health;
    
    public int Health {
        get { return health; }
        set {
            if (value < 0) health = 0;
            else if (value > 100) health = 100;
            else health = value;
        }
    }
}</div></div>
`
    },
    8: {
        title: "Наследование и полиморфизм",
        titleEn: "Inheritance and Polymorphism",
        content: `
<h3>🔗 Наследование и полиморфизм</h3>

<div class="section">
<strong>Базовый класс:</strong>
<div class="code">class Character {
    public string Name;
    public int Health;
    
    public virtual void Attack() {
        Console.WriteLine($"{Name} атакует!");
    }
}</div>
</div>

<div class="section">
<strong>Наследование:</strong>
<div class="code">class Warrior : Character {
    public int Strength;
    
    public override void Attack() {
        Console.WriteLine($"{Name} наносит мощный удар мечом!");
    }
}

class Mage : Character {
    public int Mana;
    
    public override void Attack() {
        Console.WriteLine($"{Name} использует огненный шар!");
    }
}</div>
</div>

<div class="section">
<strong>Полиморфизм:</strong>
<div class="code">Character warrior = new Warrior { Name = "Воин" };
Character mage = new Mage { Name = "Маг" };

warrior.Attack();  // Воин наносит мощный удар мечом!
mage.Attack();     // Маг использует огненный шар!</div>
</div>

<div class="section">
<strong>Ключевое слово base:</strong>
<div class="code">class Boss : Character {
    public override void Attack() {
        base.Attack();  // Вызов метода базового класса
        Console.WriteLine("Босс использует специальную атаку!");
    }
}</div>
</div>
`,
        contentEn: `
<h3>🔗 Inheritance and Polymorphism</h3>
<div class="section"><strong>Base class:</strong>
<div class="code">class Character {
    public string Name;
    public int Health;
    
    public virtual void Attack() {
        Console.WriteLine($"{Name} attacks!");
    }
}</div></div>
<div class="section"><strong>Inheritance:</strong>
<div class="code">class Warrior : Character {
    public int Strength;
    
    public override void Attack() {
        Console.WriteLine($"{Name} strikes with sword!");
    }
}

class Mage : Character {
    public int Mana;
    
    public override void Attack() {
        Console.WriteLine($"{Name} casts fireball!");
    }
}</div></div>
<div class="section"><strong>Polymorphism:</strong>
<div class="code">Character warrior = new Warrior { Name = "Warrior" };
Character mage = new Mage { Name = "Mage" };

warrior.Attack();  // Warrior strikes with sword!
mage.Attack();     // Mage casts fireball!</div></div>
`
    },
    9: {
        title: "Интерфейсы и абстрактные классы",
        titleEn: "Interfaces and Abstract Classes",
        content: `
<h3>🎭 Интерфейсы и абстрактные классы</h3>

<div class="section">
<strong>Интерфейсы:</strong>
<div class="code">interface IDamageable {
    void TakeDamage(int damage);
    int Health { get; set; }
}

interface IMovable {
    void Move(float x, float y);
    float Speed { get; }
}

class Enemy : IDamageable, IMovable {
    public int Health { get; set; }
    public float Speed { get; private set; }
    
    public void TakeDamage(int damage) {
        Health -= damage;
    }
    
    public void Move(float x, float y) {
        // Логика движения
    }
}</div>
</div>

<div class="section">
<strong>Абстрактные классы:</strong>
<div class="code">abstract class Weapon {
    public string Name;
    public int Damage;
    
    // Абстрактный метод
    public abstract void Use();
    
    // Обычный метод
    public void Display() {
        Console.WriteLine($"{Name}: {Damage} урона");
    }
}

class Sword : Weapon {
    public override void Use() {
        Console.WriteLine("Удар мечом!");
    }
}

class Bow : Weapon {
    public override void Use() {
        Console.WriteLine("Выстрел из лука!");
    }
}</div>
</div>
`,
        contentEn: `
<h3>🎭 Interfaces and Abstract Classes</h3>
<div class="section"><strong>Interfaces:</strong>
<div class="code">interface IDamageable {
    void TakeDamage(int damage);
    int Health { get; set; }
}

interface IMovable {
    void Move(float x, float y);
    float Speed { get; }
}

class Enemy : IDamageable, IMovable {
    public int Health { get; set; }
    public float Speed { get; private set; }
    
    public void TakeDamage(int damage) {
        Health -= damage;
    }
    
    public void Move(float x, float y) {
        // Movement logic
    }
}</div></div>
<div class="section"><strong>Abstract classes:</strong>
<div class="code">abstract class Weapon {
    public string Name;
    public int Damage;
    
    // Abstract method
    public abstract void Use();
    
    // Regular method
    public void Display() {
        Console.WriteLine($"{Name}: {Damage} damage");
    }
}

class Sword : Weapon {
    public override void Use() {
        Console.WriteLine("Sword strike!");
    }
}

class Bow : Weapon {
    public override void Use() {
        Console.WriteLine("Bow shot!");
    }
}</div></div>
`
    },
    10: {
        title: "Паттерны проектирования",
        titleEn: "Design Patterns",
        content: `
<h3>🎨 Паттерны проектирования</h3>

<div class="section">
<strong>Singleton (Одиночка):</strong>
<div class="code">class GameManager {
    private static GameManager instance;
    
    public static GameManager Instance {
        get {
            if (instance == null) {
                instance = new GameManager();
            }
            return instance;
        }
    }
    
    private GameManager() { }
    
    public void StartGame() {
        Console.WriteLine("Игра началась!");
    }
}

// Использование
GameManager.Instance.StartGame();</div>
</div>

<div class="section">
<strong>Factory (Фабрика):</strong>
<div class="code">abstract class Enemy {
    public abstract void Attack();
}

class Goblin : Enemy {
    public override void Attack() {
        Console.WriteLine("Гоблин атакует!");
    }
}

class Orc : Enemy {
    public override void Attack() {
        Console.WriteLine("Орк атакует!");
    }
}

class EnemyFactory {
    public static Enemy CreateEnemy(string type) {
        switch (type) {
            case "goblin": return new Goblin();
            case "orc": return new Orc();
            default: return null;
        }
    }
}</div>
</div>

<div class="section">
<strong>Observer (Наблюдатель):</strong>
<div class="code">class HealthSystem {
    private int health;
    public event Action&lt;int&gt; OnHealthChanged;
    
    public int Health {
        get { return health; }
        set {
            health = value;
            OnHealthChanged?.Invoke(health);
        }
    }
}

// Использование
HealthSystem healthSystem = new HealthSystem();
healthSystem.OnHealthChanged += (newHealth) => {
    Console.WriteLine($"Здоровье изменилось: {newHealth}");
};

healthSystem.Health = 50;  // Вызовет событие</div>
</div>
`,
        contentEn: `
<h3>🎨 Design Patterns</h3>
<div class="section"><strong>Singleton:</strong>
<div class="code">class GameManager {
    private static GameManager instance;
    
    public static GameManager Instance {
        get {
            if (instance == null) {
                instance = new GameManager();
            }
            return instance;
        }
    }
    
    private GameManager() { }
    
    public void StartGame() {
        Console.WriteLine("Game started!");
    }
}

// Usage
GameManager.Instance.StartGame();</div></div>
<div class="section"><strong>Factory:</strong>
<div class="code">abstract class Enemy {
    public abstract void Attack();
}

class Goblin : Enemy {
    public override void Attack() {
        Console.WriteLine("Goblin attacks!");
    }
}

class EnemyFactory {
    public static Enemy CreateEnemy(string type) {
        switch (type) {
            case "goblin": return new Goblin();
            default: return null;
        }
    }
}</div></div>
<div class="section"><strong>Observer:</strong>
<div class="code">class HealthSystem {
    private int health;
    public event Action&lt;int&gt; OnHealthChanged;
    
    public int Health {
        get { return health; }
        set {
            health = value;
            OnHealthChanged?.Invoke(health);
        }
    }
}

// Usage
HealthSystem healthSystem = new HealthSystem();
healthSystem.OnHealthChanged += (newHealth) => {
    Console.WriteLine($"Health changed: {newHealth}");
};

healthSystem.Health = 50;  // Triggers event</div></div>
`
    },
    11: {
        title: "Игровой цикл (Game Loop)",
        titleEn: "Game Loop",
        content: `
<h3>🎮 Игровой цикл (Game Loop)</h3>

<div class="section">
<strong>Основная концепция:</strong>
<p>Игровой цикл - это бесконечный цикл, который обновляет состояние игры и отрисовывает кадры.</p>
<div class="code">class GameLoop {
    private bool isRunning = true;
    private float deltaTime = 0.016f;  // ~60 FPS
    
    public void Run() {
        Initialize();
        
        while (isRunning) {
            Update(deltaTime);
            Render();
        }
        
        Cleanup();
    }
    
    void Initialize() {
        Console.WriteLine("Инициализация игры...");
    }
    
    void Update(float dt) {
        // Обновление логики игры
        // Физика, AI, ввод пользователя
    }
    
    void Render() {
        // Отрисовка кадра
    }
    
    void Cleanup() {
        Console.WriteLine("Завершение игры...");
    }
}</div>
</div>

<div class="section">
<strong>Пример с Unity:</strong>
<div class="code">// В Unity используются встроенные методы
void Start() {
    // Вызывается один раз при запуске
}

void Update() {
    // Вызывается каждый кадр
    float dt = Time.deltaTime;
}

void FixedUpdate() {
    // Вызывается с фиксированным интервалом
    // Используется для физики
}

void LateUpdate() {
    // Вызывается после всех Update
    // Используется для камеры
}</div>
</div>
`,
        contentEn: `
<h3>🎮 Game Loop</h3>
<div class="section"><strong>Main concept:</strong>
<p>The game loop is an infinite loop that updates game state and renders frames.</p>
<div class="code">class GameLoop {
    private bool isRunning = true;
    private float deltaTime = 0.016f;  // ~60 FPS
    
    public void Run() {
        Initialize();
        
        while (isRunning) {
            Update(deltaTime);
            Render();
        }
        
        Cleanup();
    }
    
    void Initialize() {
        Console.WriteLine("Initializing game...");
    }
    
    void Update(float dt) {
        // Update game logic
        // Physics, AI, user input
    }
    
    void Render() {
        // Draw frame
    }
    
    void Cleanup() {
        Console.WriteLine("Shutting down...");
    }
}</div></div>
<div class="section"><strong>Unity example:</strong>
<div class="code">// Unity uses built-in methods
void Start() {
    // Called once at startup
}

void Update() {
    // Called every frame
    float dt = Time.deltaTime;
}

void FixedUpdate() {
    // Called at fixed intervals
    // Used for physics
}

void LateUpdate() {
    // Called after all Updates
    // Used for camera
}</div></div>
`
    },
    12: {
        title: "Компонентная система",
        titleEn: "Component System",
        content: `
<h3>🧩 Компонентная система</h3>

<div class="section">
<strong>Концепция компонентов:</strong>
<p>Компонентная архитектура позволяет создавать гибкие и переиспользуемые игровые объекты.</p>
<div class="code">// Базовый компонент
abstract class Component {
    public GameObject Owner;
    
    public virtual void Update(float deltaTime) { }
    public virtual void Render() { }
}

// Игровой объект
class GameObject {
    public string Name;
    private List&lt;Component&gt; components = new List&lt;Component&gt;();
    
    public void AddComponent(Component component) {
        component.Owner = this;
        components.Add(component);
    }
    
    public T GetComponent&lt;T&gt;() where T : Component {
        foreach (var comp in components) {
            if (comp is T) return comp as T;
        }
        return null;
    }
    
    public void Update(float deltaTime) {
        foreach (var comp in components) {
            comp.Update(deltaTime);
        }
    }
}</div>
</div>

<div class="section">
<strong>Примеры компонентов:</strong>
<div class="code">class TransformComponent : Component {
    public float X, Y;
    public float Rotation;
}

class HealthComponent : Component {
    public int MaxHealth = 100;
    public int CurrentHealth;
    
    public void TakeDamage(int damage) {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) {
            Console.WriteLine($"{Owner.Name} уничтожен!");
        }
    }
}

class MovementComponent : Component {
    public float Speed = 5.0f;
    
    public override void Update(float deltaTime) {
        var transform = Owner.GetComponent&lt;TransformComponent&gt;();
        // Логика движения
    }
}</div>
</div>

<div class="section">
<strong>Использование:</strong>
<div class="code">GameObject player = new GameObject { Name = "Player" };
player.AddComponent(new TransformComponent());
player.AddComponent(new HealthComponent());
player.AddComponent(new MovementComponent());

// Получение компонента
var health = player.GetComponent&lt;HealthComponent&gt;();
health.TakeDamage(20);</div>
</div>
`,
        contentEn: `
<h3>🧩 Component System</h3>
<div class="section"><strong>Component concept:</strong>
<p>Component architecture allows creating flexible and reusable game objects.</p>
<div class="code">// Base component
abstract class Component {
    public GameObject Owner;
    
    public virtual void Update(float deltaTime) { }
    public virtual void Render() { }
}

// Game object
class GameObject {
    public string Name;
    private List&lt;Component&gt; components = new List&lt;Component&gt;();
    
    public void AddComponent(Component component) {
        component.Owner = this;
        components.Add(component);
    }
    
    public T GetComponent&lt;T&gt;() where T : Component {
        foreach (var comp in components) {
            if (comp is T) return comp as T;
        }
        return null;
    }
    
    public void Update(float deltaTime) {
        foreach (var comp in components) {
            comp.Update(deltaTime);
        }
    }
}</div></div>
<div class="section"><strong>Component examples:</strong>
<div class="code">class TransformComponent : Component {
    public float X, Y;
    public float Rotation;
}

class HealthComponent : Component {
    public int MaxHealth = 100;
    public int CurrentHealth;
    
    public void TakeDamage(int damage) {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) {
            Console.WriteLine($"{Owner.Name} destroyed!");
        }
    }
}

class MovementComponent : Component {
    public float Speed = 5.0f;
    
    public override void Update(float deltaTime) {
        var transform = Owner.GetComponent&lt;TransformComponent&gt;();
        // Movement logic
    }
}</div></div>
<div class="section"><strong>Usage:</strong>
<div class="code">GameObject player = new GameObject { Name = "Player" };
player.AddComponent(new TransformComponent());
player.AddComponent(new HealthComponent());
player.AddComponent(new MovementComponent());

// Get component
var health = player.GetComponent&lt;HealthComponent&gt;();
health.TakeDamage(20);</div></div>
`
    },
    13: {
        title: "Система событий",
        titleEn: "Event System",
        content: `
<h3>📡 Система событий</h3>

<div class="section">
<strong>События в C#:</strong>
<div class="code">// Определение события
class Player {
    public event Action OnDeath;
    public event Action&lt;int&gt; OnHealthChanged;
    public event Action&lt;int, int&gt; OnLevelUp;
    
    private int health = 100;
    
    public void TakeDamage(int damage) {
        health -= damage;
        OnHealthChanged?.Invoke(health);
        
        if (health <= 0) {
            OnDeath?.Invoke();
        }
    }
    
    public void LevelUp(int oldLevel, int newLevel) {
        OnLevelUp?.Invoke(oldLevel, newLevel);
    }
}</div>
</div>

<div class="section">
<strong>Подписка на события:</strong>
<div class="code">Player player = new Player();

// Подписка на события
player.OnHealthChanged += (newHealth) => {
    Console.WriteLine($"Здоровье: {newHealth}");
};

player.OnDeath += () => {
    Console.WriteLine("Игрок погиб!");
};

player.OnLevelUp += (oldLvl, newLvl) => {
    Console.WriteLine($"Уровень повышен: {oldLvl} → {newLvl}");
};

// Вызов событий
player.TakeDamage(30);
player.LevelUp(1, 2);</div>
</div>

<div class="section">
<strong>Система событий для игры:</strong>
<div class="code">class EventManager {
    private static Dictionary&lt;string, Action&lt;object&gt;&gt; events 
        = new Dictionary&lt;string, Action&lt;object&gt;&gt;();
    
    public static void Subscribe(string eventName, Action&lt;object&gt; listener) {
        if (!events.ContainsKey(eventName)) {
            events[eventName] = null;
        }
        events[eventName] += listener;
    }
    
    public static void Unsubscribe(string eventName, Action&lt;object&gt; listener) {
        if (events.ContainsKey(eventName)) {
            events[eventName] -= listener;
        }
    }
    
    public static void Trigger(string eventName, object data = null) {
        if (events.ContainsKey(eventName)) {
            events[eventName]?.Invoke(data);
        }
    }
}

// Использование
EventManager.Subscribe("EnemyKilled", (data) => {
    Console.WriteLine("Враг убит! +100 опыта");
});

EventManager.Trigger("EnemyKilled");</div>
</div>
`,
        contentEn: `
<h3>📡 Event System</h3>
<div class="section"><strong>Events in C#:</strong>
<div class="code">// Event definition
class Player {
    public event Action OnDeath;
    public event Action&lt;int&gt; OnHealthChanged;
    public event Action&lt;int, int&gt; OnLevelUp;
    
    private int health = 100;
    
    public void TakeDamage(int damage) {
        health -= damage;
        OnHealthChanged?.Invoke(health);
        
        if (health <= 0) {
            OnDeath?.Invoke();
        }
    }
    
    public void LevelUp(int oldLevel, int newLevel) {
        OnLevelUp?.Invoke(oldLevel, newLevel);
    }
}</div></div>
<div class="section"><strong>Event subscription:</strong>
<div class="code">Player player = new Player();

// Subscribe to events
player.OnHealthChanged += (newHealth) => {
    Console.WriteLine($"Health: {newHealth}");
};

player.OnDeath += () => {
    Console.WriteLine("Player died!");
};

player.OnLevelUp += (oldLvl, newLvl) => {
    Console.WriteLine($"Level up: {oldLvl} → {newLvl}");
};

// Trigger events
player.TakeDamage(30);
player.LevelUp(1, 2);</div></div>
<div class="section"><strong>Event system for games:</strong>
<div class="code">class EventManager {
    private static Dictionary&lt;string, Action&lt;object&gt;&gt; events 
        = new Dictionary&lt;string, Action&lt;object&gt;&gt;();
    
    public static void Subscribe(string eventName, Action&lt;object&gt; listener) {
        if (!events.ContainsKey(eventName)) {
            events[eventName] = null;
        }
        events[eventName] += listener;
    }
    
    public static void Unsubscribe(string eventName, Action&lt;object&gt; listener) {
        if (events.ContainsKey(eventName)) {
            events[eventName] -= listener;
        }
    }
    
    public static void Trigger(string eventName, object data = null) {
        if (events.ContainsKey(eventName)) {
            events[eventName]?.Invoke(data);
        }
    }
}

// Usage
EventManager.Subscribe("EnemyKilled", (data) => {
    Console.WriteLine("Enemy killed! +100 XP");
});

EventManager.Trigger("EnemyKilled");</div></div>
`
    }
};

// DOM elements
const menu = document.getElementById('menu');
const lessonContent = document.getElementById('lesson-content');
const lessonOutput = document.getElementById('lesson-output');
const backBtn = document.getElementById('back-btn');

// Event listeners
document.querySelectorAll('.lesson-btn').forEach(btn => {
    btn.addEventListener('click', () => {
        const lessonId = parseInt(btn.dataset.lesson);
        showLesson(lessonId);
    });
});

backBtn.addEventListener('click', showMenu);

// Functions
function showLesson(id) {
    const lesson = lessons[id];
    if (!lesson) return;

    const content = currentLang === 'ru' ? lesson.content : (lesson.contentEn || lesson.content);
    lessonOutput.innerHTML = content;
    lessonOutput.dataset.currentLesson = id;
    menu.classList.add('hidden');
    lessonContent.classList.remove('hidden');

    // Scroll to top
    window.scrollTo(0, 0);
}

function showMenu() {
    menu.classList.remove('hidden');
    lessonContent.classList.add('hidden');

    // Scroll to top
    window.scrollTo(0, 0);
}

// Language system
let currentLang = 'ru';

const translations = {
    title: {
        ru: '🎮 ОБУЧЕНИЕ C# ДЛЯ UNITY 🎮',
        en: '🎮 C# LEARNING FOR UNITY 🎮'
    }
};

const langBtn = document.getElementById('lang-btn');
const mainTitle = document.getElementById('main-title');

langBtn.addEventListener('click', toggleLanguage);

function toggleLanguage() {
    currentLang = currentLang === 'ru' ? 'en' : 'ru';
    langBtn.textContent = currentLang === 'ru' ? 'EN' : 'RU';
    updateLanguage();
}

function updateLanguage() {
    // Update title
    mainTitle.textContent = translations.title[currentLang];

    // Update all elements with data-ru and data-en attributes
    document.querySelectorAll('[data-ru][data-en]').forEach(element => {
        const text = currentLang === 'ru' ? element.dataset.ru : element.dataset.en;
        if (element.tagName === 'BUTTON' || element.tagName === 'H2' || element.tagName === 'P') {
            element.textContent = text;
        }
    });

    // Update lesson content if visible
    if (!lessonContent.classList.contains('hidden')) {
        const currentLessonId = parseInt(lessonOutput.dataset.currentLesson);
        if (currentLessonId) {
            showLesson(currentLessonId);
        }
    }
}

// Initialize
console.log('🎮 Обучение C# для Unity загружено!');
