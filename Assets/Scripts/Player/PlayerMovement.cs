using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private float _horizontalSpeed = 2f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _rotationSpeed = 2f;
    [SerializeField] private float _maxRotationZ = 45f;
    [SerializeField] private float _minRotationZ = -90f;

    private Rigidbody2D _rigidbody;
    private Quaternion _upRotation;
    private Quaternion _downRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _upRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _downRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void OnEnable()
    {
        _input.JumpPerformed += OnJump;
    }

    private void OnDisable()
    {
        _input.JumpPerformed -= OnJump;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _downRotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnJump()
    {
        _rigidbody.linearVelocity = new Vector2(_horizontalSpeed, _jumpForce);
        transform.rotation = _upRotation;
    }
}