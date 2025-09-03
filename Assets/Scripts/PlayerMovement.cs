using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private PlayerInput input;
    private Vector2 _movement;
    private InputAction _action;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

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
        animator.SetFloat("Speed", _movement.sqrMagnitude);

        if (_movement.x != 0)
        {
            spriteRenderer.flipX = _movement.x < 0;
        }
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = _movement.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            FightContext.Instance.EnnemyName = collision.gameObject.name;
            SceneManager.LoadScene(1);
        }
    }
}
