using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {


    public float rotationSpeed;
    private Rigidbody2D rb;
    private float rotation;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = rotationSpeed;
    }

    private void FixedUpdate()
    {
        transform.rotation = new Quaternion(rotation, 0.0f,0.0f,0.0f);
        rotation += rotationSpeed;
    }
}
