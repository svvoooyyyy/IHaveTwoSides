using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ActiveSlot : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemsPool;
    [SerializeField] private float _pickUpRadius;
    [SerializeField] private LayerMask _itemMask;
    private ItemType _activeItem = ItemType.None;
    private GameObject _pickedItem;

    public ItemType PickedItemType {get; private set;}
    
    private GameObject TryPickUp()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _pickUpRadius, _itemMask);
    
        if (hit != null)
            return hit.gameObject;
        
        return null;
    }

    private void PickUpItem(ItemType itemType)
    {
        if (_activeItem != ItemType.None)
            return;

        _activeItem = itemType;
        _itemsPool[(int)_activeItem].SetActive(true);
    }

    private void DropItem()
    {
        if (_activeItem == ItemType.None)
            return;
        
        _itemsPool[(int)_activeItem].SetActive(false);
        _activeItem = ItemType.None;
        _itemsPool[(int)_activeItem].SetActive(true);
    }

    public void PickUp(InputAction.CallbackContext context)
    {
        GameObject item = TryPickUp();
        
        if (context.performed && item != null) 
        {
            _pickedItem = item;
            PickedItemType = _pickedItem.GetComponent<Item>().GetItemType();
            PickUpItem(PickedItemType);
            _pickedItem.SetActive(false);
        }
    }

    public void DropItem(InputAction.CallbackContext context)
    {
        if (context.performed) {
            DropItem();

            if (_pickedItem != null)
            {
                _pickedItem.transform.position = transform.position;
                _pickedItem.SetActive(true);
                _pickedItem = null;
                PickedItemType = ItemType.None;
            }
        }
    }
}