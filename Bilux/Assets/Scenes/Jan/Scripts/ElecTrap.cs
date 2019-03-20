using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElecTrap : MonoBehaviour {

    PMov player;
    public GameObject ElectricTrap;

    float DOT;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DOT = 1 * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        player = other.gameObject.GetComponent<PMov>();
        if (player != null)
        {
            player.ReceiveDamage(DOT);
        }
    }
}
