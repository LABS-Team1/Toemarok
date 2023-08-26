using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Item", menuName = "Create Item Data/Weapon Item")]
public class WeaponItemData : EquipableItemData
{
    public WeaponItem Create()
    {
        return new WeaponItem(this);
    }

    public override void Instantiate(Transform transform)
    {
        WeaponItem weapon = Create();

        if (Prefab != null)
        {
            GameObject obj = GameObject.Instantiate(Prefab);
            obj.transform.position = transform.position;

            if (obj.TryGetComponent(out WeaponObject weaponObject))
            {
                weaponObject.SetData(weapon);
            }
        }
    }
}