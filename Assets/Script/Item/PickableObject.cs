using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool isInRange; // 플레이어가 범위 내에 있는지 체크

    public virtual void Update()
    {
        // 범위 내에 있고, F키를 누르면 아이템 획득
        if (isInRange && Input.GetKeyDown(KeyCode.Z))
        {
            PickUp();
        }
    }

    // 아이템 획득 로직
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
