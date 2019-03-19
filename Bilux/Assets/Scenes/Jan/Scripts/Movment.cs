using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {


    public bool isInWater;
    public bool canInput;
    public float maxVelocity;
    private float maxVelocityBackup;
    public float acceleration;
    private float accelerationBackup;
    public float jumpForce;
    public Rigidbody2D rb;
    public float moveHorizontal; //sirve para almacenar la posicon horizontal de un joystick o teclado (0 - 1)
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
    public bool boost;
    public float boostTime;
    private float boostTimeBackup;
    public float boostCooldown;
    private TrailRenderer tr;



    void Start () {

        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        maxVelocityBackup = maxVelocity;
        accelerationBackup = acceleration;
        boostTimeBackup = boostTime;
        move = false;
        jump = false;
        boost = false;
        canInput = true;
        isInWater = false;
	}
	
	void Update () {

        //Debug.Log(rb.velocity.magnitude);
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (canInput)
        {
            if (Input.GetButton("Boost"))
            {
                boostTime -= Time.deltaTime;

                if (boostTime <= 0)
                {
                    boost = false;
                    boostTime = 0;
                }
                else
                {
                    boost = true;
                }
            }
            else
            {
                boostTime += boostCooldown / 10;

                if (boostTime > boostTimeBackup)
                {
                    boostTime = boostTimeBackup;
                }
            }

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
    }

    private void FixedUpdate()
    {

        speedV2 = rb.velocity;
        rotationSpeed = rb.angularVelocity;



        tr.time = ((boostTime) / (rb.velocity.magnitude));



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
            jump = false;
            wantsToJump = true;
            timer = 0.1f;
        }

        if (wantsToJump)
        {
            timer -= Time.fixedDeltaTime;
        }

        if (timer < 0)
        {
            wantsToJump = false;
        }

        if (IsGorunded() && wantsToJump || IsOnRamp() && wantsToJump || isInWater && wantsToJump)
        {
            speedV2.y = jumpForce;
            JumpTimeCounter = 0;
            isJumping = true;
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if (JumpTimeCounter < JumpTime)
            {
                speedV2.y = jumpForce;
                JumpTimeCounter += Time.fixedDeltaTime;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        ////////////////////////////////////////////////BOOST

        if (boost)
        {
            boost = false;
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




    public void Move() //Es publica para que se pueda llamar des de otros scripts para cinematicas
    {

    }

    public bool IsGorunded()
    {
        position = rb.position;
        Debug.DrawRay(position, Vector2.down * 0.5f, Color.red, 0.1f);
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 0.5f, groundLayer);
        
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
        if (!IsGorunded())
        {
            position = rb.position;
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 0.7f, groundLayer);

            if (hit.collider != null)
            {
                return (true);
            }
            else
            {

            return (false);
            }
        }
        else
        {
            return (false);
        }
    }
}
