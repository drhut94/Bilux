using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook_block : MonoBehaviour {


    private Rigidbody2D rb;
    private DistanceJoint2D dj;
    private SpriteRenderer sr;
    private bool canDestroy;
    

	void Start () {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        canDestroy = false;
	}
	

	void Update () {

        if(Input.GetButtonDown("Deshook") && IsHooked())
        {
            Destroy(dj);

        }
        Debug.Log(IsHooked());
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        sr.color = Color.green;
        Rigidbody2D rbJugador = col.gameObject.GetComponent<Rigidbody2D>();
        if(col.gameObject.tag == "Player" && Input.GetButtonDown("Jump"))
        {
            if (!IsHooked())
            {
                dj = gameObject.AddComponent<DistanceJoint2D>();
                dj.connectedBody = rbJugador;
                dj.maxDistanceOnly = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        sr.color = Color.red;
    }

    public bool IsHooked() //Si el componente de joint no existe significa que no esta usando el hook
    {
        if (GetComponent<DistanceJoint2D>() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
