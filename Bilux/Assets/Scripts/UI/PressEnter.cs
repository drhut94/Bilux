using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressEnter : MonoBehaviour {

    Button botton;
    public Button[] button;
    ScrollScript scroll;

    void Start()
    {
        botton = GetComponent<Button>();
        if (gameObject.GetComponent<ScrollScript>() != null)
        {
            foreach (Button but in button)
            {
                but.interactable = false;
            }
            scroll = GetComponent<ScrollScript>();
        }
    }

    void Update()
    {
        Debug.Log(GameObject.Find("Scroll"));
        Debug.Log(GameObject.Find("PlayerMenu"));
        if (GameObject.Find("Scroll") != null)
        {
            if (ScrollScript.visible[ScrollScript._currentPage] == true)
            {
                button[ScrollScript._currentPage].interactable = true;
            }
            if (Input.GetKeyDown(KeyCode.Return) && ScrollScript.visible[ScrollScript._currentPage] == true)
            {
                button[ScrollScript._currentPage].onClick.Invoke();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            botton.onClick.Invoke();
        }

    }
}
