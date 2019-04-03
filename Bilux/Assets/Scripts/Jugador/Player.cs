using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int health;
    int maxHealth;
    int recovery;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Movment movment;
    public GameObject fireTrail;
    public GameObject normalTrail;
    public GameObject damageIndicator; //<--Assign in inspector.
    public float damageDuration; //<--Show canvas for this duration each hit.
    public float recoveryDuration; //<--Show canvas for this duration each hit.
    Image colorIndicator;
    float healthTime;
    float healthTimeBackup;
    Vector2 recoveryVelocity;

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
        HideDamageIndicator();
        colorIndicator = damageIndicator.GetComponent<Image>();
        healthTimeBackup = healthTime;
        recoveryVelocity = new Vector2(0f, 0f);

    }

    void Update() {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        trail();
        Debug.Log(healthTime);
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
        else if (damage < 0)
        {
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
        if (Input.GetButton("Boost"))
        {
            fireTrail.gameObject.SetActive(true);
            normalTrail.gameObject.SetActive(false);
        }
        else
        {
            fireTrail.gameObject.SetActive(false);
            normalTrail.gameObject.SetActive(true);
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
}
