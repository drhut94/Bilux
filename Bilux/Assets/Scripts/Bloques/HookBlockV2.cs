using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBlockV2 : MonoBehaviour {


 //   public float maxVelocity;
 //   private DistanceJoint2D dj;
 //   private Movment player;
 //   private SpriteRenderer sr;
 //   private LineRenderer lr;


	//// Use this for initialization
	//void Start () {
 //       sr = GetComponent<SpriteRenderer>();
 //       sr.color = Color.red;
	//}
	
	//// Update is called once per frame
	//void Update () {
 //       if (Input.GetButtonDown("Jump"))
 //       {
 //           if (dj != null)
 //           {
 //               if (dj.isActiveAndEnabled)
 //               {
 //                   Deshook();
 //               }
 //               else if (!player.IsGorunded())
 //               {
 //                   Hook();
 //               }
 //           }
 //       }
 //   }

 //   private void OnTriggerEnter2D(Collider2D collision)
 //   {
 //       if (collision.gameObject.CompareTag("Player"))
 //       {
 //           dj = collision.gameObject.GetComponent<DistanceJoint2D>();
 //           player = collision.gameObject.GetComponent<Movment>();
 //           lr = collision.gameObject.GetComponent<LineRenderer>();
 //           sr.color = Color.green;

 //       }
 //   }

 //   private void OnTriggerStay2D(Collider2D collision)
 //   {
 //       if (collision.gameObject.CompareTag("Player"))
 //       {
 //           if (dj.isActiveAndEnabled)
 //           {
 //               lr.enabled = true;
 //               lr.SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));
 //               lr.SetPosition(0, new Vector3(collision.transform.position.x, collision.transform.position.y, 0));
 //           }
 //       }
 //   }

 //   private void OnTriggerExit2D(Collider2D collision)
 //   {
 //       if (collision.gameObject.CompareTag("Player"))
 //       {
 //           sr.color = Color.red;
 //       }
 //   }

 //   public void Hook()
 //   {
 //       dj.connectedAnchor = gameObject.transform.position;
 //       dj.enabled = true;
 //   }

 //   public void Deshook()
 //   {
 //       dj.enabled = false;
 //       lr.enabled = false;
 //   }
}
