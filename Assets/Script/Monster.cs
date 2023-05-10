using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float detectionRadius; // ���� ������
    public float moveSpeed = 1.0f;

    private GameObject[] players; // �÷��̾� ���̾�
    private GameObject target;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        target = FindNearestPlayer();

        
        if (IsTargetDetected()) // �÷��̾ �� �ȿ� ���� ��
        {

            Flip();// player �� ���ͺ��� ���ʿ� ������ flipt

            // �÷��̾ ����
            transform.position = Vector3.MoveTowards
                (transform.position, target.transform.position, moveSpeed * Time.deltaTime);

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

    private GameObject FindNearestPlayer()
    {
        float minDistance = 0.0f;
        GameObject result = null;
        foreach (var player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < minDistance || result == null)
            {
                distance = minDistance;
                result = player;
            }
        }
        return result;
    }

    private void Flip()
    {
        if (target.transform.position.x < transform.position.x) { // �÷��̾ ���ʿ� ���� ��� filp
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false;
    }

    public GameObject GetTarget()
    {
        return target;
    }

    public bool IsTargetDetected()
    {
        if (target == null) return false;

        // �÷��̾�� ������ �Ÿ� ���
        float distance = Vector2.Distance(transform.position, target.transform.position);


        return distance <= detectionRadius;
    }
}