using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public AudioClip jump;
    public AudioClip land;
    private AudioSource jumpSound;
    private Movment movment;


	void Start () {
        jumpSound = GetComponent<AudioSource>();
        movment = GetComponent<Movment>();
	}
	


	void Update () {
		
        if (movment.IsGorunded() && Input.GetButtonDown("Jump"))
        {
            jumpSound.PlayOneShot(jump);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpSound.PlayOneShot(land);
    }
}
