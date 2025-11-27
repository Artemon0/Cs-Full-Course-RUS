// Lessons data
const lessons = {
	1: {
		title: 'Variables and Data Types',
		content: `
<h3>📝 Variables and Data Types in C#</h3>

<div class="section">
<strong>Basic Data Types:</strong>
<div class="code">// Integers
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
<strong>Implicit Typing (var):</strong>
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
`,
	},
	2: {
		title: 'Operators',
		content: `
<h3>🔢 Operators in C#</h3>

<div class="section">
<strong>Arithmetic Operators:</strong>
<div class="code">int a = 10, b = 3;
int sum = a + b;        // 13
int diff = a - b;       // 7
int product = a * b;    // 30
int quotient = a / b;   // 3
int remainder = a % b;  // 1</div>
</div>

<div class="section">
<strong>Comparison Operators:</strong>
<div class="code">int health = 50;
bool isLow = health < 30;      // false
bool isFull = health == 100;   // false
bool notZero = health != 0;    // true
bool isHigh = health >= 50;    // true</div>
</div>

<div class="section">
<strong>Logical Operators:</strong>
<div class="code">bool hasKey = true;
bool doorOpen = false;

bool canEnter = hasKey && doorOpen;  // false (AND)
bool canTry = hasKey || doorOpen;    // true (OR)
bool locked = !doorOpen;             // true (NOT)</div>
</div>

<div class="section">
<strong>Increment and Decrement:</strong>
<div class="code">int score = 10;
score++;  // 11 (postfix)
++score;  // 12 (prefix)
score--;  // 11</div>
</div>
`,
	},
	3: {
		title: 'Conditional Statements',
		content: `
<h3>🔀 Conditional Statements</h3>

<div class="section">
<strong>If-Else Statement:</strong>
<div class="code">int health = 75;

if (health > 80) {
    Console.WriteLine("Excellent health!");
} else if (health > 50) {
    Console.WriteLine("Good health");
} else if (health > 20) {
    Console.WriteLine("Low health!");
} else {
    Console.WriteLine("Critical condition!");
}</div>
<div class="result">Result: Good health</div>
</div>

<div class="section">
<strong>Ternary Operator:</strong>
<div class="code">int level = 15;
string rank = level >= 10 ? "Expert" : "Beginner";</div>
<div class="result">Result: Expert</div>
</div>

<div class="section">
<strong>Switch Statement:</strong>
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
`,
	},
	4: {
		title: 'Loops',
		content: `
<h3>🔄 Loops in C#</h3>

<div class="section">
<strong>For Loop:</strong>
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
<strong>While Loop:</strong>
<div class="code">int health = 100;
int damage = 15;

while (health > 0) {
    health -= damage;
    Console.WriteLine($"Health: {health}");
}</div>
<div class="result">
Health: 85
Health: 70
Health: 55
Health: 40
Health: 25
Health: 10
Health: -5
</div>
</div>

<div class="section">
<strong>Foreach Loop:</strong>
<div class="code">string[] items = { "Sword", "Shield", "Potion" };

foreach (string item in items) {
    Console.WriteLine($"Item: {item}");
}</div>
<div class="result">
Item: Sword
Item: Shield
Item: Potion
</div>
</div>

<div class="section">
<strong>Break and Continue Operators:</strong>
<div class="code">for (int i = 1; i <= 10; i++) {
    if (i == 5) continue;  // Skip 5
    if (i == 8) break;     // Stop at 8
    Console.WriteLine(i);
}</div>
<div class="result">1, 2, 3, 4, 6, 7</div>
</div>
`,
	},
	5: {
		title: 'Arrays and Collections',
		content: `
<h3>📦 Arrays and Collections</h3>

<div class="section">
<strong>Arrays:</strong>
<div class="code">// Declaration and initialization
int[] scores = new int[5];
scores[0] = 100;

// Initialization with values
string[] weapons = { "Sword", "Bow", "Staff" };

// Array length
int length = weapons.Length;  // 3</div>
</div>

<div class="section">
<strong>List (dynamic list):</strong>
<div class="code">List&lt;string&gt; inventory = new List&lt;string&gt;();

// Adding elements
inventory.Add("Health Potion");
inventory.Add("Key");
inventory.Add("Map");

// Removing
inventory.Remove("Key");

// Count of elements
int count = inventory.Count;  // 2</div>
</div>

<div class="section">
<strong>Dictionary (dictionary):</strong>
<div class="code">Dictionary&lt;string, int&gt; stats = new Dictionary&lt;string, int&gt;();

stats["Strength"] = 10;
stats["Dexterity"] = 15;
stats["Intelligence"] = 8;

// Getting value
int strength = stats["Strength"];  // 10

// Checking for key existence
bool hasKey = stats.ContainsKey("Strength");  // true</div>
</div>
`,
	},
	6: {
		title: 'Methods',
		content: `
<h3>⚙️ Methods in C#</h3>

<div class="section">
<strong>Method Declaration:</strong>
<div class="code">// Method with no return value
void Greet(string name) {
    Console.WriteLine($"Hello, {name}!");
}

// Method with return value
int Add(int a, int b) {
    return a + b;
}

// Calling methods
Greet("Player");
int result = Add(5, 3);  // 8</div>
</div>

<div class="section">
<strong>Default Parameters:</strong>
<div class="code">void Attack(string target, int damage = 10) {
    Console.WriteLine($"{target} took {damage} damage");
}

Attack("Enemy");        // Damage 10
Attack("Boss", 25);    // Damage 25</div>
</div>

<div class="section">
<strong>Method Overloading:</strong>
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
<strong>Ref and out Parameters:</strong>
<div class="code">void ModifyValue(ref int value) {
    value = value * 2;
}

void GetValues(out int x, out int y) {
    x = 10;
    y = 20;
}</div>
</div>
`,
	},
	7: {
		title: 'Classes and Objects',
		content: `
<h3>🏗️ Classes and Objects</h3>

<div class="section">
<strong>Creating a Class:</strong>
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
        Console.WriteLine($"{Name} recovered {amount} health");
    }
}</div>
</div>

<div class="section">
<strong>Creating Objects:</strong>
<div class="code">Player hero = new Player("Hero", 100);
hero.TakeDamage(20);
hero.Heal(10);

Console.WriteLine($"Health: {hero.Health}");  // 90</div>
</div>

<div class="section">
<strong>Properties:</strong>
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
	},
	8: {
		title: 'Inheritance and Polymorphism',
		content: `
<h3>🔗 Inheritance and Polymorphism</h3>

<div class="section">
<strong>Base Class:</strong>
<div class="code">class Character {
    public string Name;
    public int Health;
    
    public virtual void Attack() {
        Console.WriteLine($"{Name} attacks!");
    }
}</div>
</div>

<div class="section">
<strong>Inheritance:</strong>
<div class="code">class Warrior : Character {
    public int Strength;
    
    public override void Attack() {
        Console.WriteLine($"{Name} delivers a powerful sword strike!");
    }
}

class Mage : Character {
    public int Mana;
    
    public override void Attack() {
        Console.WriteLine($"{Name} casts a fireball!");
    }
}</div>
</div>

<div class="section">
<strong>Polymorphism:</strong>
<div class="code">Character warrior = new Warrior { Name = "Warrior" };
Character mage = new Mage { Name = "Mage" };

warrior.Attack();  // Warrior delivers a powerful sword strike!
mage.Attack();     // Mage casts a fireball!</div>
</div>

<div class="section">
<strong>Base Keyword:</strong>
<div class="code">class Boss : Character {
    public override void Attack() {
        base.Attack();  // Calling base class method
        Console.WriteLine("Boss uses special attack!");
    }
}</div>
</div>
`,
	},
	9: {
		title: 'Interfaces and Abstract Classes',
		content: `
<h3>🎭 Interfaces and Abstract Classes</h3>

<div class="section">
<strong>Interfaces:</strong>
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
}</div>
</div>

<div class="section">
<strong>Abstract Classes:</strong>
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
}</div>
</div>
`,
	},
	10: {
		title: 'Design Patterns',
		content: `
