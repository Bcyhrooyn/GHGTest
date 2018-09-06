using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    [SerializeField]
    private GameObject floor;

    private float groundHorizontalLength;

    // Use this for initialization
    void Start() {
        groundHorizontalLength = floor.GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector3 groundOffset = new Vector3(groundHorizontalLength * 2f, 0, 0);
        transform.position = (Vector3)transform.position + groundOffset;
    }
}
