using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rigidBody;

    private PlayerInput input;
    private Vector2 _movement;
    private InputAction _action;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        input.actions = Instantiate(input.actions);
        _action = input.actions["Move"];
    }

    private void OnEnable()
    {
        _action.Enable();
    }

    private void OnDisable()
    {
        _action.Disable();
    }

    void Update()
    {
        _movement = _action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = _movement.normalized * speed;
    }
}
