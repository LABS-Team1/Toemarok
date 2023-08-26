using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicItem : EquipableItem
{
    public RelicItem(RelicItemData data) : base(data) { }

    public override void Equip()
    {

    }

    public override void UnEquip()
    {

    }

    protected override EquipableItem Create()
    {
        return new RelicItem(EquipableItemData as RelicItemData);
    }
}