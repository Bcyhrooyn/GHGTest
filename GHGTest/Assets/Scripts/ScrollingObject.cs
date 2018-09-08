using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb;
    public float scrollSpeed = 0;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}	

    public void StartScroll()
    {
        rb.velocity = new Vector2(scrollSpeed, 0);
    }
}
