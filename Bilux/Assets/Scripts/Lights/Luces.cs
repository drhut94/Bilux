using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luces : MonoBehaviour {


    Vector3 InitPos;
    int distanceBackup;
    float velocityBackup;

    public float velocity;
    public int distance;
    public int direction;


	// Use this for initialization
	void Start () {
        InitPos = gameObject.transform.position;
        distanceBackup = distance;
        velocityBackup = velocity;
	}
	
	// Update is called once per frame
	void Update () {

        velocity -= Time.deltaTime;


            if (velocity <= 0)
            {
                transform.position += new Vector3(0, 1 * (float)direction, 0);
                velocity = velocityBackup;
                distance--;
            }

            if (distance <= 0)
            {
                transform.position = InitPos;
                distance = distanceBackup;
            }

	}
}
