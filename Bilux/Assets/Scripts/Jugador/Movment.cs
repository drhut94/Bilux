using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {

    public float maxVelocity;
    public float maxHookVelocity;
    public float acceleration;
    public float jumpForce;
    public LayerMask groundLayer;
    public float JumpTime;
    public bool boost;
    public float boostTime;
    public float boostCooldown;


    [HideInInspector]
    public Rigidbody2D rb;

    private float maxVelocityBackup;
    private float accelerationBackup;
    private float moveHorizontal; //sirve para almacenar la posicon horizontal de un joystick o teclado (0 - 1)
    private float rotationSpeed;
    private Vector2 speedV2;
    private Vector2 position; 
    private float JumpTimeCounter;
    private bool isJumping;
    private float angularVelocity;
    private bool wantsToJump;
    private float timer;
    private bool jump;
    private float boostTimeBackup;
    private TrailRenderer tr;
    public bool groundCollsion;
    private DistanceJoint2D dj;
    private LineRenderer lr;
    private bool wantsToHook;


    void Start () {

        lr = GetComponent<LineRenderer>();
        dj = GetComponent<DistanceJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        maxVelocityBackup = maxVelocity;
        accelerationBackup = acceleration;
        boostTimeBackup = boostTime;
        jump = false;
        boost = false;
        CanInput = true;
        Water = false;
        groundCollsion = false;
        wantsToHook = false;
	}
	
	void Update () {

        moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (CanInput)
        {
            if (Input.GetButton("Boost"))
            {
                boost = true;

            }
            else
            {
                boost = false;
            }

            if (Input.GetButtonDown("Boost"))
            {
                FindObjectOfType<AudioManager>().PlaySound("boost");
                FindObjectOfType<AudioManager>().PlaySound("boostStart");
            }

            if (Input.GetButtonUp("Boost"))
            {
                FindObjectOfType<AudioManager>().PlaySound("boostEnd");
                FindObjectOfType<AudioManager>().StopSound("boost", 0.0f);
            }

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }

            if (Input.GetButtonDown("Jump") && !IsGorunded())
            {
                wantsToHook = true;
            }
        }
    }

    private void FixedUpdate()
    {

        speedV2 = rb.velocity;
        rotationSpeed = rb.angularVelocity;



        tr.time = ((boostTime) / (rb.velocity.magnitude));

        if (rb.velocity.magnitude < 2)
        {
            tr.time = 1;
        }




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
            timer = 0.2f;
        }

        if (wantsToJump)
        {
            timer -= Time.fixedDeltaTime;
        }

        if (timer < 0)
        {
            wantsToJump = false;
        }



        if (IsGorunded() && wantsToJump && groundCollsion || IsOnRamp() && wantsToJump && groundCollsion || Water && wantsToJump && groundCollsion)
        {
            FindObjectOfType<AudioManager>().PlaySound("jump");
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

        if (dj.isActiveAndEnabled && Input.GetButton("Boost"))
        {
            rb.AddForce(rb.velocity * 2);
            Debug.Log(rb.velocity.magnitude);
            if (rb.velocity.magnitude > 10)
            {
                speedV2 = rb.velocity.normalized * 10;
            }
        }

        rb.velocity = speedV2;
        rb.angularVelocity = rotationSpeed;
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if(collision.gameObject.layer == groundLayer)
    //    {
    //        groundCollsion = true;
    //    }
    //    else
    //    {
    //        groundCollsion = false;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == groundLayer)
    //    {
    //        groundCollsion = false;
    //    }
    //}

    //public bool CollidingWithGround()
    //{
    //    if (groundCollsion == true)     return true;
    //    else                            return false;
    //}

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

    private void Hook(Collider2D collider)
    {
        if (!IsGorunded())
        {
            if (dj.isActiveAndEnabled)
            {
                FindObjectOfType<AudioManager>().PlaySound("deshook");
                dj.enabled = false;
                lr.enabled = false;
            }
            else if (!dj.isActiveAndEnabled)
            {
                FindObjectOfType<AudioManager>().PlaySound("hook");
                dj.connectedAnchor = collider.transform.position;
                dj.enabled = true;
                lr.enabled = true;
            }
        }
    }

    public bool Water { get; set; } //Funcion muy guai para hacer getters y seters de manera muy simple

    public bool CanInput { get; set; }

    public float GetMoveHorizontal ()
    {
        return moveHorizontal;
    }

    public Vector2 GetDirection()
    {
        return speedV2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().PlaySound("land");


            groundCollsion = true;
            Debug.Log("ground collsison");

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

            groundCollsion = false;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hook"))
        {
            if (wantsToHook)
            {
                Hook(collision);
                wantsToHook = false;
            }

            if (dj.isActiveAndEnabled)
            {
                lr.SetPosition(1, new Vector3(collision.transform.position.x, collision.transform.position.y, 0));
                lr.SetPosition(0, new Vector3(rb.position.x, rb.position.y, 0));
            }
        }
    }

}
