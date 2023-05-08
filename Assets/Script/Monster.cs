using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float detectionRadius; // ���� ������
    public GameObject player; // �÷��̾� ���̾�
    public float moveSpeed = 1.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // �÷��̾�� ������ �Ÿ� ���
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= detectionRadius) // �÷��̾ �� �ȿ� ���� ��
        {

            Flip();// player �� ���ͺ��� ���ʿ� ������ flipt

            // �÷��̾ ����
            transform.position = Vector3.MoveTowards
                (transform.position, player.transform.position, moveSpeed * Time.deltaTime);

            animator.SetBool("TrackingPlayer", true);
        }
        else // �÷��̾ �� �ۿ� ���� ��
        {
            animator.SetBool("TrackingPlayer", false);
        }
    }

    private void OnDrawGizmos()
    {
        // ���� ������ ������ ���� �׷��ݴϴ�.
        Gizmos.color = new Color(1f, 0f, 0f, 0.2f);
        Gizmos.DrawSphere(transform.position, detectionRadius);
    }

    void Flip()
    {
        if (player.transform.position.x < transform.position.x) { // �÷��̾ ���ʿ� ���� ��� filp
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false;
    }
}