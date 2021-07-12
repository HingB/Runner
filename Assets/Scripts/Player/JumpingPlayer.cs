using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpingPlayer : MonoBehaviour
{
    [SerializeField] private float _jumpForse;
    private PlayerInput _playerInput;

    private Rigidbody _rigidbody;
    private bool _isGrounded;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Player.Jump.performed += ctx => Jump();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if(_isGrounded == true)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForse);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Road road))
            _isGrounded = true;
    }
}
