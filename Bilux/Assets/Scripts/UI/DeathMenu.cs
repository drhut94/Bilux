using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

    //public GameMngr level;
    //public Slider slider;

    public Canvas deathMenu;
    bool muerto;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player") == null && muerto==false)
        {   
            Invoke("PopDeathMenu", 1f);
            Debug.Log("Dead");
            muerto = true;
        }
        else if (GameObject.FindGameObjectWithTag("Player"))
        {
            muerto = false;
            deathMenu.gameObject.SetActive(false);
            Debug.Log("Alive");
        }

    }

    public void PopDeathMenu()
    {
        deathMenu.gameObject.SetActive(true);

    }
}
