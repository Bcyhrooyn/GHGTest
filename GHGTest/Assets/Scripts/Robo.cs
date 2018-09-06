using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour {

    Animator animator;
    Rigidbody rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameManager gm;
    private bool isJumping = false;
    private bool isFlipped = false;
    private bool isAttacking = false;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }        
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isJumping)
        {
            Attack();
        }
        //else
        //{
        //    isAttacking = false;
        //    animator.SetBool("isAttacking", isAttacking);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check for punching crystal - it should play some particle effect and get destroyed
        if (collision.gameObject.CompareTag("Destructible") && isAttacking)
        {
            Destroy(collision.gameObject);
        }

        // Specifically for landing on the ground
        else if (collision.gameObject.CompareTag("Environment"))
        {
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
            rb.velocity = new Vector3(0, 0, 0);
        }



        // All other collisions, i.e Game Over
        else
        {
            gm.TogglePauseMenu();
        }
    }

    private void HandleMovement(float horizontal)
    {
        Vector3 movement = new Vector3(horizontal * speed, rb.velocity.y, rb.velocity.z);
        rb.velocity = movement;
        if ((horizontal > 0 && isFlipped) || (horizontal < 0 && !isFlipped))
        {
            isFlipped = !isFlipped;
            Vector3 scale = transform.localScale;
            scale.z *= -1;
            transform.localScale = scale;
        }

        animator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void Jump()
    {
        isJumping = true;
        animator.SetBool("isJumping", isJumping);
        Vector3 movement = new Vector3(0, 350, 0);
        rb.AddForce(movement);
    }

    private void Attack()
    {
        isAttacking = true;
        animator.SetBool("isAttacking", isAttacking);
    }

    public void SetIsAttacking(bool val)
    {
        isAttacking = val;
        animator.SetBool("isAttacking", isAttacking);
    }

}
