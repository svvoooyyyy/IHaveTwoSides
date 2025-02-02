using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _resourceMask;

    private void Obtain(ItemType itemType) 
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _resourceMask);

        foreach (Collider2D collider in hit)
        {
            Resource resource = collider.GetComponent<Resource>();
            if (resource.IsObtainable(itemType))
            {
                resource.GetValues(out ResourceType resourceType, out int resourceAmount);
                ResourcesManager.Instance.AddResourses(resourceType, resourceAmount);
            }
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        ItemType itemType = GetComponent<HandSlot>().PickedItemType;
        if (context.performed)
            Obtain(itemType);
    }
}
