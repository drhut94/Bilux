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
    public GameObject deathParticles;
    public GameObject deadPlayer;

    void Start() {
        //deadPlayer.SetActive(false);
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
        //colorIndicator = damageIndicator.GetComponent<Image>();
        healthTimeBackup = healthTime;
        recoveryVelocity = new Vector2(0f, 0f);
        initPlayerPos = transform.position;

        for (int i = 0; i < fireTrail.Length; i++)
        {
            fireTrail[i].Stop();
        }

    }

    void Update() {
        if (health <= 0)
        {

            DestroyPlayer();

            deathParticles.transform.position = transform.position;
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

    public void Die()
    {
        deathParticles.GetComponent<ParticleSystem>().Play();

    }

    public int GetHealth
    {
        get { return health; }
    }

    public void trail()
    {

        if (Input.GetButton("Boost"))
        {
            normalTrail.Stop();
            if (!fireTrail[1].isEmitting)
            {
                for(int i = 0; i < fireTrail.Length; i++)
                {
                    fireTrail[i].Play();
                }
            }
        }
        else
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



    void RecoverHealth(int recover)
    {
        recover = recovery * -1;
        SetHealth(recover);
        if (health > maxHealth)
        health = maxHealth;
    }

    public void InitPlayer()
    {
        for (int i = 0; i < fireTrail.Length; i++)
        {
            fireTrail[i].Stop();
        }
        normalTrail.Stop();
        maxHealth = 100;
        health = maxHealth;
        movment.Ishooked = false;
        recovery = 5;
        healthTime = 1f;
        damageDuration = 0.6f;
        recoveryDuration = 1.1f;
        rb.velocity = new Vector2(0.0f, 0.0f);
        transform.position = initPlayerPos;

        FindObjectOfType<AudioManager>().PlayMusic(FindObjectOfType<AudioManager>().musicName, 1.0f);

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

    private void DestroyPlayer()
    {
        GameObject obj = Instantiate(deadPlayer, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
        Rigidbody2D[] rb2d = obj.GetComponentsInChildren<Rigidbody2D>();

        for(int i = 0; i < rb2d.Length; i++)
        {
            float rand = Random.Range(2.0f, -2.0f);
            rb2d[i].bodyType = RigidbodyType2D.Dynamic;
            rb2d[i].velocity = movment.Speed * new Vector2(rand , rand);
            rb2d[i].angularVelocity = rand * 100;
        }

    }
}
