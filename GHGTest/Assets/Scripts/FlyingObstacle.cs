using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacle : MonoBehaviour {

    private Rigidbody rb;
    [SerializeField]
    float scrollSpeed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(scrollSpeed, 0, 0);
    }

    private void FixedUpdate()
    {
        Vector3 scroll = new Vector3(scrollSpeed, 0, 0);
        rb.MovePosition(transform.position + scroll * Time.deltaTime);
    }
}
