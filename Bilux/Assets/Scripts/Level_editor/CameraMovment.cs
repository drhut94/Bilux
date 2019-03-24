using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour {





	void Update () {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);	
	}
}
