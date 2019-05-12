using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Invoke("MenuScene", 9.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MenuScene()
    {
        SceneManager.LoadScene(1);
    }
}
