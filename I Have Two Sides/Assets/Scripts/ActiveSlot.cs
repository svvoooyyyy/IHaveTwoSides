using System.Collections.Generic;
using UnityEngine;

public class ActiveSlot : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemsPool;
    private ItemType _activeItem = ItemType.None;
    
    public void PickUpItem(ItemType itemType)
    {
        if (_activeItem != ItemType.None)
            return;

        _activeItem = itemType;
        _itemsPool[(int)_activeItem].SetActive(true);
    }

    public void DropItem(ItemType itemType)
    {
        if (_activeItem == ItemType.None)
            return;
        
        _itemsPool[(int)_activeItem].SetActive(false);
        _activeItem = itemType;
        _itemsPool[(int)_activeItem].SetActive(true);
    }
}