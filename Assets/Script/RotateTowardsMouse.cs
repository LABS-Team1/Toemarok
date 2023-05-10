using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public float rotationSpeed = 10f; // 회전 속도
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
        mousePosition.z = Camera.main.transform.position.z; // 마우스 포인터의 z좌표를 카메라 위치와 동일하게 설정
        Vector3 direction = Camera.main.ScreenToWorldPoint(mousePosition) - player.transform.position; // 캐릭터와 마우스 포인터 간의 방향 계산
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction); // 회전 Quaternion 생성
        Vector3 playerRotation = player.transform.rotation.eulerAngles; // player의 현재 회전값 저장
        rotation.eulerAngles = new Vector3(0, 0, rotation.eulerAngles.z - playerRotation.z); // player를 기준으로 회전값 계산
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime); // 회전 적용
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
