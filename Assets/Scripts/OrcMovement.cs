using System.Collections;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
    private readonly float _moveInterval = 0.3f;
    private readonly float _speed = 3.0f;
    public Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveRandomly());
    }

    private IEnumerator MoveRandomly()
    {
        while(true)
        {
            Vector2 direction = GetRandomDirection();

            rigidBody.linearVelocity = direction * _speed;

            yield return new WaitForSeconds(_moveInterval);
        }
    }

    private Vector2 GetRandomDirection()
    {
        int rand = Random.Range(0, 4);
        return rand switch
        {
            0 => Vector2.up,
            1 => Vector2.down,
            2 => Vector2.left,
            3 => Vector2.right,
            _ => Vector2.zero,
        };
    }
}
