# Module 4: Game Mechanics

## 🎯 Цели модуля

Научиться реализовывать основные игровые системы и механики.

## 📚 Содержание

### 1. Movement and Controls
- Character Controller (3D)
- Rigidbody movement (2D/3D)
- Прыжки и гравитация
- Dash и специальные движения
- Wall jump, double jump

### 2. Система камеры
- Follow camera (следование за игроком)
- Camera bounds (ограничения)
- Camera shake (тряска камеры)
- Zoom и переключение камер
- Cinemachine Basics

### 3. Физика и коллизии
- Colliders и Triggers
- OnCollisionEnter / OnTriggerEnter
- Raycast и Physics queries
- Layers и collision matrix
- Check земли

### 4. Боевая система
- Система здоровья
- Нанесение и получение урона
- Система оружия
- Стрельба (raycast и projectile)
- Перезарядка
- Система брони

### 5. UI и HUD
- Canvas и UI элементы
- Health bars (полоски здоровья)
- Ammo counter (счетчик патронов)
- Меню и паузы
- Система диалогов

### 6. Анимация
- Animator Controller
- Animation States
- Transitions и Parameters
- Blend Trees
- Animation Events

## 🎮 Практические примеры

```csharp
// Движение персонажа
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}

// Система здоровья
public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
}

// Стрельба
public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
    }
}
```

## ⏱️ Time изучения

Рекомендуемое время: **3 недели**

## 🚀 Следующий шаг

[Модуль 5: Продвинутый C#](../Module05_AdvancedCSharp/)

