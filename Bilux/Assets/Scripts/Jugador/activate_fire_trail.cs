using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_fire_trail : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Boost"))
        {
            Debug.Log("TRAIL");
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }


    }
}
