using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rigidbody;
    public PlayerInput input;

    private Vector2 _movement;
    private InputAction _action;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        input.actions = Instantiate(input.actions);
        _action = input.actions["Move"];
    }

    void Update()
    {
        _movement = _action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rigidbody.linearVelocity = _movement * speed;
    }
}
