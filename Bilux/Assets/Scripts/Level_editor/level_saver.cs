using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class level_saver : MonoBehaviour {


    
    // Use this for initialization
    void Start () {
        

 
	}
	
	// Update is called once per frame
	void Update () {

       
    }

    public void AddBlockToList(GameObject blockInstance)
    {
        
    }
}

[System.Serializable]

public class SaveGlob
{
    public List<GameObject> blocks = new List<GameObject>();
}
