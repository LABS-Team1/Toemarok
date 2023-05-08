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
        if (Input.GetMouseButtonDown(0)) // ���콺 ��Ŭ�� �Է� ����
        {
            Debug.Log("Swing");
            animator.SetTrigger("isAttack"); // isAttack �Ű������� true�� ����

            // �ٸ� �ݶ��̴��� �����ߴ��� �˻�
            Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0);
            foreach (Collider2D collider in colliders) {
                if (collider.gameObject.tag != "Player") // �ڱ� �ڽŰ� Trigger �ݶ��̴��� ����
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
