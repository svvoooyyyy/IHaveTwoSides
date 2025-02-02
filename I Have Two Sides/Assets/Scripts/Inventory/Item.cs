using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;

    public ItemType GetItemType()
    {
        return _itemType;
    }
}
