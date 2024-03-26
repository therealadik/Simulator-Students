using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const string AnimatorParameterRunName = "IsRun";

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rb;
    private Animator _animator;

    private bool _canRun = true;
    private bool _runInput = false;

    private float _currentSpeed;
    private Vector2 direction;
    private Vector3 movement;

    public bool IsMove => Mathf.Abs(_rb.velocity.x) + Mathf.Abs(_rb.velocity.z) > 0.01f;
    public bool IsRunning { get; private set; }


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Initialize(); 
        //VisibleOff();
    }

    // Update is called once per frame
    void Update()
    {
        IsRunning = _canRun && _runInput;
        _currentSpeed = IsRunning ? _runSpeed : _walkSpeed;



        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if (_animator)
        {
            _animator.SetBool(AnimatorParameterRunName, IsMove);
        }
    }

    private void VisibleOff()
    {
        SkinnedMeshRenderer[] list = GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (SkinnedMeshRenderer renderer in list)
            renderer.enabled = false;

    }

    private void Initialize()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        movement.y = _rb.velocity.y;
        movement = (direction.y * transform.forward + direction.x * transform.right) * _currentSpeed;
        _rb.velocity = movement;
    }

    private void OnMove(InputValue input)
    {
        direction = input.Get<Vector2>();
    }

    private void OnRun(InputValue input)
    {
        _runInput = input.isPressed;
    }
}
