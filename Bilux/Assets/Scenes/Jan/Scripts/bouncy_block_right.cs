using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncy_block_right : MonoBehaviour {

    public int force;


    void Start()
    {

    }


    void Update()
    {

    }


    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject jugador = col.gameObject;
            jugador.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        }
    }
}