<h3>🎨 Design Patterns</h3>

<div class="section">
<strong>Singleton (Singleton):</strong>
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
GameManager.Instance.StartGame();</div>
</div>

<div class="section">
<strong>Factory (Factory):</strong>
<div class="code">abstract class Enemy {
    public abstract void Attack();
}

class Goblin : Enemy {
    public override void Attack() {
        Console.WriteLine("Goblin attacks!");
    }
}

class Orc : Enemy {
    public override void Attack() {
        Console.WriteLine("Orc attacks!");
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
<strong>Observer (Observer):</strong>
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

healthSystem.Health = 50;  // Will trigger event</div>
</div>
`,
	},
	11: {
		title: 'Game Loop',
		content: `
<h3>🎮 Game Loop</h3>

<div class="section">
<strong>Main Concept:</strong>
<p>A game loop is an infinite loop that updates the game state and renders frames.</p>
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
        Console.WriteLine("Game initialization...");
    }
    
    void Update(float dt) {
        // Update game logic
        // Physics, AI, user input
    }
    
    void Render() {
        // Render frame
    }
    
    void Cleanup() {
        Console.WriteLine("Game shutdown...");
    }
}</div>
</div>

<div class="section">
<strong>Example with Unity:</strong>
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
}</div>
</div>
`,
	},
	12: {
		title: 'Component System',
		content: `
