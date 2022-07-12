using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _animator;

    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator.SetBool("Grounded", true);
    }

    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        if (_joystick.Direction != Vector2.zero)
        {
            _controller.Move(new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y) * _speed * Time.deltaTime);
            _animator.SetFloat("MoveSpeed", 10);
        }
        else
        {
            _animator.SetFloat("MoveSpeed", 0);
        }
    }

    private void Look()
    {
        if (_joystick.Direction != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y) * _speed * Time.deltaTime);
        }
    }
}
