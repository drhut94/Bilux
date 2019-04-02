using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Movment movment;
    public GameObject fireTrail;
    public GameObject normalTrail;
    public GameObject damageIndicator; //<--Assign in inspector.
    public float damageDuration = 0.1f; //<--Show canvas for this duration each hit.



    void Start () {
        health = 100;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        movment = GetComponent<Movment>();
        HideDamageIndicator();
    }
	
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        trail();
	}



    public void SetHealth(int damage)
    {
        health -= damage;
        ShowDamageIndicator();
        CancelInvoke("HideDamageIndicator"); //<--Resets timer if hit before indicator is hidden.
        Invoke("HideDamageIndicator", damageDuration);
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
}
