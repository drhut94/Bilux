using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spyke_block : MonoBehaviour {


	void Start () {
		
	}
	
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().health -= 100;
        }
    }
}
