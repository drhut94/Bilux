using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMngmnt : MonoBehaviour {


    public Player player;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Reload"))
        {
            player.transform.position = player.initPlayerPos;
            player.InitPlayer();
            player.gameObject.SetActive(true);
            FindObjectOfType<color_change>().ChangeScreenColor(1);
        }
    }
}
