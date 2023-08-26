using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : EquipableItem
{
    public WeaponItem(WeaponItemData data) : base(data) { }

    public override void Equip()
    {

    }

    public override void UnEquip()
    {

    }

    protected override EquipableItem Create()
    {
        return new WeaponItem(EquipableItemData as WeaponItemData);
    }
}
