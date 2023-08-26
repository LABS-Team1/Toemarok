using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템의 본체 스크립트 (기능)
[System.Serializable]
public abstract class Item
{
    public ItemData ItemData => itemData;

    [SerializeField]
    private ItemData itemData;

    public Item(ItemData data) => itemData = data;

}