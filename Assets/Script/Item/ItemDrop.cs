using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 1f)]
    private float dropProbability;
    public List<ItemData> commonDropItems = new List<ItemData>();
    public List<ItemData> rareDropItems = new List<ItemData>();
    public List<ItemData> legendaryDropItems = new List<ItemData>();

    public void DropItem()
    {
        if (dropProbability == 100 || Random.Range(0f, 1f) < dropProbability)
        {
            if (GetRandomItem() != null) GetRandomItem().Instantiate(transform);
        }
    }

    private ItemData GetRandomItem()
    {
        float randomValue = Random.Range(0f, 1f);

        if (randomValue < 0.05f)
        {
            return GetRandomItemFromList(legendaryDropItems);
        }
        else if (randomValue < 0.25f)
        {
            return GetRandomItemFromList(rareDropItems);
        }
        else
        {
            return GetRandomItemFromList(commonDropItems);
        }
    }

    private ItemData GetRandomItemFromList(List<ItemData> itemList)
    {
        if (itemList.Count == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, itemList.Count);
        return itemList[randomIndex];
    }
}
