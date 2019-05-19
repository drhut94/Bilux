using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMngmnt : MonoBehaviour {


    public Player player;
    //public GameObject deathParticles;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Reload") && !player.isActiveAndEnabled)
        {
            player.InitPlayer();
            player.gameObject.SetActive(true);
            FindObjectOfType<NearDeath>().ResetEffects();
        }

        //deathParticles.transform.position = player.transform.position;

        //if (player.health <= 0)
        //{
        //    deathParticles.GetComponent<ParticleSystem>().Play();
        //}
    }

    
}
