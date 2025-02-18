using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Range(1f, 10f)][SerializeField] private float speed = 3f;
    [SerializeField] private SpriteRenderer CharacterRenderer;
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }
    private Rigidbody2D rigidbody2D;
    private float lastMoveX = 0f;
    private float lastMoveY = -1f;
    private Animator animator;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = movementDirection * speed;
    }

    void OnMove (InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
        if (movementDirection != Vector2.zero)
        {
            lastMoveX = movementDirection.x;
            lastMoveY = movementDirection.y;
        }
        animator.SetFloat("MoveX", movementDirection.x);
        animator.SetFloat("MoveY", movementDirection.y);

        if(movementDirection.magnitude > 0.1f)
        {
            animator.SetBool("IsRun", true);
        }
        else
        {
            animator.SetBool("IsRun", false);
            animator.SetFloat("LastMoveX", lastMoveX);
            animator.SetFloat("LastMoveY", lastMoveY);
        }
    }
}
