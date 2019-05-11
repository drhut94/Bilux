using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {

    public GameObject[] checkpoint;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt("checkpoint") == 0)
        {
            for (int i = 0; i < checkpoint.Length; i++)
            {
                checkpoint[i].active = false;
            }
        }
        else if (PlayerPrefs.GetInt("checkpoint") == 1)
        {
            for (int i = 0; i < checkpoint.Length; i++)
            {
                checkpoint[i].active = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
