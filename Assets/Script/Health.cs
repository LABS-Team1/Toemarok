using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ISubject
{
    public int maxHealth = 5;
    public int currentHealth;
    public float knockbackForce = 10f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Color hitColor;
    private List<IObserver> observers = new List<IObserver>();
    private ItemDrop itemDrop;

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        itemDrop = GetComponent<ItemDrop>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UIManager.Instance.ShowUIPrefab("BossHP_Bar");
        UIManager.Instance.FindUIComponent<StatBar>("BossHP_Bar").DecreaseStat(currentHealth, maxHealth);

        Debug.Log(gameObject.name + " takes " + damageAmount + " damage. Remaining health: " + currentHealth);

        if (currentHealth <= 0) {
            Die();
            UIManager.Instance.HideUIPrefab("BossHP_Bar");
        }
        else {
            MoveBack();
            StartCoroutine(FlashSprite());
        }

        NotifyObservers();
    }

    private void Die()
    {
        // 적을 죽이거나 플레이어가 죽었을 때 처리할 로직을 작성합니다.
        itemDrop.DropItem();
        Destroy(gameObject);
    }

    private void MoveBack()
    {
        Vector2 knockbackDirection = (transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }

    IEnumerator FlashSprite()
    {
        Color originalColor = GetComponent<SpriteRenderer>().color;
        Color flashColor = new Color(1f, 1f, 1f, 0.5f); // 연하게 표시할 색상
        float flashDuration = 0.1f; // 반복 간격 (0.1초)
        int numberOfFlashes = 5; // 반복 횟수

        for (int i = 0; i < numberOfFlashes; i++) {
            GetComponent<SpriteRenderer>().color = flashColor;
            yield return new WaitForSeconds(flashDuration / 2);
            GetComponent<SpriteRenderer>().color = originalColor;
            yield return new WaitForSeconds(flashDuration / 2);
        }
    }

    public void ResisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.GetNotified();
        }
    }
}
