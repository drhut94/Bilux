using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {


    public float maxVelocity;
    public float acceleration;
    public float jumpForce;
    private Rigidbody2D rb;
    private float moveHorizontal; //sirve para almacenar la posicon horizontal de un joystick o teclado (0 - 1)
    private float rotationSpeed;
    private Vector2 speedV2;
    private Vector2 position; 
    public LayerMask groundLayer;
    private float JumpTimeCounter;
    public float JumpTime;
    private bool isJumping;
    


    void Start () {

        rb = GetComponent<Rigidbody2D>();
       
	}
	
	void Update () {


    }

    private void FixedUpdate()
    {


        moveHorizontal = Input.GetAxisRaw("Horizontal");

        speedV2 = rb.velocity;
        rotationSpeed = rb.angularVelocity;
        

        Move();

        Jump();

        rb.velocity = speedV2;
        rb.angularVelocity = rotationSpeed;

        Debug.Log(IsGorunded());
    }




    public void Move() //Es publica para que se pueda llamar des de otros scripts para cinematicas
    {

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
        else if (moveHorizontal == 0 && IsGorunded())
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
    }

    public bool IsGorunded()
    {
        position = rb.position;
        Debug.DrawRay(position, Vector2.down, Color.red, 1, true);
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 0.6f, groundLayer);
        
        if(hit.collider != null)
        {
            return true;
        }

        return false;
    }

    public void Jump()
    {
        if (IsGorunded() && Input.GetButtonDown("Jump"))
        {
            speedV2.y = jumpForce;
            JumpTimeCounter = 0;
            isJumping = true;
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if(JumpTimeCounter < JumpTime)
            {
                speedV2.y = jumpForce;
                JumpTimeCounter += Time.fixedDeltaTime;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }
}
