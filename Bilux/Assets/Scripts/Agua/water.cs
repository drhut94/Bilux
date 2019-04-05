using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {

    Movment movment;
    Player player;

    public float timer;
    private bool timerOn;
    private float timerBackup;
    public float waterVelocity;
    public float damageTimer;
    private float damageTimerBackup;
    public int damage;
    private bool takeDamage;
    

    // Use this for initialization
    void Start()
    {
        // fer bé
        //damageTimer = 0.5f;
        //timer = 0.5f;
        //waterVelocity = 150f;
        //damage = 5;
        //
        timerBackup = timer;
        timerOn = false;
        takeDamage = false;
        damageTimerBackup = damageTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timerOn)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            if (movment != null)
            {
                movment.Water = true;
                movment.GetComponent<Rigidbody2D>().AddTorque(waterVelocity * movment.GetMoveHorizontal() * -1);
            }
            
        }

        if (takeDamage)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                if (movment != null)
                {
                    player.SetHealth(damage);
                    damageTimer = damageTimerBackup;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("WATER");
        if (collision.gameObject.tag == "Player")
        {
            movment = collision.GetComponent<Movment>();
            player = collision.GetComponent<Player>();
            timerOn = true;
            takeDamage = true;
            player.SetHealth(damage);
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            movment = collision.GetComponent<Movment>();
            movment.Water = false;
            timerOn = false;
            timer = timerBackup;
            takeDamage = false;
            damageTimer = damageTimerBackup;
        }
    }


}
