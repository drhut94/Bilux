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
    public Movment movment;
    private Collider2D col;
    private bool hook;
    private bool boost;

    private Light lt;
    private float intensityBackup;
    public float fadeDuration;




    void Start () {

        lt = GetComponentInChildren<Light>();
        intensityBackup = lt.intensity;
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
        col = null;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	

	void Update () {

        FadeLight();

        if (player != null)
        {
            if (!player.activeInHierarchy)
            {
                isHooked = false;
                movment.Ishooked = isHooked;
            }
        }

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
        if (player != null)
        {
            if (!player.activeInHierarchy)
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

            //if (isHooked)
            //{
            //    if (boost && movment.boost) //Boost que obtiene al estar usando el gancho
            //    {
            //        boost = false;
            //        //rbPlayer.AddForce(rbPlayer.velocity * 2);
            //        rbPlayer.velocity += new Vector2(rb.velocity.x * 2, rb.velocity.y * 2);

            //        if (rbPlayer.velocity.magnitude > maxVelocity)
            //        {
            //            rbPlayer.velocity = rbPlayer.velocity.normalized * maxVelocity;
            //        }
            //    }
            //}
        }
    }

    private void FadeLight()
    {

        if(lt.intensity >= intensityBackup)
        {
            lt.intensity -= lt.intensity * Time.deltaTime * fadeDuration;
        }
        else if(lt.intensity <= 0)
        {
            lt.intensity += lt.intensity * Time.deltaTime * fadeDuration;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sr.color = Color.green;
            player = collision.gameObject;
            rbPlayer = player.GetComponent<Rigidbody2D>();
            movment = player.GetComponent<Movment>();
            col = collision;
            Debug.Log("entrado trigger");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sr.color = Color.red;
            player = null;
            rbPlayer = null;
            movment = null;
            col = null;
            Debug.Log("salido trigger");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            movment.Ishooked = isHooked;
        }
    }
}
