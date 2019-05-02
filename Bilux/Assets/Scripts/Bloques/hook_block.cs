using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook_block : MonoBehaviour {


    private Rigidbody2D rb;
    private DistanceJoint2D dj;
    private SpriteRenderer sr;
    private LineRenderer lr;
    public float maxVelocity;
    private bool isHooked;
    private GameObject player;
    private Rigidbody2D rbPlayer;
    private Movment movment;
    private Collider2D col;
    private bool hook;
    private bool boost;



    void Start () {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        lr = GetComponent<LineRenderer>();
        dj = GetComponent<DistanceJoint2D>();
        dj.connectedBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        sr.color = Color.red;
        lr.enabled = false;
        dj.enabled = false;
        isHooked = false;
        hook = false;
        boost = false;
    }
	

	void Update () {

        if (isHooked)
        {
            lr.SetPosition(1, new Vector3(rb.position.x, rb.position.y, 0));
            lr.SetPosition(0, new Vector3(rbPlayer.position.x, rbPlayer.position.y, 0));
        }

        if (Input.GetButtonDown("Jump") && col != null)
        {
            hook = true;
        }

        if (Input.GetButton("Boost"))
        {
            boost = true;
        }


    }

    private void FixedUpdate()
    {
        if (!player.active)
        {
            dj.enabled = false;
            isHooked = false;
            lr.enabled = false;
            Debug.Log("Deshook!!!");
            hook = false;
            sr.color = Color.red;
            player = null;
            rbPlayer = null;
            movment = null;
            col = null;
        }

        if (col != null)
        {
            if (Input.GetButtonDown("Reload"))
            {
                dj.enabled = false;
                isHooked = false;
                lr.enabled = false;
                Debug.Log("Deshook!!!");
            }

            if (col.gameObject.tag == "Player" && hook)
            {
                hook = false;
                if (!isHooked && !movment.IsGorunded())
                {
                    FindObjectOfType<AudioManager>().PlaySound("hook");
                    lr.enabled = true;
                    dj.enabled = true;
                    isHooked = true;
                    Debug.Log("hook!!!");
                }
                else if (isHooked)
                {
                    dj.enabled = false;
                    isHooked = false;
                    lr.enabled = false;
                    Debug.Log("Deshook!!!");
                    FindObjectOfType<AudioManager>().PlaySound("deshook");
                }

            }

            if (isHooked)
            {
                if (boost && movment.boost) //Boost que obtiene al estar usando el gancho
                {
                    boost = false;
                    rbPlayer.AddForce(rbPlayer.velocity * 2);



                    if (rbPlayer.velocity.magnitude > maxVelocity)
                    {
                        rbPlayer.velocity = rbPlayer.velocity.normalized * maxVelocity;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sr.color = Color.green;
        player = collision.gameObject;
        rbPlayer = player.GetComponent<Rigidbody2D>();
        movment = player.GetComponent<Movment>();
        col = collision;
        Debug.Log("entrado trigger");
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        sr.color = Color.red;
        player = null;
        rbPlayer = null;
        movment = null;
        col = null;
        Debug.Log("salido trigger");
    }


}
