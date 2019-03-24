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

    public void Selector(Transform selectorTrans)
    {
        Camera.main.transform.LookAt(selectorTrans.position);
    }

    public void BackMenu(Transform menuTrans)
    {
        Camera.main.transform.LookAt(menuTrans.position);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadEditor()
    {
        SceneManager.LoadScene("demo", LoadSceneMode.Single);
    }
}   

