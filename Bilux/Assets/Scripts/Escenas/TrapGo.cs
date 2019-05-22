using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGo : MonoBehaviour {

    public bool trap = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            trap = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            trap = false;
    }

}
