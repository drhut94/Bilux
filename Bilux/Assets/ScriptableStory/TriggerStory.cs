using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStory : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    [SerializeField]
    private StoryManager storyPart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log(storyPart.storyText);
        //if (collision.gameObject.tag == "Player")
        //{
        //}
    }
}
