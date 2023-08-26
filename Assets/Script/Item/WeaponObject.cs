using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : PickableObject
{
    [SerializeField]
    private SpriteRenderer sprite;
    private Item item;

    public void Awake()
    {
        if (sprite == null)
        {
            if (TryGetComponent(out SpriteRenderer sprite)) this.sprite = sprite;
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        // ui
    }

    public override void PickUp()
    {
        // Equip
    }

    public void SetData(Item item)
    {
        this.item = item;
        if (item.ItemData.Sprite != null) sprite.sprite = item.ItemData.Sprite;
    }
}
