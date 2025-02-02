using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject _body;
    [SerializeField] private GameObject _instruments;

    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private Animator _animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);
        if (_rb.velocity != Vector2.zero)
            _animator.Play("Run");
        else
            _animator.Play("Idle");
        
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
        if (_moveDirection.x > 0)
        {
            _body.transform.localScale = new Vector3(-Mathf.Abs(_body.transform.localScale.x), _body.transform.localScale.y);
            _instruments.transform.localScale = new Vector3(-Mathf.Abs(_instruments.transform.localScale.x), _instruments.transform.localScale.y);
        }
        else
        {
            _body.transform.localScale = new Vector3(Mathf.Abs(_body.transform.localScale.x), _body.transform.localScale.y);
            _instruments.transform.localScale = new Vector3(Mathf.Abs(_instruments.transform.localScale.x), _instruments.transform.localScale.y);
        }
    }
}
