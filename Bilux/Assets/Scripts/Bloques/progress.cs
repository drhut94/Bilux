using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progress : MonoBehaviour {

    public float progressLevel;
    public string levelName;
	
	// Update is called once per frame
	void Update () {
    		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("checkpoint") == 1)
            {
                if (PlayerPrefs.GetFloat(levelName) < 100)
                {
                    PlayerPrefs.SetFloat(levelName, progressLevel);
                }
            }
            else if (PlayerPrefs.GetInt("checkpoint") == 0)
            {
                if (PlayerPrefs.GetFloat(levelName) < 100)
                {
                    PlayerPrefs.SetFloat(levelName + "NC", progressLevel);
                }
            }
        }
    }
}
