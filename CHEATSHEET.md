# 📝 C# Cheatsheet for Unity

## Basic Syntax

### Variables

```csharp
int health = 100;              // Integer
float speed = 5.5f;            // Floating point number
string playerName = "Hero";    // Text
bool isAlive = true;           // true or false
```

### Operators

```csharp
// Arithmetic
int sum = 5 + 3;        // 8
int diff = 10 - 4;      // 6
int product = 3 * 4;    // 12
int quotient = 10 / 2;  // 5
int remainder = 10 % 3; // 1

// Comparison
bool equal = (5 == 5);      // true
bool notEqual = (5 != 3);   // true
bool greater = (10 > 5);    // true
bool less = (3 < 7);        // true

// Logical
bool and = true && false;   // false
bool or = true || false;    // true
bool not = !true;           // false
```

### Conditions

```csharp
if (health > 50)
{
    Debug.Log("Healthy");
}
else if (health > 20)
{
    Debug.Log("Wounded");
}
else
{
    Debug.Log("Critical");
}

// Switch
switch (weaponType)
{
    case "Sword":
        damage = 50;
        break;
    case "Bow":
        damage = 30;
        break;
    default:
        damage = 10;
        break;
}

// Ternary operator
string status = health > 50 ? "Healthy" : "Wounded";
```

### Loops

```csharp
// For
for (int i = 0; i < 10; i++)
{
    Debug.Log(i);
}

// While
while (health > 0)
{
    health -= 10;
}

// Foreach
foreach (string item in inventory)
{
    Debug.Log(item);
}
```

## Collections

### Arrays

```csharp
int[] scores = new int[5];
scores[0] = 100;

string[] weapons = { "Sword", "Bow", "Staff" };
```

### List

```csharp
List<string> inventory = new List<string>();
inventory.Add("Potion");
inventory.Remove("Potion");
int count = inventory.Count;
```

### Dictionary

```csharp
Dictionary<string, int> stats = new Dictionary<string, int>();
stats.Add("Health", 100);
stats["Health"] = 80;
int health = stats["Health"];
```

## Methods

```csharp
// Without return
void PrintMessage(string message)
{
    Debug.Log(message);
}

// With return
int CalculateDamage(int base, int bonus)
{
    return base + bonus;
}

// Calling
PrintMessage("Hello");
int damage = CalculateDamage(20, 10);
```

## Classes

````csharp
public class Player
{
    // Fields
    public string name;
    private int health;

    // Properties
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    // Constructor
    public Player(string playerName)
    {
        name = playerName;
        health = 100;
    }

    // Methods
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

// Usage
Player player = new Player("Hero");
player.TakeDamage(20);
```## Unity специфичное

### MonoBehaviour

```csharp
public class PlayerController : MonoBehaviour
{
    void Awake()
    {
        // Инициализация (вызывается первым)
    }

    void Start()
    {
        // Старт (после Awake)
    }

    void Update()
    {
        // Каждый кадр
    }

    void FixedUpdate()
    {
        // Фиксированный интервал (physics)
    }

