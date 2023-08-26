using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemGrade
{
    Common,
    Rare,
    Legend
}

public abstract class ItemData : ScriptableObject
{
    public int ID;
    public string Name;
    public string Desc;
    public Sprite Sprite;
    public GameObject Prefab;

    public abstract void Instantiate(Transform transform);
}

public abstract class EquipableItemData : ItemData
{
    public ItemGrade itemGrade;
}

[CreateAssetMenu(fileName = "Relic Item", menuName = "Create Item Data/Relic Item")]
public class RelicItemData : EquipableItemData
{

    public override void Instantiate(Transform transform)
    {
        throw new System.NotImplementedException();
    }
}
