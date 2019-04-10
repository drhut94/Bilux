using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentV2 : MonoBehaviour {

    public float maxVelocity;
    public float acceleration;

    private float horizontalInput;
    private Rigidbody2D rb;
    private Vector2 speedV2;
    private float rotationSpeed;
    private float maxVelocityBackup;
    private float accelerationBackup;


    private enum State
    {
        Idle,
        Move,
        Boost,
        Jump,
    }

    State state;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxVelocityBackup = maxVelocity;
        accelerationBackup = acceleration;
    }

    void Update()
    {

        state = State.Idle;

        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            state = State.Move;
        }

        if (Input.GetButtonDown("Jump"))
        {
            state = State.Jump;
        }

        if (Input.GetButton("Boost"))
        {
            state = State.Boost;
        }
    }

    private void FixedUpdate()
    {

        speedV2 = rb.velocity;
        rotationSpeed = rb.angularVelocity;
        maxVelocity = maxVelocityBackup;
        acceleration = accelerationBackup;

        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Move:
                Move();
                break;
            case State.Boost:
                Boost();
                Move();
                break;
            case State.Jump:
                Jump();
                break;
        }

        rb.velocity = speedV2;
        rb.angularVelocity = rotationSpeed;
    }

    private void Idle()
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

    private void Move()
    {
        if (Mathf.Abs(rb.angularVelocity) < maxVelocity * Mathf.Abs(horizontalInput))
        {
            rotationSpeed += acceleration * horizontalInput * -1; // acelerar
        }

        if(state == State.Move)
        {
            if (Mathf.Abs(rotationSpeed) >= maxVelocity * Mathf.Abs(horizontalInput))
            {
                rotationSpeed = maxVelocity * horizontalInput * -1; //Mover a velocidad constante
            }
        }


        if (((horizontalInput < 0) && (rb.angularVelocity < 0)) ||   //Permite cambiar de direccion mas rapidamente
            ((horizontalInput > 0) && (rb.angularVelocity > 0)))
        {
            rotationSpeed += acceleration * horizontalInput * -1;
        }
    }

    private void Boost()
    {
            maxVelocity = maxVelocityBackup * 1.7f;
            acceleration = accelerationBackup * 1.7f;
    }


    

    private void Jump()
    {

    }
}
