using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public float rotationSpeed = 10f; // ȸ�� �ӵ�
    public GameObject player;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        RotateTowardsMousePointer();
        FlipSpriteAndColliderBasedOnMousePosition();
    }

    private void RotateTowardsMousePointer()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z; // ���콺 �������� z��ǥ�� ī�޶� ��ġ�� �����ϰ� ����
        Vector3 direction = Camera.main.ScreenToWorldPoint(mousePosition) - player.transform.position; // ĳ���Ϳ� ���콺 ������ ���� ���� ���
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction); // ȸ�� Quaternion ����
        Vector3 playerRotation = player.transform.rotation.eulerAngles; // player�� ���� ȸ���� ����
        rotation.eulerAngles = new Vector3(0, 0, rotation.eulerAngles.z - playerRotation.z); // player�� �������� ȸ���� ���
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime); // ȸ�� ����
    }

    private void FlipSpriteAndColliderBasedOnMousePosition()
    {
        bool isMouseOnRightSide = Input.mousePosition.x > Screen.width / 2;
        spriteRenderer.flipX = isMouseOnRightSide;

        float colliderOffsetX = Mathf.Abs(boxCollider2D.offset.x);
        if (isMouseOnRightSide) {
            boxCollider2D.offset = new Vector2(colliderOffsetX, boxCollider2D.offset.y);
        }
        else {
            boxCollider2D.offset = new Vector2(-colliderOffsetX, boxCollider2D.offset.y);
        }
    }
}