    void LateUpdate()
    {
        // После всех Update (camera)
    }
}
````

### GameObject and Components

```csharp
// Get component
Rigidbody rb = GetComponent<Rigidbody>();

// Find object
GameObject player = GameObject.Find("Player");
GameObject enemy = GameObject.FindWithTag("Enemy");

// Create object
GameObject bullet = Instantiate(bulletPrefab, position, rotation);

// Destroy object
Destroy(gameObject);
Destroy(gameObject, 2f); // After 2 seconds
```

### Transform

```csharp
// Position
transform.position = new Vector3(0, 0, 0);
transform.position += Vector3.forward;

// Rotation
transform.rotation = Quaternion.identity;
transform.Rotate(0, 90, 0);

// Scale
transform.localScale = new Vector3(2, 2, 2);

// Parent
transform.parent = parentTransform;
```

### Input

```csharp
// Keys
if (Input.GetKeyDown(KeyCode.Space))
{
    Jump();
}

if (Input.GetKey(KeyCode.W))
{
    MoveForward();
}

// Axes
float horizontal = Input.GetAxis("Horizontal");
float vertical = Input.GetAxis("Vertical");

// Mouse
if (Input.GetMouseButtonDown(0))
{
    Shoot();
}
```

### Coroutines

```csharp
// Definition
IEnumerator SpawnEnemies()
{
    yield return new WaitForSeconds(2f);
    Instantiate(enemyPrefab);
}

// Start
StartCoroutine(SpawnEnemies());

// Stop
StopCoroutine(SpawnEnemies());
StopAllCoroutines();
```

### Collisions

```csharp
// Collision
void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "Enemy")
    {
        TakeDamage(10);
    }
}

// Trigger
void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Coin"))
    {
        CollectCoin();
    }
}
```

### Physics

```csharp
// Raycast
if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10f))
{
    Debug.Log("Hit: " + hit.collider.name);
}

// Rigidbody
Rigidbody rb = GetComponent<Rigidbody>();
rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
rb.velocity = new Vector3(moveX, rb.velocity.y, moveZ);
```

### UI

```csharp
using UnityEngine.UI;

// Text
Text scoreText = GetComponent<Text>();
scoreText.text = "Score: " + score;

// Button
Button button = GetComponent<Button>();
button.onClick.AddListener(OnButtonClick);

// Image
Image healthBar = GetComponent<Image>();
healthBar.fillAmount = health / maxHealth;
```

## Advanced

### Events

```csharp
// Definition
public static event Action<int> OnScoreChanged;

// Invoke
OnScoreChanged?.Invoke(newScore);

// Subscribe
void OnEnable()
{
    OnScoreChanged += UpdateScore;
}

void OnDisable()
{
    OnScoreChanged -= UpdateScore;
}
```

### LINQ

```csharp
using System.Linq;

// Where
var weakEnemies = enemies.Where(e => e.health < 50).ToList();

// OrderBy
var sorted = enemies.OrderBy(e => e.health).ToList();

// First
Enemy closest = enemies.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).FirstOrDefault();
```

### ScriptableObject

```csharp
[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int damage;
    public float fireRate;
}
```

## Useful Attributes

```csharp
[SerializeField] private int health;        // Visible in Inspector
[HideInInspector] public int score;         // Hidden in Inspector
[Range(0, 100)] public int volume;          // Slider
[Header("Player Stats")] public int level;  // Header
[Tooltip("Player health")] public int hp;   // Tooltip
[RequireComponent(typeof(Rigidbody))]       // Requires component
```

## Debug

```csharp
Debug.Log("Message");                       // Normal message
Debug.LogWarning("Warning");                // Warning
Debug.LogError("Error");                    // Error

Debug.DrawRay(origin, direction, Color.red, 2f);  // Ray in Scene
Debug.DrawLine(start, end, Color.blue);           // Line in Scene
```

## Math

```csharp
// Vector3
Vector3 pos = new Vector3(0, 0, 0);
Vector3 forward = Vector3.forward;          // (0, 0, 1)
Vector3 up = Vector3.up;                    // (0, 1, 0)
float distance = Vector3.Distance(a, b);
Vector3 direction = (target - transform.position).normalized;

// Mathf
int max = Mathf.Max(5, 10);                 // 10
int min = Mathf.Min(5, 10);                 // 5
float clamp = Mathf.Clamp(value, 0, 100);   // Clamp value
float lerp = Mathf.Lerp(a, b, t);           // Interpolation
```

## Common Patterns

### Singleton

```csharp
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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

### Object Pool

```csharp
Queue<GameObject> pool = new Queue<GameObject>();

GameObject Get()
{
    if (pool.Count > 0)
    {
        GameObject obj = pool.Dequeue();
        obj.SetActive(true);
        return obj;
    }
    return Instantiate(prefab);
}

void Return(GameObject obj)
{
    obj.SetActive(false);
    pool.Enqueue(obj);
}
```

---

**Tip:** Keep this cheatsheet handy during development!
