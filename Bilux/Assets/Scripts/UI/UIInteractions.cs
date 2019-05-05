using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIInteractions : MonoBehaviour {

    public GameObject menu;
    

    public void LoadTutorial()
    {
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadLevel1()
    {
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void LoadLevel2()
    {
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void LoadLevel3()
    {
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }


    public void Settings(GameObject settings)
    {
        FindObjectOfType<AudioManager>().PlaySound("button");
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void Selector(GameObject selector)
    {
        FindObjectOfType<AudioManager>().PlaySound("button");
        selector.SetActive(true);
        menu.SetActive(false);
    }

    public void SelectorBack(GameObject selector)
    {
        FindObjectOfType<AudioManager>().PlaySound("button");
        selector.SetActive(false);
        menu.SetActive(true);
    }

    public void BackMenu(GameObject UI)
    {
        FindObjectOfType<AudioManager>().PlaySound("button");
        UI.SetActive(false);
        menu.SetActive(true);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().PlaySound("button");
        Application.Quit();
    }

    //public void LoadEditor()
    //{
    //    SceneManager.LoadScene("demo", LoadSceneMode.Single);
    //}
}   

