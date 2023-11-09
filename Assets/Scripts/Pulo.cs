using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulo : MonoBehaviour
{
    public float jumpForce = 5f;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private Animator animator;
    public AudioSource audioDoPulo;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
            audioDoPulo.Play();
        }
    }

    private void Jump()
    {
        isJumping = true;
        rb.velocity = Vector2.up * jumpForce;

        // Ative a animação de pulo

        animator.SetBool("taPulando", true);

        if (rb.velocity.y == 0)
        {
            animator.SetBool("taPulando", true);
        }
        animator.SetTrigger("taPulando");
    }   
        

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

            // Desative a animação de pulo
            animator.ResetTrigger("taPulando");
        }
    }
}