﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMngr : MonoBehaviour {

    public static GameMngr instance;
    public float tutorial;
    public float level1;
    public float level2;
    public float level3;
    public float level4;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetFloat("tutorial", 100);
        PlayerPrefs.SetFloat("level1", 0);
        PlayerPrefs.SetFloat("level2", 0);
        PlayerPrefs.SetFloat("level3", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateLevels()
    {
        tutorial = PlayerPrefs.GetFloat("tutorial");
        level1 = PlayerPrefs.GetFloat("level1");
        level2 = PlayerPrefs.GetFloat("level2");
        level3 = PlayerPrefs.GetFloat("level3");
        level4 = PlayerPrefs.GetFloat("level4");

        if (tutorial >= 100)
        {
            FindObjectOfType<UIInteractions>().UnlockLevel(1);
        }
        if (level1 >= 100)
        {
            FindObjectOfType<UIInteractions>().UnlockLevel(2);
        }
        if (level2 >= 100)
        {
            FindObjectOfType<UIInteractions>().UnlockLevel(3);
        }

    }


}
