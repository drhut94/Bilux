using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInteractions : MonoBehaviour {

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }
    public void Settings(Transform settingsTrans)
    {
        Camera.main.transform.LookAt(settingsTrans.position);
    }

    public void BackButtonMenu(Transform menuTrans)
    {
        Camera.main.transform.LookAt(menuTrans.position);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}   

