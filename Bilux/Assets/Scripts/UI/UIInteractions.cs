using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInteractions : MonoBehaviour {

    public GameObject menu;
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }

    public void Settings(GameObject settings)
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void Selector(GameObject selector)
    {
        selector.SetActive(true);
        menu.SetActive(false);
    }

    public void BackMenu(GameObject UI)
    {
        UI.SetActive(false);
        menu.SetActive(true);
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

