using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

    //public GameMngr level;
    //public Slider slider;

    public Canvas deathMenu;
    bool muerto;
    public Slider slider;
    public Text text;
    Scene scene;

	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player") == null && muerto==false)
        {   
            Invoke("PopDeathMenu", 0.3f);
            muerto = true;
        }
        else if (GameObject.FindGameObjectWithTag("Player"))
        {
            muerto = false;
            deathMenu.gameObject.SetActive(false);
        }

        Debug.Log(scene.name);

        UpdateProgress();

    }

    public void PopDeathMenu()
    {
        deathMenu.gameObject.SetActive(true);

    }

    void UpdateProgress()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "Tutorial")
        {
            slider.value = PlayerPrefs.GetFloat("tutorial");
            text.text = PlayerPrefs.GetFloat("tutorial").ToString() + "%";
        }
        else if (scene.name == "Level1")
        {
            slider.value = PlayerPrefs.GetFloat("level1");
            text.text = PlayerPrefs.GetFloat("level1").ToString() + "%";
        }
        else if (scene.name == "Level 2")
        {
            slider.value = PlayerPrefs.GetFloat("level2");
            text.text = PlayerPrefs.GetFloat("level2").ToString() + "%";
        }
        else if (scene.name == "Level 3")
        {
            slider.value = PlayerPrefs.GetFloat("level3");
            text.text = PlayerPrefs.GetFloat("level3").ToString() + "%";
        }
        else if (scene.name == "Level7")
        {
            slider.value = PlayerPrefs.GetFloat("level4");
            text.text = PlayerPrefs.GetFloat("level4").ToString() + "%";
        }
        else if (scene.name == "Level4")
        {
            slider.value = PlayerPrefs.GetFloat("level5");
            text.text = PlayerPrefs.GetFloat("level5").ToString() + "%";
        }
        else if (scene.name == "BonusLevel")
        {
            slider.value = PlayerPrefs.GetFloat("levelBonus");
            text.text = PlayerPrefs.GetFloat("levelBonus").ToString() + "%";
        }
    }
}
