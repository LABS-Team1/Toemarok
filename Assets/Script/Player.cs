using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator; // �ִϸ����� ������Ʈ
    public float moveSpeed = 5f; // �̵� �ӵ�
    //private bool isMoving = false;
    

    Rigidbody2D rb; // Rigidbody2D ������Ʈ

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // ���� �Է� �ޱ�
        float vertical = Input.GetAxisRaw("Vertical"); // ���� �Է� �ޱ�

        if (horizontal != 0f && vertical == 0f) // �¿� ����Ű�� ������ ���
        {
            Move(horizontal, 0f);
            //SetAnimation(horizontal, 0f);
        }
        else if (vertical != 0f && horizontal == 0f) // ���� ����Ű�� ������ ���
        {
            Move(0f, vertical);
            //SetAnimation(0f, vertical);
        }
        else // ����Ű�� 2�� �̻� ������ ���
        {
            //animator.SetFloat("Horizontal", 0f); // �ִϸ��̼� �Ķ���� �ʱ�ȭ
            //animator.SetFloat("Vertical", 0f);
            //animator.SetBool("isMoving", false); // �̵��� true �̵��� false
            rb.velocity = Vector2.zero; // Rigidbody2D �ӵ� �ʱ�ȭ
        }
    }

    void Move(float horizontal, float vertical)
    {
        Vector2 direction = new Vector2(horizontal, vertical).normalized; // �̵� ���� ����
        Vector2 velocity = direction * moveSpeed; // �̵� �ӵ� ����
        rb.velocity = velocity; // Rigidbody2D�� �ӵ� ����
    }

    void SetAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Horizontal", horizontal); // �ִϸ��̼� �Ķ���� ����
        animator.SetFloat("Vertical", vertical);
        animator.SetBool("isMoving", true); // �̵��� true �̵��� false
    }
}
