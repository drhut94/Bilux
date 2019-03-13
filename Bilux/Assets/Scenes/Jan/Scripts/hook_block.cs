using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook_block : MonoBehaviour {


    private Rigidbody2D rb;
    private DistanceJoint2D dj;
    private SpriteRenderer sr;
    private LineRenderer lr;
    

	void Start () {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        lr = GetComponent<LineRenderer>();
        sr.color = Color.red;
        lr.enabled = false;
    }
	

	void Update () {

	}

    private void OnTriggerStay2D(Collider2D col)
    {
        sr.color = Color.green;
        GameObject player = col.gameObject;
        Rigidbody2D rbPlayer = player.GetComponent<Rigidbody2D>();
        Movment movment = player.GetComponent<Movment>();


        if (col.gameObject.tag == "Player" && Input.GetButtonDown("Jump"))
        {
            if (!IsHooked() && !movment.IsGorunded())
            {
                lr.enabled = true;
                dj = gameObject.AddComponent<DistanceJoint2D>();
                lr.sortingOrder = 1;
                dj.connectedBody = rbPlayer;
                dj.maxDistanceOnly = true;
                dj.enableCollision = true;
            }
            else if(IsHooked()){
                Destroy(dj);
            }
            
        }

        if (IsHooked())
        {
            lr.SetPosition(1, new Vector3(rb.position.x, rb.position.y, 0));
            lr.SetPosition(0, new Vector3(rbPlayer.position.x, rbPlayer.position.y, 0));
        }
        else
        {
            if (GetComponent<LineRenderer>() != null)
            {
                lr.enabled = false;
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
