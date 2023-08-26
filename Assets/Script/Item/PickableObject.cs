using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool isInRange; // �÷��̾ ���� ���� �ִ��� üũ

    public virtual void Update()
    {
        // ���� ���� �ְ�, FŰ�� ������ ������ ȹ��
        if (isInRange && Input.GetKeyDown(KeyCode.Z))
        {
            PickUp();
        }
    }

    // ������ ȹ�� ����
    public virtual void PickUp()
    {
        Debug.Log("Picked up the item!");
    }

    public virtual void Skill()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
