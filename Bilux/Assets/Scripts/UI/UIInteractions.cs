using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIInteractions : MonoBehaviour {

    public GameObject menu;
    public Button[] levels;
    public GameObject[] locks;
    public Slider[] sliders;


    private void Start()
    {
        for (int i = 1; 1 < levels.Length; i++)
        {
            levels[i].enabled = false;
            sliders[i].gameObject.SetActive(false);
            locks[i].gameObject.SetActive(true);

            //levels[i].interactable = false;
        }
        FindObjectOfType<GameMngr>().UpdateLevels();
    }

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

    public void UnlockLevel(int level, string levelName)
    {
        sliders[level].value = PlayerPrefs.GetFloat(levelName);
        levels[level].enabled = true;
        locks[level].gameObject.SetActive(false);
        sliders[level].gameObject.SetActive(true);

        //levels[level].interactable = true;
    }

    //public void LoadEditor()
    //{
    //    SceneManager.LoadScene("demo", LoadSceneMode.Single);
    //}
}   

