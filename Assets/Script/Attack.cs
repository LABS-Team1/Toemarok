using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider2D;
    public int damageAmount = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭 입력 감지
        {
            Debug.Log("Swing");
            animator.SetTrigger("isAttack"); // isAttack 매개변수를 true로 변경

            // 다른 콜라이더와 접촉했는지 검사
            Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0);
            foreach (Collider2D collider in colliders) {
                if (collider.gameObject.tag != "Player") // 자기 자신과 Trigger 콜라이더는 제외
                {
                    Debug.Log("Collided with " + collider.gameObject.name);
                    Health health = collider.gameObject.GetComponent<Health>();
                    if (health != null) {
                        health.TakeDamage(damageAmount);
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with " + other.gameObject.name);
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null) {
            health.TakeDamage(damageAmount);
        }
    }
}
