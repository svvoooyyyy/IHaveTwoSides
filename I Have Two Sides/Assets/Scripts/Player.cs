using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _pickUpRadius;
    [SerializeField] private LayerMask _itemMask;

    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private GameObject _pickedItem;

    public ItemType PickedItemType {get; private set;}

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);
    }

    private GameObject TryPickUp()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _pickUpRadius, _itemMask);
    
        if (hit != null)
            return hit.gameObject;
        
        return null;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    public void PickUp(InputAction.CallbackContext context)
    {
        GameObject item = TryPickUp();
        
        if (context.performed && item != null) 
        {
            _pickedItem = item;
            PickedItemType = _pickedItem.GetComponent<Item>().GetItemType();
            GetComponent<ActiveSlot>().PickUpItem(PickedItemType);
            _pickedItem.SetActive(false);
        }
    }

    public void DropItem(InputAction.CallbackContext context)
    {
        if (context.performed) {
            GetComponent<ActiveSlot>().DropItem();

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
