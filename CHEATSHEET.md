# 📝 Шпаргалка C# для Unity

## Базовый синтаксис

### Переменные
```csharp
int health = 100;              // Целое число
float speed = 5.5f;            // Число с плавающей точкой
string playerName = "Hero";    // Текст
bool isAlive = true;           // true или false
```

### Операторы
```csharp
// Арифметические
int sum = 5 + 3;        // 8
int diff = 10 - 4;      // 6
int product = 3 * 4;    // 12
int quotient = 10 / 2;  // 5
int remainder = 10 % 3; // 1

// Сравнение
bool equal = (5 == 5);      // true
bool notEqual = (5 != 3);   // true
bool greater = (10 > 5);    // true
bool less = (3 < 7);        // true

// Логические
bool and = true && false;   // false
bool or = true || false;    // true
bool not = !true;           // false
```

### Условия
```csharp
if (health > 50)
{
    Debug.Log("Здоров");
}
else if (health > 20)
{
    Debug.Log("Ранен");
}
else
{
    Debug.Log("Критично");
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

// Тернарный оператор
string status = health > 50 ? "Здоров" : "Ранен";
```

### Циклы
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

## Коллекции

### Массивы
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

## Методы

```csharp
// Без возврата
void PrintMessage(string message)
{
    Debug.Log(message);
}

// С возвратом
int CalculateDamage(int base, int bonus)
{
    return base + bonus;
}

// Вызов
PrintMessage("Hello");
int damage = CalculateDamage(20, 10);
```

## Классы

```csharp
public class Player
{
    // Поля
    public string name;
    private int health;
    
    // Свойства
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    
    // Конструктор
    public Player(string playerName)
    {
        name = playerName;
        health = 100;
    }
    
    // Методы
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

// Использование
Player player = new Player("Hero");
player.TakeDamage(20);
```

## Unity специфичное

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
        // Фиксированный интервал (физика)
    }
    
    void LateUpdate()
    {
        // После всех Update (камера)
    }
}
```

### GameObject и Components
```csharp
// Получить компонент
Rigidbody rb = GetComponent<Rigidbody>();

// Найти объект
GameObject player = GameObject.Find("Player");
GameObject enemy = GameObject.FindWithTag("Enemy");

// Создать объект
GameObject bullet = Instantiate(bulletPrefab, position, rotation);

// Уничтожить объект
Destroy(gameObject);
Destroy(gameObject, 2f); // Через 2 секунды
```

### Transform
```csharp
// Позиция
transform.position = new Vector3(0, 0, 0);
transform.position += Vector3.forward;

// Поворот
transform.rotation = Quaternion.identity;
transform.Rotate(0, 90, 0);

// Масштаб
transform.localScale = new Vector3(2, 2, 2);

// Родитель
transform.parent = parentTransform;
```

### Input
```csharp
// Клавиши
if (Input.GetKeyDown(KeyCode.Space))
{
    Jump();
}

if (Input.GetKey(KeyCode.W))
{
    MoveForward();
}

// Оси
float horizontal = Input.GetAxis("Horizontal");
float vertical = Input.GetAxis("Vertical");

// Мышь
if (Input.GetMouseButtonDown(0))
{
    Shoot();
}
```

### Coroutines
```csharp
// Определение
IEnumerator SpawnEnemies()
{
    yield return new WaitForSeconds(2f);
    Instantiate(enemyPrefab);
}

// Запуск
StartCoroutine(SpawnEnemies());

// Остановка
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

## Продвинутое

### Events
```csharp
// Определение
public static event Action<int> OnScoreChanged;

// Вызов
OnScoreChanged?.Invoke(newScore);

// Подписка
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

## Полезные атрибуты

```csharp
[SerializeField] private int health;        // Видно в Inspector
[HideInInspector] public int score;         // Скрыто в Inspector
[Range(0, 100)] public int volume;          // Слайдер
[Header("Player Stats")] public int level;  // Заголовок
[Tooltip("Player health")] public int hp;   // Подсказка
[RequireComponent(typeof(Rigidbody))]       // Требует компонент
```

## Debug

```csharp
Debug.Log("Message");                       // Обычное сообщение
Debug.LogWarning("Warning");                // Предупреждение
Debug.LogError("Error");                    // Ошибка

Debug.DrawRay(origin, direction, Color.red, 2f);  // Луч в Scene
Debug.DrawLine(start, end, Color.blue);           // Линия в Scene
```

## Математика

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
float clamp = Mathf.Clamp(value, 0, 100);   // Ограничение
float lerp = Mathf.Lerp(a, b, t);           // Интерполяция
```

## Частые паттерны

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

**Совет:** Держите эту шпаргалку под рукой во время разработки!
