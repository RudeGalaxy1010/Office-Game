using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_joystick.Direction != Vector2.zero)
        {
            _rigidbody.velocity = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y) * _speed;
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
