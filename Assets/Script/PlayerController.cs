using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngineInternal;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpForce = 5;
    private Animator animator;
    private Rigidbody2D rb;
    private float dirX;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJump", true);
        }
        animator.SetBool("isJump", false);
        RunAnimation();
        Attack();
        animator.SetBool("isAttack", false);

    }

    private void RunAnimation()
    {
        if (dirX > 0)
        {
            animator.SetBool("isRun", true);
            GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (dirX < 0)
        {
            animator.SetBool("isRun", true);
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else
            animator.SetBool("isRun", false);
    }

    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("isAttack", true);
        }
    }
}
