using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class BossMonster : MonoBehaviour, IObserver
{
    // phase 1: 이순신, phase 2: 이순신+거북선
    public int phase = 1;

    public bool attacking = false;
    public float attackCooldown;
    public float remainingAttackCooldown;

    public GameObject arrow;
    public Sprite boss2;

    private Health health;
    private SpriteRenderer spriteRenderer;
    private Monster monster;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        monster = GetComponent<Monster>();
        health = GetComponent<Health>();
        health.ResisterObserver(this);
        remainingAttackCooldown = attackCooldown;
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if (attacking == false)
            {
                if (monster && monster.IsTargetDetected() && remainingAttackCooldown <= 0)
                {
                    attacking = true;
                    remainingAttackCooldown = attackCooldown;
                    Attack();
                }

                remainingAttackCooldown = Mathf.Max(remainingAttackCooldown - Time.smoothDeltaTime, 0);
            }
            
            yield return null;
        }
    }

    private void Attack()
    {
        if (phase == 1)
        {
            int pattern = Random.Range(1, 3);
            if (pattern == 1) StartCoroutine(ArrowAttack1Coroutine());
            else if (pattern == 2) StartCoroutine(ArrowAttack2Coroutine());
        }
        else if (phase == 2)
        {
            StartCoroutine(ArrowAttack3Coroutine());
        }
    }

    private IEnumerator ArrowAttack1Coroutine()
    {
        Vector3 direction = monster.GetTarget().transform.position - transform.position;
        SpawnArrow(direction);

        Vector3 leftDirection = Quaternion.AngleAxis(30, Vector3.forward) * direction;
        SpawnArrow(leftDirection);

        Vector3 rightDirection = Quaternion.AngleAxis(-30, Vector3.forward) * direction;
        SpawnArrow(rightDirection);
        
        yield return null;

        attacking = false;
    }

    private IEnumerator ArrowAttack2Coroutine()
    {
        Vector3 direction = monster.GetTarget().transform.position - transform.position;
        SpawnArrow(direction);
        yield return new WaitForSeconds(0.5f);

        direction = monster.GetTarget().transform.position - transform.position;
        SpawnArrow(direction);
        yield return new WaitForSeconds(0.5f);

        direction = monster.GetTarget().transform.position - transform.position;
        SpawnArrow(direction);

        attacking = false;
    }

    private IEnumerator ArrowAttack3Coroutine()
    {
        Vector3 direction = monster.GetTarget().transform.position - transform.position;

        for (int i = 0; i < 8; i++)
        {
            SpawnArrow(Quaternion.AngleAxis(i * 45, Vector3.forward) * direction);
        }
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 8; i++)
        {
            SpawnArrow(Quaternion.AngleAxis(i * 45 + 22.5f, Vector3.forward) * direction);
        }

        attacking = false;
    }

    private void SpawnArrow(Vector3 direction)
    {
        float angle = GetAngle(Vector3.zero, direction);
        GameObject obj = Instantiate(arrow, transform.position, Quaternion.identity);
        obj.transform.GetChild(0).Rotate((new Vector3(0, 0, angle - 90)));
        obj.GetComponent<Arrow>().direction = direction;
        obj.GetComponent<Arrow>().SpawnPosition = transform.position;
    }

    private float GetAngle(Vector3 start, Vector3 end)
    {
        Vector3 vector = end - start;
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    }

    public void GetNotified()
    {
        if (phase == 1 && health.currentHealth <= 5)
        {
            phase = 2;
            health.maxHealth = 20;
            health.currentHealth = 20;
            spriteRenderer.sprite = boss2;
        }
    }
}
