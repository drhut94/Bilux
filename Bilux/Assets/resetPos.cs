using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPos : MonoBehaviour {


    Vector3 InitPos;

	// Use this for initialization
	void Start () {
        InitPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Reload"))
        {
            transform.position = new Vector3(InitPos.x +0.2f, InitPos.y, InitPos.z);
        }
	}
}
