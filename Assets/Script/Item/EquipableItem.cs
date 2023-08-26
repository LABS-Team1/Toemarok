using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipableItem : Item
{
    public EquipableItemData EquipableItemData { get; private set; }

    public EquipableItem(EquipableItemData data) : base(data)
    {
        EquipableItemData = data;
    }

    public abstract void Equip();
    public abstract void UnEquip();
    protected abstract EquipableItem Create();
}