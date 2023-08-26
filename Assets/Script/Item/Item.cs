using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������� ��ü ��ũ��Ʈ (���)
[System.Serializable]
public abstract class Item
{
    public ItemData ItemData => itemData;

    [SerializeField]
    private ItemData itemData;

    public Item(ItemData data) => itemData = data;

}