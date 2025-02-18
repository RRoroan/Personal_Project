using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameEnemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer enemyCharater;
    [SerializeField] private float followRange = 15f;
    [Range(1,5)] [SerializeField] private float speed = 1.5f;
    private Transform target;
    private bool playerTouch;
    private Vector2 movementDirection = Vector2.zero;
    private Vector2 MovementDirection { get { return movementDirection; } }
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = movementDirection * speed;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float distance = DistancetoTarget();
        
        if (distance > followRange)
        {
            movementDirection = Vector2.zero;
            return;
        }
        Vector2 direction = DirectiontoTarget();
        movementDirection = direction;
    }

    private float DistancetoTarget ()
    {
        return Vector3.Distance(transform.position, target.position);
    }

    private Vector2 DirectiontoTarget()
    {
        return (target.position - transform.position).normalized;
    }

}
