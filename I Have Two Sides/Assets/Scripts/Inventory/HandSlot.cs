using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class HandSlot : MonoBehaviour
{
    [SerializeField] private float _pickUpRadius;
    [SerializeField] private LayerMask _itemMask;
    [SerializeField] private List<GameObject> _itemsPool;

    private GameObject _pickedItemObject;
    public ItemType PickedItemType { get; private set; } = ItemType.None;
    
    private GameObject TryPickUp()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _pickUpRadius, _itemMask);
    
        if (hit != null)
            return hit.gameObject;
        
        return null;
    }

    private void PickUp(ItemType itemType)
    {
        if (PickedItemType != ItemType.None)
            return;

        _itemsPool[(int)itemType].SetActive(true);
        PickedItemType = itemType;
    }

    private void Drop()
    {
        if (PickedItemType == ItemType.None)
            return;
        
        _itemsPool[(int)PickedItemType].SetActive(false);
        PickedItemType = ItemType.None;
        _itemsPool[(int)PickedItemType].SetActive(true);
    }

    public void PickUp(InputAction.CallbackContext context)
    {
        GameObject item = TryPickUp();
        
        if (context.performed && item != null) 
        {
            _pickedItemObject = item;
            PickedItemType = item.GetComponent<Item>().GetItemType();
            PickUp(PickedItemType);
            item.SetActive(false);
        }
    }

    public void Drop(InputAction.CallbackContext context)
    {
        if (context.performed) {
            Drop();

            if (_pickedItemObject != null)
            {
                _pickedItemObject.transform.position = transform.position;
                _pickedItemObject.SetActive(true);
                _pickedItemObject = null;
                PickedItemType = ItemType.None;
            }
        }
    }
}