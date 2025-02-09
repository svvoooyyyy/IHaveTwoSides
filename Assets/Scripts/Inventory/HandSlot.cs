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

    private void PickUp(GameObject item)
    {
        ItemType itemType = item.GetComponent<Item>().GetItemType();

        item.SetActive(false);
        _itemsPool[(int)itemType].SetActive(true);
        _pickedItemObject = item;
        PickedItemType = itemType;
    }

    private void Drop()
    {
        _itemsPool[(int)PickedItemType].SetActive(false);
        PickedItemType = ItemType.None;
        _itemsPool[(int)PickedItemType].SetActive(true);

        _pickedItemObject.transform.position = transform.position;
        _pickedItemObject.SetActive(true);
        _pickedItemObject = null;
    }

    public void PickUp(InputAction.CallbackContext context)
    {
        GameObject item = TryPickUp();
        
        if (context.performed && item != null && PickedItemType == ItemType.None) 
            PickUp(item);
    }

    public void Drop(InputAction.CallbackContext context)
    {
        if (context.performed && PickedItemType != ItemType.None)
            Drop();
    }
}