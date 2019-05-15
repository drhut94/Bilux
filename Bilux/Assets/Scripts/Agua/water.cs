using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {


    public int damage;

    private void Start()
    {
        damage = 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().Die();
            collision.GetComponent<Player>().SetHealth(damage);
        }
    }

}
