using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public GameObject[] go;
    public TrapGo trap;

    private void Update()
    {
    if (/*collision.gameObject.CompareTag("Player") ||*/ trap.trap == true)
    {
        for (int i = 0; i < go.Length; i++)
        {
            go[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
        Debug.Log(trap.trap);
    }

}
