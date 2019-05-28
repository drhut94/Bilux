using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPos : MonoBehaviour {


    Vector3 InitPos;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        InitPos = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Reload"))
        {
            transform.position = new Vector3(InitPos.x, InitPos.y, InitPos.z);
            transform.rotation = Quaternion.identity;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector2(0f, 0f);
        }
	}
}
