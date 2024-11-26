using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayer : MonoBehaviour
{
    //Basic script for fake player that follows your mouse on the start menu screen 
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    float moveSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (rb.velocity.magnitude > 0.5f)
        {
            animator.SetFloat("magnitude", rb.velocity.normalized.magnitude);
        }
        else
        {
            animator.SetFloat("magnitude", 0);
        }

        // Get the mouse position in the world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Set the y-position to the player's current y-position to restrict movement to left and right
        mousePosition.y = transform.position.y;

        Vector2 moveDirection = (mousePosition - transform.position).normalized;

        // Set the velocity based on the direction and move speed
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, 0f);
        spriteRenderer.flipX = moveDirection.x < 0;
    }
}
