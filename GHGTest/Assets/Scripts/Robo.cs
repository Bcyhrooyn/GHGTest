using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour {

    Animator animator;
    Rigidbody rb;
    BoxCollider bCollider;

    [SerializeField]
    private float speed;
    private bool isJumping;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        bCollider = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
        }
    }

    private void HandleMovement(float horizontal)
    {
        Vector3 movement = new Vector3(horizontal * speed, rb.velocity.y, rb.velocity.z);
        rb.velocity = movement;
        
        animator.SetFloat("speed", horizontal * speed);
    }

    private void Jump()
    {
        isJumping = true;
        animator.SetBool("isJumping", isJumping);
        Vector3 movement = new Vector3(0, 250, 0);
        rb.AddForce(movement);
    }

}
