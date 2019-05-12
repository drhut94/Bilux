using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailerCamera : MonoBehaviour {


    public float speed;
    private float xPos;
    private float yPos;
    private float zPos;

	// Use this for initialization
	void Start () {
        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void FixedUpdate()
    {
        xPos += speed;
        transform.position = new Vector3(xPos, yPos, zPos);
    }
}
