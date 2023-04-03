using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveS = 5f;
    public Animator animator;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveS * Time.fixedDeltaTime);
    }

    private void Move()
    {
        rb.velocity = new Vector2(movement.x, movement.y);
    }
}
