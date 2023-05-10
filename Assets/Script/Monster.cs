using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float detectionRadius; // 원의 반지름
    public float moveSpeed = 1.0f;

    private GameObject[] players; // 플레이어 레이어
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

        
        if (IsTargetDetected()) // 플레이어가 원 안에 있을 때
        {

            Flip();// player 가 몬스터보다 왼쪽에 잇으면 flipt

            // 플레이어를 추적
            transform.position = Vector3.MoveTowards
                (transform.position, target.transform.position, moveSpeed * Time.deltaTime);

            animator.SetBool("TrackingPlayer", true);
        }
        else // 플레이어가 원 밖에 있을 때
        {
            animator.SetBool("TrackingPlayer", false);
        }
    }

    private void OnDrawGizmos()
    {
        // 게임 씬에서 가상의 원을 그려줍니다.
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
        if (target.transform.position.x < transform.position.x) { // 플레이어가 왼쪽에 있을 경우 filp
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

        // 플레이어와 몬스터의 거리 계산
        float distance = Vector2.Distance(transform.position, target.transform.position);


        return distance <= detectionRadius;
    }
}