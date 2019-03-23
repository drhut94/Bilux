using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInteractions : MonoBehaviour {

    public new Camera camera;
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }
    public void Settings()
    {
        float posX = camera.transform.position.x;

        posX = 1924;
        Debug.Log(posX + "camera");
    }
}
