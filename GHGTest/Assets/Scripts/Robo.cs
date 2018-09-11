using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour {

    Animator animator;
    Rigidbody rb;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpHeight;

    [SerializeField]
    private GameManager gm;
    private bool isJumping = false;
    private bool isAttacking = false;
    [SerializeField]
    private BoxCollider[] feetColliders;
    private BoxCollider bodyCollider;

    [SerializeField]
    private AudioClip jumpAudio;
    [SerializeField]
    private AudioClip punchAudio;
    [SerializeField]
    private Vector3 audioLocation = new Vector3(0, 0, -8);

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        bodyCollider = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //float horizontal = Input.GetAxis("Horizontal");
        //HandleMovement(horizontal)
        float jump = Input.GetAxis("Jump");
        if (jump > 0 && !isJumping)
        {
            Jump();
            AudioSource.PlayClipAtPoint(jumpAudio, audioLocation);
        }
        float attack = Input.GetAxis("Fire1");
        if (attack > 0 && !isAttacking)
        {
            Attack();
            AudioSource.PlayClipAtPoint(punchAudio, audioLocation);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check for punching crystal - it should get destroyed
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
            bodyCollider.enabled = true;
            foreach (BoxCollider collider in feetColliders)
            {
                collider.enabled = false;
            }

        }

        else if (collision.gameObject.CompareTag("Finish"))
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        // All other collisions, i.e Game Over
        else
        {
            gm.OpenGameOverMenu();
        }
    }

    private void Jump()
    {
        isJumping = true;
        animator.SetBool("isJumping", isJumping);
        Vector3 movement = new Vector3(0, jumpHeight, 0);
        rb.AddForce(movement);

        bodyCollider.enabled = !bodyCollider.enabled;
        foreach (BoxCollider collider in feetColliders)
        {
            collider.enabled = !collider.enabled;
        }
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

    public void SetIsMoving(bool val)
    {
        animator.SetBool("isMoving", val);
    }

}