<h3>🧩 Component System</h3>

<div class="section">
<strong>Component Concept:</strong>
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
}</div>
</div>

<div class="section">
<strong>Component Examples:</strong>
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
}</div>
</div>

<div class="section">
<strong>Usage:</strong>
<div class="code">GameObject player = new GameObject { Name = "Player" };
player.AddComponent(new TransformComponent());
player.AddComponent(new HealthComponent());
player.AddComponent(new MovementComponent());

// Getting component
var health = player.GetComponent&lt;HealthComponent&gt;();
health.TakeDamage(20);</div>
</div>
`,
	},
	13: {
		title: 'Event System',
		content: `
<h3>📡 Event System</h3>

<div class="section">
<strong>Events in C#:</strong>
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
}</div>
</div>

<div class="section">
<strong>Subscribing to Events:</strong>
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
player.LevelUp(1, 2);</div>
</div>

<div class="section">
<strong>Game Event System:</strong>
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
    Console.WriteLine("Enemy killed! +100 experience");
});

EventManager.Trigger("EnemyKilled");</div>
</div>
`,
	},
}

// DOM elements
const menu = document.getElementById('menu')
const lessonContent = document.getElementById('lesson-content')
const lessonOutput = document.getElementById('lesson-output')
const backBtn = document.getElementById('back-btn')

// Event listeners
document.querySelectorAll('.lesson-btn').forEach(btn => {
	btn.addEventListener('click', () => {
		const lessonId = parseInt(btn.dataset.lesson)
		showLesson(lessonId)
	})
})

backBtn.addEventListener('click', showMenu)

// Functions
function showLesson(id) {
	const lesson = lessons[id]
	if (!lesson) return

	lessonOutput.innerHTML = lesson.content
	menu.classList.add('hidden')
	lessonContent.classList.remove('hidden')

	// Scroll to top
	window.scrollTo(0, 0)
}

function showMenu() {
	menu.classList.remove('hidden')
	lessonContent.classList.add('hidden')

	// Scroll to top
	window.scrollTo(0, 0)
}

// Initialize
console.log('🎮 C# Learning for Unity loaded!')
