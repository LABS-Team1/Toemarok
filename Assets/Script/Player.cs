using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator; // 애니메이터 컴포넌트
    public float moveSpeed = 5f; // 이동 속도
    //private bool isMoving = false;
    

    Rigidbody2D rb; // Rigidbody2D 컴포넌트

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // 수평 입력 받기
        float vertical = Input.GetAxisRaw("Vertical"); // 수직 입력 받기

        if (horizontal != 0f && vertical == 0f) // 좌우 방향키만 눌렸을 경우
        {
            Move(horizontal, 0f);
            //SetAnimation(horizontal, 0f);
        }
        else if (vertical != 0f && horizontal == 0f) // 상하 방향키만 눌렸을 경우
        {
            Move(0f, vertical);
            //SetAnimation(0f, vertical);
        }
        else // 방향키가 2개 이상 눌렸을 경우
        {
            //animator.SetFloat("Horizontal", 0f); // 애니메이션 파라미터 초기화
            //animator.SetFloat("Vertical", 0f);
            //animator.SetBool("isMoving", false); // 이동중 true 이동시 false
            rb.velocity = Vector2.zero; // Rigidbody2D 속도 초기화
        }
    }

    void Move(float horizontal, float vertical)
    {
        Vector2 direction = new Vector2(horizontal, vertical).normalized; // 이동 방향 설정
        Vector2 velocity = direction * moveSpeed; // 이동 속도 설정
        rb.velocity = velocity; // Rigidbody2D에 속도 적용
    }

    void SetAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Horizontal", horizontal); // 애니메이션 파라미터 설정
        animator.SetFloat("Vertical", vertical);
        animator.SetBool("isMoving", true); // 이동중 true 이동시 false
    }
}
