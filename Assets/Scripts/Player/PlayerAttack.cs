using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _resourceMask;
    [SerializeField] private LayerMask _taskMask;
    [SerializeField] private Animator _attackAnimator;

    private void Obtain(ItemType itemType) 
    {
        if (!_attackAnimator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            return;
            
        _attackAnimator.Play("attack");

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

    private GameObject TryInteract()
    {
        Collider2D hit = Physics2D.OverlapCircle(_attackPoint.position, _attackRadius, _taskMask);
    
        if (hit != null)
            return hit.gameObject;
        
        return null;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        ItemType itemType = GetComponent<HandSlot>().PickedItemType;
        if (context.performed)
            Obtain(itemType);
    }

    public void Interact(InputAction.CallbackContext context)
    {
        GameObject taskObject = TryInteract();
        ItemType handType = GetComponent<HandSlot>().PickedItemType;

        if (context.performed && taskObject != null)
        {
            Task task = taskObject.GetComponent<Task>();

            if (task.GetNeedItem() != ItemType.None && handType != task.GetNeedItem())
                return;
            
            task.TryComplete();
        }
    }
}
