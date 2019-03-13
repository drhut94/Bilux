﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {


    public float maxVelocity;
    private float maxVelocityBackup;
    public float acceleration;
    private float accelerationBackup;
    public float jumpForce;
    private Rigidbody2D rb;
    private float moveHorizontal; //sirve para almacenar la posicon horizontal de un joystick o teclado (0 - 1)
    private float rotationSpeed;
    public Vector2 speedV2;
    private Vector2 position; 
    public LayerMask groundLayer;
    private float JumpTimeCounter;
    public float JumpTime;
    private bool isJumping;
    private float angularVelocity;
    bool wantsToJump;
    float timer;
    private bool move;
    private bool jump;
    private bool boost;



    void Start () {

        rb = GetComponent<Rigidbody2D>();
        maxVelocityBackup = maxVelocity;
        accelerationBackup = acceleration;
        move = false;
        jump = false;
        boost = false;
	}
	
	void Update () {

        Debug.Log(IsGorunded());
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Boost"))
        {
            boost = true;
        }
        else
        {
            boost = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        speedV2 = rb.velocity;
        rotationSpeed = rb.angularVelocity;


        //////////////////////////////////////MOVE

        if (moveHorizontal != 0)
        {
            if (Mathf.Abs(rb.angularVelocity) < maxVelocity * Mathf.Abs(moveHorizontal))
            {
                rotationSpeed += acceleration * moveHorizontal * -1; // acelerar
            }

            if (Mathf.Abs(rotationSpeed) >= maxVelocity * Mathf.Abs(moveHorizontal))
            {
                rotationSpeed = maxVelocity * moveHorizontal * -1; //Mover a velocidad constante
            }

            if (((moveHorizontal < 0) && (rb.angularVelocity < 0)) ||   //Permite cambiar de direccion mas rapidamente
                ((moveHorizontal > 0) && (rb.angularVelocity > 0)))
            {
                rotationSpeed += acceleration * moveHorizontal * -1;
            }
        }
        else if (moveHorizontal == 0 && IsGorunded() && !IsOnRamp())
        {
            if (rb.angularVelocity > 0)
            {
                rotationSpeed -= acceleration;

                if (rotationSpeed < 0)
                {
                    rotationSpeed = 0;
                }
            }
            else if (rb.angularVelocity < 0)
            {
                rotationSpeed += acceleration;

                if (rotationSpeed > 0)
                {
                    rotationSpeed = 0;
                }
            }
        }

        /////////////////////////////////////////////JUMP

        if (jump)
        {
            wantsToJump = true;
            timer = 1;
        }

        if (wantsToJump)
        {
            timer -= Time.fixedDeltaTime;
        }

        if (timer < 0)
        {
            wantsToJump = false;
        }

        if (IsGorunded() && wantsToJump)
        {
            speedV2.y = jumpForce;
            JumpTimeCounter = 0;
            isJumping = true;
        }

        //if (Input.GetButton("Jump") && isJumping)
        //{
        //    if(JumpTimeCounter < JumpTime)
        //    {
        //        speedV2.y = jumpForce;
        //        JumpTimeCounter += Time.fixedDeltaTime;
        //    }
        //}

        //if (Input.GetButtonUp("Jump"))
        //{
        //    isJumping = false;
        //}

        ////////////////////////////////////////////////BOOST

        if (boost)
        {
            maxVelocity = maxVelocityBackup * 1.7f;
            acceleration = accelerationBackup * 1.7f;
        }
        else
        {
            maxVelocity = maxVelocityBackup;
            acceleration = accelerationBackup;

        }



        rb.velocity = speedV2;
        rb.angularVelocity = rotationSpeed;
    }

    private void FixedUpdate()
    {


       
    }




    public void Move() //Es publica para que se pueda llamar des de otros scripts para cinematicas
    {

    }

    public bool IsGorunded()
    {
        position = rb.position;
        Debug.DrawRay(position, Vector2.down * 1.0f, Color.red, 0.1f);
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 0.7f, groundLayer);
        
        if(hit.collider != null)
        {
            return (true);
        }
        else
        {
        return (false);
        }
    }

    public bool IsOnRamp()
    {
        position = rb.position;
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 0.6f, groundLayer);

        if (hit.collider != null)
        {
            return (false);
        }
        else
        {

        return (true);
        }
    }

    public void Boost()
    {

    }


}
