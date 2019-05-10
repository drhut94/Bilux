using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private DistanceJoint2D dj;
    public int health;
    int maxHealth;
    int recovery;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Movment movment;
    public GameObject damageIndicator; //<--Assign in inspector.
    public float damageDuration; //<--Show canvas for this duration each hit.
    public float recoveryDuration; //<--Show canvas for this duration each hit.
    Image colorIndicator;
    float healthTime;
    float healthTimeBackup;
    Vector2 recoveryVelocity;
    public Vector2 initPlayerPos;
    public ParticleSystem normalTrail;
    public ParticleSystem[] fireTrail;

    void Start() {
        maxHealth = 100;
        health = maxHealth;
        recovery = 5;
        healthTime = 1f;
        damageDuration = 0.6f;
        recoveryDuration = 1.1f;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        movment = GetComponent<Movment>();
        dj = GetComponent<DistanceJoint2D>();
        HideDamageIndicator();
        colorIndicator = damageIndicator.GetComponent<Image>();
        healthTimeBackup = healthTime;
        recoveryVelocity = new Vector2(0f, 0f);
        initPlayerPos = gameObject.transform.position;

        for (int i = 0; i < fireTrail.Length; i++)
        {
            fireTrail[i].Stop();
        }

    }

    void Update() {
        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().StopSound("music_level3", 0.0f);
            FindObjectOfType<AudioManager>().PlaySound("die");
            gameObject.SetActive(false);
        }

        //if (Input.GetButtonDown("Reload"))
        //{
        //    gameObject.transform.position = initPlayerPos;
        //    gameObject.SetActive(true);
        //}

        trail();
        //Debug.Log(healthTime);
        if (movment.rb.velocity == recoveryVelocity && health < maxHealth)
        {
            healthTime -= Time.deltaTime;
            if (healthTime <= 0)
            {
                RecoverHealth(recovery);
                healthTime = healthTimeBackup;
            }
            
        } else if (movment.rb.velocity != recoveryVelocity)
                healthTime = healthTimeBackup;
    }

    public void SetHealth(int damage)
    {
        health -= damage;
        if (damage > 0)
        {
            colorIndicator.color = new Color32(255, 0, 0, 100);
            ShowDamageIndicator();
            CancelInvoke("HideDamageIndicator"); //<--Resets timer if hit before indicator is hidden.
            Invoke("HideDamageIndicator", damageDuration);
        }
        else if (damage <= 0)
        {
            health = 0;
            colorIndicator.color = new Color32(0, 255, 0, 100);
            ShowDamageIndicator();
            CancelInvoke("HideDamageIndicator"); //<--Resets timer if hit before indicator is hidden.
            Invoke("HideDamageIndicator", recoveryDuration);
        }
       
    }



    public int GetHealth
    {
        get { return health; }
    }

    public void trail()
    {
        if (Input.GetButtonDown("Boost"))
        {
            for(int i = 0; i < fireTrail.Length; i++)
            {
                fireTrail[i].Play();
            }
            normalTrail.Stop();
        }
        if (Input.GetButtonUp("Boost"))
        {
            for (int i = 0; i < fireTrail.Length; i++)
            {
                fireTrail[i].Stop();
            }
            normalTrail.Play();
        }
    }

    void ShowDamageIndicator()
    {
        damageIndicator.SetActive(true);
    }

    void HideDamageIndicator()
    {
        damageIndicator.SetActive(false);
    }

    void RecoverHealth(int recover)
    {
        recover = recovery * -1;
        SetHealth(recover);
        if (health > maxHealth)
        health = maxHealth;
    }

    public void InitPlayer()
    {
        maxHealth = 100;
        health = maxHealth;
        movment.Ishooked = false;
        recovery = 5;
        healthTime = 1f;
        damageDuration = 0.6f;
        recoveryDuration = 1.1f;
        rb.velocity = new Vector2(0.0f, 0.0f);
        FindObjectOfType<AudioManager>().PlayMusic(FindObjectOfType<AudioManager>().musicName, 1.0f);

        for (int i = 0; i < fireTrail.Length; i++)
        {
            fireTrail[i].Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            FindObjectOfType<AudioManager>().PlaySound("checkpoint");
            initPlayerPos = transform.position;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Final")
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BouncyBlock")
        {
            FindObjectOfType<AudioManager>().PlaySound("bounce");
        }
    }
}
