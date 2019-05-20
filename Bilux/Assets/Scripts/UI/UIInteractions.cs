using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIInteractions : MonoBehaviour {

    public GameObject menu;
    public GameObject selector;
    public GameObject settings;
    public Button[] levels;
    public GameObject[] locks;
    public Slider[] sliders;
    public Slider[] slidersNC;
    public Text[] percentage;
    public Text[] percentageNC;



    private void Start()
    {
        for (int i = 1; 1 < levels.Length; i++)
        {
            levels[i].enabled = true;
            sliders[i].gameObject.SetActive(false);
            slidersNC[i].gameObject.SetActive(false);
            locks[i].gameObject.SetActive(true);

            //levels[i].interactable = false;
        }
        FindObjectOfType<GameMngr>().UpdateLevels();
    }

    public void LoadTutorial()
    {
        PlayerPrefs.SetInt("checkpoint", 1);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void LoadTutorialNC()
    {
        PlayerPrefs.SetInt("checkpoint", 0);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void LoadLevel1()
    {
        PlayerPrefs.SetInt("checkpoint", 1);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void LoadLevel1NC()
    {
        PlayerPrefs.SetInt("checkpoint", 0);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void LoadLevel2()
    {
        PlayerPrefs.SetInt("checkpoint", 1);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void LoadLevel2NC()
    {
        PlayerPrefs.SetInt("checkpoint", 0);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void LoadLevel3()
    {
        //En teoria level 5 en UI
        PlayerPrefs.SetInt("checkpoint", 1);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }

    public void LoadLevel3NC()
    {
        //En teoria level 5 en UI
        PlayerPrefs.SetInt("checkpoint", 0);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }

    public void LoadLevel4()
    {
        //En teoria level 3 en UI
        PlayerPrefs.SetInt("checkpoint", 1);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }

    public void LoadLevel4NC()
    {
        //En teoria level 3 en UI
        PlayerPrefs.SetInt("checkpoint", 0);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }
    public void LoadLevel5()
    {
        //En teoria level 4 en UI
        PlayerPrefs.SetInt("checkpoint", 1);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }

    public void LoadLevel5NC()
    {
        //En teoria level 4 en UI
        PlayerPrefs.SetInt("checkpoint", 0);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }
    public void LoadLevelBonus()
    {
        PlayerPrefs.SetInt("checkpoint", 1);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(7, LoadSceneMode.Single);
    }

    public void LoadLevelBonusNC()
    {
        PlayerPrefs.SetInt("checkpoint", 0);
        FindObjectOfType<AudioManager>().PlaySound("loadlevel");
        SceneManager.LoadScene(7, LoadSceneMode.Single);
    }

    public void Settings()
    {
        FindObjectOfType<AudioManager>().PlaySound("button");
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void Selector()
    {
        FindObjectOfType<AudioManager>().PlaySound("button");
        selector.SetActive(true);
        menu.SetActive(false);
    }

    public void SelectorBack()
    {
        FindObjectOfType<AudioManager>().PlaySound("button");
        selector.SetActive(false);
        menu.SetActive(true);
    }

    public void BackMenu()
    {
        FindObjectOfType<AudioManager>().PlaySound("button");
        settings.SetActive(false);
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
        slidersNC[level].value = PlayerPrefs.GetFloat(levelName + "NC");
        levels[level].enabled = true;
        locks[level].gameObject.SetActive(false);
        sliders[level].gameObject.SetActive(true);
        slidersNC[level].gameObject.SetActive(true);
        percentage[level].text = PlayerPrefs.GetFloat(levelName).ToString() + '%';
        percentageNC[level].text = PlayerPrefs.GetFloat(levelName + "NC").ToString() + '%';

        //levels[level].interactable = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameObject.Find("Canvas_selector"))
            {
                SelectorBack();
            }
            else if(GameObject.Find("Canvas_settings"))
            {
                BackMenu();
            }
        }
    }
    //public void LoadEditor()
    //{
    //    SceneManager.LoadScene("demo", LoadSceneMode.Single);
    //}
}   

