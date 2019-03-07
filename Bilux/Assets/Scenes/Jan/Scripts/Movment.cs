using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {


    public float maxVelocity;
    public float acceleration;
    public float jumpForce;
    private Rigidbody2D rb;
    private float moveHorizontal; //sirve para almacenar la posicon horizontal de un joystick o teclado (0 - 1)
    //private float MoveVertical;
    private float rotationSpeed;


    void Start () {

        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {


    }

    private void FixedUpdate()
    {

        moveHorizontal = Input.GetAxisRaw("Horizontal");

        Move();

        rb.angularVelocity = rotationSpeed;


    }




    public void Move() //Es publica para que se pueda llamar des de otros scripts para cinematicas
    {

        if (moveHorizontal != 0)
        {
            if (Mathf.Abs(rb.angularVelocity) < maxVelocity * Mathf.Abs(moveHorizontal)) // acelerar
            {
                rotationSpeed += acceleration * moveHorizontal * -1;
            }

            if(Mathf.Abs(rb.angularVelocity) >= maxVelocity * Mathf.Abs(moveHorizontal))
            {
                rotationSpeed = maxVelocity * moveHorizontal * -1; //Mover a velocidad constante
            }

        }
        else if (moveHorizontal == 0)
        {
            if (rb.angularVelocity > 0)
            {
                rotationSpeed -= acceleration;

                if(rb.angularVelocity < 0)
                {
                    rotationSpeed = 0;
                }
            }
            else if(rb.angularVelocity < 0)
            {
                rotationSpeed += acceleration;

                if (rb.angularVelocity > 0)
                {
                    rotationSpeed = 0;
                }
            }
        }

        Debug.Log(rb.angularVelocity);
    }
}
