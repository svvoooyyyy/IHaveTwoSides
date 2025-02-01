using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rb;
    private Vector2 _moveDirection;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }
}
