﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour {
    private Rigidbody rb;
    public float scrollSpeed = 0;
    [SerializeField]
    private GameManager gm;

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

    private void OnCollisionEnter(Collision collision)
    {
        gm.ToggleVictoryMenu();
    }
}
