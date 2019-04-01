using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_normal_trail : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Boost"))
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }


    }
}
